﻿#pragma checksum "..\..\..\..\wins\winAciklamaEkle.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3A1EDCD288BACC4332F1DEAFCDC5AB04BB4ECC35"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ExtremeTaleplerV2.wins;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace ExtremeTaleplerV2.wins {
    
    
    /// <summary>
    /// winAciklamaEkle
    /// </summary>
    public partial class winAciklamaEkle : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\wins\winAciklamaEkle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpGorusmeTarihi;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\wins\winAciklamaEkle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label x;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\wins\winAciklamaEkle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGorusmeNotu;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\wins\winAciklamaEkle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNot1;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\wins\winAciklamaEkle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNot2;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\wins\winAciklamaEkle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNot3;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\wins\winAciklamaEkle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAciklamaEkle;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ExtremeTaleplerV2;component/wins/winaciklamaekle.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\wins\winAciklamaEkle.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\wins\winAciklamaEkle.xaml"
            ((ExtremeTaleplerV2.wins.winAciklamaEkle)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dpGorusmeTarihi = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.x = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtGorusmeNotu = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtNot1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtNot2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtNot3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnAciklamaEkle = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\wins\winAciklamaEkle.xaml"
            this.btnAciklamaEkle.Click += new System.Windows.RoutedEventHandler(this.btnAciklamaEkle_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

