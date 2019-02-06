using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;                // Added for IO exception
using System.IO.Ports;          // Added for serial ports
using System.Threading;         // Added for sleep

namespace AlienGUIPrototype
{
    public partial class Form1 : Form
    {
        static SerialPort serialPort1 = new SerialPort();

        // COM connection status
        static bool comconnected = false;

        const int COM_BAUD = 115200;
        const int READ_TIMEOUT = 10000;     // Read reply timeout

        public Form1()
        {
            InitializeComponent();
            // Initial setup
            p_maintenance.Visible = false;
            mo_operation.Enabled = false;
            cb_colourchoice.SelectedIndex = 0;
            cb_servoselect.SelectedIndex = 0;
            cb_taskselect.SelectedIndex = 0;
            // Unimplemented button operations
            b_ledset.Enabled = false;
            b_readcolour.Enabled = false;
            b_readdistance.Enabled = false;
            b_servoset.Enabled = false;
            b_start.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_portselect.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cb_portselect.Items.Add(s);
            }
            if (cb_portselect.Items.Count > 0)
            {
                cb_portselect.SelectedIndex = 0;
            }
            else
            {
                tb_debug.AppendText("No COM ports found.\r\n");
            }
            serialPort1.BaudRate = COM_BAUD;
        }

        private void mo_exit_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Application.Exit();
        }

        private void mo_maintenance_Click(object sender, EventArgs e)
        {
            p_maintenance.Visible = true;
            p_operations.Visible = false;
            mo_maintenance.Enabled = false;
            mo_operation.Enabled = true;
        }

        private void mo_operation_Click(object sender, EventArgs e)
        {
            p_maintenance.Visible = false;
            p_operations.Visible = true;
            mo_maintenance.Enabled = true;
            mo_operation.Enabled = false;
        }

        private void b_task_Click(object sender, EventArgs e)
        {
            String selected = cb_taskselect.SelectedItem.ToString();
            try
            {
                if (comconnected)
                    switch (selected)
                    {
                        case "Test MBED Connection":
                            serialPort1.Write("p,0,");
                            string portin = serialPort1.ReadLine();
                            tb_debug.AppendText(portin + "\r\n");
                            break;
                        case "Test FPGA Connection":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Rotate Turntable":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Activate Pusher":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Find Red":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Find Green":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Find Blue":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Test Distance":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Spew COM Data":
                            while (true)
                            {
                                tb_debug.AppendText(serialPort1.ReadLine() + "\r\n");
                            }
                            break;
                        default:
                            break;
                    }
                else tb_debug.AppendText("Please select a COM port and connnect.");
            }
            catch (IOException ex)
            {
                tb_debug.AppendText("Error in operation:\r\n");
                tb_debug.AppendText(ex + "\r\n");
            }
        }

        private void b_refreshcom_Click(object sender, EventArgs e)
        {
            cb_portselect.Items.Clear();
            tb_debug.AppendText("Available Ports:\r\n");
            foreach (string s in SerialPort.GetPortNames())
            {
                cb_portselect.Items.Add(s);
                tb_debug.AppendText(s + "\r\n");
            }
            if (SerialPort.GetPortNames().Length == 0)
            {
                tb_debug.AppendText("none\r\n");
            }
            else
            {
                cb_portselect.SelectedIndex = 0;
            }
            serialPort1.BaudRate = COM_BAUD;
            Thread.Sleep(2000);   // sleep 2 seconds
        }

        private bool establishCOMConnection()
        {
            try
            {
                if (cb_portselect.Items.Count == 0) return false;
                string portname = cb_portselect.SelectedItem.ToString();
                serialPort1.PortName = portname;
                serialPort1.Open();
                return true;
            }
            catch (IOException e)
            {
                tb_debug.AppendText(e.ToString() + "\r\n");
                return false;
            }
        }

        private void b_comconnect_Click(object sender, EventArgs e)
        {
            comconnected = establishCOMConnection();
            if (comconnected)
            {
                tb_debug.AppendText("Connected to COM port " + cb_portselect.SelectedItem.ToString() + "\r\n");
            }
            else
            {
                tb_debug.AppendText("Failed to connect to COM port.\r\n");
            }
        }
    }
}
