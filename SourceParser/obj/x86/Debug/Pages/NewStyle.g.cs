﻿#pragma checksum "C:\Users\KramRul\Documents\GitHub\SourceParser\SourceParser\Pages\NewStyle.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BAADB2805FB8A0A0FD4D478D7CBB7447"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SourceParser.Pages
{
    partial class NewStyle : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\NewStyle.xaml line 16
                {
                    this.Styles = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Pages\NewStyle.xaml line 26
                {
                    this.ButtonAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButtonAdd).Click += this.ButtonAdd_Click;
                }
                break;
            case 4: // Pages\NewStyle.xaml line 195
                {
                    this.ButtonSave = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButtonSave).Click += this.ButtonSave_Click;
                }
                break;
            case 5: // Pages\NewStyle.xaml line 196
                {
                    this.ButtonDelete = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButtonDelete).Click += this.ButtonDelete_Click;
                }
                break;
            case 6: // Pages\NewStyle.xaml line 132
                {
                    this.ListOfPublishUniverTexts = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 7: // Pages\NewStyle.xaml line 145
                {
                    this.ListOfPublishUniverDateParts = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 10: // Pages\NewStyle.xaml line 105
                {
                    this.ListOfPublisherTexts = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 11: // Pages\NewStyle.xaml line 118
                {
                    this.ListOfYearDatePublisherDateParts = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 14: // Pages\NewStyle.xaml line 87
                {
                    this.ListOfWebDockTexts = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 16: // Pages\NewStyle.xaml line 33
                {
                    this.GridOfButtons = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

