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

namespace ftGraph
{
    public partial class Form1 : Form
    {
        string DataOUT;
        string sendWidth;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxComPort.Items.AddRange(ports);

            btnOpen.Enabled = true;
            btnClose.Enabled = false;


            chBoxDtrEnable.Checked = false;
            serialPort1.DtrEnable = false;
            chBoxRtsEnable.Checked = false;
            serialPort1.RtsEnable = false;
            btnSendData.Enabled = false;
            chBoxWriteLine.Checked = false;
            chBoxWrite.Checked = true;
            sendWidth = "Write";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tBoxDataOut_TextChanged(object sender, EventArgs e)
        {
            int dataOutLenght = tBoxDataOut.TextLength;
            lblDataOutLenght.Text = string.Format("{0:00}", dataOutLenght);   // "{0:00}" 2 digit tutmak icin
            if (chBoxUsingEnter.Checked)
            {
                tBoxDataOut.Text = tBoxDataOut.Text.Replace(Environment.NewLine, "");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxComPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);

                serialPort1.Open();
                progressBar1.Value = 100;
                btnOpen.Enabled = false;
                btnClose.Enabled = true;

                lblStatusCom.Text = "ON";

            }
            
            catch(Exception er)
            {
                MessageBox.Show(er.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblStatusCom.Text = "OFF";
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                btnOpen.Enabled = true;
                btnClose.Enabled = false;

                lblStatusCom.Text = "OFF";

            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                DataOUT = tBoxDataOut.Text;
                if (sendWidth == "WriteLine")
                {
                    serialPort1.WriteLine(DataOUT); // alt alta gönderir
                }
                else if (sendWidth == "Write")
                {
                    serialPort1.Write(DataOUT);  //Aynı satırda gönderir
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void chBoxDtrEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxDtrEnable.Checked)
            {
                serialPort1.DtrEnable = true;
            }
            else
            {
                serialPort1.DtrEnable = false;
            }
        }

        private void chBoxRtsEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxRtsEnable.Checked)
            {
                serialPort1.RtsEnable = true;
            }
            else
            {
                serialPort1.RtsEnable = false;
            }
        }

        private void btnClearDataOut_Click(object sender, EventArgs e)  // text box daki datayı siler
        {
            if(tBoxDataOut.Text != "")
            {
                tBoxDataOut.Text = "";

            }

        }

        private void chBoxUsingEnter_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chBoxUsingButton_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxUsingButton.Checked)
            {
                btnSendData.Enabled = true;
            }
            else
            {
                btnSendData.Enabled = false;
            }
        }

        private void tBoxDataOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (chBoxUsingEnter.Checked)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    if (serialPort1.IsOpen)   // send serial data
                    {
                        DataOUT = tBoxDataOut.Text;
                        if(sendWidth == "WriteLine")
                {
                            serialPort1.WriteLine(DataOUT); // alt alta gönderir
                        }
                        else if (sendWidth == "Write")
                        {
                            serialPort1.Write(DataOUT);  //Aynı satırda gönderir
                        }
                    }

                }
            }
        }

        private void chBoxWriteLine_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxWriteLine.Checked)
            {
                sendWidth = "WriteLine";
                chBoxWrite.Checked = false;
                chBoxWriteLine.Checked = true;

            }
        }

        private void chBoxWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxWrite.Checked)
            {
                sendWidth = "Write";
                chBoxWrite.Checked = true;
                chBoxWriteLine.Checked= false;
            }
        }
    }
}
