﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio_Tiaraju.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            DevExpress.XamarinForms.Editors.Initializer.Init();
            InitializeComponent();
        }
       
    }
}