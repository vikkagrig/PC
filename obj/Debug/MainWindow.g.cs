﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "29373BC51BC9324C96E90D0BD2B52D75E1C15E2B52A09AC082CDEE1891743C5C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Приемная_комиссия {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox log;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pas1;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pas;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image im1;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image im2;
        
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
            System.Uri resourceLocater = new System.Uri("/Приемная_комиссия;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            
            #line 58 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.log = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\MainWindow.xaml"
            this.log.GotFocus += new System.Windows.RoutedEventHandler(this.log_GotFocus);
            
            #line default
            #line hidden
            
            #line 66 "..\..\MainWindow.xaml"
            this.log.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.log_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 66 "..\..\MainWindow.xaml"
            this.log.LostFocus += new System.Windows.RoutedEventHandler(this.log_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.pas1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\MainWindow.xaml"
            this.pas1.GotFocus += new System.Windows.RoutedEventHandler(this.pas1_GotFocus);
            
            #line default
            #line hidden
            
            #line 68 "..\..\MainWindow.xaml"
            this.pas1.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.log_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pas = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 69 "..\..\MainWindow.xaml"
            this.pas.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.log_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.im1 = ((System.Windows.Controls.Image)(target));
            
            #line 70 "..\..\MainWindow.xaml"
            this.im1.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.im2 = ((System.Windows.Controls.Image)(target));
            
            #line 71 "..\..\MainWindow.xaml"
            this.im2.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 74 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 75 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

