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
    public partial class homePage : Form
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

        public homePage()
        {
            InitializeComponent();
            CenterToScreen();
            if (Login.person != null)
            {
                this.linkLabel6.Text = Login.person.voornaam + " " + Login.person.achternaam;
            }
        }

        private void AvailabilityTable_Paint(object sender, PaintEventArgs e)
        {

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

        private void ExitButton_Hover_Enter(object sender, EventArgs e)
        {
            ExitButton.ForeColor = Color.Red;
        }

        private void ExitButton_Hover_Leave(object sender, EventArgs e)
        {
            ExitButton.ForeColor = Color.Black;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeButton_Hover_Enter(object sender, EventArgs e)
        {
            MinimizeButton.ForeColor = Color.Red;
        }
        private void MinimizeButton_Hover_Leave(object sender, EventArgs e)
        {
            MinimizeButton.ForeColor = Color.Black;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            contactUs contactForm = new contactUs();
            contactForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Reservation reservationForm = new Reservation(Login.person.id);
                this.Hide();
                reservationForm.Show();
            }
            catch
            {
                MessageBox.Show("Je moet eerst ingelogd zijn.");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            checkReservation checkReservationForm = new checkReservation();
            checkReservationForm.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login.previousPage = "Home";
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Menu menuForm = new Menu();
            menuForm.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            aboutUs aboutForm = new aboutUs();
            aboutForm.Show();
        }
    }

    /*
     * ----- CHECK AVAILABILITY BUTTON -----
     * People = seats.value
     * Date = dateTimePicker1.value
     * TableSize = 4
     * TablesNeeded = People // TableSize
     * ShowAvailableTables(TablesNeeded)
     * 
     * 
     * 
     * ----- ShowShowAvailableTables(int amountOfTables) -----
     * fetch data from the database
     * look for amounrOfTables in the same zone for the same time
     * 
     *
     * 
     * 
     */
}
