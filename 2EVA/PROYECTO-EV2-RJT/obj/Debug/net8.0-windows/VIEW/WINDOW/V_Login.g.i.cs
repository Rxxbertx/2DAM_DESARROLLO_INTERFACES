﻿#pragma checksum "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1A3E01566472C78B8972C4AB6BB7CB7DD1D073EA"
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
using PROYECTO_EV2_RJT.CORE;
using PROYECTO_EV2_RJT.VIEWMODEL;
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
    /// V_Login
    /// </summary>
    public partial class V_Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PROYECTO_EV2_RJT.VIEW.V_Login window;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimize;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button maximize;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox username;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock loginResultTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/PROYECTO-EV2-RJT;component/view/window/v_login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.window = ((PROYECTO_EV2_RJT.VIEW.V_Login)(target));
            return;
            case 2:
            
            #line 17 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Login_Command_Executed);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Login_Command_CanExecute);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 39 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.minimize = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
            this.minimize.Click += new System.Windows.RoutedEventHandler(this.Control_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.maximize = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
            this.maximize.Click += new System.Windows.RoutedEventHandler(this.Control_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.exit = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\..\VIEW\WINDOW\V_Login.xaml"
            this.exit.Click += new System.Windows.RoutedEventHandler(this.Control_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.loginResultTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

