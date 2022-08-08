using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Bowen
{
     delegate void EmailDelegate(string email, List<Emailgetter> list);
    delegate void MobileDelegate(string mobile, List<MobileGetter> list);
    public partial class ManageNotificationSubscription : Form
    {
        
        private string patternEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private string patternPhone = @"^\d{10}$";
        public ManageNotificationSubscription()
        {
            InitializeComponent();
        }

   
        private void frmManageSubscription_Load(object sender, EventArgs e)
        {
            UpdateEmail(Program.emailSubList);
            UpdatePhone(Program.mobileSubList);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
           
        }
        private static void EmailList(string email,List<Emailgetter> list)
        {
            Emailgetter em = new Emailgetter(email);
            if (!list.Any(i => i.EG == em.EG))
            {
                list.Add(em);
                MessageBox.Show($"{em.EG} added to the list");
            }
            else
            {
                MessageBox.Show($"{em.EG} is already exist");
            }
        }//1
        private static void MobileList(string mobile,List<MobileGetter> list)
        {
            MobileGetter mo = new MobileGetter(mobile);
                if (!list.Any(i => i.Phone == mo.Phone))
            {
                list.Add(mo);
                MessageBox.Show($"Success.! {mo.Phone} is added to subcription list");
            }
            else
            {
                MessageBox.Show($"Error.! {mo.Phone} is already subcribed");
            }
        }//2
       private void UpdateEmail(List<Emailgetter> emSubList)
        {
            List<string> emailList = new List<string>();
            foreach (Emailgetter em in emSubList)
            {
                emailList.Add(em.EG);
            }
            listBox1.DataSource = emailList;
        }
        private void UpdatePhone(List<MobileGetter> phoneSubList)
        {
            List<string> phoneList = new List<string>();
            foreach (MobileGetter ph in phoneSubList)
            {
                phoneList.Add(ph.Phone);
            }
            listBox2.DataSource = phoneList;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
          
            string em = textBox1.Text;
            if (checkBox1.Checked)
            {
                if (String.IsNullOrEmpty(em) || em == "bdai@my.centennialcollege.ca")
                {
                    label1.Visible = true;
                    label1.Text = "Please fill in your email first";
                }
                else
                {
                   
                    if (Regex.IsMatch(em, patternEmail))
                    {
                        label1.Visible = false;
                        EmailList(em, Program.emailSubList);
                    }
                    else
                    {
                        label1.Visible = true;
                    }
                }
            }
           
            string phone = textBox2.Text;
            if (checkBox2.Checked)
            {
                if (String.IsNullOrEmpty(phone) || phone == "Enter Phone Number")
                {
                    label2.Visible = true;
                    label2.Text = "Please fill in your phone first";
                }
                else
                {
                    
                    if (Regex.IsMatch(phone, patternPhone))
                    {
                        label2.Visible = false;
                        MobileList(phone, Program.mobileSubList);
                     
                    }
                    else
                    {
                        label2.Visible = true;
                    }
                }
            }

            UpdateEmail(Program.emailSubList);
            UpdatePhone(Program.mobileSubList);
        }
        private static void DeleteEmFromList(String email,List<Emailgetter> list)
        {
            Emailgetter em = list.SingleOrDefault(i => i.EG == email);
            if(em != null)
            {
                list.Remove(em);
                MessageBox.Show($"{em.EG}  has been deleted from the list");
            }
            else MessageBox.Show($"! {email} is not subcribed ");
        }
        private static void DeletePhFromList(String phone, List<MobileGetter> list)
        {
            MobileGetter ph = list.SingleOrDefault(i => i.Phone == phone);
            if (ph != null)
            {
                list.Remove(ph);
                MessageBox.Show($"{ph.Phone}  has been deleted from the list");
            }
            else MessageBox.Show($"! {phone} is not subcribed ");
        }
        private void txtBox1_Focus(object sender, EventArgs e)
        {
            if (textBox1.Text == "bdai@my.centennialcollege.ca")
            {
                textBox1.Text = "";
            }
        }
        private void txtBox1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "bdai@my.centennialcollege.ca";
            }
        }
        private void textBox2_Focus(object sender, EventArgs e)
        {
            if (textBox2.Text == "bdai@my.centennialcollege.ca")
            {
                textBox2.Text = "";
            }
        }
        private void txtBox2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "bdai@my.centennialcollege.ca";
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            
            string em = textBox1.Text;
            if (checkBox1.Checked)
            {
                if(string.IsNullOrEmpty(em) || em == "bdai@my.centennialcollege.ca")
                {
                    label1.Visible = true;
                    label1.Text = "Enter your email first";
                }
                else
                {
                    label1.Visible = false;
                    DeleteEmFromList(em, Program.emailSubList);
                }
            }
            //----
            string phone = textBox2.Text;
            if (checkBox2.Checked)
            {
                if (string.IsNullOrEmpty(phone) || phone == "bdai@my.centennialcollege.ca")
                {
                    label2.Visible = true;
                    label2.Text = "Enter your phone number first";
                }
                else
                {
                    label2.Visible = false;
                    DeletePhFromList(phone, Program.mobileSubList);
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainScreen = new Form1();
            mainScreen.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ManageNotificationSubscription_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox2.Checked;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "bdai@my.centennialcollege.ca")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Text == "whats your phone number")
            {
                checkBox2.Text = "";
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox2.Checked;
        }
    }
}
