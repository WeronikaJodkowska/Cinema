﻿#pragma checksum "..\..\InsertSession.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04D8FF54979DC57E2D584F58CE53B46E6BC94FAD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Cinema_Administrator;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Cinema_Administrator {
    
    
    /// <summary>
    /// InsertSession
    /// </summary>
    public partial class InsertSession : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\InsertSession.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Movie;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\InsertSession.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cinema;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\InsertSession.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Hall;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\InsertSession.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\InsertSession.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Cost;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\InsertSession.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Time;
        
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
            System.Uri resourceLocater = new System.Uri("/Cinema_Administrator;component/insertsession.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InsertSession.xaml"
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
            this.Movie = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.Cinema = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Hall = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.Cost = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Time = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 36 "..\..\InsertSession.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Session);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 37 "..\..\InsertSession.xaml"
            ((MaterialDesignThemes.Wpf.PackIcon)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PackIcon_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
