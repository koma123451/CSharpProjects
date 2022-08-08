using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Bowen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
;        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ManageNotificationSubscription mainForm = new ManageNotificationSubscription();
            this.Hide();
            mainForm.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PublishNotifications_Click(object sender, EventArgs e)
        {
            this.Hide();
            SendNotification mainForm = new SendNotification();
            
            mainForm.Show();
            
        }
        private void MainScreen_Load(object sender, EventArgs e)
        {
            if(Program.emailSubList.Any()|| Program.mobileSubList.Any())
            {
                PublishNotifications.Enabled = true;
            }
        }
    }
   
}
