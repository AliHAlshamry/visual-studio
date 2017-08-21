using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using SmsModem.classes;
using System.Threading;

namespace SmsModem
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort();
        connect objcls = new connect();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.TabPages.Remove(tabPage2);
                this.tabControl1.TabPages.Remove(tabPage3);
            }
            catch (Exception ex)
            {
                this.msg.Text = ("OOPS ! there is some error \n please restart app ");
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
           // port.PortName = this.PortName.Text;
            //port.ReadTimeout = 2000;
            //port.Open();
            port.Write("AT\r");
            port.Write("AT+CMGF=1\r");
            System.Threading.Thread.Sleep(2000);
            port.Write("AT+CMGS=\"" + txtphone.Text + "\"\r\n");
            port.Write(sms.Text + "\x1A");
            MessageBox.Show("messsage sent successfully !", "messsage", MessageBoxButtons.OK, MessageBoxIcon.Information);
           

        }

        private void cboPortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Open communication port 
                this.port = objcls._port(this.PortName.Text);

                if (this.port != null)
                {
                    this.msg.Text = ("modem is connected at PORT " + this.PortName.Text);
                    this.tabControl1.TabPages.Add(tabPage2);
                    this.tabControl1.TabPages.Add(tabPage3);
                }

                else
                {
                    this.msg.Text = ("OOPS ! there is some error \n please try again later ");
                   
                }
            }
            catch (Exception ex)
            {
                this.msg.Text = ("OOPS ! there is some error \n please check port ");
                   
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

            port.Write("AT" + System.Environment.NewLine);
            Thread.Sleep(1000);
            port.Encoding = Encoding.GetEncoding("iso-8859-1");
            port.WriteLine("AT+CMGF=1" + System.Environment.NewLine);
            Thread.Sleep(1000);
            port.WriteLine("AT+CMGL=\"ALL\"\r" + System.Environment.NewLine); //("AT+CMGL=\"REC UNREAD\"\r");          
            Thread.Sleep(3000);
            textBox1.Text=(port.ReadExisting());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.WordWrap = false;
        }
    }
}
