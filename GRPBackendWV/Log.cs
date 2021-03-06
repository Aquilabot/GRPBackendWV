﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRPBackendWV
{
    public static class Log
    {
        public static RichTextBox box = null;
        public static int MinPriority = 10; //1..10 1=less, 10=all

        public static void WriteLine(int priority, string s, object color = null)
        {
            if (box == null) return;
            try
            {
                box.Invoke(new Action(delegate
                {
                    string stamp = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " : [" + priority.ToString("D2") + "]";
                    if (priority <= MinPriority)
                    {
                        Color c;
                        if (color != null)
                            c = (Color)color;
                        else
                            c = Color.Black;
                        if (s.ToLower().Contains("error"))
                            c = Color.Red;
                        box.SelectionStart = box.TextLength;
                        box.SelectionLength = 0;
                        box.SelectionColor = c;
                        box.AppendText(stamp + s + "\n");
                        box.SelectionColor = box.ForeColor;
                        box.ScrollToCaret();
                    }
                    File.AppendAllText("log.txt", stamp + s + "\n");
                }));
            }
            catch { }
        }
    }
}
