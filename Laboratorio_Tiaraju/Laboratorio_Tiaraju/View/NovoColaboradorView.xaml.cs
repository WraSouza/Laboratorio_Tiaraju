﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio_Tiaraju.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoColaboradorView : ContentPage
    {
        public NovoColaboradorView()
        {
            DevExpress.XamarinForms.Editors.Initializer.Init();
            InitializeComponent();
            this.BindingContext = new List<string>() { "COMERCIAL", "COMPRAS", "CQ", "GQ", "PRODUÇÃO", "RH", "TI" };
        }
    }
}