﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStep.Services;
using OnlineStep.ViewModels;
using OnlineStep.Views;
using Xamarin.Forms;

namespace OnlineStep
{
 
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        //This part should probably be handle by a viewmodel
        private void Handle_Clicked_Get_Started(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseView());
        }
    }
}
