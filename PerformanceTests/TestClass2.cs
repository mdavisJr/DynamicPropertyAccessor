using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests
{
    public class TestClass2 : ITestClass2
    {
        public int? NullableIntProp { get; set; }
        public DateTime? NullableDateTimeProp { get; set; }
        public long? NullableLongProp { get; set; }
    }
}
