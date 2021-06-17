﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Web;

namespace Bit.Client.Web.BlazorUI.Playground.Web.Pages
{
    public partial class Component
    {
        private bool CheckBoxOnChangedValue= false;
        private bool IsCheckBoxChecked = false;
        private bool IsCheckBoxIndeterminate = true;
        private bool IsCheckBoxIndeterminateInCode = true;
        private bool IsToggleChecked = true;
        private bool IsToggleUnChecked = false;

        private bool IsMessageBarHidden = false;
        private TextFieldType InputType = TextFieldType.Password;

        private int RatingBoundValue = 2;
        private int RatingLargeValue = 3;
        private int RatingSmallValue = 4;
        private int RatingReadOnlyValue = 5;
        private int RatingOutsideValue = 5;

        private readonly List<NavLink> BasicNavLinks = new()
        {
            new NavLink
            {
                Name = "Home",
                Url = "http://example.com",
                Key = "key1",
                Title = "Home",
                Target = "_blank",
                IsExpanded = true,
                CollapseAriaLabel = "Collapse Home section",
                Links = new List<NavLink>
                        {
                            new NavLink{
                                Name= "Activity",
                                Url= "http://msn.com",
                                Key= "key1-1",
                                Title="Activity",
                                Links=new List<NavLink>
                                {
                                    new NavLink{ Name= "Activity",Title= "Activity",Url= "http://msn.com",Key= "key1-1-1"},
                                    new NavLink{ Name= "MSN",Title= "MSN", Url= "http://msn.com", Key= "key1-1-2",Disabled=true}
                                }
                            },
                            new NavLink{Name= "MSN",Title="MSN", Url= "http://msn.com", Key= "key1-2",Disabled=true },
                        }
            },
            new NavLink { Name = "Documents", Title = "Documents", Url = "http://example.com", Key = "key2", Target = "_blank", IsExpanded = true },
            new NavLink { Name = "Pages", Title = "Pages", Url = "http://msn.com", Key = "key3", Target = "_parent" },
            new NavLink { Name = "Notebook", Title = "Notebook", Url = "http://msn.com", Key = "key4", Disabled = true },
            new NavLink { Name = "Communication and Media", Title = "Communication and Media", Url = "http://msn.com", Key = "key5", Target = "_top" },
            new NavLink { Name = "News", Title = "News", Url = "http://msn.com", Key = "key6", Icon = "News", Target = "_self" },
        };

        private readonly List<NavLink> BasicNoToolTipNavLinks = new()
        {
            new NavLink
            {
                Name = "Home",
                Url = "http://example.com",
                Key = "key1",
                Target = "_blank",
                IsExpanded = true,
                CollapseAriaLabel = "Collapse Home section",
                Links = new List<NavLink>
                        {
                            new NavLink{
                                Name= "Activity",
                                Url= "http://msn.com",
                                Key= "key1-1",
                                Links=new List<NavLink>
                                {
                                    new NavLink{Name= "Activity",Url= "http://msn.com",Key= "key1-1-1" },
                                    new NavLink{Name= "MSN", Url= "http://msn.com", Key= "key1-1-2",Disabled=true }
                                } },
                            new NavLink{Name= "MSN", Url= "http://msn.com", Key= "key1-2",Disabled=true },
                        }
            },
            new NavLink { Name = "Shared Documents and Files", Url = "http://example.com", Key = "key2", Target = "_blank", IsExpanded = true },
            new NavLink { Name = "Pages", Url = "http://msn.com", Key = "key3", Target = "_parent" },
            new NavLink { Name = "Notebook", Url = "http://msn.com", Key = "key4", Disabled = true },
            new NavLink { Name = "Communication and Media", Url = "http://msn.com", Key = "key5", Target = "_top" },
            new NavLink { Name = "News", Url = "http://msn.com", Key = "key6", Icon = "News", Target = "_self" },
        };

        private readonly List<NavLink> BasicNoUrlNavLinks = new()
        {
            new NavLink
            {
                Name = "Basic components",
                Key = "Key1",
                CollapseAriaLabel = "Collapse Basic components section",
                IsExpanded = true,
                Links = new List<NavLink>
                        {
                            new NavLink{Name= "ActivityItem", Key= "ActivityItem",Url="#/examples/activityitem" },
                            new NavLink{Name= "Breadcrumb", Key= "Breadcrumb",Url="#/examples/breadcrumb" },
                            new NavLink{Name= "Button", Key= "Button",Url="#/examples/button" }
                        }
            },
            new NavLink
            {
                Name = "Extended components",
                Key = "Key2",
                CollapseAriaLabel = "Collapse Extended components section",
                IsExpanded = true,
                Links = new List<NavLink>
                        {
                            new NavLink{Name= "ColorPicker", Key= "ColorPicker",Url="#/examples/colorpicker" },
                            new NavLink{Name= "ExtendedPeoplePicker", Key= "ExtendedPeoplePicker",Url="#/examples/extendedpeoplepicker" },
                            new NavLink{Name= "GroupedList", Key= "GroupedList",Url="#/examples/groupedlist" }
                        }
            },
            new NavLink
            {
                Name = "Utilities",
                Key = "Key3",
                CollapseAriaLabel = "Collapse Utilities section",
                IsExpanded = true,
                Links = new List<NavLink>
                        {
                            new NavLink{Name= "FocusTrapZone", Key= "FocusTrapZone",Url="#/examples/focustrapzone" },
                            new NavLink{Name= "FocusZone", Key= "FocusZone",Url="#/examples/focuszone" },
                            new NavLink{Name= "MarqueeSelection", Key= "MarqueeSelection",Url="#/examples/marqueeselection" }
                        }
            },
        };

