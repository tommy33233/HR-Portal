﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_PortalInterfaces
{
  public  interface ILogger
    {
        void Info(string message);
        void Info(string format, params object[] args);
        void Info(Exception ex, string message);
        void Info(Exception ex, string format, params object[] args);

        void Error(string message);
        void Error(string format, params object[] args);
        void Error(Exception ex, string message);
        void Error(Exception ex, string format, params object[] args);
    }
}
