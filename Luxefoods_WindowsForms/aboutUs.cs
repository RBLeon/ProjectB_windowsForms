﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luxefoods_WindowsForms
{
    public partial class aboutUs : Form
    {
        // Allows the user to drag the window
        // This piece of code was taken from StackOverFlow https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public aboutUs()
        {
            InitializeComponent();
            CenterToScreen();
            if (Login.person != null)
            {
                this.LoginBtn.Text = "Logout";
            }
            AboutBtn.BackColor = Color.FromArgb(100, Color.Black);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

       
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LuxeFoodsLogoLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            homePage homeForm = new homePage();
            homeForm.Show();

        }

        private void menuButton_LinkClicked(object sender, EventArgs e)
        {
            this.Hide();
            Menu menuForm = new Menu();
            menuForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                checkReservation reservationForm = new checkReservation(Login.person.id);
                this.Hide();
                reservationForm.Show();
            }
            catch
            {
                MessageBox.Show("You have to be logged in order to see this page.");
            }
        }

        private void reservationsButton_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                Reservation reservationForm = new Reservation(Login.person.id);
                this.Hide();
                reservationForm.Show();
            }
            catch
            {
                MessageBox.Show("You have to be logged in order to see this page.");
            }

        }

        private void contactUsButton_LinkClicked(object sender, EventArgs e)
        {
            this.Hide();
            contactUs contactForm = new contactUs();
            contactForm.Show();
        }

        private void loginButton_LinkClicked(object sender, EventArgs e)
        {
            Login.previousPage = "AboutUs";
            if (Login.person != null)
            {
                this.Hide();
                Template form1 = new Template();
                form1.Show();
            }
            else
            {
                this.Hide();
                Login form2 = new Login();
                form2.Show();
            }
        }

        private void FullscreenBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                FullscreenBtn.BackgroundImage = global::Luxefoods_WindowsForms.Properties.Resources.expand;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                FullscreenBtn.BackgroundImage = global::Luxefoods_WindowsForms.Properties.Resources.compress;
                WindowState = FormWindowState.Maximized;
            }
        }
    }
}
