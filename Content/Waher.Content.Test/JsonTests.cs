﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waher.Content;

namespace Waher.Content.Test
{
	[TestClass]
    public class JsonTests
    {
		// JSON Parsing diagram: http://json.org/

		[TestMethod]
		public void Test_01_True()
		{
			Assert.AreEqual(true, JSON.Parse("true"));
		}

		[TestMethod]
		public void Test_02_False()
		{
			Assert.AreEqual(false, JSON.Parse("false"));
		}

		[TestMethod]
		public void Test_03_Null()
		{
			Assert.AreEqual(null, JSON.Parse("null"));
		}

		[TestMethod]
		public void Test_04_Number_1()
		{
			Assert.AreEqual(12, JSON.Parse("12"));
		}

		[TestMethod]
		public void Test_05_Number_2()
		{
			Assert.AreEqual(12.3, JSON.Parse("12.3"));
		}

		[TestMethod]
		public void Test_05_Number_3()
		{
			Assert.AreEqual(12e3, JSON.Parse("12e3"));
		}

		[TestMethod]
		public void Test_06_Number_4()
		{
			Assert.AreEqual(12e-3, JSON.Parse("12e-3"));
		}

		[TestMethod]
		public void Test_07_Number_5()
		{
			Assert.AreEqual(12.3E+4, JSON.Parse("12.3E+4"));
		}

		[TestMethod]
		public void Test_08_Number_6()
		{
			Assert.AreEqual(.3, JSON.Parse(".3"));	// Not strictly JSON.
		}

		[TestMethod]
		public void Test_09_String_1()
		{
			Assert.AreEqual("Hello", JSON.Parse("\"Hello\"")); 
		}

		[TestMethod]
		public void Test_10_String_2()
		{
			Assert.AreEqual("He\"llo", JSON.Parse("\"He\\\"llo\""));
		}

		[TestMethod]
		public void Test_11_String_3()
		{
			Assert.AreEqual("He\\llo", JSON.Parse("\"He\\\\llo\""));
		}

		[TestMethod]
		public void Test_12_String_4()
		{
			Assert.AreEqual("He/llo", JSON.Parse("\"He\\/llo\""));
		}

		[TestMethod]
		public void Test_13_String_5()
		{
			Assert.AreEqual("He\bllo", JSON.Parse("\"He\\bllo\""));
		}

		[TestMethod]
		public void Test_14_String_6()
		{
			Assert.AreEqual("He\fllo", JSON.Parse("\"He\\fllo\""));
		}

		[TestMethod]
		public void Test_15_String_7()
		{
			Assert.AreEqual("He\nllo", JSON.Parse("\"He\\nllo\""));
		}

		[TestMethod]
		public void Test_16_String_8()
		{
			Assert.AreEqual("He\rllo", JSON.Parse("\"He\\rllo\""));
		}

		[TestMethod]
		public void Test_17_String_9()
		{
			Assert.AreEqual("He\tllo", JSON.Parse("\"He\\tllo\""));
		}

		[TestMethod]
		public void Test_18_String_10()
		{
			Assert.AreEqual("He\u1234llo", JSON.Parse("\"He\\u1234llo\""));
		}

		[TestMethod]
		public void Test_19_ParseObject()
		{
			string Json = "{\n  \"success\": true,\n  \"challenge_ts\": \"2017-04-17T06:41:36Z\",\n  \"hostname\": \"localhost\"\n}";

			Dictionary<string, object> Obj = (Dictionary<string, object>)JSON.Parse(Json);

			Assert.AreEqual(3, Obj.Count);
			Assert.AreEqual(true, Obj["success"]);
			Assert.AreEqual("2017-04-17T06:41:36Z", Obj["challenge_ts"]);
			Assert.AreEqual("localhost", Obj["hostname"]);
		}

		[TestMethod]
		public void Test_20_ParseArray()
		{
			string Json = "[1, \"Hello\", {\"a\":1,\"b\":2}]";

			object[] A = (object[])JSON.Parse(Json);

			Assert.AreEqual(3, A.Length);
			Assert.AreEqual(1, A[0]);
			Assert.AreEqual("Hello", A[1]);

			Dictionary<string, object> Obj = (Dictionary<string, object>)A[2];

			Assert.AreEqual(2, Obj.Count);
			Assert.AreEqual(1, Obj["a"]);
			Assert.AreEqual(2, Obj["b"]);
		}

		[TestMethod]
		public void Test_21_Misc1()
		{
			string Json = "{\"sn\":\"20:19:AB:F4:04:51\",\"data\":{\"acc\":{\"x\":26,\"y\":32,\"z\":1012,\"unit\":\"mG\"},\"gyro\":{\"x\":1220,\"y\":-6835,\"z\":-2319,\"unit\":\"mdeg/s\"},\"mag\":{\"x\":40,\"y\":1,\"z\":-4,\"unit\":\"uT\"},\"light\":{\"value\":5483,\"unit\":\"mLux\"},\"temp\":{\"value\":50000,\"unit\":\"mCelsius\"},\"pressure\":{\"value\":98897,\"unit\":\"Pascal\"},\"humidity\":{\"value\":39,\"unit\":\"%rh\"}}}";
			object Obj = JSON.Parse(Json);
		}

		[TestMethod]
		public void Test_22_Misc2()
		{
			string Json = "{\"id\": 8413652,\"key\": {\"kty\": \"RSA\",\"n\": \"sjmhiy0aCAeF7t_6NGYdCZPU0oo6Xf-xCXETkSz2Gx4nZ1K47gwVSrZFdMwOvBoig2IXuI2hxTV57T8W4NWqo9bOPUvr31mm-USN-KT3_CV37PAzog_flUAfTa0C8DSLNaO21dcDFGoQF7taOPtAV9auXDp4_7xOJry9uOr8s_7qM09cxFdEAVl7i3rNB0KOhpLgBlZrhDCVEap-2Oz80medXisIqpqCQxfNJut6qNDHJbqytZ0-y42T2ioc4YrwFCq0WA2C9RTzfXXxUy5-gKO0YK5AIYeK_mbvm7qeY2wHDust55jQPHQpeOkyihVq3SuMJkt3R0i8gFWSaj8F_nmYKv6wOqam52OyKOywElHHZEVG_s8kX6AOJAiVwkv0NaYQBJ6DTqXX2ye-RqKpKFSXa07pUQI2Pu1S5GKVoEmhcyG9RxOtaPB8sPuJiQZKZhuQ2a-1sM_GMeXTTkAX-AtPoiLSZ4cy-JAteVHKuSV3UUsrUsryQ133l7rETATYqnBPUk-ZkSR49ym38IbieShFUxajQaV4SyMruHKAyQ43KUQnt3p4wwD0LuE--502sB0DcRvrFMfefhu8jfrN9JWnSJfB-SDpqsZkv_p3rbDhCzh51RKP9kQcEVd00fZn0ce2IpMkEAlBI0hjbD3eNcGSfvEBEKIHy5CJWATl6lE\",\"e\": \"AQAB\"},\"contact\": [],\"agreement\": \"https://letsencrypt.org/documents/LE-SA-v1.2-November-15-2017.pdf\",\"initialIp\": \"81.229.128.148\",\"createdAt\": \"2019-03-02T17:40:07Z\",\"status\": \"valid\"}";
			object Obj = JSON.Parse(Json);
		}
	}
}
