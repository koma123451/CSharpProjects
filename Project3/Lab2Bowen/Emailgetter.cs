using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Bowen
{
    class Emailgetter
    {
        private string eg;
        public string EG
        {
            get {
                return eg;
            }
            set
            {
                eg = value;
            }
        }
        public Emailgetter() { }
        public Emailgetter(string eg)
        {
            EG = eg;
        }
        public void SendEmail(String message)
        {
            MessageBox.Show($"Message {message} has been sent to {EG}");
        }
        public void Unsubscribe(publish publish)
        {
            publish.publishMessage -= SendEmail;
        }
        public void subscribe(publish publish)
        {
            publish.publishMessage += SendEmail;
        }
    }
}