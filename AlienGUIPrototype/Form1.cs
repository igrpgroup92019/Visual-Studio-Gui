using System;
using System.Windows.Forms;
using System.IO;                // Added for IO exception
using System.IO.Ports;          // Added for serial ports
using System.Threading;         // Added for sleep
using System.Speech.Synthesis;  // Added for speech

namespace AlienGUIPrototype
{
    public partial class Form1 : Form
    {
        static SerialPort serialPort1 = new SerialPort();

        // COM connection status
        static bool comconnected = false;
        // COM constants
        const int COM_BAUD = 9600;
        const int READ_TIMEOUT = 10000;     // Read reply timeout
        // Speech
        static SpeechSynthesizer speak = new SpeechSynthesizer();

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
            b_start.Enabled = false;
            // Other
            speak.SetOutputToDefaultAudioDevice();
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
            String selected = cb_taskselect.SelectedText;//cb_taskselect.SelectedItem.ToString();
            try
            {
                if (comconnected)
                    switch (selected)
                    {
                        case "Find Red":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Find Green":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Find Blue":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Find Yellow":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Find White":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Test Distance":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Rotate Turntable Once":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        case "Activate Pusher":
                            tb_debug.AppendText("Unimplemented task\r\n");
                            break;
                        default:
                            break;
                    }
                else tb_debug.AppendText("Please select a COM port and connnect.\r\n");
            }
            catch (IOException ex)
            {
                tb_debug.AppendText("\r\nError in operation:\r\n  ");
                tb_debug.AppendText(ex.Message + "\r\n");
            }
            catch (InvalidOperationException exep)
            {
                tb_debug.AppendText("\r\n" + exep.Message + "\r\n");
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
                cb_portselect.SelectedIndex = -1;
                cb_portselect.Text = "";
            }
            else
            {
                cb_portselect.SelectedIndex = 0;
            }
            //Thread.Sleep(2000);   // sleep 2 seconds
        }

