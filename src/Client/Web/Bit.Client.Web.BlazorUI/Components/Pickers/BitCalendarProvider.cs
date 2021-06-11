using System;
using System.Collections.Generic;

namespace Bit.Client.Web.BlazorUI
{
    public class BitCalendarProvider
    {
        private List<Month> months = new List<Month>();
        private List<Day> days = new List<Day>();

        public void SetMonth(int monthNumber,string name,int daysCount)
        {
            if (monthNumber < 1 || monthNumber>12)
            {
                throw new Exception($"Invalid month number :{monthNumber}");
            }
            Month? listedMonth = months.Find(property => property.Number.Equals(monthNumber));
            if (listedMonth is null)
            {
                months.Add(new Month()
                {
                    Number = monthNumber,
                    Name = name,
                    DaysCount = daysCount,
                });
            }
            else
            {
                listedMonth.DaysCount = daysCount;
                listedMonth.Name = name;
            }
        }

        public void SetDay(DayOfWeek dayOfWeek, string name)
        {
            Day? listedDay = days.Find(property => property.DayOfWeek.Equals(dayOfWeek));
            if (listedDay is null)
            {
                days.Add(new Day()
                {
                    DayOfWeek = dayOfWeek,
                    Name = name
                });
            }
            else
            {
                listedDay.DayOfWeek = dayOfWeek;
                listedDay.Name = name;
            }
        }

        public void GetMonth(int number)
        {
            
        }

        public virtual bool CheckYearIsLeap()
        {
            return false;
        }

        public virtual bool CheckMonthIsLeap(int monthNumber)
        {
            return false;
        }

    }
}
