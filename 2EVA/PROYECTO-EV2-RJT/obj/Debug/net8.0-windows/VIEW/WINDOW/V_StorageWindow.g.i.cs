﻿#pragma checksum "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68B38B089820B12575A591F3D20141BCA4D9F7FA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PROYECTO_EV2_RJT;
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


namespace PROYECTO_EV2_RJT.VIEW {
    
    
    /// <summary>
    /// V_StorageWindow
    /// </summary>
    public partial class V_StorageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Title;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStorage;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock infoTextStorage;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddOrModify;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PROYECTO-EV2-RJT;component/view/window/v_storagewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
            ((PROYECTO_EV2_RJT.VIEW.V_StorageWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.AddModifyStorage_CanExecute);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddModifyStorage_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtStorage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.infoTextStorage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.BtnAddOrModify = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.BtnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\..\VIEW\WINDOW\V_StorageWindow.xaml"
            this.BtnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
