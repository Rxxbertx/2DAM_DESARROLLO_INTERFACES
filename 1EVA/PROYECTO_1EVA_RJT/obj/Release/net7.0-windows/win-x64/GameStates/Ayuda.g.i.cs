﻿#pragma checksum "..\..\..\..\..\GameStates\Ayuda.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0503B5A8BD59526B2723A9A738F59547DDB16BAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PROYECTO_1EVA_RJT.GameStates;
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


namespace PROYECTO_1EVA_RJT.GameStates {
    
    
    /// <summary>
    /// Ayuda
    /// </summary>
    public partial class Ayuda : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\..\GameStates\Ayuda.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image salirX;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\GameStates\Ayuda.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock interactuarInfo;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\GameStates\Ayuda.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock interactuarInfo2;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\GameStates\Ayuda.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock interactuarInfo2_Copiar;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\GameStates\Ayuda.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock interactuarInfo_Copiar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PROYECTO_1EVA_RJT;component/gamestates/ayuda.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\GameStates\Ayuda.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.salirX = ((System.Windows.Controls.Image)(target));
            
            #line 17 "..\..\..\..\..\GameStates\Ayuda.xaml"
            this.salirX.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SalirX_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\..\GameStates\Ayuda.xaml"
            this.salirX.MouseEnter += new System.Windows.Input.MouseEventHandler(this.SalirX_MouseEnter);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\..\GameStates\Ayuda.xaml"
            this.salirX.MouseLeave += new System.Windows.Input.MouseEventHandler(this.SalirX_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.interactuarInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.interactuarInfo2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.interactuarInfo2_Copiar = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.interactuarInfo_Copiar = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

