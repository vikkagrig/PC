﻿#pragma checksum "..\..\Spiski.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DACA84823AEB2F5B7AD9CC33F56FECDAD88469BEA406C419340810A18E1C62F2"
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
using Приемная_комиссия;


namespace Приемная_комиссия {
    
    
    /// <summary>
    /// Spiski
    /// </summary>
    public partial class Spiski : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 71 "..\..\Spiski.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox inst;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\Spiski.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox spec;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Spiski.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox form;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\Spiski.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock num;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\Spiski.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\Spiski.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid table;
        
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
            System.Uri resourceLocater = new System.Uri("/Приемная_комиссия;component/spiski.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Spiski.xaml"
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
            
            #line 62 "..\..\Spiski.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.inst = ((System.Windows.Controls.ComboBox)(target));
            
            #line 71 "..\..\Spiski.xaml"
            this.inst.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.inst_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.spec = ((System.Windows.Controls.ComboBox)(target));
            
            #line 75 "..\..\Spiski.xaml"
            this.spec.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.spec_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.form = ((System.Windows.Controls.ComboBox)(target));
            
            #line 79 "..\..\Spiski.xaml"
            this.form.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.for_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.num = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.table = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

