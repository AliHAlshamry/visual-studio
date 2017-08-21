using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace SmsModem.classes
{
    class connect
    {
        public SerialPort _port(string port_name)
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();
            try
            {
                port.PortName = port_name;
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
                return port;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public AutoResetEvent receiveNow;


    }
}
