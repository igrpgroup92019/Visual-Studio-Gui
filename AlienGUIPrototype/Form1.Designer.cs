namespace AlienGUIPrototype
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.p_operations = new System.Windows.Forms.Panel();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.cb_colourchoice = new System.Windows.Forms.ComboBox();
            this.b_start = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.m_options = new System.Windows.Forms.ToolStripMenuItem();
            this.mo_maintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.mo_operation = new System.Windows.Forms.ToolStripMenuItem();
            this.mo_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_togglevoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_language = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_language_english = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_language_other = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_debug = new System.Windows.Forms.TextBox();
            this.gb_servos = new System.Windows.Forms.GroupBox();
            this.b_servoset = new System.Windows.Forms.Button();
            this.ud_servoangle = new System.Windows.Forms.NumericUpDown();
            this.l_servoangle = new System.Windows.Forms.Label();
            this.gb_inputs = new System.Windows.Forms.GroupBox();
            this.b_readall = new System.Windows.Forms.Button();
            this.b_readdistance = new System.Windows.Forms.Button();
            this.b_readcolour = new System.Windows.Forms.Button();
            this.gb_tasks = new System.Windows.Forms.GroupBox();
            this.b_task = new System.Windows.Forms.Button();
            this.cb_taskselect = new System.Windows.Forms.ComboBox();
            this.gb_com = new System.Windows.Forms.GroupBox();
            this.b_comconnect = new System.Windows.Forms.Button();
            this.b_refreshcom = new System.Windows.Forms.Button();
            this.l_comselect = new System.Windows.Forms.Label();
            this.cb_portselect = new System.Windows.Forms.ComboBox();
            this.p_maintenance = new System.Windows.Forms.Panel();
            this.gb_speak = new System.Windows.Forms.GroupBox();
            this.tb_speak = new System.Windows.Forms.TextBox();
            this.b_speak = new System.Windows.Forms.Button();
            this.l_speak = new System.Windows.Forms.Label();
            this.gb_manualcommand = new System.Windows.Forms.GroupBox();
            this.tb_command = new System.Windows.Forms.TextBox();
            this.b_sendcommand = new System.Windows.Forms.Button();
            this.p_operations.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gb_servos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_servoangle)).BeginInit();
            this.gb_inputs.SuspendLayout();
            this.gb_tasks.SuspendLayout();
            this.gb_com.SuspendLayout();
            this.p_maintenance.SuspendLayout();
            this.gb_speak.SuspendLayout();
            this.gb_manualcommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_operations
            // 
            this.p_operations.Controls.Add(this.tb_output);
            this.p_operations.Controls.Add(this.cb_colourchoice);
            this.p_operations.Controls.Add(this.b_start);
            this.p_operations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_operations.Location = new System.Drawing.Point(0, 0);
            this.p_operations.Name = "p_operations";
            this.p_operations.Size = new System.Drawing.Size(1303, 464);
            this.p_operations.TabIndex = 0;
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(549, 127);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.Size = new System.Drawing.Size(317, 212);
            this.tb_output.TabIndex = 4;
            // 
            // cb_colourchoice
            // 
            this.cb_colourchoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_colourchoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_colourchoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_colourchoice.FormattingEnabled = true;
            this.cb_colourchoice.Items.AddRange(new object[] {
            "Select a colour...",
            "Red",
            "Green",
            "Blue",
            "Yellow",
            "White"});
            this.cb_colourchoice.Location = new System.Drawing.Point(296, 159);
            this.cb_colourchoice.Name = "cb_colourchoice";
            this.cb_colourchoice.Size = new System.Drawing.Size(197, 24);
            this.cb_colourchoice.TabIndex = 2;
            this.cb_colourchoice.SelectedIndexChanged += new System.EventHandler(this.cb_colourchoice_SelectedIndexChanged);
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(359, 233);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(75, 23);
            this.b_start.TabIndex = 0;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_options,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1303, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // m_options
            // 
            this.m_options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mo_maintenance,
            this.mo_operation,
            this.mo_exit});
            this.m_options.Name = "m_options";
            this.m_options.Size = new System.Drawing.Size(73, 24);
            this.m_options.Text = "Options";
            // 
            // mo_maintenance
            // 
            this.mo_maintenance.Name = "mo_maintenance";
            this.mo_maintenance.Size = new System.Drawing.Size(169, 26);
            this.mo_maintenance.Text = "Maintenance";
            this.mo_maintenance.Click += new System.EventHandler(this.mo_maintenance_Click);
            // 
            // mo_operation
            // 
            this.mo_operation.Enabled = false;
            this.mo_operation.Name = "mo_operation";
            this.mo_operation.Size = new System.Drawing.Size(169, 26);
            this.mo_operation.Text = "Operation";
            this.mo_operation.Click += new System.EventHandler(this.mo_operation_Click);
            // 
            // mo_exit
            // 
            this.mo_exit.Name = "mo_exit";
            this.mo_exit.Size = new System.Drawing.Size(169, 26);
            this.mo_exit.Text = "Exit";
            this.mo_exit.Click += new System.EventHandler(this.mo_exit_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_togglevoice,
            this.mi_language});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // mi_togglevoice
            // 
            this.mi_togglevoice.Name = "mi_togglevoice";
            this.mi_togglevoice.Size = new System.Drawing.Size(169, 26);
            this.mi_togglevoice.Text = "Enable Voice";
            this.mi_togglevoice.Click += new System.EventHandler(this.mi_togglevoice_Click);
            // 
            // mi_language
            // 
            this.mi_language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_language_english,
            this.mi_language_other});
            this.mi_language.Name = "mi_language";
            this.mi_language.Size = new System.Drawing.Size(169, 26);
            this.mi_language.Text = "Language";
            // 
            // mi_language_english
            // 
            this.mi_language_english.Checked = true;
            this.mi_language_english.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mi_language_english.Name = "mi_language_english";
            this.mi_language_english.Size = new System.Drawing.Size(131, 26);
            this.mi_language_english.Text = "English";
            this.mi_language_english.Click += new System.EventHandler(this.mi_language_english_Click);
            // 
            // mi_language_other
            // 
            this.mi_language_other.Name = "mi_language_other";
            this.mi_language_other.Size = new System.Drawing.Size(131, 26);
            this.mi_language_other.Text = "Other";
            this.mi_language_other.Click += new System.EventHandler(this.mi_language_other_Click);
            // 
            // tb_debug
            // 
            this.tb_debug.Location = new System.Drawing.Point(505, 31);
            this.tb_debug.Multiline = true;
            this.tb_debug.Name = "tb_debug";
            this.tb_debug.ReadOnly = true;
            this.tb_debug.Size = new System.Drawing.Size(431, 423);
            this.tb_debug.TabIndex = 5;
            // 
            // gb_servos
            // 
            this.gb_servos.Controls.Add(this.b_servoset);
            this.gb_servos.Controls.Add(this.ud_servoangle);
            this.gb_servos.Controls.Add(this.l_servoangle);
            this.gb_servos.Location = new System.Drawing.Point(12, 31);
            this.gb_servos.Name = "gb_servos";
            this.gb_servos.Size = new System.Drawing.Size(200, 158);
            this.gb_servos.TabIndex = 6;
            this.gb_servos.TabStop = false;
            this.gb_servos.Text = "Servo Control";
            // 
            // b_servoset
            // 
            this.b_servoset.Location = new System.Drawing.Point(64, 111);
            this.b_servoset.Name = "b_servoset";
            this.b_servoset.Size = new System.Drawing.Size(121, 23);
            this.b_servoset.TabIndex = 7;
            this.b_servoset.Text = "Go";
            this.b_servoset.UseVisualStyleBackColor = true;
            this.b_servoset.Click += new System.EventHandler(this.b_servoset_Click);
            // 
            // ud_servoangle
            // 
            this.ud_servoangle.Location = new System.Drawing.Point(64, 69);
            this.ud_servoangle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.ud_servoangle.Name = "ud_servoangle";
            this.ud_servoangle.Size = new System.Drawing.Size(120, 22);
            this.ud_servoangle.TabIndex = 8;
            // 
            // l_servoangle
            // 
            this.l_servoangle.AutoSize = true;
            this.l_servoangle.Location = new System.Drawing.Point(6, 68);
            this.l_servoangle.Name = "l_servoangle";
            this.l_servoangle.Size = new System.Drawing.Size(44, 17);
            this.l_servoangle.TabIndex = 4;
            this.l_servoangle.Text = "Angle";
            // 
            // gb_inputs
            // 
            this.gb_inputs.Controls.Add(this.b_readall);
            this.gb_inputs.Controls.Add(this.b_readdistance);
            this.gb_inputs.Controls.Add(this.b_readcolour);
            this.gb_inputs.Location = new System.Drawing.Point(12, 195);
            this.gb_inputs.Name = "gb_inputs";
            this.gb_inputs.Size = new System.Drawing.Size(200, 144);
            this.gb_inputs.TabIndex = 8;
            this.gb_inputs.TabStop = false;
            this.gb_inputs.Text = "Read Sensors";
            // 
            // b_readall
            // 
            this.b_readall.Location = new System.Drawing.Point(34, 97);
            this.b_readall.Name = "b_readall";
            this.b_readall.Size = new System.Drawing.Size(98, 23);
            this.b_readall.TabIndex = 2;
            this.b_readall.Text = "All";
            this.b_readall.UseVisualStyleBackColor = true;
            this.b_readall.Click += new System.EventHandler(this.b_readall_Click);
            // 
            // b_readdistance
            // 
            this.b_readdistance.Location = new System.Drawing.Point(34, 68);
            this.b_readdistance.Name = "b_readdistance";
            this.b_readdistance.Size = new System.Drawing.Size(98, 23);
            this.b_readdistance.TabIndex = 1;
            this.b_readdistance.Text = "Distance";
            this.b_readdistance.UseVisualStyleBackColor = true;
            this.b_readdistance.Click += new System.EventHandler(this.b_readdistance_Click);
            // 
            // b_readcolour
            // 
            this.b_readcolour.Location = new System.Drawing.Point(34, 38);
            this.b_readcolour.Name = "b_readcolour";
            this.b_readcolour.Size = new System.Drawing.Size(98, 23);
            this.b_readcolour.TabIndex = 0;
            this.b_readcolour.Text = "Colour";
            this.b_readcolour.UseVisualStyleBackColor = true;
            this.b_readcolour.Click += new System.EventHandler(this.b_readcolour_Click);
            // 
            // gb_tasks
            // 
            this.gb_tasks.Controls.Add(this.b_task);
            this.gb_tasks.Controls.Add(this.cb_taskselect);
            this.gb_tasks.Location = new System.Drawing.Point(218, 195);
            this.gb_tasks.Name = "gb_tasks";
            this.gb_tasks.Size = new System.Drawing.Size(281, 144);
            this.gb_tasks.TabIndex = 9;
            this.gb_tasks.TabStop = false;
            this.gb_tasks.Text = "Tasks";
            // 
            // b_task
            // 
            this.b_task.Location = new System.Drawing.Point(76, 85);
            this.b_task.Name = "b_task";
            this.b_task.Size = new System.Drawing.Size(121, 23);
            this.b_task.TabIndex = 1;
            this.b_task.Text = "Run";
            this.b_task.UseVisualStyleBackColor = true;
            this.b_task.Click += new System.EventHandler(this.b_task_Click);
            // 
            // cb_taskselect
            // 
            this.cb_taskselect.FormattingEnabled = true;
            this.cb_taskselect.Items.AddRange(new object[] {
            "Find Red",
            "Find Green",
            "Find Blue",
            "Find Yellow",
            "Find White",
            "Test Distance",
            "Rotate Turntable Once",
            "Activate Pusher"});
            this.cb_taskselect.Location = new System.Drawing.Point(10, 38);
            this.cb_taskselect.Name = "cb_taskselect";
            this.cb_taskselect.Size = new System.Drawing.Size(265, 24);
            this.cb_taskselect.TabIndex = 0;
            // 
            // gb_com
            // 
            this.gb_com.Controls.Add(this.b_comconnect);
            this.gb_com.Controls.Add(this.b_refreshcom);
            this.gb_com.Controls.Add(this.l_comselect);
            this.gb_com.Controls.Add(this.cb_portselect);
            this.gb_com.Location = new System.Drawing.Point(218, 31);
            this.gb_com.Name = "gb_com";
            this.gb_com.Size = new System.Drawing.Size(281, 158);
            this.gb_com.TabIndex = 11;
            this.gb_com.TabStop = false;
            this.gb_com.Text = "COM Ports";
            // 
            // b_comconnect
            // 
            this.b_comconnect.Location = new System.Drawing.Point(41, 92);
            this.b_comconnect.Name = "b_comconnect";
            this.b_comconnect.Size = new System.Drawing.Size(75, 23);
            this.b_comconnect.TabIndex = 13;
            this.b_comconnect.Text = "Connect";
            this.b_comconnect.UseVisualStyleBackColor = true;
            this.b_comconnect.Click += new System.EventHandler(this.b_comconnect_Click);
            // 
            // b_refreshcom
            // 
            this.b_refreshcom.Location = new System.Drawing.Point(122, 92);
            this.b_refreshcom.Name = "b_refreshcom";
            this.b_refreshcom.Size = new System.Drawing.Size(121, 23);
            this.b_refreshcom.TabIndex = 12;
            this.b_refreshcom.Text = "Refresh List";
            this.b_refreshcom.UseVisualStyleBackColor = true;
            this.b_refreshcom.Click += new System.EventHandler(this.b_refreshcom_Click);
            // 
            // l_comselect
            // 
            this.l_comselect.AutoSize = true;
            this.l_comselect.Location = new System.Drawing.Point(38, 38);
            this.l_comselect.Name = "l_comselect";
            this.l_comselect.Size = new System.Drawing.Size(77, 17);
            this.l_comselect.TabIndex = 11;
            this.l_comselect.Text = "Port Select";
            // 
            // cb_portselect
            // 
            this.cb_portselect.FormattingEnabled = true;
            this.cb_portselect.Location = new System.Drawing.Point(122, 38);
            this.cb_portselect.Name = "cb_portselect";
            this.cb_portselect.Size = new System.Drawing.Size(121, 24);
            this.cb_portselect.TabIndex = 10;
            // 
            // p_maintenance
            // 
            this.p_maintenance.Controls.Add(this.gb_manualcommand);
            this.p_maintenance.Controls.Add(this.gb_speak);
            this.p_maintenance.Controls.Add(this.gb_com);
            this.p_maintenance.Controls.Add(this.gb_tasks);
            this.p_maintenance.Controls.Add(this.gb_inputs);
            this.p_maintenance.Controls.Add(this.gb_servos);
            this.p_maintenance.Controls.Add(this.tb_debug);
            this.p_maintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_maintenance.Location = new System.Drawing.Point(0, 0);
            this.p_maintenance.Name = "p_maintenance";
            this.p_maintenance.Size = new System.Drawing.Size(1303, 464);
            this.p_maintenance.TabIndex = 1;
            // 
            // gb_speak
            // 
            this.gb_speak.Controls.Add(this.tb_speak);
            this.gb_speak.Controls.Add(this.b_speak);
            this.gb_speak.Controls.Add(this.l_speak);
            this.gb_speak.Location = new System.Drawing.Point(12, 345);
            this.gb_speak.Name = "gb_speak";
            this.gb_speak.Size = new System.Drawing.Size(487, 109);
            this.gb_speak.TabIndex = 9;
            this.gb_speak.TabStop = false;
            this.gb_speak.Text = "Speech Synthesis";
            // 
            // tb_speak
            // 
            this.tb_speak.Location = new System.Drawing.Point(47, 38);
            this.tb_speak.Name = "tb_speak";
            this.tb_speak.Size = new System.Drawing.Size(434, 22);
            this.tb_speak.TabIndex = 8;
            // 
            // b_speak
            // 
            this.b_speak.Location = new System.Drawing.Point(201, 66);
            this.b_speak.Name = "b_speak";
            this.b_speak.Size = new System.Drawing.Size(121, 28);
            this.b_speak.TabIndex = 7;
            this.b_speak.Text = "Speak";
            this.b_speak.UseVisualStyleBackColor = true;
            this.b_speak.Click += new System.EventHandler(this.b_speak_Click);
            // 
            // l_speak
            // 
            this.l_speak.AutoSize = true;
            this.l_speak.Location = new System.Drawing.Point(6, 38);
            this.l_speak.Name = "l_speak";
            this.l_speak.Size = new System.Drawing.Size(35, 17);
            this.l_speak.TabIndex = 3;
            this.l_speak.Text = "Text";
            // 
            // gb_manualcommand
            // 
            this.gb_manualcommand.Controls.Add(this.b_sendcommand);
            this.gb_manualcommand.Controls.Add(this.tb_command);
            this.gb_manualcommand.Location = new System.Drawing.Point(955, 32);
            this.gb_manualcommand.Name = "gb_manualcommand";
            this.gb_manualcommand.Size = new System.Drawing.Size(200, 100);
            this.gb_manualcommand.TabIndex = 12;
            this.gb_manualcommand.TabStop = false;
            this.gb_manualcommand.Text = "Command";
            // 
            // tb_command
            // 
            this.tb_command.Location = new System.Drawing.Point(7, 34);
            this.tb_command.Name = "tb_command";
            this.tb_command.Size = new System.Drawing.Size(187, 22);
            this.tb_command.TabIndex = 0;
            // 
            // b_sendcommand
            // 
            this.b_sendcommand.Location = new System.Drawing.Point(7, 67);
            this.b_sendcommand.Name = "b_sendcommand";
            this.b_sendcommand.Size = new System.Drawing.Size(75, 23);
            this.b_sendcommand.TabIndex = 1;
            this.b_sendcommand.Text = "Send";
            this.b_sendcommand.UseVisualStyleBackColor = true;
            this.b_sendcommand.Click += new System.EventHandler(this.b_sendcommand_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 464);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.p_maintenance);
            this.Controls.Add(this.p_operations);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Alien Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.p_operations.ResumeLayout(false);
            this.p_operations.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gb_servos.ResumeLayout(false);
            this.gb_servos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_servoangle)).EndInit();
            this.gb_inputs.ResumeLayout(false);
            this.gb_tasks.ResumeLayout(false);
            this.gb_com.ResumeLayout(false);
            this.gb_com.PerformLayout();
            this.p_maintenance.ResumeLayout(false);
            this.p_maintenance.PerformLayout();
            this.gb_speak.ResumeLayout(false);
            this.gb_speak.PerformLayout();
            this.gb_manualcommand.ResumeLayout(false);
            this.gb_manualcommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_operations;
        private System.Windows.Forms.ComboBox cb_colourchoice;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m_options;
        private System.Windows.Forms.ToolStripMenuItem mo_maintenance;
        private System.Windows.Forms.ToolStripMenuItem mo_operation;
        private System.Windows.Forms.ToolStripMenuItem mo_exit;
        private System.Windows.Forms.TextBox tb_debug;
        private System.Windows.Forms.GroupBox gb_servos;
        private System.Windows.Forms.Button b_servoset;
        private System.Windows.Forms.NumericUpDown ud_servoangle;
        private System.Windows.Forms.Label l_servoangle;
        private System.Windows.Forms.GroupBox gb_inputs;
        private System.Windows.Forms.Button b_readall;
        private System.Windows.Forms.Button b_readdistance;
        private System.Windows.Forms.Button b_readcolour;
        private System.Windows.Forms.GroupBox gb_tasks;
        private System.Windows.Forms.Button b_task;
        private System.Windows.Forms.ComboBox cb_taskselect;
        private System.Windows.Forms.GroupBox gb_com;
        private System.Windows.Forms.Button b_comconnect;
        private System.Windows.Forms.Button b_refreshcom;
        private System.Windows.Forms.Label l_comselect;
        private System.Windows.Forms.ComboBox cb_portselect;
        private System.Windows.Forms.Panel p_maintenance;
        private System.Windows.Forms.GroupBox gb_speak;
        private System.Windows.Forms.TextBox tb_speak;
        private System.Windows.Forms.Button b_speak;
        private System.Windows.Forms.Label l_speak;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_language;
        private System.Windows.Forms.ToolStripMenuItem mi_language_english;
        private System.Windows.Forms.ToolStripMenuItem mi_togglevoice;
        private System.Windows.Forms.ToolStripMenuItem mi_language_other;
        private System.Windows.Forms.GroupBox gb_manualcommand;
        private System.Windows.Forms.Button b_sendcommand;
        private System.Windows.Forms.TextBox tb_command;
    }
}

