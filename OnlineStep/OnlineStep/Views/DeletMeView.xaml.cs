﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineStep.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletMeView : ContentPage
    {
        public DeletMeView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }   
    }
}