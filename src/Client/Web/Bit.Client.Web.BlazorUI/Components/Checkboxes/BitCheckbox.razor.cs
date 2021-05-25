﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Bit.Client.Web.BlazorUI
{
    public partial class BitCheckbox
    {
        private bool isIndeterminate;
        private BoxSide boxSide;
        private bool isChecked;

        public ElementReference CheckboxElement { get; set; }

        [Inject] public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                if (value == isChecked) return;
                isChecked = value;
                ClassBuilder.Reset();
                _ = IsCheckedChanged.InvokeAsync(value);
            }
        }

        [Parameter] public EventCallback<bool> IsCheckedChanged { get; set; }

        [Parameter]
        public BoxSide BoxSide
        {
            get => boxSide;
            set
            {
                if (value == boxSide) return;
                boxSide = value;
                ClassBuilder.Reset();
            }
        }

        [Parameter]
        public bool IsIndeterminate
        {
            get => isIndeterminate;
            set
            {
                if (value == isIndeterminate) return;
                isIndeterminate = value;
                _ = JSRuntime.SetProperty(CheckboxElement, "indeterminate", value);
                ClassBuilder.Reset();
                _ = IsIndeterminateChanged.InvokeAsync(value);
            }
        }

        [Parameter] public EventCallback<bool> IsIndeterminateChanged { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public EventCallback<bool> OnChange { get; set; }

        protected override string RootElementClass => "bit-chb";

        protected override void RegisterComponentClasses()
        {
            ClassBuilder.Register(() => IsIndeterminate ? $"{RootElementClass}-indeterminate-{VisualClassRegistrar()}" : string.Empty);
            ClassBuilder.Register(() => IsChecked ? $"{RootElementClass}-checked-{VisualClassRegistrar()}" : string.Empty);

            ClassBuilder.Register(() => BoxSide == BoxSide.End
                                        ? $"{RootElementClass}-end-{VisualClassRegistrar()}"
                                        : string.Empty);

            ClassBuilder.Register(() => IsEnabled is false && IsChecked
                                        ? $"{RootElementClass}-checked-disabled-{VisualClassRegistrar()}"
                                        : string.Empty);

            ClassBuilder.Register(() => IsEnabled is false && IsIndeterminate
                                        ? $"{RootElementClass}-indeterminate-disabled-{VisualClassRegistrar()}"
                                        : string.Empty);
        }

        protected async Task HandleCheckboxClick(MouseEventArgs e)
        {
            if (IsEnabled is false) return;

            if (IsIndeterminate)
            {
                if (IsIndeterminateChanged.HasDelegate is false) return;
                IsIndeterminate = false;
            }
            else
            {
                if (IsCheckedChanged.HasDelegate is false) return;
                IsChecked = !IsChecked;
            }

            await OnChange.InvokeAsync(IsChecked);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.SetProperty(CheckboxElement, "indeterminate", IsIndeterminate);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
