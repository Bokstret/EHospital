﻿#pragma checksum "..\..\NewDoctorWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4A0B24341093E2F8B9219543CF74BB36FCCFEE492E0FACBF6ADC3381F499F913"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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
using eHospital;


namespace eHospital {
    
    
    /// <summary>
    /// NewDoctorWindow
    /// </summary>
    public partial class NewDoctorWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\NewDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal eHospital.NewDoctorWindow ThisWindow;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\NewDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button extBtn;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\NewDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox docBirthField;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\NewDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox docCabinetField;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\NewDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addNewNurse;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\NewDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addNewDoctor;
        
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
            System.Uri resourceLocater = new System.Uri("/eHospital;component/newdoctorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewDoctorWindow.xaml"
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
            this.ThisWindow = ((eHospital.NewDoctorWindow)(target));
            
            #line 16 "..\..\NewDoctorWindow.xaml"
            this.ThisWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.extBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\NewDoctorWindow.xaml"
            this.extBtn.Click += new System.Windows.RoutedEventHandler(this.extBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.docBirthField = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\NewDoctorWindow.xaml"
            this.docBirthField.LostFocus += new System.Windows.RoutedEventHandler(this.docBirthField_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.docCabinetField = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\NewDoctorWindow.xaml"
            this.docCabinetField.LostFocus += new System.Windows.RoutedEventHandler(this.docCabinetField_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.addNewNurse = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.addNewDoctor = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

