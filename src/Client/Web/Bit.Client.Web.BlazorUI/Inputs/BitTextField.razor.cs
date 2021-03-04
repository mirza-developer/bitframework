﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bit.Client.Web.BlazorUI.Inputs
{
    public partial class BitTextField
    {
        [Parameter] public string Value { get; set; }
        [Parameter] public string Placeholder { get; set; }
        [Parameter] public bool IsReadonly { get; set; } = false;
        public string ReadonlyClass => IsReadonly ? "no-text-select" : "";
        public string BorderClass { get; set; } = "";
        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (ParameterValue parameter in parameters)
            {
                switch (parameter.Name)
                {
                    case nameof(Value):
                        Value = (string)parameter.Value;
                        break;
                    case nameof(Placeholder):
                        Placeholder = (string)parameter.Value;
                        break;
                }
            }
            return base.SetParametersAsync(parameters);
        }
       private async Task OnFocusIn(FocusEventArgs e)
       {
           BorderClass = "x";
       }
       private async Task OnFocusOut(FocusEventArgs e)
       {
           BorderClass = "";
       }

    }
}