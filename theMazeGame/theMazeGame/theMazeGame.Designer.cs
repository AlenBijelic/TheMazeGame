namespace theMazeGame
{
    partial class theMazeGame
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(theMazeGame));
            this.panelGame = new System.Windows.Forms.Panel();
            this.panelTopMenu = new System.Windows.Forms.Panel();
            this.buttonExit2 = new System.Windows.Forms.Button();
            this.labelGameTitle = new System.Windows.Forms.Label();
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.buttonDisplayScores = new System.Windows.Forms.Button();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.groupBoxTimerSpeed = new System.Windows.Forms.GroupBox();
            this.radioButtonTimerHard = new System.Windows.Forms.RadioButton();
            this.radioButtonTimerRegular = new System.Windows.Forms.RadioButton();
            this.radioButtonTimerEasy = new System.Windows.Forms.RadioButton();
            this.labelMouseSense = new System.Windows.Forms.Label();
            this.trackBarMouseSensitivity = new System.Windows.Forms.TrackBar();
            this.PanelInstructions = new System.Windows.Forms.Panel();
            this.pictureBoxDisplayLevel = new System.Windows.Forms.PictureBox();
            this.buttonInstructions = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.comboBoxChooseLevel = new System.Windows.Forms.ComboBox();
            this.labelLife = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelGeneratePanel = new System.Windows.Forms.Panel();
            this.labelChrono = new System.Windows.Forms.Label();
            this.timerFlash = new System.Windows.Forms.Timer(this.components);
            this.groupBoxInstruction1 = new System.Windows.Forms.GroupBox();
            this.groupBoxInstruction2 = new System.Windows.Forms.GroupBox();
            this.groupBoxInstruction3 = new System.Windows.Forms.GroupBox();
            this.groupBoxInstruction4 = new System.Windows.Forms.GroupBox();
            this.richTextBoxInstruction1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.panelGame.SuspendLayout();
            this.panelTopMenu.SuspendLayout();
            this.panelMainMenu.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.groupBoxTimerSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMouseSensitivity)).BeginInit();
            this.PanelInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplayLevel)).BeginInit();
            this.groupBoxInstruction1.SuspendLayout();
            this.groupBoxInstruction2.SuspendLayout();
            this.groupBoxInstruction3.SuspendLayout();
            this.groupBoxInstruction4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGame.Controls.Add(this.panelTopMenu);
            this.panelGame.Controls.Add(this.panelMainMenu);
            this.panelGame.Controls.Add(this.labelLife);
            this.panelGame.Controls.Add(this.buttonRestart);
            this.panelGame.Controls.Add(this.buttonStart);
            this.panelGame.Controls.Add(this.panelGeneratePanel);
            this.panelGame.Controls.Add(this.labelChrono);
            this.panelGame.Location = new System.Drawing.Point(-1, -1);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(900, 893);
            this.panelGame.TabIndex = 4;
            // 
            // panelTopMenu
            // 
            this.panelTopMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelTopMenu.Controls.Add(this.buttonExit2);
            this.panelTopMenu.Controls.Add(this.labelGameTitle);
            this.panelTopMenu.Location = new System.Drawing.Point(-1, -1);
            this.panelTopMenu.Name = "panelTopMenu";
            this.panelTopMenu.Size = new System.Drawing.Size(900, 40);
            this.panelTopMenu.TabIndex = 7;
            this.panelTopMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopMenu_MouseDown);
            // 
            // buttonExit2
            // 
            this.buttonExit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonExit2.Location = new System.Drawing.Point(855, 5);
            this.buttonExit2.Name = "buttonExit2";
            this.buttonExit2.Size = new System.Drawing.Size(30, 30);
            this.buttonExit2.TabIndex = 1;
            this.buttonExit2.Text = "X";
            this.buttonExit2.UseVisualStyleBackColor = true;
            this.buttonExit2.Click += new System.EventHandler(this.buttonExit2_Click);
            // 
            // labelGameTitle
            // 
            this.labelGameTitle.AutoSize = true;
            this.labelGameTitle.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelGameTitle.Location = new System.Drawing.Point(345, 10);
            this.labelGameTitle.Name = "labelGameTitle";
            this.labelGameTitle.Size = new System.Drawing.Size(180, 24);
            this.labelGameTitle.TabIndex = 0;
            this.labelGameTitle.Text = "The Maze Game";
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.Controls.Add(this.PanelInstructions);
            this.panelMainMenu.Controls.Add(this.buttonDisplayScores);
            this.panelMainMenu.Controls.Add(this.panelOptions);
            this.panelMainMenu.Controls.Add(this.pictureBoxDisplayLevel);
            this.panelMainMenu.Controls.Add(this.buttonInstructions);
            this.panelMainMenu.Controls.Add(this.buttonExit);
            this.panelMainMenu.Controls.Add(this.buttonOptions);
            this.panelMainMenu.Controls.Add(this.buttonPlay);
            this.panelMainMenu.Controls.Add(this.comboBoxChooseLevel);
            this.panelMainMenu.Location = new System.Drawing.Point(-1, -1);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(900, 889);
            this.panelMainMenu.TabIndex = 7;
            // 
            // buttonDisplayScores
            // 
            this.buttonDisplayScores.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonDisplayScores.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonDisplayScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisplayScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonDisplayScores.ForeColor = System.Drawing.Color.White;
            this.buttonDisplayScores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonDisplayScores.Location = new System.Drawing.Point(50, 687);
            this.buttonDisplayScores.Name = "buttonDisplayScores";
            this.buttonDisplayScores.Size = new System.Drawing.Size(150, 75);
            this.buttonDisplayScores.TabIndex = 10;
            this.buttonDisplayScores.Text = "Scores";
            this.buttonDisplayScores.UseVisualStyleBackColor = false;
            this.buttonDisplayScores.Click += new System.EventHandler(this.buttonDisplayScores_Click);
            // 
            // panelOptions
            // 
            this.panelOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptions.Controls.Add(this.groupBoxTimerSpeed);
            this.panelOptions.Controls.Add(this.labelMouseSense);
            this.panelOptions.Controls.Add(this.trackBarMouseSensitivity);
            this.panelOptions.Location = new System.Drawing.Point(-1, -1);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(900, 600);
            this.panelOptions.TabIndex = 6;
            this.panelOptions.Visible = false;
            // 
            // groupBoxTimerSpeed
            // 
            this.groupBoxTimerSpeed.Controls.Add(this.radioButtonTimerHard);
            this.groupBoxTimerSpeed.Controls.Add(this.radioButtonTimerRegular);
            this.groupBoxTimerSpeed.Controls.Add(this.radioButtonTimerEasy);
            this.groupBoxTimerSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxTimerSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTimerSpeed.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBoxTimerSpeed.Location = new System.Drawing.Point(105, 51);
            this.groupBoxTimerSpeed.Name = "groupBoxTimerSpeed";
            this.groupBoxTimerSpeed.Size = new System.Drawing.Size(200, 200);
            this.groupBoxTimerSpeed.TabIndex = 3;
            this.groupBoxTimerSpeed.TabStop = false;
            this.groupBoxTimerSpeed.Text = "Timer level";
            // 
            // radioButtonTimerHard
            // 
            this.radioButtonTimerHard.AutoSize = true;
            this.radioButtonTimerHard.Location = new System.Drawing.Point(30, 150);
            this.radioButtonTimerHard.Name = "radioButtonTimerHard";
            this.radioButtonTimerHard.Size = new System.Drawing.Size(76, 29);
            this.radioButtonTimerHard.TabIndex = 2;
            this.radioButtonTimerHard.Text = "Hard";
            this.radioButtonTimerHard.UseVisualStyleBackColor = true;
            this.radioButtonTimerHard.CheckedChanged += new System.EventHandler(this.radioButtonTimerHard_CheckedChanged);
            // 
            // radioButtonTimerRegular
            // 
            this.radioButtonTimerRegular.AutoSize = true;
            this.radioButtonTimerRegular.Location = new System.Drawing.Point(30, 90);
            this.radioButtonTimerRegular.Name = "radioButtonTimerRegular";
            this.radioButtonTimerRegular.Size = new System.Drawing.Size(105, 29);
            this.radioButtonTimerRegular.TabIndex = 1;
            this.radioButtonTimerRegular.Text = "Regular";
            this.radioButtonTimerRegular.UseVisualStyleBackColor = true;
            this.radioButtonTimerRegular.CheckedChanged += new System.EventHandler(this.radioButtonTimerRegular_CheckedChanged);
            // 
            // radioButtonTimerEasy
            // 
            this.radioButtonTimerEasy.AutoSize = true;
            this.radioButtonTimerEasy.Checked = true;
            this.radioButtonTimerEasy.Location = new System.Drawing.Point(30, 30);
            this.radioButtonTimerEasy.Name = "radioButtonTimerEasy";
            this.radioButtonTimerEasy.Size = new System.Drawing.Size(78, 29);
            this.radioButtonTimerEasy.TabIndex = 0;
            this.radioButtonTimerEasy.TabStop = true;
            this.radioButtonTimerEasy.Text = "Easy";
            this.radioButtonTimerEasy.UseVisualStyleBackColor = true;
            this.radioButtonTimerEasy.CheckedChanged += new System.EventHandler(this.radioButtonTimerEasy_CheckedChanged);
            // 
            // labelMouseSense
            // 
            this.labelMouseSense.AutoSize = true;
            this.labelMouseSense.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.labelMouseSense.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMouseSense.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelMouseSense.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelMouseSense.Location = new System.Drawing.Point(555, 86);
            this.labelMouseSense.Name = "labelMouseSense";
            this.labelMouseSense.Size = new System.Drawing.Size(181, 25);
            this.labelMouseSense.TabIndex = 2;
            this.labelMouseSense.Text = "Mouse Sensibility";
            // 
            // trackBarMouseSensitivity
            // 
            this.trackBarMouseSensitivity.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.trackBarMouseSensitivity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBarMouseSensitivity.Location = new System.Drawing.Point(349, 81);
            this.trackBarMouseSensitivity.Maximum = 20;
            this.trackBarMouseSensitivity.Name = "trackBarMouseSensitivity";
            this.trackBarMouseSensitivity.Size = new System.Drawing.Size(200, 45);
            this.trackBarMouseSensitivity.TabIndex = 1;
            this.trackBarMouseSensitivity.Value = 10;
            this.trackBarMouseSensitivity.Scroll += new System.EventHandler(this.trackBarMouseSensitivity_Scroll);
            // 
            // PanelInstructions
            // 
            this.PanelInstructions.Controls.Add(this.groupBoxInstruction4);
            this.PanelInstructions.Controls.Add(this.groupBoxInstruction3);
            this.PanelInstructions.Controls.Add(this.groupBoxInstruction2);
            this.PanelInstructions.Controls.Add(this.groupBoxInstruction1);
            this.PanelInstructions.Location = new System.Drawing.Point(-1, -1);
            this.PanelInstructions.Name = "PanelInstructions";
            this.PanelInstructions.Size = new System.Drawing.Size(900, 682);
            this.PanelInstructions.TabIndex = 8;
            this.PanelInstructions.Visible = false;
            // 
            // pictureBoxDisplayLevel
            // 
            this.pictureBoxDisplayLevel.InitialImage = null;
            this.pictureBoxDisplayLevel.Location = new System.Drawing.Point(575, 300);
            this.pictureBoxDisplayLevel.Name = "pictureBoxDisplayLevel";
            this.pictureBoxDisplayLevel.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxDisplayLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDisplayLevel.TabIndex = 8;
            this.pictureBoxDisplayLevel.TabStop = false;
            // 
            // buttonInstructions
            // 
            this.buttonInstructions.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonInstructions.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonInstructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonInstructions.ForeColor = System.Drawing.Color.White;
            this.buttonInstructions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonInstructions.Location = new System.Drawing.Point(255, 687);
            this.buttonInstructions.Name = "buttonInstructions";
            this.buttonInstructions.Size = new System.Drawing.Size(150, 75);
            this.buttonInstructions.TabIndex = 4;
            this.buttonInstructions.Text = "Instructions";
            this.buttonInstructions.UseVisualStyleBackColor = false;
            this.buttonInstructions.Click += new System.EventHandler(this.buttonInstructions_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonExit.Location = new System.Drawing.Point(685, 687);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(150, 75);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOptions
            // 
            this.buttonOptions.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonOptions.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonOptions.ForeColor = System.Drawing.Color.White;
            this.buttonOptions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonOptions.Location = new System.Drawing.Point(474, 687);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(150, 75);
            this.buttonOptions.TabIndex = 1;
            this.buttonOptions.Text = "Options";
            this.buttonOptions.UseVisualStyleBackColor = false;
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonPlay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonPlay.Enabled = false;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonPlay.ForeColor = System.Drawing.Color.White;
            this.buttonPlay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonPlay.Location = new System.Drawing.Point(375, 200);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(150, 75);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // comboBoxChooseLevel
            // 
            this.comboBoxChooseLevel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.comboBoxChooseLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxChooseLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChooseLevel.ForeColor = System.Drawing.Color.White;
            this.comboBoxChooseLevel.FormattingEnabled = true;
            this.comboBoxChooseLevel.ItemHeight = 24;
            this.comboBoxChooseLevel.Items.AddRange(new object[] {
            "All level",
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4",
            "Level 5",
            "Level 6",
            "Level 7",
            "Level 8",
            "Level 9",
            "Level 10"});
            this.comboBoxChooseLevel.Location = new System.Drawing.Point(375, 298);
            this.comboBoxChooseLevel.Name = "comboBoxChooseLevel";
            this.comboBoxChooseLevel.Size = new System.Drawing.Size(150, 32);
            this.comboBoxChooseLevel.TabIndex = 7;
            this.comboBoxChooseLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseLevel_SelectedIndexChanged);
            // 
            // labelLife
            // 
            this.labelLife.AutoSize = true;
            this.labelLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLife.ForeColor = System.Drawing.Color.Red;
            this.labelLife.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelLife.Location = new System.Drawing.Point(250, 90);
            this.labelLife.Name = "labelLife";
            this.labelLife.Size = new System.Drawing.Size(120, 55);
            this.labelLife.TabIndex = 8;
            this.labelLife.Text = "♥♥♥";
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonRestart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonRestart.Enabled = false;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonRestart.ForeColor = System.Drawing.Color.White;
            this.buttonRestart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRestart.Location = new System.Drawing.Point(625, 75);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(150, 75);
            this.buttonRestart.TabIndex = 3;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonStart.ForeColor = System.Drawing.Color.White;
            this.buttonStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonStart.Location = new System.Drawing.Point(100, 75);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(150, 75);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelGeneratePanel
            // 
            this.panelGeneratePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGeneratePanel.Location = new System.Drawing.Point(100, 160);
            this.panelGeneratePanel.Name = "panelGeneratePanel";
            this.panelGeneratePanel.Size = new System.Drawing.Size(700, 700);
            this.panelGeneratePanel.TabIndex = 1;
            // 
            // labelChrono
            // 
            this.labelChrono.AutoSize = true;
            this.labelChrono.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.labelChrono.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChrono.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelChrono.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelChrono.Location = new System.Drawing.Point(380, 85);
            this.labelChrono.Name = "labelChrono";
            this.labelChrono.Size = new System.Drawing.Size(0, 55);
            this.labelChrono.TabIndex = 9;
            // 
            // timerFlash
            // 
            this.timerFlash.Interval = 1000;
            this.timerFlash.Tick += new System.EventHandler(this.timerFlash_Tick);
            // 
            // groupBoxInstruction1
            // 
            this.groupBoxInstruction1.Controls.Add(this.richTextBoxInstruction1);
            this.groupBoxInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInstruction1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBoxInstruction1.Location = new System.Drawing.Point(75, 75);
            this.groupBoxInstruction1.Name = "groupBoxInstruction1";
            this.groupBoxInstruction1.Size = new System.Drawing.Size(290, 290);
            this.groupBoxInstruction1.TabIndex = 0;
            this.groupBoxInstruction1.TabStop = false;
            this.groupBoxInstruction1.Text = "Instruction";
            // 
            // groupBoxInstruction2
            // 
            this.groupBoxInstruction2.Controls.Add(this.richTextBox2);
            this.groupBoxInstruction2.Controls.Add(this.richTextBox1);
            this.groupBoxInstruction2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInstruction2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBoxInstruction2.Location = new System.Drawing.Point(450, 75);
            this.groupBoxInstruction2.Name = "groupBoxInstruction2";
            this.groupBoxInstruction2.Size = new System.Drawing.Size(290, 290);
            this.groupBoxInstruction2.TabIndex = 1;
            this.groupBoxInstruction2.TabStop = false;
            this.groupBoxInstruction2.Text = "Win - Lose";
            // 
            // groupBoxInstruction3
            // 
            this.groupBoxInstruction3.Controls.Add(this.richTextBox4);
            this.groupBoxInstruction3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInstruction3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBoxInstruction3.Location = new System.Drawing.Point(75, 371);
            this.groupBoxInstruction3.Name = "groupBoxInstruction3";
            this.groupBoxInstruction3.Size = new System.Drawing.Size(290, 290);
            this.groupBoxInstruction3.TabIndex = 2;
            this.groupBoxInstruction3.TabStop = false;
            this.groupBoxInstruction3.Text = "Special";
            // 
            // groupBoxInstruction4
            // 
            this.groupBoxInstruction4.Controls.Add(this.richTextBox3);
            this.groupBoxInstruction4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInstruction4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBoxInstruction4.Location = new System.Drawing.Point(450, 371);
            this.groupBoxInstruction4.Name = "groupBoxInstruction4";
            this.groupBoxInstruction4.Size = new System.Drawing.Size(290, 290);
            this.groupBoxInstruction4.TabIndex = 3;
            this.groupBoxInstruction4.TabStop = false;
            this.groupBoxInstruction4.Text = "Score";
            // 
            // richTextBoxInstruction1
            // 
            this.richTextBoxInstruction1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBoxInstruction1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInstruction1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.richTextBoxInstruction1.Location = new System.Drawing.Point(7, 30);
            this.richTextBoxInstruction1.Name = "richTextBoxInstruction1";
            this.richTextBoxInstruction1.Size = new System.Drawing.Size(275, 175);
            this.richTextBoxInstruction1.TabIndex = 0;
            this.richTextBoxInstruction1.Text = "The goal of the game is to go from the blue case to the red case without touching" +
    " the green area. If you touch the green area the cursor will be replaced to the " +
    "beggining and you will lose a life.";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.richTextBox1.Location = new System.Drawing.Point(7, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(275, 100);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "To win the game you need to have one or more of life and finish the level 10. \n";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.richTextBox2.Location = new System.Drawing.Point(6, 136);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(275, 100);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "To lose the game you need to have anymore life and you will not finish the level " +
    "or the game.";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.richTextBox3.Location = new System.Drawing.Point(7, 30);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(275, 169);
            this.richTextBox3.TabIndex = 3;
            this.richTextBox3.Text = "The score is saved when you win or lose the game. You can see your score in the m" +
    "ain menu when you click on score button. In the score window you can see the use" +
    "rname the score the life and the date.";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.richTextBox4.Location = new System.Drawing.Point(7, 28);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(275, 175);
            this.richTextBox4.TabIndex = 1;
            this.richTextBox4.Text = resources.GetString("richTextBox4.Text");
            // 
            // theMazeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(890, 890);
            this.Controls.Add(this.panelGame);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(890, 890);
            this.Name = "theMazeGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Maze Game";
            this.Load += new System.EventHandler(this.theMazeGame_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.theMazeGame_KeyUp);
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.panelTopMenu.ResumeLayout(false);
            this.panelTopMenu.PerformLayout();
            this.panelMainMenu.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.groupBoxTimerSpeed.ResumeLayout(false);
            this.groupBoxTimerSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMouseSensitivity)).EndInit();
            this.PanelInstructions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplayLevel)).EndInit();
            this.groupBoxInstruction1.ResumeLayout(false);
            this.groupBoxInstruction2.ResumeLayout(false);
            this.groupBoxInstruction3.ResumeLayout(false);
            this.groupBoxInstruction4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Panel panelMainMenu;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonInstructions;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label labelMouseSense;
        private System.Windows.Forms.TrackBar trackBarMouseSensitivity;
        private System.Windows.Forms.Timer timerCount;
        private System.Windows.Forms.Label labelLife;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panelGeneratePanel;
        private System.Windows.Forms.Label labelChrono;
        private System.Windows.Forms.Timer timerFlash;
        private System.Windows.Forms.Panel panelTopMenu;
        private System.Windows.Forms.Button buttonExit2;
        private System.Windows.Forms.Label labelGameTitle;
        private System.Windows.Forms.ComboBox comboBoxChooseLevel;
        private System.Windows.Forms.Panel PanelInstructions;
        private System.Windows.Forms.PictureBox pictureBoxDisplayLevel;
        private System.Windows.Forms.GroupBox groupBoxTimerSpeed;
        private System.Windows.Forms.RadioButton radioButtonTimerHard;
        private System.Windows.Forms.RadioButton radioButtonTimerRegular;
        private System.Windows.Forms.RadioButton radioButtonTimerEasy;
        private System.Windows.Forms.Button buttonDisplayScores;
        private System.Windows.Forms.GroupBox groupBoxInstruction4;
        private System.Windows.Forms.GroupBox groupBoxInstruction3;
        private System.Windows.Forms.GroupBox groupBoxInstruction2;
        private System.Windows.Forms.GroupBox groupBoxInstruction1;
        private System.Windows.Forms.RichTextBox richTextBoxInstruction1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
    }
}

