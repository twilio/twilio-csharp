using System;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class TwilioResponse : ElementBase
	{
		public TwilioResponse()
		{
			Element = new XElement("Response");

			AllowedChildren.Add("Say");
			AllowedChildren.Add("Play");
			AllowedChildren.Add("Gather");
			AllowedChildren.Add("Dial");
			AllowedChildren.Add("Record");
			AllowedChildren.Add("Reject");
			AllowedChildren.Add("Redirect");
			AllowedChildren.Add("Sms");
			AllowedChildren.Add("Hangup");
			AllowedChildren.Add("Pause");
		}

		public TwilioResponse Dial(string number)
		{
			Add(new Dial(number));
			return this;
		}

		public TwilioResponse Dial(string number, object attributes)
		{
			Add(new Dial(number, attributes));
			return this;
		}

		public TwilioResponse Dial(string number, object dialAttributes, object numberAttributes)
		{
			BeginDial(dialAttributes);
			Add(new Number(number, numberAttributes));
			return EndDial();
		}

		public TwilioResponse Dial(Number number)
		{
			BeginDial();
			Add(number);
			return EndDial();
		}

		public TwilioResponse Dial(Number number, object dialAttributes)
		{
			BeginDial(dialAttributes);
			Add(number);
			return EndDial();
		}

		public TwilioResponse Dial(Conference conf)
		{
			BeginDial();
			Add(conf);
			return EndDial();
		}

		public TwilioResponse Dial(Conference conf, object dialAttributes)
		{
			BeginDial(dialAttributes);
			Add(conf);
			return EndDial();
		}

		public TwilioResponse DialConference(string room)
		{
			BeginDial();
			Add(new Conference(room));
			return EndDial();
		}

		public TwilioResponse DialConference(string room, object attributes)
		{
			BeginDial();
			Add(new Conference(room, attributes));
			return EndDial();
		}

		public TwilioResponse DialConference(string room, object conferenceAttributes, object dialAttributes)
		{
			BeginDial(dialAttributes);
			Add(new Conference(room, conferenceAttributes));
			return EndDial();
		}

		public TwilioResponse DialNumbers(params string[] numbers)
		{
			BeginDial();
			var dial = new Dial();
			foreach (var number in numbers)
			{
				Add(new Number(number));
			}
			return EndDial();
		}

		protected TwilioResponse BeginDial()
		{
			Current.Push(new Dial());
			return this;
		}

		protected TwilioResponse BeginDial(object attributes)
		{
			Current.Push(new Dial(null, attributes));
			return this;
		}

		protected TwilioResponse EndDial()
		{
			Add(Current.Pop());
			return this;
		}

		public TwilioResponse BeginGather()
		{
			Current.Push(new Gather());
			return this;
		}

		public TwilioResponse BeginGather(object attributes)
		{
			Current.Push(new Gather(attributes));
			return this;
		}

		public TwilioResponse EndGather()
		{
			Add(Current.Pop());
			return this;
		}

		public TwilioResponse Gather()
		{
			Add(new Gather());
			return this;
		}

		public TwilioResponse Gather(object attributes)
		{
			Add(new Gather(attributes));
			return this;
		}

		public TwilioResponse Hangup()
		{
			Add(new Hangup());
			return this;
		}

		public TwilioResponse Pause()
		{
			Add(new Pause());
			return this;
		}

		public TwilioResponse Pause(int length)
		{
			Add(new Pause(length));
			return this;
		}

		public TwilioResponse Play(string url)
		{
			Add(new Play(url));
			return this;
		}

		public TwilioResponse Play(string url, object attributes)
		{
			Add(new Play(url, attributes));
			return this;
		}

		public TwilioResponse Record()
		{
			Add(new Record());
			return this;
		}

		public TwilioResponse Record(object attributes)
		{
			Add(new Record(attributes));
			return this;
		}

		public TwilioResponse Redirect()
		{
			Add(new Redirect());
			return this;
		}

		public TwilioResponse Redirect(string url)
		{
			Add(new Redirect(url));
			return this;
		}

		public TwilioResponse Redirect(string url, string method)
		{
			Add(new Redirect(url, method));
			return this;
		}

		public TwilioResponse Reject()
		{
			Add(new Reject());
			return this;
		}

		public TwilioResponse Reject(string reason)
		{
			Add(new Reject(reason));
			return this;
		}

		public TwilioResponse Say(string text)
		{
			Add(new Say(text));
			return this;
		}

		public TwilioResponse Say(string text, object attributes)
		{
			Add(new Say(text, attributes));
			return this;
		}

		public TwilioResponse Sms(string text)
		{
			Add(new Sms(text));
			return this;
		}

		public TwilioResponse Sms(string text, object attributes)
		{
			Add(new Sms(text, attributes));
			return this;
		}

		public override string ToString()
		{
			return ToXDocument().ToString();
		}

		public XDocument ToXDocument()
		{
			return new XDocument(Element);
		}
	}
}
