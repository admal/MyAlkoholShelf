using System;

namespace MyAlkoholShelf.Web.FrontEndModels
{
    public class DurationFrontEndModel
    {
        public int Days { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
    }

    public static class TimeSpanExtensions
    {
        public static DurationFrontEndModel ToDuration(this TimeSpan timespane)
        {
            var years = (int)(timespane.Days / 365);
            var months = (timespane.Days - years * 365) / 30;
            var days = timespane.Days - years * 365 - months * 30;

            return new DurationFrontEndModel()
            {
                Days = days,
                Months = months,
                Years = years
            };
        }

        public static TimeSpan ToTimeSpan(this DurationFrontEndModel duration)
        {
            var days = duration.Years * 365 + duration.Months * 30 + duration.Days;
            return new TimeSpan(days, 0, 0, 0);
        }
    }
}