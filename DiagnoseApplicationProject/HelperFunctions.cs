﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    class HelperFunctions
    {
        String elementText = "";
        int elementTextInt = 0;

        public void changeElementText(object element, String text)
        {
            if ((element.GetType() == typeof(TextBox)) && ((TextBox)element).InvokeRequired) ((TextBox)element).BeginInvoke((MethodInvoker)delegate() { ((TextBox)element).Text = text; ((TextBox)element).Refresh(); });
            else if ((element.GetType() == typeof(TextBox)))
            {
                ((TextBox)element).Text = text;
                ((TextBox)element).Refresh();
            }

            if ((element.GetType() == typeof(Label)) && ((Label)element).InvokeRequired) ((Label)element).BeginInvoke((MethodInvoker)delegate() { ((Label)element).Text = text; ((Label)element).Refresh(); });
            else if ((element.GetType() == typeof(Label)))
            {
                ((Label)element).Text = text;
                ((Label)element).Refresh();
            }

            if ((element.GetType() == typeof(Button)) && ((Button)element).InvokeRequired) ((Button)element).BeginInvoke((MethodInvoker)delegate() { ((Button)element).Text = text; ((Button)element).Refresh(); });
            else if ((element.GetType() == typeof(Button)))
            {
                ((Button)element).Text = text;
                ((Button)element).Refresh();
            }
        }

        public void changeElementEnabled(object element, bool enabled)
        {
            if ((element.GetType() == typeof(TextBox)) && ((TextBox)element).InvokeRequired) ((TextBox)element).BeginInvoke((MethodInvoker)delegate() { ((TextBox)element).Visible = enabled; ((TextBox)element).Refresh(); });
            else if ((element.GetType() == typeof(TextBox)))
            {
                ((TextBox)element).Enabled = enabled;
                ((TextBox)element).Refresh();
            }

            if ((element.GetType() == typeof(Label)) && ((Label)element).InvokeRequired) ((Label)element).BeginInvoke((MethodInvoker)delegate() { ((Label)element).Visible = enabled; ((Label)element).Refresh(); });
            else if ((element.GetType() == typeof(Label)))
            {
                ((Label)element).Enabled = enabled;
                ((Label)element).Refresh();
            }

            if ((element.GetType() == typeof(Button)) && ((Button)element).InvokeRequired) ((Button)element).BeginInvoke((MethodInvoker)delegate() { ((Button)element).Visible = enabled; ((Button)element).Refresh(); });
            else if ((element.GetType() == typeof(Button)))
            {
                ((Button)element).Enabled = enabled;
                ((Button)element).Refresh();
            }
        }

        public int getElementText(object element)
        {
            if ((element.GetType() == typeof(NumericUpDown)) && ((NumericUpDown)element).InvokeRequired) ((NumericUpDown)element).BeginInvoke((MethodInvoker)delegate() { this.elementTextInt = Convert.ToInt32(((NumericUpDown)element).Value); });
            else if ((element.GetType() == typeof(NumericUpDown))) this.elementText = ((NumericUpDown)element).Text;

            return this.elementTextInt;
        }

        public void clearElement(object element)
        {
            if ((element.GetType() == typeof(TextBox)) && ((TextBox)element).InvokeRequired) ((TextBox)element).BeginInvoke((MethodInvoker)delegate() { ((TextBox)element).Clear(); });
            else if ((element.GetType() == typeof(TextBox))) ((TextBox)element).Text = "";

            if ((element.GetType() == typeof(Label)) && ((Label)element).InvokeRequired) ((Label)element).BeginInvoke((MethodInvoker)delegate() { ((Label)element).Text = ""; });
            else if ((element.GetType() == typeof(Label))) ((Label)element).Text = "";

            if ((element.GetType() == typeof(Button)) && ((Button)element).InvokeRequired) ((Button)element).BeginInvoke((MethodInvoker)delegate() { ((Button)element).Text = ""; });
            else if ((element.GetType() == typeof(Button))) ((Button)element).Text = "";

            if ((element.GetType() == typeof(ListView)) && ((ListView)element).InvokeRequired) ((ListView)element).BeginInvoke((MethodInvoker)delegate() { ((ListView)element).Items.Clear(); });
            else if ((element.GetType() == typeof(ListView))) ((ListView)element).Items.Clear();
        
        }
       

    }
}
