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


namespace Bloomberglp.Blpapi.Examples
{

    public class IntradayPriceBloombergRequest
    {
        private DateTime getPreviousTradingDate()
        {
            DateTime tradedOn = DateTime.Now;
            tradedOn = tradedOn.AddDays(-1);
            
            if (tradedOn.DayOfWeek == DayOfWeek.Sunday)
            {
                tradedOn = tradedOn.AddDays(-2);
            }
            else if (tradedOn.DayOfWeek == DayOfWeek.Saturday)
            {
                tradedOn = tradedOn.AddDays(-1);
            }
            return tradedOn;
        }

        public void RunIntradayUpdate(string dataFeedID, Datetime requestDate)
        {
            string serverHost = "localhost";
            int serverPort = 8194;

            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = serverHost;
            sessionOptions.ServerPort = serverPort;

            Session session = new Session(sessionOptions);
            bool sessionStarted = session.Start();
            if (!sessionStarted)
            {
                System.Windows.Forms.MessageBox.Show("Failed to start session.");
                return;
            }
            if (!session.OpenService("//blp/refdata"))
            {
                System.Windows.Forms.MessageBox.Show("Failed to open //blp/refdata");
                return;
            }

            Service refDataService = session.GetService("//blp/refdata");
            Request request = refDataService.CreateRequest("IntradayTickRequest");
            request.Set("security", dataFeedID);
            request["eventTypes"].AppendValue("TRADE");
            request["eventTypes"].AppendValue("AT_TRADE");
            DateTime tradedOn = getPreviousTradingDate();
            request.Set("startDateTime", requestDate);
            request.Set("endDateTime", new Datetime(requestDate.ToSystemDateTime().AddMinutes(5)));
            request.Set("includeConditionCodes", true);

            session.SendRequest(request, null);

            while (true)
            {
                Event eventObj = session.NextEvent();
                foreach (Message msg in eventObj)
                {
                    MessageBox.Show(msg.AsElement.ToString());
                }
                if (eventObj.Type == Event.EventType.RESPONSE)
                {
                    break;
                }
            }
        }
    }
}
