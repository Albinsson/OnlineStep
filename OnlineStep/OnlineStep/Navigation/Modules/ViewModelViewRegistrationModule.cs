﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using OnlineStep.ViewModels;
using OnlineStep.Views;

namespace OnlineStep.Navigation.Modules
{
    public class ViewModelViewRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainView>().SingleInstance();
            builder.RegisterType<MainViewModel>().SingleInstance();

            builder.RegisterType<CourseView>();
            builder.RegisterType<CourseViewModel>();

            builder.RegisterType<ChapterView>();
            builder.RegisterType<ChapterViewModel>();

            builder.RegisterType<McqView>();
            builder.RegisterType<McqViewModel>();

            builder.RegisterType<ClozeView>();
            builder.RegisterType<ClozeViewModel>();

            builder.RegisterType<Testing>();
            builder.RegisterType<TestingViewModel>();

            builder.RegisterType<TestingChapter>();
            builder.RegisterType<TestingChapterViewModel>();
        }
    }
}
