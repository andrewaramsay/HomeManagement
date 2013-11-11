using System;
using System.ComponentModel.DataAnnotations;
using HomeManagement.Domain;

namespace HomeManagementMobile.Models
{
    public class PumpingViewModel
    {
        public PumpingViewModel()
        {

        }

        public PumpingViewModel(Pumping pumping)
        {
            Id = pumping.Id;
            Milliliters = pumping.Milliliters;
            StartTime = pumping.StartTime;
            EndTime = pumping.EndTime;
            BreastfeedingAttempt = pumping.BreastfeedingAttempt;
            BreastfeedingComments = pumping.BreastfeedingComments;
        }

        public Pumping ToPumping()
        {
            return new Pumping
            {
                Id = this.Id,
                Milliliters = this.Milliliters,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                BreastfeedingAttempt = this.BreastfeedingAttempt,
                BreastfeedingComments = this.BreastfeedingComments
            };
        }

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss.fffffffzzz}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss.fffffffzzz}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

        public int? Milliliters { get; set; }
        public bool? BreastfeedingAttempt { get; set; }
        public string BreastfeedingComments { get; set; }
        public decimal? FormulaAmount { get { return Milliliters / 80m * 2.5m; } }
    }
}