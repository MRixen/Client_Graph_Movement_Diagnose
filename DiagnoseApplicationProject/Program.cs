﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{

    static class Program
    { 
        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           var formMain = new FormDatabase();
            formMain.startApplication();
            formMain.Show();
            
            Application.Run();
        }
    }
}
