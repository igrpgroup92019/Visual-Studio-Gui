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
            this.l_operationinstructions = new System.Windows.Forms.Label();
            this.cb_colourchoice = new System.Windows.Forms.ComboBox();
            this.b_start = new System.Windows.Forms.Button();
            this.p_maintenance = new System.Windows.Forms.Panel();
            this.gb_tasks = new System.Windows.Forms.GroupBox();
            this.b_task = new System.Windows.Forms.Button();
            this.cb_taskselect = new System.Windows.Forms.ComboBox();
            this.gb_inputs = new System.Windows.Forms.GroupBox();
            this.b_readdistance = new System.Windows.Forms.Button();
            this.b_readcolour = new System.Windows.Forms.Button();
            this.gb_led = new System.Windows.Forms.GroupBox();
            this.b_ledset = new System.Windows.Forms.Button();
            this.clb_led = new System.Windows.Forms.CheckedListBox();
            this.gb_servos = new System.Windows.Forms.GroupBox();
            this.b_servoset = new System.Windows.Forms.Button();
            this.ud_servoangle = new System.Windows.Forms.NumericUpDown();
            this.cb_servoselect = new System.Windows.Forms.ComboBox();
            this.l_servoselect = new System.Windows.Forms.Label();
            this.l_servoangle = new System.Windows.Forms.Label();
            this.tb_debug = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.m_options = new System.Windows.Forms.ToolStripMenuItem();
            this.mo_maintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.mo_operation = new System.Windows.Forms.ToolStripMenuItem();
            this.mo_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.p_operations.SuspendLayout();
            this.p_maintenance.SuspendLayout();
            this.gb_tasks.SuspendLayout();
            this.gb_inputs.SuspendLayout();
            this.gb_led.SuspendLayout();
            this.gb_servos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_servoangle)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_operations
            // 
            this.p_operations.Controls.Add(this.l_operationinstructions);
            this.p_operations.Controls.Add(this.cb_colourchoice);
            this.p_operations.Controls.Add(this.b_start);
            this.p_operations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_operations.Location = new System.Drawing.Point(0, 28);
            this.p_operations.Name = "p_operations";
            this.p_operations.Size = new System.Drawing.Size(800, 422);
            this.p_operations.TabIndex = 0;
            // 
            // l_operationinstructions
            // 
            this.l_operationinstructions.AutoSize = true;
            this.l_operationinstructions.Location = new System.Drawing.Point(279, 152);
            this.l_operationinstructions.Name = "l_operationinstructions";
            this.l_operationinstructions.Size = new System.Drawing.Size(240, 17);
            this.l_operationinstructions.TabIndex = 3;
            this.l_operationinstructions.Text = "Select a block colour then click Start.";
            // 
            // cb_colourchoice
            // 
            this.cb_colourchoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_colourchoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_colourchoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_colourchoice.FormattingEnabled = true;
            this.cb_colourchoice.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.cb_colourchoice.Location = new System.Drawing.Point(335, 188);
            this.cb_colourchoice.Name = "cb_colourchoice";
            this.cb_colourchoice.Size = new System.Drawing.Size(121, 24);
            this.cb_colourchoice.TabIndex = 2;
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(360, 228);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(75, 23);
            this.b_start.TabIndex = 0;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            // 
            // p_maintenance
            // 
            this.p_maintenance.Controls.Add(this.gb_tasks);
            this.p_maintenance.Controls.Add(this.gb_inputs);
            this.p_maintenance.Controls.Add(this.gb_led);
            this.p_maintenance.Controls.Add(this.gb_servos);
            this.p_maintenance.Controls.Add(this.tb_debug);
            this.p_maintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_maintenance.Location = new System.Drawing.Point(0, 0);
            this.p_maintenance.Name = "p_maintenance";
            this.p_maintenance.Size = new System.Drawing.Size(800, 450);
            this.p_maintenance.TabIndex = 1;
            this.p_maintenance.Visible = false;
            // 
            // gb_tasks
            // 
            this.gb_tasks.Controls.Add(this.b_task);
            this.gb_tasks.Controls.Add(this.cb_taskselect);
            this.gb_tasks.Location = new System.Drawing.Point(238, 259);
            this.gb_tasks.Name = "gb_tasks";
            this.gb_tasks.Size = new System.Drawing.Size(200, 158);
            this.gb_tasks.TabIndex = 9;
            this.gb_tasks.TabStop = false;
            this.gb_tasks.Text = "Tasks";
            // 
            // b_task
            // 
            this.b_task.Location = new System.Drawing.Point(25, 67);
            this.b_task.Name = "b_task";
            this.b_task.Size = new System.Drawing.Size(121, 23);
            this.b_task.TabIndex = 1;
            this.b_task.Text = "Run";
            this.b_task.UseVisualStyleBackColor = true;
            // 
            // cb_taskselect
            // 
            this.cb_taskselect.FormattingEnabled = true;
            this.cb_taskselect.Items.AddRange(new object[] {
            "Test MBED Connection",
            "Test FPGA Connection",
            "Rotate Turntable",
            "Activate Pusher",
            "Find Red",
            "Find Green",
            "Find Blue",
            "Test Distance"});
            this.cb_taskselect.Location = new System.Drawing.Point(25, 38);
            this.cb_taskselect.Name = "cb_taskselect";
            this.cb_taskselect.Size = new System.Drawing.Size(121, 24);
            this.cb_taskselect.TabIndex = 0;
            // 
            // gb_inputs
            // 
            this.gb_inputs.Controls.Add(this.b_readdistance);
            this.gb_inputs.Controls.Add(this.b_readcolour);
            this.gb_inputs.Location = new System.Drawing.Point(12, 259);
            this.gb_inputs.Name = "gb_inputs";
            this.gb_inputs.Size = new System.Drawing.Size(200, 158);
            this.gb_inputs.TabIndex = 8;
            this.gb_inputs.TabStop = false;
            this.gb_inputs.Text = "Read Sensors";
            // 
            // b_readdistance
            // 
            this.b_readdistance.Location = new System.Drawing.Point(34, 68);
            this.b_readdistance.Name = "b_readdistance";
            this.b_readdistance.Size = new System.Drawing.Size(98, 23);
            this.b_readdistance.TabIndex = 1;
            this.b_readdistance.Text = "Distance";
            this.b_readdistance.UseVisualStyleBackColor = true;
            // 
            // b_readcolour
            // 
            this.b_readcolour.Location = new System.Drawing.Point(34, 38);
            this.b_readcolour.Name = "b_readcolour";
            this.b_readcolour.Size = new System.Drawing.Size(98, 23);
            this.b_readcolour.TabIndex = 0;
            this.b_readcolour.Text = "Colour";
            this.b_readcolour.UseVisualStyleBackColor = true;
            // 
            // gb_led
            // 
            this.gb_led.Controls.Add(this.b_ledset);
            this.gb_led.Controls.Add(this.clb_led);
            this.gb_led.Location = new System.Drawing.Point(238, 54);
            this.gb_led.Name = "gb_led";
            this.gb_led.Size = new System.Drawing.Size(200, 158);
            this.gb_led.TabIndex = 7;
            this.gb_led.TabStop = false;
            this.gb_led.Text = "LED Testing";
            // 
            // b_ledset
            // 
            this.b_ledset.Location = new System.Drawing.Point(25, 129);
            this.b_ledset.Name = "b_ledset";
            this.b_ledset.Size = new System.Drawing.Size(120, 23);
            this.b_ledset.TabIndex = 1;
            this.b_ledset.Text = "Set LEDs";
            this.b_ledset.UseVisualStyleBackColor = true;
            // 
            // clb_led
            // 
            this.clb_led.FormattingEnabled = true;
            this.clb_led.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.clb_led.Location = new System.Drawing.Point(25, 38);
            this.clb_led.Name = "clb_led";
            this.clb_led.Size = new System.Drawing.Size(120, 89);
            this.clb_led.TabIndex = 0;
            // 
            // gb_servos
            // 
            this.gb_servos.Controls.Add(this.b_servoset);
            this.gb_servos.Controls.Add(this.ud_servoangle);
            this.gb_servos.Controls.Add(this.cb_servoselect);
            this.gb_servos.Controls.Add(this.l_servoselect);
            this.gb_servos.Controls.Add(this.l_servoangle);
            this.gb_servos.Location = new System.Drawing.Point(12, 54);
            this.gb_servos.Name = "gb_servos";
            this.gb_servos.Size = new System.Drawing.Size(200, 158);
            this.gb_servos.TabIndex = 6;
            this.gb_servos.TabStop = false;
            this.gb_servos.Text = "Servo Control";
            // 
            // b_servoset
            // 
            this.b_servoset.Location = new System.Drawing.Point(63, 129);
            this.b_servoset.Name = "b_servoset";
            this.b_servoset.Size = new System.Drawing.Size(121, 23);
            this.b_servoset.TabIndex = 7;
            this.b_servoset.Text = "Go";
            this.b_servoset.UseVisualStyleBackColor = true;
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
            // cb_servoselect
            // 
            this.cb_servoselect.FormattingEnabled = true;
            this.cb_servoselect.Items.AddRange(new object[] {
            "Turntable",
            "Pusher"});
            this.cb_servoselect.Location = new System.Drawing.Point(63, 38);
            this.cb_servoselect.Name = "cb_servoselect";
            this.cb_servoselect.Size = new System.Drawing.Size(121, 24);
            this.cb_servoselect.TabIndex = 7;
            // 
            // l_servoselect
            // 
            this.l_servoselect.AutoSize = true;
            this.l_servoselect.Location = new System.Drawing.Point(6, 38);
            this.l_servoselect.Name = "l_servoselect";
            this.l_servoselect.Size = new System.Drawing.Size(45, 17);
            this.l_servoselect.TabIndex = 3;
            this.l_servoselect.Text = "Servo";
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
            // tb_debug
            // 
            this.tb_debug.Location = new System.Drawing.Point(444, 54);
            this.tb_debug.Multiline = true;
            this.tb_debug.Name = "tb_debug";
            this.tb_debug.Size = new System.Drawing.Size(344, 384);
            this.tb_debug.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_options});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.p_operations);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.p_maintenance);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.p_operations.ResumeLayout(false);
            this.p_operations.PerformLayout();
            this.p_maintenance.ResumeLayout(false);
            this.p_maintenance.PerformLayout();
            this.gb_tasks.ResumeLayout(false);
            this.gb_inputs.ResumeLayout(false);
            this.gb_led.ResumeLayout(false);
            this.gb_servos.ResumeLayout(false);
            this.gb_servos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_servoangle)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_operations;
        private System.Windows.Forms.ComboBox cb_colourchoice;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.Panel p_maintenance;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m_options;
        private System.Windows.Forms.ToolStripMenuItem mo_maintenance;
        private System.Windows.Forms.ToolStripMenuItem mo_operation;
        private System.Windows.Forms.ToolStripMenuItem mo_exit;
        private System.Windows.Forms.Label l_operationinstructions;
        private System.Windows.Forms.Label l_servoselect;
        private System.Windows.Forms.Label l_servoangle;
        private System.Windows.Forms.TextBox tb_debug;
        private System.Windows.Forms.GroupBox gb_servos;
        private System.Windows.Forms.ComboBox cb_servoselect;
        private System.Windows.Forms.NumericUpDown ud_servoangle;
        private System.Windows.Forms.Button b_servoset;
        private System.Windows.Forms.GroupBox gb_led;
        private System.Windows.Forms.Button b_ledset;
        private System.Windows.Forms.CheckedListBox clb_led;
        private System.Windows.Forms.GroupBox gb_inputs;
        private System.Windows.Forms.Button b_readdistance;
        private System.Windows.Forms.Button b_readcolour;
        private System.Windows.Forms.GroupBox gb_tasks;
        private System.Windows.Forms.Button b_task;
        private System.Windows.Forms.ComboBox cb_taskselect;
    }
}

