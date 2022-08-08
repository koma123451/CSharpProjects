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
    public partial class SendNotification : Form
    {
        public SendNotification()
        {
            InitializeComponent();
        }
       
      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text) || textBox1.Text == "Type your message here")
            {
                label2.Visible = true;
                label2.Text = "fill the message first";
                MessageBox.Show("fill the message first");
            }
            else
            {
                label2.Visible = false;
                publish pbt = new publish();
                foreach (Emailgetter email in Program.emailSubList)
                {
                    email.subscribe(pbt);
                }
                foreach (MobileGetter mobile in Program.mobileSubList)
                {
                    mobile.subscribe(pbt);
                }

                pbt.PublishInfo(textBox1.Text);

                MessageBox.Show("Message sent to all subscribers");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainScreen = new Form1();
            mainScreen.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            if(textBox1.Text== "Type your message here")
            {
                textBox1.Text = "";
            }
        }
    }
}
