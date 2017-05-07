using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests
{
    public class TestClass1
    {
        public string StringProp { get; set; }
        public short ShortProp { get; set; }
        public int IntProp { get; set; }
        public long LongProp { get; set; }
        public float FloatProp { get; set; }
        public decimal DecimalProp { get; set; }
        public double DoubleProp { get; set; }
        public DateTime DateTimeProp { get; set; }
        public char CharProp { get; set; }
        public byte ByteProp { get; set; }
        public int[] IntArrayProp { get; set; }
        public string[] StringArrayProp { get; set; }
        public ITestClass2 TestClass2 { get; set; }
    }
}
