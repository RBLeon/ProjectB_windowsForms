﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luxefoods_WindowsForms
{
    public partial class aboutUs : Form
    {
        public aboutUs()
        {
            InitializeComponent();
            if (Login.person != null)
            {
                this.loginButton.Text = Login.person.voornaam + " " + Login.person.achternaam;
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

        private void LuxeFoodsLogoLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            homePage homeForm = new homePage();
            homeForm.Show();

        }

        private void menuButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Menu menuForm = new Menu();
            menuForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            checkReservation reservationForm = new checkReservation();
            reservationForm.Show();
        }

        private void reservationsButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Reservation reservationForm = new Reservation();
            reservationForm.Show();

        }

        private void contactUsButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            contactUs contactForm = new contactUs();
            contactForm.Show();
        }

        private void loginButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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