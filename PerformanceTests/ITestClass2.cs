using System;

namespace PerformanceTests
{
    public interface ITestClass2
    {
        DateTime? NullableDateTimeProp { get; set; }
        int? NullableIntProp { get; set; }
        long? NullableLongProp { get; set; }
    }
}