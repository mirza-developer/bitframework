﻿using System;
using System.Globalization;

namespace Bit.Client.Web.BlazorUI
{
    public static class CalendarExtensions
    {
        public static string GetMonthName(this Calendar calendar, int month)
        {
            if (calendar is GregorianCalendar)
            {
                switch (month)
                {
                    case 1:
                        return "January";
                    case 2:
                        return "February";
                    case 3:
                        return "March";
                    case 4:
                        return "April";
                    case 5:
                        return "May";
                    case 6:
                        return "June";
                    case 7:
                        return "July";
                    case 8:
                        return "August";
                    case 9:
                        return "September";
                    case 10:
                        return "October";
                    case 11:
                        return "November";
                    case 12:
                        return "December";
                }
            }
            if (calendar is PersianCalendar)
            {
                switch (month)
                {
                    case 1:
                        return "Farvardin";
                    case 2:
                        return "Ordibehesht";
                    case 3:
                        return "Khordad";
                    case 4:
                        return "Tir";
                    case 5:
                        return "Mordad";
                    case 6:
                        return "Shahrivar";
                    case 7:
                        return "Mehr";
                    case 8:
                        return "Aban";
                    case 9:
                        return "Azar";
                    case 10:
                        return "Dey";
                    case 11:
                        return "Bahman";
                    case 12:
                        return "Esfand";
                }
            }
            return "";
        }
        public static string GetMonthShortName(this Calendar calendar, int month)
        {
            if (calendar is GregorianCalendar)
            {
                switch (month)
                {
                    case 1:
                        return "Jan";
                    case 2:
                        return "Feb";
                    case 3:
                        return "Mar";
                    case 4:
                        return "Apr";
                    case 5:
                        return "May";
                    case 6:
                        return "Jun";
                    case 7:
                        return "Jul";
                    case 8:
                        return "Aug";
                    case 9:
                        return "Sep";
                    case 10:
                        return "Oct";
                    case 11:
                        return "Nov";
                    case 12:
                        return "Dec";
                }
            }
            if (calendar is PersianCalendar)
            {
                switch (month)
                {
                    case 1:
                        return "Far";
                    case 2:
                        return "Ord";
                    case 3:
                        return "Khr";
                    case 4:
                        return "Tir";
                    case 5:
                        return "Mrd";
                    case 6:
                        return "Shr";
                    case 7:
                        return "Mhr";
                    case 8:
                        return "Abn";
                    case 9:
                        return "Azr";
                    case 10:
                        return "Dey";
                    case 11:
                        return "Bah";
                    case 12:
                        return "Esf";
                }
            }
            return "";
        }

        public static string GetWeekDayName(this Calendar calendar,DayOfWeek dayOfWeek)
        {
            if (calendar is GregorianCalendar)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "Sunday";
                    case DayOfWeek.Monday:
                        return "Monday";
                    case DayOfWeek.Tuesday:
                        return "Tuesday";
                    case DayOfWeek.Wednesday:
                        return "Wednesday";
                    case DayOfWeek.Thursday:
                        return "Thursday";
                    case DayOfWeek.Friday:
                        return "Friday";
                    case DayOfWeek.Saturday:
                        return "Saturday";
                }
            }
            if (calendar is PersianCalendar)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "Yekshanbe";
                    case DayOfWeek.Monday:
                        return "Doshanbe";
                    case DayOfWeek.Tuesday:
                        return "Seshanbe";
                    case DayOfWeek.Wednesday:
                        return "Chaharshanbe";
                    case DayOfWeek.Thursday:
                        return "Panjshanbe";
                    case DayOfWeek.Friday:
                        return "Jome'e";
                    case DayOfWeek.Saturday:
                        return "Shanbe";
                }
            }
            return "";
        }
    }
}
