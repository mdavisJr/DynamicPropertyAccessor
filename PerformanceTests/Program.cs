using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicPropertyAccessor;

namespace PerformanceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            int executeNumberOfTimes = 1000000;
            DateTime dateTime = DateTime.Now;
            int[] intArrayValue = new int[] { 1, 2, 3, 4, 5 };
            string[] stringArrayValue = new string[] { "asdf", "asldkj", "asdfk;", "alsdkfj", "oiweru" };

            //Regular Property Access Performance Test
            TestClass1 testClass1 = new TestClass1();
            TestClass2 testClass2 = new TestClass2();
            Stopwatch regularProperyAccessSW = Stopwatch.StartNew();
            for (int i = 0; i < executeNumberOfTimes; i++)
            {
                testClass1.StringProp = "StringProp";
                testClass1.ShortProp = 1;
                testClass1.IntProp = 67;
                testClass1.LongProp = 1000000000000000;
                testClass1.FloatProp = 23.45f;
                testClass1.DecimalProp = 99.45m;
                testClass1.DateTimeProp = dateTime;
                testClass1.CharProp = 'c';
                testClass1.ByteProp = 1;
                testClass1.IntArrayProp = intArrayValue;
                testClass1.StringArrayProp = stringArrayValue;
                testClass2.NullableIntProp = 23;
                testClass2.NullableDateTimeProp = dateTime;
                testClass2.NullableLongProp = 1000000000000000;
                testClass1.TestClass2 = testClass2;

                string stringProp = testClass1.StringProp;
                short shortProp = testClass1.ShortProp;
                int intProp = testClass1.IntProp;
                long longProp = testClass1.LongProp;
                float floatProp = testClass1.FloatProp;
                decimal decimalProp = testClass1.DecimalProp;
                DateTime dateTimeProp = testClass1.DateTimeProp;
                char charProp = testClass1.CharProp;
                byte byteProp = testClass1.ByteProp;
                int[] intArrayProp = testClass1.IntArrayProp;
                string[] stringArrayProp = testClass1.StringArrayProp;
                ITestClass2 testClass22 = testClass1.TestClass2;
                int? nullableIntProp = testClass22.NullableIntProp;
                DateTime? nullableDateTimeProp = testClass22.NullableDateTimeProp;
                long? nullableLongProp = testClass22.NullableLongProp;
            }
            regularProperyAccessSW.Stop();

            //DynamicPropertyAccessor Code Performance Test 
            testClass1 = new TestClass1();
            testClass2 = new TestClass2();
            Stopwatch dpaSw = Stopwatch.StartNew();
            for (int i = 0; i < executeNumberOfTimes; i++)
            {
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

                string stringProp = testClass1.GetProperty<string>("StringProp");
                short shortProp = testClass1.GetProperty<short>("ShortProp");
                int intProp = testClass1.GetProperty<int>("IntProp");
                long longProp = testClass1.GetProperty<long>("LongProp");
                float floatProp = testClass1.GetProperty<float>("FloatProp");
                decimal decimalProp = testClass1.GetProperty<decimal>("DecimalProp");
                DateTime dateTimeProp = testClass1.GetProperty<DateTime>("DateTimeProp");
                char charProp = testClass1.GetProperty<char>("CharProp");
                byte byteProp = testClass1.GetProperty<byte>("ByteProp");
                int[] intArrayProp = testClass1.GetProperty<int[]>("IntArrayProp");
                string[] stringArrayProp = testClass1.GetProperty<string[]>("StringArrayProp");
                ITestClass2 testClass22 = testClass1.GetProperty<ITestClass2>("TestClass2");
                int? nullableIntProp = testClass22.GetProperty<int?>("NullableIntProp");
                DateTime? nullableDateTimeProp = testClass22.GetProperty<DateTime?>("NullableDateTimeProp");
                long? nullableLongProp = testClass22.GetProperty<long?>("NullableLongProp");
            }
            dpaSw.Stop();

            //Reflection Performance Test
            testClass1 = new TestClass1();
            testClass2 = new TestClass2();
            Stopwatch normalReflectionSw = Stopwatch.StartNew();
            Type testClassType1 = typeof(TestClass1);
            Type testClassType2 = typeof(TestClass2);
            for (int i = 0; i < executeNumberOfTimes; i++)
            {
                testClassType1.GetProperty("StringProp").SetValue(testClass1, "StringProp");
                testClassType1.GetProperty("ShortProp").SetValue(testClass1, (short)1);
                testClassType1.GetProperty("IntProp").SetValue(testClass1, 67);
                testClassType1.GetProperty("LongProp").SetValue(testClass1, 1000000000000000);
                testClassType1.GetProperty("FloatProp").SetValue(testClass1, 23.45f);
                testClassType1.GetProperty("DecimalProp").SetValue(testClass1, 99.45m);
                testClassType1.GetProperty("DateTimeProp").SetValue(testClass1, DateTime.Now);
                testClassType1.GetProperty("CharProp").SetValue(testClass1, 'c');
                testClassType1.GetProperty("ByteProp").SetValue(testClass1, (byte)1);
                testClassType1.GetProperty("IntArrayProp").SetValue(testClass1, intArrayValue);
                testClassType1.GetProperty("StringArrayProp").SetValue(testClass1, stringArrayValue);
                testClassType2.GetProperty("NullableIntProp").SetValue(testClass2, 23);
                testClassType2.GetProperty("NullableDateTimeProp").SetValue(testClass2, dateTime);
                testClassType2.GetProperty("NullableLongProp").SetValue(testClass2, 1000000000000000);
                testClassType1.GetProperty("TestClass2").SetValue(testClass1, testClass2);

                string stringProp = testClassType1.GetProperty("StringProp").GetValue(testClass1) as string;
                short shortProp = (short)testClassType1.GetProperty("ShortProp").GetValue(testClass1);
                int intProp = (int)testClassType1.GetProperty("IntProp").GetValue(testClass1);
                long longProp = (long)testClassType1.GetProperty("LongProp").GetValue(testClass1);
                float floatProp = (float)testClassType1.GetProperty("FloatProp").GetValue(testClass1);
                decimal decimalProp = (decimal)testClassType1.GetProperty("DecimalProp").GetValue(testClass1);
                DateTime dateTimeProp = (DateTime)testClassType1.GetProperty("DateTimeProp").GetValue(testClass1);
                char charProp = (char)testClassType1.GetProperty("CharProp").GetValue(testClass1);
                byte byteProp = (byte)testClassType1.GetProperty("ByteProp").GetValue(testClass1);
                int[] intArrayProp = (int[])testClassType1.GetProperty("IntArrayProp").GetValue(testClass1);
                string[] stringArrayProp = (string[])testClassType1.GetProperty("StringArrayProp").GetValue(testClass1);
                ITestClass2 testClass22 = (TestClass2)testClassType1.GetProperty("TestClass2").GetValue(testClass1);
                int? nullableIntProp = (int?)testClassType2.GetProperty("NullableIntProp").GetValue(testClass2);
                DateTime? nullableDateTimeProp = (DateTime?)testClassType2.GetProperty("NullableDateTimeProp").GetValue(testClass2);
                long? nullableLongProp = (long?)testClassType2.GetProperty("NullableLongProp").GetValue(testClass2);
            }
            normalReflectionSw.Stop();

            double percentage = (((double)normalReflectionSw.ElapsedMilliseconds / (double)dpaSw.ElapsedMilliseconds) * 100);
            Console.WriteLine();
            Console.WriteLine($"Performance Test Results {executeNumberOfTimes.ToString("#,##0")} iterations");
            Console.WriteLine("===========================================================================");
            Console.WriteLine("Regular Property Access:");
            Console.WriteLine($"\t{regularProperyAccessSW.ElapsedMilliseconds} ms");
            Console.WriteLine("\tBaseline can't get faster than this");
            Console.WriteLine();
            Console.WriteLine("DynamicPropertyAccessor Code:");            
            Console.WriteLine($"\t{dpaSw.ElapsedMilliseconds} ms");
            Console.WriteLine($"\t{percentage.ToString("0.00")}% faster than normal reflection below");
            Console.WriteLine();
            Console.WriteLine("Reflection:");
            Console.WriteLine($"\t{normalReflectionSw.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}
