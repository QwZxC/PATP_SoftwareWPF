﻿#pragma checksum "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B508CC6AF159E8EFA95D88591EADFA965EE1AC28"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PAPT_SoftwareWPF.Windows.Pages;
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


namespace PAPT_SoftwareWPF.Windows.Pages {
    
    
    /// <summary>
    /// HRDepartamentPage
    /// </summary>
    public partial class HRDepartamentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 11 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HRDepartamentGrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid employmentsDataTable;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu membersDataTableContextMenu;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addEmploymentMenuItem;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem deleteEmploymentMenuItem;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PAPT_SoftwareWPF;component/windows/pages/hrdepartamentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.HRDepartamentGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.employmentsDataTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 40 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
            this.employmentsDataTable.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.employmentsDataTable_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.membersDataTableContextMenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 5:
            this.addEmploymentMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 116 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
            this.addEmploymentMenuItem.Click += new System.Windows.RoutedEventHandler(this.addEmploymentMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.deleteEmploymentMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 119 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
            this.deleteEmploymentMenuItem.Click += new System.Windows.RoutedEventHandler(this.deleteEmploymentMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 227 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 231 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 94 "..\..\..\..\..\Windows\Pages\HRDepartamentPage.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.departmentsComboBox_SelectionChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

