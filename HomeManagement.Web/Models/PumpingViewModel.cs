using System;
using System.ComponentModel.DataAnnotations;
using HomeManagement.Domain;

namespace HomeManagement.Web.Models
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
            FortifyTime = pumping.FortifyTime;
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
                BreastfeedingComments = this.BreastfeedingComments,
                FortifyTime = this.FortifyTime
            };
        }

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FortifyTime { get; set; }

        public string Duration
        {
            get
            {
                if (EndTime == null)
                    return null;

                var duration = EndTime.Value.Subtract(StartTime);


                return string.Format("{0} mins", (int)duration.TotalMinutes);
            }
        }

        public int? Milliliters { get; set; }
        public bool? BreastfeedingAttempt { get; set; }
        public string BreastfeedingComments { get; set; }
        public decimal? FormulaAmount { get { return Milliliters / 80m * 2.5m; } }
    }
}