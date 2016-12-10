namespace theMazeGame
{
    partial class MapEditor
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
            this.panelTopMenu = new System.Windows.Forms.Panel();
            this.buttonExit2 = new System.Windows.Forms.Button();
            this.labelGameTitle = new System.Windows.Forms.Label();
            this.panelMenuTop = new System.Windows.Forms.Panel();
            this.checkBoxLongLine = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxChooseThink = new System.Windows.Forms.ComboBox();
            this.panelGenerateEditor = new System.Windows.Forms.Panel();
            this.panelTopMenu.SuspendLayout();
            this.panelMenuTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopMenu
            // 
            this.panelTopMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelTopMenu.Controls.Add(this.buttonExit2);
            this.panelTopMenu.Controls.Add(this.labelGameTitle);
            this.panelTopMenu.Location = new System.Drawing.Point(-1, -1);
            this.panelTopMenu.Name = "panelTopMenu";
            this.panelTopMenu.Size = new System.Drawing.Size(893, 40);
            this.panelTopMenu.TabIndex = 8;
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
            this.labelGameTitle.Location = new System.Drawing.Point(344, 6);
            this.labelGameTitle.Name = "labelGameTitle";
            this.labelGameTitle.Size = new System.Drawing.Size(180, 24);
            this.labelGameTitle.TabIndex = 0;
            this.labelGameTitle.Text = "The Maze Game";
            // 
            // panelMenuTop
            // 
            this.panelMenuTop.BackColor = System.Drawing.Color.White;
            this.panelMenuTop.Controls.Add(this.checkBoxLongLine);
            this.panelMenuTop.Controls.Add(this.buttonClear);
            this.panelMenuTop.Controls.Add(this.comboBoxChooseThink);
            this.panelMenuTop.Location = new System.Drawing.Point(-1, 35);
            this.panelMenuTop.Name = "panelMenuTop";
            this.panelMenuTop.Size = new System.Drawing.Size(891, 35);
            this.panelMenuTop.TabIndex = 9;
            // 
            // checkBoxLongLine
            // 
            this.checkBoxLongLine.AutoSize = true;
            this.checkBoxLongLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLongLine.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.checkBoxLongLine.Location = new System.Drawing.Point(292, 4);
            this.checkBoxLongLine.Name = "checkBoxLongLine";
            this.checkBoxLongLine.Size = new System.Drawing.Size(98, 24);
            this.checkBoxLongLine.TabIndex = 2;
            this.checkBoxLongLine.Text = "Long Line";
            this.checkBoxLongLine.UseVisualStyleBackColor = true;
            this.checkBoxLongLine.CheckedChanged += new System.EventHandler(this.checkBoxLongLine_CheckedChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(154, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(121, 28);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxChooseThink
            // 
            this.comboBoxChooseThink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChooseThink.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.comboBoxChooseThink.FormattingEnabled = true;
            this.comboBoxChooseThink.Items.AddRange(new object[] {
            "Wall",
            "Teleporter",
            "Key",
            "Gum"});
            this.comboBoxChooseThink.Location = new System.Drawing.Point(13, 3);
            this.comboBoxChooseThink.Name = "comboBoxChooseThink";
            this.comboBoxChooseThink.Size = new System.Drawing.Size(121, 28);
            this.comboBoxChooseThink.TabIndex = 0;
            this.comboBoxChooseThink.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseThink_SelectedIndexChanged);
            // 
            // panelGenerateEditor
            // 
            this.panelGenerateEditor.Location = new System.Drawing.Point(100, 120);
            this.panelGenerateEditor.Name = "panelGenerateEditor";
            this.panelGenerateEditor.Size = new System.Drawing.Size(700, 700);
            this.panelGenerateEditor.TabIndex = 10;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(890, 890);
            this.Controls.Add(this.panelGenerateEditor);
            this.Controls.Add(this.panelMenuTop);
            this.Controls.Add(this.panelTopMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapEditor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.panelTopMenu.ResumeLayout(false);
            this.panelTopMenu.PerformLayout();
            this.panelMenuTop.ResumeLayout(false);
            this.panelMenuTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopMenu;
        private System.Windows.Forms.Button buttonExit2;
        private System.Windows.Forms.Label labelGameTitle;
        private System.Windows.Forms.Panel panelMenuTop;
        private System.Windows.Forms.ComboBox comboBoxChooseThink;
        private System.Windows.Forms.Panel panelGenerateEditor;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.CheckBox checkBoxLongLine;
    }
}