        private readonly List<NavLink> NestedLinks = new()
        {
            new NavLink
            {
                Name = "Parent link 1",
                Url = "http://example.com",
                Key = "Key1",
                Title = "Parent link 1",
                CollapseAriaLabel = "Collapse Parent link 1",
                Links = new List<NavLink>
                {
                    new NavLink
                    {
                        Name= "Child link 1",
                        Url= "http://msn.com",
                        Key= "Key1-1",
                        Title="Child link 1",
                        Links=new List<NavLink>
                        {
                            new NavLink{Name= "3rd level link 1",Title="3rd level link 1",Url= "http://msn.com",Key= "Key1-1-1" },
                            new NavLink{Name= "3rd level link 2",Title="3rd level link 2", Url= "http://msn.com", Key= "Key1-1-2",Disabled=true }
                        }
                    },
                    new NavLink{Name = "Child link 2", Title = "Child link 2", Url = "http://msn.com", Key = "Key1-2" },
                    new NavLink{Name = "Child link 3", Title = "Child link 3", Url = "http://msn.com", Key = "Key1-3", Disabled = true },
                }
            },
            new NavLink
            {
                Name = "Parent link 2",
                Title = "Parent link 2",
                Url = "http://example.com",
                Key = "Key2",
                CollapseAriaLabel = "Collapse Parent link 2",
                Links = new List<NavLink>
                {
                    new NavLink{Name= "Child link 4", Title= "Child link 4", Url= "http://example.com", Key= "Key2-1" }
                }
            }
        };

        private readonly List<NavLink> CustomHeaderLinks = new()
        {
            new NavLink
            {
                Name = "Pages",
                Links = new List<NavLink>
                {
                    new NavLink{Name= "Activity", Url= "http://msn.com", Key= "Key1-1", Title="Activity" },
                    new NavLink{Name= "News",Title="News", Url= "http://msn.com", Key= "Key1-2" },
                }
            },
            new NavLink
            {
                Name = "More pages",
                Links = new List<NavLink>
                {
                    new NavLink{Name= "Settings", Title= "Settings", Url= "http://example.com", Key= "Key2-1" },
                    new NavLink{Name= "Notes", Title= "Notes", Url= "http://example.com", Key= "Key2-1" }
                }
            }
        };

        #region PivotSamples

        public string OverridePivotSelectedKey { get; set; } = "1";
        public string SelectedPivotItemKey { get; set; } = "1";
        public BitPivotItem BitPivotItem { get; set; }
        public ComponentVisibility PivotItemVisibility { get; set; }
        public BitPivotItem SelectedPivotKey { get; set; } = new BitPivotItem { ItemKey = "Foo" };

        public void PivotSelectedKeyChanged(string key)
        {
            OverridePivotSelectedKey = key;
        }

        public void TogglePivotItemVisobility()
        {
            PivotItemVisibility = PivotItemVisibility == ComponentVisibility.Visible ? ComponentVisibility.Collapsed : ComponentVisibility.Visible;
        }

        #endregion 

        private void HideMessageBar(MouseEventArgs args)

        {
            IsMessageBarHidden = true;
        }

        private string RatingChangedText = "";

        private List<DropDownItem> GetDropdownItems()
        {
            List<DropDownItem> items = new();
            items.Add(new DropDownItem()
            {
                ItemType = DropDownItemType.Header,
                Text = "Fruits"
            });
            items.Add(new DropDownItem()
            {
                ItemType = DropDownItemType.Normal,
                Text = "Apple",
                Value = "f-app"
            });
            items.Add(new DropDownItem()
            {
                ItemType = DropDownItemType.Normal,
                Text = "Orange",
                Value = "f-ora",
                IsEnabled = false
            });
            items.Add(new DropDownItem()
            {
                ItemType = DropDownItemType.Normal,
                Text = "Banana",
                Value = "f-ban",
            });
            items.Add(new DropDownItem()
            {
                ItemType = DropDownItemType.Divider,
            });
            items.Add(new DropDownItem()
            {
                ItemType = DropDownItemType.Header,
                Text = "Vegetables"
            });
            items.Add(new DropDownItem()
            {
                ItemType = DropDownItemType.Normal,
                Text = "Broccoli",
                Value = "v-bro",
            });

            return items;
        }
    }
}
