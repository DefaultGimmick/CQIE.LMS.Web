using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LMS.Models
{
    public class ChartSeries
    {
        public string type { get; set; }
        public string name { get; set; }
        public List<int> data { get; set; }
    }

    public class ChartXAxis
    {
        public string type { get; set; }
        public List<string> data { get; set; }
    }

    public class ChartLegend
    {
        public List<string> data { get; set; }

    }
}
