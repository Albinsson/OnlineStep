﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Text;
using System.Threading;
using OnlineStep.Annotations;
using OnlineStep.Helpers;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Views;
using Xamarin.Forms;
using Page = OnlineStep.Models.Page;

namespace OnlineStep.ViewModels
{
    class PageViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;

        protected PageViewModel(INavigator navigator)
        {
            Debug.WriteLine("PageViewModel Constructor: ");
            _navigator = navigator;
        }

        }
    }

