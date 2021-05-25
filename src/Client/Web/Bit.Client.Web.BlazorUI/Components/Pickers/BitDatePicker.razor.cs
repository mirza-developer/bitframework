using Microsoft.AspNetCore.Components;

namespace Bit.Client.Web.BlazorUI
{
    public partial class BitDatePicker
    {
        [Parameter] public bool IsOpen { get; set; } = false;

        protected override string RootElementClass { get; } = "bit-dtp";

        protected override void RegisterComponentClasses()
        {
            ClassBuilder.Register(() => IsEnabled is false
                ? $"{RootElementClass}-disabled-{VisualClassRegistrar()}" : string.Empty);

            ClassBuilder.Register(() => IsOpen is false
                ? $"{RootElementClass}-open-{VisualClassRegistrar()}" : string.Empty);
        }
    }
}
