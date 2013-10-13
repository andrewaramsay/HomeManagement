using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HomeManagement.Domain
{
    public class Pumping
    {
        public virtual int Id { get; set; }
        public virtual int? Milliliters { get; set; }
        public virtual bool? BreastfeedingAttempt { get; set; }
        public virtual string BreastfeedingComments { get; set; }
        public virtual ICollection<PumpingTime> PumpingTimes { get; set; }
    }

    public class PumpingTime
    {
        public virtual int Id { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime? EndTime { get; set; }

        public virtual int PumpingId { get; set; }
        public virtual Pumping Pumping { get; set; }
    }
}