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
using Event = Bloomberglp.Blpapi.Event;
using Element = Bloomberglp.Blpapi.Element;
using InvalidRequestException = Bloomberglp.Blpapi.InvalidRequestException;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using Request = Bloomberglp.Blpapi.Request;
using Service = Bloomberglp.Blpapi.Service;
using Session = Bloomberglp.Blpapi.Session;
using TraceLevel = System.Diagnostics.TraceLevel;
using String = System.String;
using ArrayList = System.Collections.ArrayList;
using RefDataExample;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PriceUpdateProgram;

namespace Bloomberglp.Blpapi.Examples
{

	public class BloombergRequest
	{
        public event System.EventHandler InstrumentUpdated;

		private static readonly Name SECURITY_DATA = new Name("securityData");
		private static readonly Name SECURITY = new Name("security");
		private static readonly Name FIELD_DATA = new Name("fieldData");
		private static readonly Name RESPONSE_ERROR = new Name("responseError");
		private static readonly Name SECURITY_ERROR = new Name("securityError");
		private static readonly Name FIELD_EXCEPTIONS = new Name("fieldExceptions");
		private static readonly Name FIELD_ID = new Name("fieldId");
		private static readonly Name ERROR_INFO = new Name("errorInfo");
		private static readonly Name CATEGORY = new Name("category");
		private static readonly Name MESSAGE = new Name("message");
        private string     d_host;
		private int        d_port;
        public List<BBInstrument> BloombergInstruments { get; set; }
        private List<string> bloombergDataFields { get; set; }

    
        //public List<BBInstrument> Results { get; set; }
        public void Fill(List<BBInstrument> instruments, List<string> dataFields, BloombergRequestTypeEnum requestType)
		{
            BloombergInstruments = new List<BBInstrument>();
            bloombergDataFields = dataFields;
            d_host = "localhost";
            d_port = 8194;
            foreach (BBInstrument i in instruments)
            {
                BloombergInstruments.Add(i);
            }
            if (requestType == BloombergRequestTypeEnum.Full)
            {
                C();
            }
            else if (requestType == BloombergRequestTypeEnum.Intraday)
            {

            }
		}

		public void CreateFullSession()
		{
			SessionOptions sessionOptions = new SessionOptions();
			sessionOptions.ServerHost = d_host;
			sessionOptions.ServerPort = d_port;

			Session session = new Session(sessionOptions);
            
			bool sessionStarted = session.Start();
			if (!sessionStarted)
			{
                throw new InvalidRequestException("Could not start request");
			}
			if (!session.OpenService("//blp/refdata"))
			{
                throw new NotFoundException("Could not open the refdata service in Bloomberg");
			}

			try
			{
				sendRefDataRequest(session);
			}
			catch (InvalidRequestException e)
			{
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

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

		// return true if processing is completed, false otherwise
		private void processResponseEvent(Event eventObj)
		{
			foreach (Message msg in eventObj)
			{
				if (msg.HasElement(RESPONSE_ERROR))
				{
					continue;
				}

				Element securities = msg.GetElement(SECURITY_DATA);
                for (int i = 0; i < securities.NumValues; ++i)
                {
                    Element security = securities.GetValueAsElement(i);
                    //string ticker = security.GetElementAsString(SECURITY);
                    if (security.HasElement("securityError"))
                    {
                        continue;
                    }

                    List<Element>  _res = requestFieldElements(security);
                    //if(_res.Single(p => p.GetValueAsString("MARKET_SECTOR_DES") == "Index"))
                    Element _id = _res.Single(p => p.Name.ToString() == "ID_BB_Unique");
                    BBInstrument _i = BloombergInstruments.Single(p => p.BloombergID == _id.GetValueAsString());
                    _i.OverrideValues(_res);


                    string message = $"{BloombergInstruments.Count(p=>p.BloombergUpdate == true)} of {BloombergInstruments.Count} complete";
                    InstrumentUpdated(message, new System.EventArgs());

                    //changed here
                    Element fieldExceptions = security.GetElement(FIELD_EXCEPTIONS);
                    if (fieldExceptions.NumValues > 0)
                    {
                        for (int k = 0; k < fieldExceptions.NumValues; ++k)
                        {
                            Element fieldException =
                                fieldExceptions.GetValueAsElement(k);
                        }
                    }

                }
            }
		}

        private List<Element> requestFieldElements(Element security)
        {
            Element fields = security.GetElement(FIELD_DATA);
            List<Element> _partial = new List<Element>();
            if (fields.NumElements > 0)
            {
                for (int j = 0; j < fields.NumElements; ++j)
                {
                    Element field = fields.GetElement(j);
                    _partial.Add(field);
                }
            }
            
            return _partial;
        }

        private void sendRefDataRequest(Session session)
		{
			Service refDataService = session.GetService("//blp/refdata");
            Request request = refDataService.CreateRequest("ReferenceDataRequest");
            Regex regex = new Regex(@"\b[eqEQ]+\b");
            List<BBInstrument> _sjnthsgh = new List<BBInstrument>();
            // Add securities to request
            Element securities = request.GetElement("securities");
            foreach (BBInstrument i in BloombergInstruments)
            {
                Match match = regex.Match(i.ID_DataFeed);
                if (match.Success)
                {
                    //string _new = i.ID_DataFeed.Replace(match.Value, "equity");
                    //i.ID_DataFeed = _new;
                    _sjnthsgh.Add(i);
                }
                else
                {
                    continue;
                }
            }
            BloombergInstruments.ForEach(p => { securities.AppendValue(p.ID_DataFeed.ToUpper()); });

			// Add fields to request
			Element fields = request.GetElement("fields");

            bloombergDataFields.ForEach(p => { fields.AppendValue(p); });
            
            session.SendRequest(request, null);
        }
	}
}
