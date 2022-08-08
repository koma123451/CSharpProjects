using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Bowen
{
    class MobileGetter
    {
        public string Phone { get; set; }
        public MobileGetter() { }
        public MobileGetter(string phone)
        {
            Phone = phone;
        }
       public  void SendMessage(string message)
        {
            MessageBox.Show($"Message {message} has been sent to {Phone}");
        }
        public void Unsubscribe(publish publish)
        {
            publish.publishMessage -= SendMessage;
        }
        public void subscribe(publish publish)
        {
            publish.publishMessage += SendMessage;
        }
    }
}
