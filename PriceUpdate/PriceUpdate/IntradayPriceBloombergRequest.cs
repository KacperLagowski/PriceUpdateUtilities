/* Copyright 2012. Bloomberg Finance L.P.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to
 * deal in the Software without restriction, including without limitation the
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
 * sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:  The above
 * copyright notice and this permission notice shall be included in all copies
 * or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
 */
using DateTime = System.DateTime;
using DayOfWeek = System.DayOfWeek;
using Datetime = Bloomberglp.Blpapi.Datetime;
using Event = Bloomberglp.Blpapi.Event;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using Request = Bloomberglp.Blpapi.Request;
using Service = Bloomberglp.Blpapi.Service;
using Session = Bloomberglp.Blpapi.Session;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Bloomberglp.Blpapi.Examples
{

    public class IntradayPriceBloombergRequest
    {

        #region fields
        private static readonly Name TICK_DATA = new Name("tickData");
        private static readonly Name COND_CODE = new Name("conditionCodes");
        private static readonly Name SIZE = new Name("size");
        private static readonly Name TIME = new Name("time");
        private static readonly Name TYPE = new Name("type");
        private static readonly Name VALUE = new Name("value");
        private static readonly Name RESPONSE_ERROR = new Name("responseError");
        private static readonly Name CATEGORY = new Name("category");
        private static readonly Name MESSAGE = new Name("message");

        private string d_host;
        private int d_port;
        private string d_security;
        private ArrayList d_events;
        private bool d_conditionCodes;
        private string d_startDateTime;
        private string d_endDateTime;
        #endregion

        public DateTime Time { get; set; }
        public double Price { get; set; }

        private string getPreviousTradingDate()
        {
            DateTime tradedOn = Time;
            tradedOn = tradedOn.AddDays(-1);
            if (tradedOn.DayOfWeek == DayOfWeek.Sunday)
            {
                tradedOn = tradedOn.AddDays(-2);
            }
            else if (tradedOn.DayOfWeek == DayOfWeek.Saturday)
            {
                tradedOn = tradedOn.AddDays(-1);
            }
            string prevDate = tradedOn.Year.ToString() + "-" +
                              tradedOn.Month.ToString() + "-" +
                              tradedOn.Day.ToString();
            return prevDate;
        }

        public IntradayPriceBloombergRequest(string instrument, DateTime from, DateTime to)
        {
            d_host = "localhost";
            d_port = 8194;
            d_events = new ArrayList();
            d_conditionCodes = false;
            d_security = instrument;
            Time = from;
            string prevTradingDate = getPreviousTradingDate();
            d_startDateTime = prevTradingDate + "T" + from.ToLongTimeString();
            d_endDateTime = prevTradingDate + "T" + to.ToLongTimeString();
        }

        public void RunIntradayPriceUpdate()
        {
            d_events.Add("TRADE");
            
            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = d_host;
            sessionOptions.ServerPort = d_port;

            Session session = new Session(sessionOptions);
            bool sessionStarted = session.Start();
            if (!sessionStarted)
            {
                return;
            }
            if (!session.OpenService("//blp/refdata"))
            {
                return;
            }

            sendIntradayTickRequest(session);

            // wait for events from session.
            eventLoop(session);

            session.Stop();
        }

        private void eventLoop(Session session)
        {
            bool done = false;
            while (!done)
            {
                Event eventObj = session.NextEvent();
                if (eventObj.Type == Event.EventType.PARTIAL_RESPONSE)
                {
                    processResponseEvent(eventObj);
                }
                else if (eventObj.Type == Event.EventType.RESPONSE)
                {
                    processResponseEvent(eventObj);
                    done = true;
                }
                else
                {
                    foreach (Message msg in eventObj)
                    {
                        if (eventObj.Type == Event.EventType.SESSION_STATUS)
                        {
                            if (msg.MessageType.Equals("SessionTerminated"))
                            {
                                done = true;
                            }
                        }
                    }
                }
            }
        }

        private void processMessage(Message msg)
        {
            List<double> _prices = new List<double>();
            Element data = msg.GetElement(TICK_DATA).GetElement(TICK_DATA); ;
            int numItems = data.NumValues;
            for (int i = 0; i < numItems; ++i)
            {
                Element item = data.GetValueAsElement(i);
                Datetime time = item.GetElementAsDate(TIME);
                string type = item.GetElementAsString(TYPE);
                double value = item.GetElementAsFloat64(VALUE);
                _prices.Add(value);
                int size = item.GetElementAsInt32(SIZE);
                string cc = "";
                if (item.HasElement(COND_CODE))
                {
                    cc = item.GetElementAsString(COND_CODE);
                }
            }
            try
            {
                Price = _prices.First();
            }
            catch
            {

            }
        }


        private void processResponseEvent(Event eventObj)
        {
            foreach (Message msg in eventObj)
            {
                if (msg.HasElement(RESPONSE_ERROR))
                {
                    continue;
                }
                processMessage(msg);
            }
        }

        private void sendIntradayTickRequest(Session session)
        {
            Service refDataService = session.GetService("//blp/refdata");
            Request request = refDataService.CreateRequest("IntradayTickRequest");

            request.Set("security", d_security);

            // Add fields to request
            Element eventTypes = request.GetElement("eventTypes");
            for (int i = 0; i < d_events.Count; ++i)
            {
                eventTypes.AppendValue((string)d_events[i]);
            }

            // All times are in GMT
            request.Set("startDateTime", d_startDateTime);
            request.Set("endDateTime", d_endDateTime);

            if (d_conditionCodes)
            {
                request.Set("includeConditionCodes", true);
            }
            session.SendRequest(request, null);
        }

        
    }
}
