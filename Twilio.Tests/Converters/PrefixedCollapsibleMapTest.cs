using NSubstitute;
using NUnit.Framework;
using System;
using Twilio.Converters;
using System.Collections.Generic;
using ExtensionMethods;
using System.Linq;

namespace Twilio.Tests
{
	[TestFixture]
	public class PrefixedCollapsibleMapTest : TwilioTest {

		[Test]
		public void TestEmptyMap() {

			Dictionary<String, Object> inputDict = new Dictionary<String, Object>();
			Dictionary<String, String> resultsDict = new Dictionary<String, String>();
			List<String> prevList = new List<String>();

			Dictionary<String, String> result = PrefixedCollapsibleMap.Flatten(
				inputDict, 
				resultsDict, 
				prevList
			);

			Dictionary<String, String> expected = new Dictionary<String, String>();
		
			Assert.IsTrue(expected.SequenceEqual(result));
		}

		[Test]
		public void TestBasicMap() {

			Dictionary<String, Object> inputDict = new Dictionary<String, Object>();

			inputDict.Add("foo", "bar");
			inputDict.Add("cool", "beans"); 

			Dictionary<String, String> resultsDict = new Dictionary<String, String>();
			List<String> prevList = new List<String>();

			Dictionary<String, String> result = PrefixedCollapsibleMap.Flatten(
				inputDict, 
				resultsDict, 
				prevList
			);

			Dictionary<String, String> expected = new Dictionary<String, String>();
			expected.Add("foo","bar");
			expected.Add("cool","beans");

			Assert.IsTrue(expected.SequenceEqual(result));
		}

		[Test]
		public void TestComplexMap() {

			Dictionary<String, Object> inputDict = new Dictionary<String, Object>();
			Dictionary<String, Object> subDict = new Dictionary<String, Object>();

			subDict.Add("cool", "people");
			subDict.Add("fun", "times");

			inputDict.Add("foo", "bar");
			inputDict.Add("really", subDict); 

			Dictionary<String, String> resultsDict = new Dictionary<String, String>();
			List<String> prevList = new List<String>();

			Dictionary<String, String> result = PrefixedCollapsibleMap.Flatten(
				inputDict, 
				resultsDict, 
				prevList
			);

			Dictionary<String, String> expected = new Dictionary<String, String>();
			expected.Add("foo","bar");
			expected.Add("really.cool","people");
			expected.Add("really.fun","times");

			Assert.IsTrue(expected.SequenceEqual(result));
		}

		[Test]
		public void TestEmptyNullSerialize() {

			Dictionary<String, String> result = PrefixedCollapsibleMap.Serialize(
				null, 
				"really"
			);

			Dictionary<String, String> expected = new Dictionary<String, String>();

			Assert.IsTrue(expected.SequenceEqual(result));

			result = PrefixedCollapsibleMap.Serialize(
				new Dictionary<String, Object>(), 
				"really"
			);

			Assert.IsTrue(expected.SequenceEqual(result));
		}

		[Test]
		public void TestNormalSerialize() {

			Dictionary<String, Object> inputDict = new Dictionary<String, Object>();
			Dictionary<String, Object> subDict = new Dictionary<String, Object>();

			subDict.Add("cool", "people");
			subDict.Add("fun", "times");

			inputDict.Add("foo", "bar");
			inputDict.Add("super", subDict); 

			Dictionary<String, String> result = PrefixedCollapsibleMap.Serialize(
				inputDict, 
				"really"
			);

			Dictionary<String, String> expected = new Dictionary<String, String>();
			expected.Add("really.foo","bar");
			expected.Add("really.super.cool","people");
			expected.Add("really.super.fun","times");

			Assert.IsTrue(expected.SequenceEqual(result));
		}
	}
}