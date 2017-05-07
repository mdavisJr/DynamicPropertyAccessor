using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests;

namespace DynamicPropertyAccessor.Tests
{
    [TestClass]
    public class DynamicPropertyAccessorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestClass1 testClass1 = new TestClass1();
            TestClass2 testClass2 = new TestClass2();
            DateTime dateTime = DateTime.Now;
            int[] intArrayValue = new int[] { 1, 2, 3, 4, 5 };
            string[] stringArrayValue = new string[] { "asdf", "asldkj", "asdfk;", "alsdkfj", "oiweru" };

            testClass1.SetProperty("StringProp", "StringProp");
            testClass1.SetProperty("ShortProp", (short)1);
            testClass1.SetProperty("IntProp", 67);
            testClass1.SetProperty("LongProp", 1000000000000000);
            testClass1.SetProperty("FloatProp", 23.45f);
            testClass1.SetProperty("DecimalProp", 99.45m);
            testClass1.SetProperty("DateTimeProp", dateTime);
            testClass1.SetProperty("CharProp", 'c');
            testClass1.SetProperty("ByteProp", (byte)1);
            testClass1.SetProperty("IntArrayProp", intArrayValue);
            testClass1.SetProperty("StringArrayProp", stringArrayValue);
            testClass2.SetProperty("NullableIntProp", 23);
            testClass2.SetProperty("NullableDateTimeProp", dateTime);
            testClass2.SetProperty("NullableLongProp", 1000000000000000);
            testClass1.SetProperty("TestClass2", testClass2);

            Assert.AreEqual("StringProp", testClass1.GetProperty<string>("StringProp"));
            Assert.AreEqual((short) 1, testClass1.GetProperty<short>("ShortProp"));
            Assert.AreEqual(67, testClass1.GetProperty<int>("IntProp"));
            Assert.AreEqual(1000000000000000, testClass1.GetProperty<long>("LongProp"));
            Assert.AreEqual(23.45f, testClass1.GetProperty<float>("FloatProp"));
            Assert.AreEqual(99.45m, testClass1.GetProperty<decimal>("DecimalProp"));
            Assert.AreEqual(dateTime, testClass1.GetProperty<DateTime>("DateTimeProp"));
            Assert.AreEqual('c', testClass1.GetProperty<char>("CharProp"));
            Assert.AreEqual((byte)1, testClass1.GetProperty<byte>("ByteProp"));
            Assert.AreEqual(intArrayValue, testClass1.GetProperty<int[]>("IntArrayProp"));
            Assert.AreEqual(stringArrayValue, testClass1.GetProperty<string[]>("StringArrayProp"));
            Assert.AreEqual(23, testClass1.GetProperty<ITestClass2>("TestClass2").GetProperty<int?>("NullableIntProp"));
            Assert.AreEqual(dateTime, testClass1.GetProperty<ITestClass2>("TestClass2").GetProperty<DateTime?>("NullableDateTimeProp"));
            Assert.AreEqual(1000000000000000, testClass1.GetProperty<ITestClass2>("TestClass2").GetProperty<long?>("NullableLongProp"));
            Assert.AreEqual(testClass2, testClass1.GetProperty<ITestClass2>("TestClass2"));

            Assert.AreEqual("StringProp", testClass1.GetProperty("StringProp"));
            Assert.AreEqual((short)1, testClass1.GetProperty("ShortProp"));
            Assert.AreEqual(67, testClass1.GetProperty("IntProp"));
            Assert.AreEqual(1000000000000000, testClass1.GetProperty("LongProp"));
            Assert.AreEqual(23.45f, testClass1.GetProperty("FloatProp"));
            Assert.AreEqual(99.45m, testClass1.GetProperty("DecimalProp"));
            Assert.AreEqual(dateTime, testClass1.GetProperty("DateTimeProp"));
            Assert.AreEqual('c', testClass1.GetProperty("CharProp"));
            Assert.AreEqual((byte)1, testClass1.GetProperty("ByteProp"));
            Assert.AreEqual(intArrayValue, testClass1.GetProperty("IntArrayProp"));
            Assert.AreEqual(stringArrayValue, testClass1.GetProperty("StringArrayProp"));
            Assert.AreEqual(23, testClass1.GetProperty("TestClass2").GetProperty("NullableIntProp"));
            Assert.AreEqual(dateTime, testClass1.GetProperty("TestClass2").GetProperty("NullableDateTimeProp"));
            Assert.AreEqual(1000000000000000, testClass1.GetProperty("TestClass2").GetProperty("NullableLongProp"));
            Assert.AreEqual(testClass2, testClass1.GetProperty("TestClass2"));
        }
    }
}
