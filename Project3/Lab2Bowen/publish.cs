using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Bowen
{
    class publish
    {
        
        public delegate void Publishmessage(string message);
        public Publishmessage publishMessage = null;
        public void PublishInfo(string mes)
        {
            publishMessage?.Invoke(mes);
        }
    }
}
