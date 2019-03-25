using System;
using System.Windows.Forms;
using System.IO;                // Added for IO exception
using System.IO.Ports;          // Added for serial ports
using System.Threading;         // Added for sleep
using System.Diagnostics;       // Added for stopwatch
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
        static bool speechenabled = false;
        // Output text
        static int language = 0;
        static string[,,] messages = new string[,,] {
        { { "Oh dear, something went wrong. Please check maintenance mode.\r\n", "Oh dear, something went wrong. Please check maintenance mode." },
                { "Oddio, qualcosa è andato storto. Controlla la modalità manutenzione.\r\n", "Oddio, qualcosa è andato storto. Controlla la modalità manutenzione." },
                { "Нещо се обърка. Моля проверете регистъра за грешки.\r\n", "Neshto se obarka. Molya proverete registara za greshki." } },
        { { "red", "red" }, { "rosso", "rosso" }, { "червената", "chervenata" } },
        { { "green", "green" }, { "verde", "verde" }, { "зелената", "zelenata" } },
        { { "blue", "blue" }, { "blu", "blu" }, { "синята", "sinyata" } },
        { { "yellow", "yellow" }, { "giallo", "giallo" }, { "жълтата", "zhaltata" } },
        { { "white", "white" }, { "bianco", "bianco" }, { "бялата", "byalata" } },
        { { "Trying to find the ", "Trying to find the " },
                { "Sto cercando di trovare il blocco ", "Sto cercando di trovare il blocco " },
                { "Намиране на ", "Namirane na " } },
        { { " block.\r\n", " block." }, { ".\r\n", "." }, { " тухличка.\r\n", " tuhlichka." } },
        { { "Sorry, I couldn't find the ", "Sorry, I couldn't find the " },
                { "Mi dispiace, non riesco a trovare il blocco ", "Mi dispiace, non riesco a trovare il blocco " },
                { "Грешка при намирането на ", "Greshka pri namiraneto na " } },
        { { " block.\r\n", " block." }, { ".\r\n", "." }, { " тухличка.\r\n", " tuhlichka." } },
        { { "I'm waiting for the robot.\r\n", "I'm waiting for the robot." },
                { "Sto aspettando il robot.\r\n", "Sto aspettando il robot." },
                { "Чакам робота.\r\n", "Chakam robota." } },
        { { "Ah, here he is. Here you go, friend.\r\n", "Ah, here he is. Here you go, friend." },
                { "Ah, è arrivato. Ecco qui, amico.\r\n", "Ah, è arrivato. Ecco qui, amico." },
                { "Ах, ето го. Заповядай, приятел.\r\n", "Ah, eto go. Zapovyaday, priyatel." } },
        { { "Bye-bye now!\r\n", "Bye-bye now" }, { "Ciao ciao!\r\n", "Ciao ciao!" }, { "Чао чао!\r\n", "Chao Chao!" } },
        { { "Connecting to alien...\r\n", "Connecting to alien" },
                { "Sto connettendo all'alieno.\r\n", "Sto connettendo all'alieno." },
                { "Свързване с извънземното...\r\n", "Svarzvane s izvanzemnoto…" } }};

        static string[,] guitext = new string[,] {
            { "Start",                  "Start",                    "Старт" },
            { "Options",                "Opzioni",                  "Опции" },
            { "Settings",               "Impostazioni",             "Настройки" },
            { "Select a colour...",     "Seleziona un colore...",   "Изберете цвят..." },
            { "Red",                    "Rosso",                    "Червен" },
            { "Green",                  "Verde",                    "Зелен" },
            { "Blue",                   "Blu",                      "Син" },
            { "Yellow",                 "Giallo",                   "Жълт" },
            { "White",                  "Bianco",                   "Бял" },
            { "Maintenance",            "Manutenzione",             "Поддръжка" },
            { "Operation",              "Operazione",               "Операция" },
            { "Exit",                   "Esci",                     "Изход" },
            { "Enable voice",           "Attiva voce",              "Активирай глас" },
            { "Disable voice",          "Disattiva voce",           "Деактивирай глас" },
            { "Language",               "Linguaggio",               "Език" } };
        // Used in debug output
        static string[] coltotext = new string[] { "red", "green", "blue", "yellow", "white", "empty" };


        public Form1()
        {
            InitializeComponent();
            // Initial setup
            p_maintenance.Visible = false;
            mo_operation.Enabled = false;
            cb_colourchoice.SelectedIndex = 0;
            cb_taskselect.SelectedIndex = 0;
            b_start.Enabled = false;
            // Other
            speak.SetOutputToDefaultAudioDevice();
            // Initialise with English language
            changeLanguage(language);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set operation mode as default
            mo_operation_Click(null, null);
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
                debug("No COM ports found.\r\n");
            }
            serialPort1.BaudRate = COM_BAUD;
        }

        // Debug message output
        private void debug(string text)
        {
            tb_debug.AppendText(text);
        }

        // Languages
        // 0 - English
        // 1 - Italian
        // 2 - Bulgarian
        private void changeLanguage(int newlanguage)
        {
            language = newlanguage;
            b_start.Text = guitext[0, language];
            m_options.Text = guitext[1, language];
            m_settings.Text = guitext[2, language];
            cb_colourchoice.Items.Clear();
            for (int i = 3; i <= 8; i++)
            {
                cb_colourchoice.Items.Add(guitext[i, language]);
            }
            cb_colourchoice.SelectedIndex = 0;
            mo_maintenance.Text = guitext[9, language];
            mo_operation.Text = guitext[10, language];
            mo_exit.Text = guitext[11, language];
            if (speechenabled)
                ms_togglevoice.Text = guitext[13, language];
            else
                ms_togglevoice.Text = guitext[12, language];
            ms_language.Text = guitext[14, language];
        }

        // Attempt to connect with the selected COM port, return true or false based on success
        private bool establishCOMConnection(string portname)
        {
            try
            {
                if (comconnected)
                    serialPort1.Close();
                if (cb_portselect.Items.Count == 0) return false;
                serialPort1.PortName = portname;
                serialPort1.Open();
                comconnected = true;
                return true;
            }
            catch (IOException e)
            {
                debug("No COM ports available.\r\n");
                return false;
            }
        }

        // Sends a message to the MBED, throws IOException if not connected to a COM port, //prints exact command sent
        private void sendToMBED(string message)
        {
            if (!comconnected)
                throw new IOException("Not connected to a COM port.");
            //debug("Sending command: " + message + "\r\n");
            serialPort1.WriteLine(message);
        }

        // Reads the next line from the MBED, returns string. Tries for (time) ms with (delay)ms delay between each. Throws IOException if
        // not connected, TimeoutException if times out.
        private string readFromMBED(int time = 15000, int delay = 5)
        {
            //debug("Attempts:" + attempts + ", delay:" + delay + "\r\n");
            if (!comconnected)
                throw new IOException("Not connected to a COM port.");
            string portIn = "";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < time)
            {
                try
                {
                    // Attempt to get input line
                    portIn = serialPort1.ReadLine();
                    // If the first char is 'm' it's a print command, display in debug and continue searching. Otherwise return valid message.
                    while (!isValidCommand(portIn))
                    {
                        if (portIn.Length == 0)
                            debug("Empty message received.\r\n");
                        if (cb_mtoggle.Checked && portIn[0] == 'm')
                            debug("Message: " + portIn + "\r\n");
                        else if (portIn[0] != 'm')
                            debug("Unexpected message: " + portIn + "\r\n");
                        portIn = serialPort1.ReadLine();
                    }
                    stopwatch.Stop();
                    return portIn;
                }
                catch (IOException e)
                {
                    // Ignore
                }
                catch (InvalidOperationException e)
                {
                    // Only thrown when disconnected mid-operation?
                    stopwatch.Stop();
                    throw new IOException("Port disconnected");
                }
                Thread.Sleep(delay);
            }
            stopwatch.Stop();
            throw new TimeoutException("No input from port in designated time.\r\n");
        }

        // Checks for message length and first character in message, true if valid (and non-m) command
        private bool isValidCommand(string message)
        {
            if (message.Length == 0)
                return false;
            char m = message[0];
            return m == 'a' || m == 'f' || m == 'c' || m == 'd' || m == 'r';
        }

        // Returns index of colour in front of sensor, throws IOException if not connected, TimeoutException if times out
        // Colours
        // 0 - red
        // 1 - green
        // 2 - blue
        // 3 - yellow
        // 4 - white
        // 5 - null
        // TODO - more tests
        private int getColour()
        {
            sendToMBED("c,0");
            string message = readFromMBED();
            int[] data = processReadings(message);
            try
            {
                debug($"Colours read: c{data[0]} r{data[1]} g{data[2]} b{data[3]}\r\n");
            }
            catch (IndexOutOfRangeException e)
            {
                debug("Error with colour data: " + data.ToString() + "\r\n from message: " + message + "\r\n");
            }
            // Logic for colour comparison
            // Variables
            double bluemult = 1.5;
            int ywcutoff = 145;
            double bluecompcheck = 0.75;
            int nullcutoff = 85;
            int r = data[1];
            int g = data[2];
            int b = Convert.ToInt32(data[3] * bluemult);
            int c = data[0];
            // Logic
            if (c < nullcutoff)
                return 5;
            if (c > ywcutoff)
            {
                double bluecomp = b / ((r + g) / (2.0));
                if (bluecomp < bluecompcheck) return 3;
                return 4;
            }
            int max = Math.Max(Math.Max(r, g), b);
            if (r == max)
                return 0;
            if (g == max)
                return 1;
            if (b == max)
                return 2;
            // Something went wrong here...
            return -1;
        }

        // Rotates the turntable to a given position (in terms of block)
        // angle = 0 - 360
        private void rotateTurntable(int angle)
        {
            // 360 degree turntable, 5 blocks, 72 degree difference
            if (angle < 0 || angle > 360)
                throw new InvalidOperationException("Invalid turntable angle");
            debug("Rotating to " + angle + "\r\n");
            sendToMBED("s,2,1," + angle);
            string message = readFromMBED();
            if (message[0] != 'a')
                throw new IOException("Turntable rotation failed: " + message);
        }

        // Finds the correct colour on the turntable based on the colour given
        private bool findColour(int block)
        {
            debug("Looking for block " + coltotext[block] + "\r\n");
            // Rotate to 0
            rotateTurntable(0);
            // Turntable is at start, block not yet found
            int rotatecount = 0;
            bool found = false;
            do
            {
                // Check block colour
                Thread.Sleep(1000);
                int col = getColour();
                debug("Current colour is " + coltotext[col] + ".\r\n");
                // If correct the right block has been found, continue
                if (col == block)
                    found = true;
                else
                {
                    // Otherwise rotate once, provided all blocks haven't been checked
                    rotatecount++;
                    if (rotatecount < 5)
                        rotateTurntable(rotatecount * 72);
                }
            } while (rotatecount < 5 && !found);        // Check if 5 or 4
            return found;
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

        // Close the program
        private void mo_exit_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Application.Exit();
        }

        // Switch to maintenance mode
        private void mo_maintenance_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(892, 416);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            p_maintenance.Visible = true;
            p_operations.Visible = false;
            mo_maintenance.Enabled = false;
            mo_operation.Enabled = true;
        }

        // Switch to operations mode
        private void mo_operation_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(550, 416);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            p_maintenance.Visible = false;
            p_operations.Visible = true;
            mo_maintenance.Enabled = true;
            mo_operation.Enabled = false;
        }

        // Select a predefined task
        private void b_task_Click(object sender, EventArgs e)
        {
            String selected = cb_taskselect.SelectedItem.ToString();
            try
            {
                if (comconnected)
                    switch (selected)
                    {
                        case "Find Red":
                            findColour(0);
                            break;
                        case "Find Green":
                            findColour(1);
                            break;
                        case "Find Blue":
                            findColour(2);
                            break;
                        case "Find Yellow":
                            findColour(3);
                            break;
                        case "Find White":
                            findColour(4);
                            break;
                        case "Test Distance":
                            sendToMBED("d,0");
                            int distance = processReadings(readFromMBED())[0];
                            if (distance < 255)
                                debug("In range.\r\n");
                            else
                                debug("Out of range.\r\n");
                            break;
                        case "List Colours":
                            debug("Listing all colours:\r\n");
                            rotateTurntable(0);
                            for (int i = 0; i < 4; i++)
                            {
                                Thread.Sleep(1000);
                                b_colourguess_Click(null, null);
                                rotateTurntable((i + 1) * 72);
                            }
                            Thread.Sleep(1000);
                            b_colourguess_Click(null, null);
                            rotateTurntable(0);
                            break;
                        default:
                            break;
                    }
                else debug("Please select a COM port and connnect.\r\n");
            }
            catch (IOException ex)
            {
                debug("Error in operation:" + ex.Message + "\r\n");
            }
            catch (InvalidOperationException exep)
            {
                debug("Invalid operation:" + exep.Message + "\r\n");
            }
        }

        // Refresh COM port list
        private void b_refreshcom_Click(object sender, EventArgs e)
        {
            cb_portselect.Items.Clear();
            debug("Available Ports:\r\n");
            foreach (string s in SerialPort.GetPortNames())
            {
                cb_portselect.Items.Add(s);
                debug(s + "\r\n");
            }
            if (SerialPort.GetPortNames().Length == 0)
            {
                debug("none\r\n");
                cb_portselect.SelectedIndex = -1;
                cb_portselect.Text = "";
            }
            else
            {
                cb_portselect.SelectedIndex = 0;
            }
            //Thread.Sleep(2000);   // sleep 2 seconds
        }

        // Call establishCOMConnection, print debug information based on success or failure
        private void b_comconnect_Click(object sender, EventArgs e)
        {
            try
            {
                string portname = cb_portselect.SelectedItem.ToString();
                comconnected = establishCOMConnection(portname);
                if (comconnected)
                {
                    debug("Connected to COM port " + portname + "\r\n");
                }
                else
                {
                    debug("Failed to connect to COM port.\r\n");
                }
            }
            catch (NullReferenceException ex)
            {
                debug("Invalid port name.\r\n");
            }
        }

        // Clears all data on serial port line
        private void b_comclear_Click(object sender, EventArgs e)
        {
            try
            {
                while (true)
                {
                    string portIn = serialPort1.ReadLine();
                    if (portIn.Length == 0)
                        return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        // Read colour from MBED, print output
        private void b_readcolour_Click(object sender, EventArgs e)
        {
            try
            {
                sendToMBED("c,0");
            }
            catch (Exception ex)
            {
                debug("Failed to request colour information:\r\n" + ex.Message + "\r\n");
                return;
            }
            try
            {
                string message = readFromMBED();
                if (char.Equals(message[0], 'c'))
                {
                    int[] vals = processReadings(message);
                    debug("Colour readings:\r\n c:" + vals[0] + ", r:" + vals[1] + ", g:" + vals[2] + ", b:" + vals[3] + "\r\n");
                }
                else
                {
                    debug("Unexpected message:\r\n  " + message + "\r\n");
                }
            }
            catch (Exception ex)
            {
                debug("Failed to read colour from port:\r\n  " + ex.Message + "\r\n");
            }
        }

        // Read distance from MBED, print output
        private void b_readdistance_Click(object sender, EventArgs e)
        {
            try
            {
                sendToMBED("d,0");
            }
            catch (Exception ex)
            {
                debug("Failed to request distance information:\r\n" + ex.Message + "\r\n");
                return;
            }
            try
            {
                string message = readFromMBED();
                if (char.Equals(message[0], 'd'))
                {
                    int[] vals = processReadings(message);
                    debug("Distance reading: " + vals[0] + "\r\n");
                }
                else
                {
                    debug("Unexpected message:\r\n  " + message + "\r\n");
                }
            }
            catch (Exception ex)
            {
                debug("Failed to read distance from port:\r\n  " + ex.Message + "\r\n");
            }
        }

        // Read colour and distance from MBED, print output
        private void b_readall_Click(object sender, EventArgs e)
        {
            try
            {
                sendToMBED("r,0");
            }
            catch (Exception ex)
            {
                debug("Failed to request sensor information:\r\n" + ex.Message + "\r\n");
                return;
            }
            try
            {
                string message = readFromMBED();
                if (char.Equals(message[0], 'r'))
                {
                    int[] vals = processReadings(message);
                    debug("Sensor readings:\r\n dist:" + vals[0] + ", c:" + vals[1] + ", r:" + vals[2] + ", g:" + vals[3] + ", b:" + vals[4] + "\r\n");
                }
                else
                {
                    debug("Unexpected message:\r\n  " + message + "\r\n");
                }
            }
            catch (Exception ex)
            {
                debug("Failed to read sensors from port:\r\n  " + ex.Message + "\r\n");
            }
        }

        // Set turntable angle
        private void b_turntableset_Click(object sender, EventArgs e)
        {
            int angle = Decimal.ToInt32(ud_servoangle.Value);
            try
            {
                sendToMBED("s,2,1," + angle);
            }
            catch (Exception ex)
            {
                debug("Failed to request turntable movement:\r\n" + ex.Message + "\r\n");
                return;
            }
            try
            {
                string message = readFromMBED();
                switch (message[0])
                {
                    case 'a':
                        debug("Task completed successfully.\r\n");
                        break;
                    case 'f':
                        debug("Failed to complete task: " + message + "\r\n");
                        break;
                    default:
                        debug("Unexpected message received:\r\n  " + message + "\r\n");
                        break;
                }
            }
            catch (TimeoutException ex)
            {
                debug("Timeout when reading from port:\r\n  " + ex.Message + "\r\n");
            }
            catch (IOException ex)
            {
                debug("Failed to read from port:\r\n  " + ex.Message + "\r\n");
            }
        }

        // Extend pusher
        private void b_push_Click(object sender, EventArgs e)
        {
            try
            {
                debug("Sending push message.\r\n");
                sendToMBED("s,2,0,1");
                string message = readFromMBED();
                switch (message[0])
                {
                    case 'a':
                        debug("Pushing...\r\n");
                        break;
                    case 'f':
                        debug("Failure: " + message + "\r\n");
                        return;
                    default:
                        debug("Unexpected message: " + message + "\r\n");
                        return;
                }
                Thread.Sleep(1000);
                debug("Sending pull message.\r\n");
                sendToMBED("s,2,0,0");
                message = readFromMBED();
                switch (message[0])
                {
                    case 'a':
                        debug("Pushing...\r\n");
                        break;
                    case 'f':
                        debug("Failure: " + message + "\r\n");
                        return;
                    default:
                        debug("Unexpected message: " + message + "\r\n");
                        return;
                }
                Thread.Sleep(1050);
                debug("Rotating to 0.\r\n");
                rotateTurntable(0);
                debug("Push operation complete.\r\n");
            }
            catch (Exception ex)
            {
                debug("Exception raised:\r\n" + ex.Message + "\r\n");
            }
        }

        // Send manually formed command
        private void b_sendcommand_Click(object sender, EventArgs e)
        {
            try
            {
                sendToMBED(tb_command.Text);
                string message = readFromMBED();
                debug("Return: " + message + "\r\n");
            }
            catch (Exception ex)
            {
                debug("Error in sending command:" + ex.Message + "\r\n");
            }
        }

        // Takes colour reading, prints colour guess
        private void b_colourguess_Click(object sender, EventArgs e)
        {
            try
            {
                int col = getColour();
                if (col == -1)
                    debug("I have no clue honestly.\r\n");
                else
                    debug("I think the colour is " + coltotext[col] + ".\r\n");
            }
            catch (Exception ex)
            {
                debug("Exception: " + ex.Message + "\r\n");
            }
        }

        // Text-to-speech for typed text
        private void b_speak_Click(object sender, EventArgs e)
        {
            speak.Speak(tb_speak.Text);
        }

        // Operation mode output - includes text and (if enabled) voice
        private void outputToUser(int text)
        {
            // 0  - error
            // 1  - red
            // 2  - green
            // 3  - blue
            // 4  - yellow
            // 5  - white
            // 6  - trying to find the [colour]
            // 7  - block
            // 8  - sorry i couldn't find the [colour]
            // 9  - block
            // 10 - waiting for robot
            // 11 - pushing block
            // 12 - robot leaves
            // 13 - connecting to alien
            tb_output.AppendText(messages[text, language, 0]);
            if (speechenabled)
                speak.Speak(messages[text, language, 1]);
        }

        // Operation mode start button
        private void b_start_Click(object sender, EventArgs e)
        {
            // Try/catch entire operation - possible errors thrown when reading to/writing from MBED
            try
            {
                // Connect to alien if not connected
                if (!comconnected)
                {
                    debug("Refreshing COM ports\r\n");
                    b_refreshcom_Click(null, null);
                    if (cb_portselect.Items.Count == 0)
                        throw new IOException("No COM ports available");
                    string portname = cb_portselect.SelectedItem.ToString();
                    debug("Connecting to port " + portname + "\r\n");
                    outputToUser(13);                           // "Connecting to alien..."
                    if (!establishCOMConnection(portname))
                    {
                        // Failure
                        throw new IOException("COM connection failed");
                    }
                    debug("Connected\r\n");
                }
                // Parse block request
                int block = cb_colourchoice.SelectedIndex - 1;
                debug("Block number:" + block + "\r\n");
                string message;
                outputToUser(6);                            // "Trying to find the
                outputToUser(block + 1);                    // colour
                outputToUser(7);                            // block."
                bool found = findColour(block);
                if (!found)
                {
                    rotateTurntable(0);
                    outputToUser(8);                        // Sorry, I couldn't find the
                    outputToUser(block + 1);                // colour
                    outputToUser(9);                        // block.
                    return;
                }
                // Wait for turtle
                outputToUser(10);                           // "Waiting for the robot."
                bool turtlehere = false;
                while (!turtlehere)
                {
                    sendToMBED("d,0");
                    message = readFromMBED();
                    if (message[0] != 'd')
                    {
                        debug("Distance error:" + message + "\r\n");
                        throw new IOException("Incorrect message recieved");
                    }
                    int[] data = processReadings(message);
                    turtlehere = (data[0] < 255 && data[0] > 0);
                }
                if (!turtlehere)
                {
                    // Used if waiting for turtle has a timer
                    throw new TimeoutException("Did not find robot in time");
                }
                // Push and retract
                outputToUser(11);                           // "Ah, here it is. Here you go, friend."
                b_push_Click(null, null);
                // Finished
                outputToUser(12);                           // "Bye-bye now!"
                return;
            }
            catch (TimeoutException ex)
            {
                debug("Timeout exception:\r\n" + ex.Message + "\r\n");
            }
            catch (IOException ex)
            {
                debug("IO exception:\r\n" + ex.Message + "\r\n");
            }
            catch (Exception ex)
            {
                debug("Exception:\r\n" + ex.Message + "\r\n");
            }
            outputToUser(0);                                // Returns before this point if no exceptions are thrown
        }

        // Operation mode combobox, greys out start if index 0
        private void cb_colourchoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            b_start.Enabled = !(cb_colourchoice.SelectedIndex == 0);
        }

        // Toggles text-to-speech
        private void ms_togglevoice_Click(object sender, EventArgs e)
        {
            speechenabled = !speechenabled;
            if (speechenabled)
                ms_togglevoice.Text = guitext[13, language];
            else
                ms_togglevoice.Text = guitext[12, language];
        }

        // Language selection - called when *any* language choice is selected
        // Used to make menu items act similarly to radiobuttons
        // Code modified from http://csharphelper.com/blog/2014/08/make-menu-items-act-like-radio-buttons-in-c/
        private void selectLanguage(ToolStripMenuItem menu, ToolStripMenuItem checked_item)
        {
            foreach (ToolStripItem item in menu.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu_item = item as ToolStripMenuItem;
                    menu_item.Checked = (menu_item == checked_item);
                }
            }
        }

        // English selected
        private void ml_language_english_Click(object sender, EventArgs e)
        {
            selectLanguage(ms_language, ml_language_english);
            changeLanguage(0);
        }

        // Italian selected
        private void ml_language_italian_Click(object sender, EventArgs e)
        {
            selectLanguage(ms_language, ml_language_italian);
            changeLanguage(1);
        }

        // Bulgarian selected
        private void ml_language_bulgarian_Click(object sender, EventArgs e)
        {
            selectLanguage(ms_language, ml_language_bulgarian);
            changeLanguage(2);
        }

    }
}