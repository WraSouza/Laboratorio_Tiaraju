﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio_Tiaraju.View.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingRoomBookView : ContentPage
    {
       
        public MeetingRoomBookView()
        {
            InitializeComponent();

            datePicker.Date = DateTime.Now;
           
        }        
        
    }
}