using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;          // Added for serial ports
using System.Threading;         // Added for sleep

namespace AlienGUIPrototype
{
    public partial class Form1 : Form
    {
        static SerialPort serialPort1 = new SerialPort();

        // Status return constants
        const int OK = 0;
        const int FORMAT_ERROR = -1;

        const int COM_BAUD = 115200;
        const int READ_TIMEOUT = 10000;     // Read reply timeout

        int global_error;

        public Form1()
        {
            InitializeComponent();
            // Initial setup
            p_maintenance.Visible = false;
            mo_operation.Enabled = false;
            cb_colourchoice.SelectedIndex = 0;
            cb_servoselect.SelectedIndex = 0;
            cb_taskselect.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_portselect.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cb_portselect.Items.Add(s);
            }
            //cb_portselect.SelectedIndex = 0;
            serialPort1.BaudRate = COM_BAUD;
            global_error = OK;
            Thread.Sleep(2000);   // sleep 2 seconds
        }

        private void mo_exit_Click(object sender, EventArgs e)
        {
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

        }

        private void b_refreshcom_Click(object sender, EventArgs e)
        {
            cb_portselect.Items.Clear();
            tb_debug.AppendText("-----------------------------\r\nAvailable Ports:\r\n");
            foreach (string s in SerialPort.GetPortNames())
            {
                cb_portselect.Items.Add(s);
                tb_debug.AppendText(s);
                tb_debug.AppendText("\r\n");
            }
            if (SerialPort.GetPortNames().Length == 0)
            {
                tb_debug.AppendText("none\r\n");
            }
            //cb_portselect.SelectedIndex = 0;
            serialPort1.BaudRate = COM_BAUD;
            global_error = OK;
            Thread.Sleep(2000);   // sleep 2 seconds
        }
    }
}
