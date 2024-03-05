using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalender.Models
{
    public class RepeatPattern
    {
        public RepeatFrequency Frequency { get; set; }
        public int Interval { get; set; }
        public DateTime? EndDate { get; set; }

    }
    public enum RepeatFrequency
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }
}
