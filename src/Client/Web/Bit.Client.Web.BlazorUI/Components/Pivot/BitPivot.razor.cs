﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Bit.Client.Web.BlazorUI
{
    public partial class BitPivot
    {
        protected override string RootElementClass => "bit-pvt";

        private string? selectedKey;
        private OverflowBehavior overflowBehavior = OverflowBehavior.None;
        private LinkFormat linkFormat = LinkFormat.Links;
        private LinkSize linkSize = LinkSize.Normal;
        private bool hasSetSelectedKey;

        [Parameter]
        public string DefaultSelectedKey { get; set; } = "0";

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public OverflowBehavior OverflowBehavior
        {
            get => overflowBehavior;
            set
            {
                overflowBehavior = value;
                ClassBuilder.Reset();
            }
        }

        [Parameter]
        public LinkFormat LinkFormat
        {
            get => linkFormat;
            set
            {
                linkFormat = value;
                ClassBuilder.Reset();
            }
        }

        [Parameter]
        public LinkSize LinkSize
        {
            get => linkSize;
            set
            {
                linkSize = value;
                ClassBuilder.Reset();
            }
        }

        [Parameter]
        public bool HeadersOnly { get; set; } = false;


        [Parameter]
        public EventCallback<BitPivotItem> OnLinkClick { get; set; }

        [Parameter]
        public string SelectedKey
        {
            get => selectedKey;
            set
            {
                if (value == selectedKey) return;
                selectedKey = value;
                _ = SelectedKeyChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<string> SelectedKeyChanged { get; set; }

        internal IDictionary<string, BitPivotItem> Items = new Dictionary<string, BitPivotItem>();

        protected override void OnInitialized()
        {
            selectedKey = selectedKey ?? DefaultSelectedKey;
            base.OnInitialized();
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (ParameterValue parameter in parameters)
            {
                switch (parameter.Name)
                {
                    case nameof(DefaultSelectedKey):
                        DefaultSelectedKey = (string)parameter.Value;
                        break;

                    case nameof(ChildContent):
                        ChildContent = (RenderFragment)parameter.Value;
                        break;

                    case nameof(OverflowBehavior):
                        OverflowBehavior = (OverflowBehavior)parameter.Value;
                        break;

                    case nameof(LinkFormat):
                        LinkFormat = (LinkFormat)parameter.Value;
                        break;
                    case nameof(LinkSize):
                        LinkSize = (LinkSize)parameter.Value;
                        break;
                    case nameof(HeadersOnly):
                        HeadersOnly = (bool)parameter.Value;
                        break;
                    case nameof(OnLinkClick):
                        OnLinkClick = (EventCallback<BitPivotItem>)parameter.Value;
                        break;
                    case nameof(SelectedKey):
                        SelectedKey = (string)parameter.Value;
                        hasSetSelectedKey = true;
                        break;
                }
            }
            return base.SetParametersAsync(parameters);
        }

        protected override void RegisterComponentClasses()
        {
            ClassBuilder.Register(() => LinkSize == LinkSize.Large ? $"{RootElementClass}-large-{VisualClassRegistrar()}"
                                      : LinkSize == LinkSize.Normal ? $"{RootElementClass}-normal-{VisualClassRegistrar()}"
                                      : string.Empty);

            ClassBuilder.Register(() => LinkFormat == LinkFormat.Links ? $"{RootElementClass}-links-{VisualClassRegistrar()}"
                                      : LinkFormat == LinkFormat.Tabs ? $"{RootElementClass}-tabs-{VisualClassRegistrar()}"
                                      : string.Empty);

            ClassBuilder.Register(() => OverflowBehavior == OverflowBehavior.Menu ? $"{RootElementClass}-menu-{VisualClassRegistrar()}"
                                      : OverflowBehavior == OverflowBehavior.Scroll ? $"{RootElementClass}-scroll-{VisualClassRegistrar()}"
                                      : OverflowBehavior == OverflowBehavior.None ? $"{RootElementClass}-none-{VisualClassRegistrar()}"
                                      : string.Empty);
        }

        internal async Task ItemClicked(KeyValuePair<string, BitPivotItem> item)
        {
            if (item.Value.IsEnabled is false) return;

            await OnLinkClick.InvokeAsync(item.Value);

            if (hasSetSelectedKey && SelectedKeyChanged.HasDelegate is false) return;
            SelectedKey = item.Key;

        }

        internal void RegisterOption(BitPivotItem item)
        {
            if (IsEnabled is false)
            {
                item.IsEnabled = false;
            }

            if (item.ItemKey is null)
            {
                item.ItemKey = GenerateUniqueKey();
            }

            Items.Add(item.ItemKey, item);
            StateHasChanged();
        }

        internal void UnregisterOption(BitPivotItem item)
        {
            Items.Remove(item.ItemKey);
        }

        private string GenerateUniqueKey()
        {
            var key = 0;

            while (Items.Keys.Contains(key.ToString()))
            {
                key++;
            }
            return key.ToString();
        }

        private string GetItemClass(BitPivotItem item)
        {
            return Items[SelectedKey] == item ? "selected-item" : string.Empty;
        }
        private string GetItemStyle(BitPivotItem item)
        {
            return item.Visibility == ComponentVisibility.Collapsed ? "display:none" : item.Visibility == ComponentVisibility.Hidden ? "visibility:hidden" : string.Empty;
        }

        internal void NotifyStateChanged() => StateHasChanged();
    }
}
