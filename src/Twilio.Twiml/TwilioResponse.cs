using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Twilio.TwiML
{
    /// <summary>
    /// The root element of Twilio's XML Markup.
    /// </summary>
    /// <remarks>
    /// In any TwiML response to a Twilio request, all verb elements must be nested 
    /// within this element. Any other structure is considered invalid.
    /// </remarks>
	public class TwilioResponse : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the TwilioResponse class.
        /// </summary>
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
            AllowedChildren.Add("Message");
			AllowedChildren.Add("Hangup");
			AllowedChildren.Add("Pause");
            AllowedChildren.Add("Enqueue");
            AllowedChildren.Add("Leave");
        }

        /// <summary>
        /// Connects the current caller to another phone number
        /// </summary>
        /// <param name="number">The phone number to dial</param>
        /// <returns></returns>
		public TwilioResponse Dial(string number)
		{
			Add(new Dial(number));
			return this;
		}

        /// <summary>
        /// Connects the current caller to another phone number
        /// </summary>
        /// <param name="number">The phone number to dial</param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse Dial(string number, object attributes)
		{
			Add(new Dial(number, attributes));
			return this;
		}

        /// <summary>
        /// Connects the current caller to another phone number
        /// </summary>
        /// <param name="number">The phone number to dial</param>
        /// <param name="dialAttributes"></param>
        /// <param name="numberAttributes"></param>
        /// <returns></returns>
		public TwilioResponse Dial(string number, object dialAttributes, object numberAttributes)
		{
			BeginDial(dialAttributes);
			Add(new Number(number, numberAttributes));
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to another phone number
        /// </summary>
        /// <param name="number">The phone number to dial</param>
        /// <returns></returns>
        public TwilioResponse Dial(Number number)
		{
			BeginDial();
			Add(number);
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to another phone number
        /// </summary>
        /// <param name="number">The phone number to dial</param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
        public TwilioResponse Dial(Number number, object dialAttributes)
		{
			BeginDial(dialAttributes);
			Add(number);
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to a Client
        /// </summary>
        /// <param name="client">The Client to dial</param>
        /// <returns></returns>
		public TwilioResponse Dial(Client client)
		{
			BeginDial();
			Add(client);
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to a Client
        /// </summary>
        /// <param name="client">The Client to dial</param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
        public TwilioResponse Dial(Client client, object dialAttributes)
		{
			BeginDial(dialAttributes);
			Add(client);
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to a Conference
        /// </summary>
        /// <param name="conf">The Conference to dial</param>
        /// <returns></returns>
        public TwilioResponse Dial(Conference conf)
		{
			BeginDial();
			Add(conf);
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to a Conference
        /// </summary>
        /// <param name="conf">The Conference to dial</param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
        public TwilioResponse Dial(Conference conf, object dialAttributes)
		{
			BeginDial(dialAttributes);
			Add(conf);
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to a Conference
        /// </summary>
        /// <param name="room">The conference room name dial</param>
        /// <returns></returns>
        public TwilioResponse DialConference(string room)
		{
			BeginDial();
			Add(new Conference(room));
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to a Conference
        /// </summary>
        /// <param name="room">The conference room name dial</param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse DialConference(string room, object attributes)
		{
			BeginDial();
			Add(new Conference(room, attributes));
			return EndDial();
		}

        /// <summary>
        /// Connects the current caller to a Conference
        /// </summary>
        /// <param name="room">The conference room name dial</param>
        /// <param name="conferenceAttributes"></param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
		public TwilioResponse DialConference(string room, object conferenceAttributes, object dialAttributes)
		{
			BeginDial(dialAttributes);
			Add(new Conference(room, conferenceAttributes));
			return EndDial();
		}

        /// <summary>
        /// Adds the current caller to a Queue
        /// </summary>
        /// <param name="queue">The Queue to add the user to</param>
        /// <returns></returns>
        public TwilioResponse Dial(Queue queue)
        {
            BeginDial();
            Add(queue);
            return EndDial();
        }

        /// <summary>
        /// Adds the current caller to a Queue
        /// </summary>
        /// <param name="queue">The Queue to add the user to</param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
        public TwilioResponse Dial(Queue queue, object dialAttributes)
        {
            BeginDial(dialAttributes);
            Add(queue);
            return EndDial();
        }

        /// <summary>
        /// Adds the current caller to a Queue
        /// </summary>
        /// <param name="name">The name of the queue to add the user to</param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
        public TwilioResponse DialQueue(string name, object dialAttributes)
        {
            BeginDial(dialAttributes);
            Add(new Queue(name));
            return EndDial();
        }

        /// <summary>
        /// Adds the current caller to a Queue
        /// </summary>
        /// <param name="name">The name of the queue to add the user to</param>
        /// <param name="queueAttributes"></param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
        public TwilioResponse DialQueue(string name, object queueAttributes, object dialAttributes)
        {
            BeginDial(dialAttributes);
            Add(new Queue(name, queueAttributes));
            return EndDial();
        }

        /// <summary>
        /// Connects the current caller to a SIP address
        /// </summary>
        /// <param name="sip">The SIP endpoint to dial</param>
        /// <returns></returns>
        public TwilioResponse Dial(Sip sip)
        {
            BeginDial();
            Add(sip);
            return EndDial();
        }

        /// <summary>
        /// Connects the current caller to a SIP address
        /// </summary>
        /// <param name="sip">The SIP endpoint to dial</param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
        public TwilioResponse Dial(Sip sip, object dialAttributes)
        {
            BeginDial(dialAttributes);
            Add(sip);
            return EndDial();
        }

        /// <summary>
        /// Simultaniously dial multiple phone numbers. The first of these calls to answer will be connected to the current caller, while the rest of the connection attempts are canceled.
        /// </summary>
        /// <param name="numbers">An array of phone numbers to dial</param>
        /// <returns></returns>
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

        /// <summary>
        /// Simultaniously dial multiple Clients. The first of these calls to answer will be connected to the current caller, while the rest of the connection attempts are canceled.
        /// </summary>
        /// <param name="clients">An array of Client names to dial</param>
        /// <returns></returns>
        public TwilioResponse DialClients(params string[] clients)
		{
			BeginDial();
			//var dial = new Dial();
			foreach (var client in clients)
			{
				Add(new Client(client));
			}
			return EndDial();
		}

        /// <summary>
        /// Simultaniously dial multiple Numbers, Clients, Conferences and Queues. The first of these calls to answer will be connected to the current caller, while the rest of the connection attempts are canceled.
        /// </summary>
        /// <param name="dialTargets">An array of Numbers, Clients, Conferences or Queues to dial</param>
        /// <returns></returns>
        public TwilioResponse Dial(params IDialNoun[] dialTargets)
		{
			BeginDial();

			foreach (IDialNoun noun in dialTargets)
			{
				Add((ElementBase)noun);
			}

			return EndDial();
		}

        /// <summary>
        /// Simultaniously dial multiple Numbers, Clients, Conferences and Queues. The first of these calls to answer will be connected to the current caller, while the rest of the connection attempts are canceled.
        /// </summary>
        /// <param name="dialTargets">An array of Numbers, Clients, Conferences or Queues to dial</param>
        /// <param name="dialAttributes"></param>
        /// <returns></returns>
        public TwilioResponse Dial(object dialAttributes, params IDialNoun[] dialTargets)
        {
            BeginDial(dialAttributes);

            foreach (IDialNoun noun in dialTargets)
            {
                Add((ElementBase)noun);
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

        public TwilioResponse BeginMessage(object attributes)
        {
            Current.Push(new Message(attributes));
            return this;
        }

        public TwilioResponse EndMessage()
        {
            Add(Current.Pop());
            return this;
        }

        /// <summary>
        /// Add a Call to a TaskQueue
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse Enqueue(object attributes)
        {
            Add(new Enqueue(String.Empty, attributes));
            return this;
        }

        /// <summary>
        /// Add a Call to a TaskQueue
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="taskAttributes">json blob for TaskRouter Task Attributes</param>
        /// <param name="taskProperties">additional parameters for a TaskRouter Task (priority, timeout)</param>
        /// <returns></returns>
        public TwilioResponse Enqueue(object attributes, string taskAttributes, object taskProperties)
        {
            var enqueue = new Enqueue(String.Empty, attributes);
            Current.Push(enqueue);

            if (!string.IsNullOrEmpty(taskAttributes)) { Add(new Task(taskAttributes, taskProperties)); }

            Add(Current.Pop());

            return this;
        }

        /// <summary>
        /// Add a Call to a TaskQueue
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        public TwilioResponse EnqueueTask(object attributes, Task task)
        {
            var enqueue = new Enqueue(String.Empty, attributes);
            Current.Push(enqueue);
            Add(task);
            Add(Current.Pop());

            return this;
        }

        /// <summary>
        /// Add a Call to a Queue
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TwilioResponse Enqueue(string name)
        {
            Add(new Enqueue(name));
            return this;
        }

        /// <summary>
        /// Add a Call to a Queue
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse Enqueue(string name, object attributes)
        {
            Add(new Enqueue(name, attributes));
            return this;
        }

        /// <summary>
        /// Collects digits that a caller enters into his or her telephone keypad
        /// </summary>
        /// <returns></returns>
		public TwilioResponse Gather()
		{
			Add(new Gather());
			return this;
		}

        /// <summary>
        /// Collects digits that a caller enters into his or her telephone keypad
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse Gather(object attributes)
		{
			Add(new Gather(attributes));
			return this;
		}

        /// <summary>
        /// Ends a call
        /// </summary>
        /// <returns></returns>
		public TwilioResponse Hangup()
		{
			Add(new Hangup());
			return this;
		}

        /// <summary>
        /// Removes a caller from a Queue and continues execution with the next TwiML verb.
        /// </summary>
        /// <returns></returns>
        public TwilioResponse Leave()
        {
            Add(new Leave());
            return this;
        }

        /// <summary>
        /// Send an Message to a phone number
        /// </summary>
        /// <param name="body">The Message body</param>
        /// <returns></returns>
        public TwilioResponse Message(string body)
        {
            return Message(body, null);
        }

        /// <summary>
        /// Send an Message to a phone number
        /// </summary>
        /// <param name="body">The Message body</param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse Message(string body, object attributes)
        {
            Add(new Message(body, attributes));
            return this;
        }

        public TwilioResponse Message(string[] mediaUrls)
        {
            return Message(mediaUrls, null);
        }

        public TwilioResponse Message(string[] mediaUrls, object attributes)
        {
            return Message(null, mediaUrls, attributes);
        }

        public TwilioResponse Message(string body, string[] mediaUrls, object attributes)
        {
            var message = new Message(attributes);
            Current.Push(message);

            if (!string.IsNullOrEmpty(body)) { Add(new Body(body)); }

            foreach (var m in mediaUrls)
            {
                Add(new Media(m));
            }

            Add(Current.Pop());

            return this;
        }

        public TwilioResponse Body(string text)
        {
            Add(new Body(text));
            return this;

        }

        public TwilioResponse Media(string url)
        {
            Add(new Media(url));
            return this;
        }

        /// <summary>
        /// Waits silently for a specific number of seconds
        /// </summary>
        /// <returns></returns>
		public TwilioResponse Pause()
		{
			Add(new Pause());
			return this;
		}

        /// <summary>
        /// Waits silently for a specific number of seconds
        /// </summary>
        /// <param name="length">The number of seconds to wait</param>
        /// <returns></returns>
        public TwilioResponse Pause(int length)
		{
			Add(new Pause(length));
			return this;
		}

        /// <summary>
        /// Plays an audio file back to the caller
        /// </summary>
        /// <param name="url">The Url containing the audio file to play</param>
        /// <returns></returns>
		public TwilioResponse Play(string url)
		{
			Add(new Play(url));
			return this;
		}

        /// <summary>
        /// Plays an audio file back to the caller
        /// </summary>
        /// <param name="url">The Url containing the audio file to play</param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse Play(string url, object attributes)
		{
			Add(new Play(url, attributes));
			return this;
		}

        /// <summary>
        /// Records the caller's voice and returns to you the URL of a file containing the audio recording
        /// </summary>
        /// <returns></returns>
		public TwilioResponse Record()
		{
			Add(new Record());
			return this;
		}

        /// <summary>
        /// Records the caller's voice and returns to you the URL of a file containing the audio recording
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse Record(object attributes)
		{
			Add(new Record(attributes));
			return this;
		}

        /// <summary>
        /// Transfers control of a call to the TwiML at a different URL
        /// </summary>
        /// <returns></returns>
		public TwilioResponse Redirect()
		{
			Add(new Redirect());
			return this;
		}

        /// <summary>
        /// Transfers control of a call to the TwiML at a different URL
        /// </summary>
        /// <param name="url">The Url to transfer control to</param>
        /// <returns></returns>
        public TwilioResponse Redirect(string url)
		{
			Add(new Redirect(url));
			return this;
		}

        /// <summary>
        /// Transfers control of a call to the TwiML at a different URL
        /// </summary>
        /// <param name="url">The Url to transfer control to</param>
        /// <param name="method">The HTTP method used to request the new Url</param>
        /// <returns></returns>
        public TwilioResponse Redirect(string url, string method)
		{
			Add(new Redirect(url, method));
			return this;
		}

        /// <summary>
        /// Rejects an incoming call to your Twilio number without billing you
        /// </summary>
        /// <returns></returns>
		public TwilioResponse Reject()
		{
			Add(new Reject());
			return this;
		}

        /// <summary>
        /// Rejects an incoming call to your Twilio number without billing you
        /// </summary>
        /// <param name="reason">The message played to a rejected call</param>
        /// <returns></returns>
        public TwilioResponse Reject(string reason)
		{
			Add(new Reject(reason));
			return this;
		}

        /// <summary>
        /// Converts text to speech that is read back to the caller
        /// </summary>
        /// <param name="text">The text to convert</param>
        /// <returns></returns>
		public TwilioResponse Say(string text)
		{
			Add(new Say(text));
			return this;
		}

        /// <summary>
        /// Converts text to speech that is read back to the caller
        /// </summary>
        /// <param name="text">The text to convert</param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public TwilioResponse Say(string text, object attributes)
		{
			Add(new Say(text, attributes));
			return this;
		}

        /// <summary>
        /// Send an SMS to a phone number
        /// </summary>
        /// <param name="text">The SMS message body</param>
        /// <returns></returns>
        public TwilioResponse Sms(string text)
		{
			Add(new Sms(text));
			return this;
		}

        /// <summary>
        /// Send an SMS to a phone number
        /// </summary>
        /// <param name="text">The SMS message body</param>
        /// <param name="attributes"></param>
        /// <returns></returns>
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
