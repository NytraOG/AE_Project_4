﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E41CB765EFACB053DDF3B84EBC6A311C719041CE6BCB4DBAD36245756A88E7B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekt_4;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Projekt_4 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AddressListBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox byte1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox byte2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox byte3;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox byte4;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox subnet1;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox subnet2;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox subnet3;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox subnet4;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NetworkAddress;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BroadcastAddress;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projekt_4.Frontend;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AddressListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.AddressListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.AddressListBox_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClick_DeleteAddressEntry);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 15 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClick_RefreshList);
            
            #line default
            #line hidden
            return;
            case 4:
            this.byte1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.byte1.LostFocus += new System.Windows.RoutedEventHandler(this.OnLostFocus);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.byte1.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.byte2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.byte2.LostFocus += new System.Windows.RoutedEventHandler(this.OnLostFocus);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.byte2.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.byte3 = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.byte3.LostFocus += new System.Windows.RoutedEventHandler(this.OnLostFocus);
            
            #line default
            #line hidden
            
            #line 21 "..\..\MainWindow.xaml"
            this.byte3.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.byte4 = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.byte4.LostFocus += new System.Windows.RoutedEventHandler(this.OnLostFocus);
            
            #line default
            #line hidden
            
            #line 22 "..\..\MainWindow.xaml"
            this.byte4.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 26 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClick_AddAddress);
            
            #line default
            #line hidden
            return;
            case 9:
            this.subnet1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\MainWindow.xaml"
            this.subnet1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Subnet_OnTextChanged);
            
            #line default
            #line hidden
            
            #line 28 "..\..\MainWindow.xaml"
            this.subnet1.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.subnet2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\MainWindow.xaml"
            this.subnet2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Subnet_OnTextChanged);
            
            #line default
            #line hidden
            
            #line 31 "..\..\MainWindow.xaml"
            this.subnet2.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocus);
            
            #line default
            #line hidden
            return;
            case 11:
            this.subnet3 = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\MainWindow.xaml"
            this.subnet3.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Subnet_OnTextChanged);
            
            #line default
            #line hidden
            
            #line 33 "..\..\MainWindow.xaml"
            this.subnet3.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocus);
            
            #line default
            #line hidden
            return;
            case 12:
            this.subnet4 = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\MainWindow.xaml"
            this.subnet4.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Subnet_OnTextChanged);
            
            #line default
            #line hidden
            
            #line 35 "..\..\MainWindow.xaml"
            this.subnet4.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocus);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 36 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.NetworkAddress = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.BroadcastAddress = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

