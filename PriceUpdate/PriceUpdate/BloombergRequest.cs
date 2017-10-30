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

namespace Bloomberglp.Blpapi.Examples
{

	public class BloombergRequest
	{
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
        public ArrayList bloombergInstruments = new ArrayList();
        private ArrayList bloombergDataFields = new ArrayList() {"ID_BB_Unique", "ID_ISIN", "TICKER", "ID_SEDOL1", "ID_COMMON", "MARKET_SECTOR_DES", "EXCH_CODE",
                "NAME", "PX_MID", "PX_BID", "PX_ASK", "PX_Last", "CRNCY", "EQY_DVD_SH_12M", "DVD_CRNCY", "FUND_NET_ASSET_VAL", "REL_1M",
                "REL_3M", "REL_6M", "REL_1YR", "REL_MTD", "REL_QTD", "REL_YTD", "IS_EPS", "PX_TO_BOOK_RATIO", "BS_CORE_CAP_RATIO",
                "CF_FREE_CASH_FLOW", "EBITDA", "EBIT", "ENTERPRISE_VALUE", "PAR_AMT", "BS_PAR_VAL", "CPN", "MATURITY", "INT_ACC_PER_BOND", "NXT_CPN_DT", "EQY_SH_OUT"};
    
        //public List<BBInstrument> Results { get; set; }
        public List<BBInstrument> Results { get; set; }

        public static int  NumberOfSecurities { get; set; }

        public BloombergRequest(List<BBInstrument> instruments)
		{
			d_host = "localhost";
			d_port = 8194;
            Results = instruments;
            foreach (BBInstrument i in Results)
            {
                bloombergInstruments.Add(i.ID_DataFeed);
            }
            Request();
		}

		public void Request()
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
                NumberOfSecurities = securities.NumValues;
				int numSecurities = securities.NumValues;
                for (int i = 0; i < NumberOfSecurities; ++i)
				{
					Element security = securities.GetValueAsElement(i);
                    if(Results.Contains(security.GetValueAsString("ID_ISIN")))
                    {

                    }
					string ticker = security.GetElementAsString(SECURITY);
					if (security.HasElement("securityError"))
					{
						continue;
					}

					Element fields = security.GetElement(FIELD_DATA);
                    List<Element> _partial = new List<Element>();
                    if (fields.NumElements > 0)
					{
						int numElements = fields.NumElements;
						for (int j = 0; j < numElements; ++j)
						{
							Element field = fields.GetElement(j);
                            _partial.Add(field);
						}

                    }
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

		private void sendRefDataRequest(Session session)
		{
			Service refDataService = session.GetService("//blp/refdata");
            Request request = refDataService.CreateRequest("ReferenceDataRequest");

			// Add securities to request
			Element securities = request.GetElement("securities");

			for (int i = 0; i < bloombergInstruments.Count; ++i)
			{
				securities.AppendValue((string)bloombergInstruments[i]);
			}

			// Add fields to request
			Element fields = request.GetElement("fields");
			for (int i = 0; i < bloombergDataFields.Count; ++i)
			{
				fields.AppendValue((string)bloombergDataFields[i]);
			}
			session.SendRequest(request, null);
            

        }

		internal class LoggingCallback : Logging.Callback
		{
			public void OnMessage(long threadId,
				TraceLevel level,
				Datetime dateTime,
				String
				loggerName,
				String message)
			{
                System.Windows.Forms.MessageBox.Show(dateTime + "  " + loggerName
					+ " [" + level.ToString() + "] Thread ID = "
					+ threadId + " " + message);
			}
		}

		private void registerCallback(int verbosityCount)
		{
			TraceLevel level = TraceLevel.Off;
			switch (verbosityCount)
			{
				case 1:
					{
						level = TraceLevel.Warning;
					} break;
				case 2:
					{
						level = TraceLevel.Info;
					} break;
				default:
					{
						level = TraceLevel.Verbose;
					} break;
			};
			Logging.RegisterCallback(new LoggingCallback(), level);
		}

		private bool parseCommandLine(string[] args)
		{
            int verbosityCount = 0;
			for (int i = 0; i < args.Length; ++i)
			{
				if (string.Compare(args[i], "-s", true) == 0)
				{
					bloombergInstruments.Add(args[i+1]);
				}
				else if (string.Compare(args[i], "-f", true) == 0)
				{
					bloombergDataFields.Add(args[i+1]);
				}
				else if (string.Compare(args[i], "-ip", true) == 0)
				{
					d_host = args[i+1];
				}
				else if (string.Compare(args[i], "-p", true) == 0)
				{
					d_port = int.Parse(args[i+1]);
				}
				else if (string.Compare(args[i], "-v", true) == 0)
				{
					++verbosityCount;
				}
				else if (string.Compare(args[i], "-h", true) == 0)
				{
					return false;
				}
			}

			if (verbosityCount > 0)
			{
				registerCallback(verbosityCount);
			}
			// handle default arguments
			return true;
		}
	}
}
