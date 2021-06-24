using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bit.Client.Web.BlazorUI
{
    public partial class BitDatePicker
    {
        private bool isOpen;
        private Calendar calendar;
        private int[,] monthWeeks = new int[6, 7];

        [Parameter]
        public bool IsOpen
        {
            get => isOpen;
            set
            {
                isOpen = value;
                ClassBuilder.Reset();
            }
        }

        [Parameter] public string GoToToday { get; set; } = "Go to today";
        [Parameter] public CalendarType CalendarType { get; set; } = CalendarType.Gregorian;

        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
        [Parameter] public EventCallback<FocusEventArgs> OnFocusIn { get; set; }
        [Parameter] public EventCallback<FocusEventArgs> OnFocusOut { get; set; }

        protected override string RootElementClass { get; } = "bit-dtp";

        protected override void RegisterComponentClasses()
        {
            ClassBuilder.Register(() => IsEnabled is false
                ? $"{RootElementClass}-disabled-{VisualClassRegistrar()}" : string.Empty);

            ClassBuilder.Register(() => IsOpen is false
                ? $"{RootElementClass}-open-{VisualClassRegistrar()}" : string.Empty);
        }

        protected async override Task OnInitializedAsync()
        {
            if (CalendarType == CalendarType.Gregorian)
            {
                calendar = new GregorianCalendar();
            }
            else if (CalendarType == CalendarType.Persian)
            {
                calendar = new PersianCalendar();
            }
            CreateMonthCalendar();
        }

        public async Task HandleClick(MouseEventArgs eventArgs)
        {
            IsOpen = true;
            await OnClick.InvokeAsync(eventArgs);
        }
        public async Task HandleFocusIn(FocusEventArgs eventArgs)
        {
            await OnFocusIn.InvokeAsync(eventArgs);
        }
        public async Task HandleFocusOut(FocusEventArgs eventArgs)
        {
            //   IsOpen = false;
            await OnFocusOut.InvokeAsync(eventArgs);
        }

        private void CreateMonthCalendar()
        {
            var month = calendar.GetMonth(DateTime.Now);
            var year = calendar.GetYear(DateTime.Now);
            CreateMonthCalendar(year, month);
        }

        private void CreateMonthCalendar(int year, int month)
        {
            var daysCount = calendar.GetDaysInMonth(year, month);
            var firstDay = calendar.ToDateTime(year, month, 1, 0, 0, 0, 0);
            var currentDay = 1;
            var dayOfWeekDifference = CalendarType == CalendarType.Persian ? -1 : 0;
            for (int weekIndex = 0; weekIndex < monthWeeks.GetLength(0); weekIndex++)
            {
                for (int dayIndex = 0; dayIndex < monthWeeks.GetLength(1) && currentDay <= daysCount ; dayIndex++)
                {
                    if ((weekIndex == 0 
                         && currentDay == 1 
                         && (int)firstDay.DayOfWeek == dayIndex + dayOfWeekDifference) 
                        || currentDay != 1)
                    {
                        monthWeeks[weekIndex, dayIndex] = currentDay;
                        currentDay++;
                    }
                }
            }
        }
    }
}