        // Attempt to connect with the selected COM port, return true or false based on success
        private bool establishCOMConnection()
        {
            try
            {
                if (comconnected)
                    serialPort1.Close();
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

        // Takes an input of the form "x,#,[...]" and returns an integer array, one entry per value
        private int[] processReadings(string readings)
        {
            string[] individual = readings.Split(',');
            int[] vals = new int[Int32.Parse(individual[1])];
            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = Int32.Parse(individual[i + 2]);
            }
            return vals;
        }

        // Sends a message to the MBED, returns false if an error is thrown, true otherwise.
        private void sendToMBED(string message)
        {
            if (!comconnected)
                throw new IOException("Not connected to a COM port.");
            serialPort1.WriteLine(message);
        }

        // Reads the next line from the MBED, tries (attempts) times with (delay)ms gap between each. Throws exception if failure.
        private string readFromMBED(int attempts = 100, int delay = 100)
        {
            if (!comconnected)
                throw new IOException("Not connected to a COM port.");
            string portIn = "";
            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    portIn = serialPort1.ReadLine();
                    //tb_debug.AppendText("\r\n\r\n" + portIn + "\r\n\r\n");
                    return portIn;
                }
                catch (IOException e)
                {
                    //tb_debug.AppendText(e.Message);
                    Thread.Sleep(delay);
                }
            }
            throw new TimeoutException("No input from port in designated time.\r\n");
        }

        private void b_readcolour_Click(object sender, EventArgs e)
        {
            try
            {
                sendToMBED("c,0");
            }
            catch (Exception ex)
            {
                tb_debug.AppendText("Failed to request colour information:\r\n" + ex.Message + "\r\n");
                return;
            }
            try
            {
                string message = readFromMBED();
                if (char.Equals(message[0], 'c'))
                {
                    int[] vals = processReadings(message);
                    tb_debug.AppendText("Colour readings:\r\n c:" + vals[0] + ", r:" + vals[1] + ", g:" + vals[2] + ", b:" + vals[3] + "\r\n");
                }
                else
                {
                    tb_debug.AppendText("Unexpected message:\r\n  " + message + "\r\n");
                }
            }
            catch (Exception ex)
            {
                tb_debug.AppendText("Failed to read colour from port:\r\n  " + ex.Message + "\r\n");
            }
        }

        private void b_readdistance_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    sendToMBED("d,0");
                }
                catch (Exception ex)
                {
                    tb_debug.AppendText("Failed to request distance information:\r\n" + ex.Message + "\r\n");
                    return;
                }
                try
                {
                    string message = readFromMBED();
                    if (char.Equals(message[0], 'd'))
                    {
                        int[] vals = processReadings(message);
                        tb_debug.AppendText("Distance reading: " + vals[0] + "\r\n");
                    }
                    else
                    {
                        tb_debug.AppendText("Unexpected message:\r\n  " + message + "\r\n");
                    }
                }
                catch (Exception ex)
                {
                    tb_debug.AppendText("Failed to read distance from port:\r\n  " + ex.Message + "\r\n");
                }
            }
        }

        private void b_readall_Click(object sender, EventArgs e)
        {
            try
            {
                sendToMBED("r,0");
            }
            catch (Exception ex)
            {
                tb_debug.AppendText("Failed to request sensor information:\r\n" + ex.Message + "\r\n");
                return;
            }
            try
            {
                string message = readFromMBED();
                if (char.Equals(message[0], 'r'))
                {
                    int[] vals = processReadings(message);
                    tb_debug.AppendText("Sensor readings:\r\n dist:" + vals[0] + ", c:" + vals[1] + ", r:" + vals[2] + ", g:" + vals[3] + ", b:" + vals[4] + "\r\n");
                }
                else
                {
                    tb_debug.AppendText("Unexpected message:\r\n  " + message + "\r\n");
                }
            }
            catch (Exception ex)
            {
                tb_debug.AppendText("Failed to read sensors from port:\r\n  " + ex.Message + "\r\n");
            }
        }

        private void b_servoset_Click(object sender, EventArgs e)
        {
            int servonum = -1;
            switch (cb_servoselect.SelectedText)
            {
                case "Turntable":
                    servonum = 0;
                    break;
                case "Pusher":
                    servonum = 1;
                    break;
            }
            int angle = Decimal.ToInt32(ud_servoangle.Value);
            try
            {
                sendToMBED("s,2," + servonum + "," + angle);
            }
            catch (Exception ex)
            {
                tb_debug.AppendText("Failed to request servo movement:\r\n" + ex.Message + "\r\n");
                return;
            }
            try
            {
                string message = readFromMBED(1000, 50);
                switch (message[0])
                {
                    case 'a':
                        tb_debug.AppendText("Task completed successfully.\r\n");
                        break;
                    case 'f':
                        tb_debug.AppendText("Failed to complete task.\r\n");
                        break;
                    default:
                        tb_debug.AppendText("Unexpected message received:\r\n  " + message + "\r\n");
                        break;
                }
            }
            catch (TimeoutException ex)
            {
                tb_debug.AppendText("Timeout when reading from port:\r\n  " + ex.Message + "\r\n");
            }
            catch (IOException ex)
            {
                tb_debug.AppendText("Failed to read from port:\r\n  " + ex.Message + "\r\n");
            }
        }

        private void b_speak_Click(object sender, EventArgs e)
        {
            speak.Speak(tb_speak.Text);
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            textOutput("You have selected the colour " + cb_colourchoice.SelectedItem.ToString()+".\r\n");
            textOutput("This is not yet implemented.\r\n");
        }

        private void textOutput(string text)
        {
            tb_output.AppendText(text);
            if(cb_voice.Checked)
                speak.Speak(text);
        }

        private void cb_colourchoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_colourchoice.SelectedIndex == 0)
                b_start.Enabled = false;
            else
                b_start.Enabled = true;
        }

        private void cb_voice_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_voice.Checked)
                cb_voice.Text = "Voice Enabled";
            else
                cb_voice.Text = "Voice Disabled";
        }
    }
}