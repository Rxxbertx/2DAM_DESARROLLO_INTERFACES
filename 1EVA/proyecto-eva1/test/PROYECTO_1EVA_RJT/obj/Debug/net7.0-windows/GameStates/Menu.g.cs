﻿#pragma checksum "..\..\..\..\GameStates\Menu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AE79395A1E7739F6766C5B72B7BB5BA948849848"
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
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\GameStates\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas ventanaPrinicipal;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\GameStates\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image jugar;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\GameStates\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image salirX;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\GameStates\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ayuda;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\GameStates\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image salir;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\GameStates\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Settings;
        
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
            System.Uri resourceLocater = new System.Uri("/PROYECTO_1EVA_RJT;component/gamestates/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GameStates\Menu.xaml"
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
            this.ventanaPrinicipal = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.jugar = ((System.Windows.Controls.Image)(target));
            
            #line 24 "..\..\..\..\GameStates\Menu.xaml"
            this.jugar.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Jugar_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\..\GameStates\Menu.xaml"
            this.jugar.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Jugar_MouseEnter);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\..\GameStates\Menu.xaml"
            this.jugar.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Jugar_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.salirX = ((System.Windows.Controls.Image)(target));
            
            #line 26 "..\..\..\..\GameStates\Menu.xaml"
            this.salirX.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Salir_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\GameStates\Menu.xaml"
            this.salirX.MouseEnter += new System.Windows.Input.MouseEventHandler(this.SalirX_MouseEnter);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\GameStates\Menu.xaml"
            this.salirX.MouseLeave += new System.Windows.Input.MouseEventHandler(this.SalirX_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ayuda = ((System.Windows.Controls.Image)(target));
            
            #line 27 "..\..\..\..\GameStates\Menu.xaml"
            this.ayuda.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ayuda_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\..\GameStates\Menu.xaml"
            this.ayuda.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Ayuda_MouseEnter);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\..\GameStates\Menu.xaml"
            this.ayuda.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Ayuda_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.salir = ((System.Windows.Controls.Image)(target));
            
            #line 39 "..\..\..\..\GameStates\Menu.xaml"
            this.salir.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Salir_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\..\GameStates\Menu.xaml"
            this.salir.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Salir_MouseEnter);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\..\GameStates\Menu.xaml"
            this.salir.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Salir_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Settings = ((System.Windows.Controls.Image)(target));
            
            #line 40 "..\..\..\..\GameStates\Menu.xaml"
            this.Settings.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Settings_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\..\GameStates\Menu.xaml"
            this.Settings.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Settings_MouseEnter);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\..\GameStates\Menu.xaml"
            this.Settings.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Settings_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 41 "..\..\..\..\GameStates\Menu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Jugar_MouseEnter);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\GameStates\Menu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Jugar_MouseLeave);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\GameStates\Menu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Jugar_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 42 "..\..\..\..\GameStates\Menu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Salir_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\GameStates\Menu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Salir_MouseEnter);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\GameStates\Menu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Salir_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

