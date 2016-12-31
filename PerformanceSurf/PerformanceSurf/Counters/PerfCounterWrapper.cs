namespace PerformanceSurf.Counters
{
    using System.Diagnostics;

    public class PerfCounterWrapper
    {
        private PerformanceCounter counter;

        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            this.counter = new PerformanceCounter(category, counter, instance, readOnly: true);
            this.Name = name;
        }

        public string Name { get; set; }
        public float Value
        {
            get
            {
                return counter.NextValue();
            }
        }
    }
}