namespace PerformanceSurf.Counters
{
    using System.Collections.Generic;
    using System.Linq;

    public class PerfCounterService
    {
        private List<PerfCounterWrapper> counters;

        public PerfCounterService()
        {
            this.counters = new List<PerfCounterWrapper>();
            this.counters.Add(new PerfCounterWrapper("Processor", "Processor", "% Processor Time", "_Total"));
            this.counters.Add(new PerfCounterWrapper("Paging", "Memory", "Memory", "Pages/sec"));
            this.counters.Add(new PerfCounterWrapper("Disk", "PhysicalDisk", "% Disk Time", "_Total"));
        }

        public dynamic GetResults()
        {
            return this.counters.Select(c => new { name = c.Name, value = c.Value });
        }
    }
}