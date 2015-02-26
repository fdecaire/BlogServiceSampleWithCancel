﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BlogServiceSampleCore;

namespace BlogServiceSample
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartingClass.Instance.Start();
        }

        protected override void OnStop()
        {
            StartingClass.Instance.Stop();
        }
    }
}