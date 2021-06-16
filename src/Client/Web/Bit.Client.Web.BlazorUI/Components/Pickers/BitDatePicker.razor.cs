using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bit.Client.Web.BlazorUI
{
    public partial class BitDatePicker
    {
        private bool isOpen;

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
    }
}
