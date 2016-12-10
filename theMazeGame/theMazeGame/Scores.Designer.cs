namespace theMazeGame
{
    partial class Scores
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
            this.scoresList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelTopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopMenu
            // 
            this.panelTopMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelTopMenu.Controls.Add(this.buttonExit2);
            this.panelTopMenu.Controls.Add(this.labelGameTitle);
            this.panelTopMenu.Location = new System.Drawing.Point(-1, -1);
            this.panelTopMenu.Name = "panelTopMenu";
            this.panelTopMenu.Size = new System.Drawing.Size(900, 40);
            this.panelTopMenu.TabIndex = 8;
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
            // scoresList
            // 
            this.scoresList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scoresList.BackColor = System.Drawing.SystemColors.GrayText;
            this.scoresList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scoresList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.scoresList.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoresList.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.scoresList.FullRowSelect = true;
            this.scoresList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scoresList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.scoresList.Location = new System.Drawing.Point(40, 85);
            this.scoresList.Name = "scoresList";
            this.scoresList.Size = new System.Drawing.Size(800, 750);
            this.scoresList.TabIndex = 9;
            this.scoresList.UseCompatibleStateImageBehavior = false;
            this.scoresList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Life";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Level";
            this.columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date";
            this.columnHeader5.Width = 160;
            // 
            // Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(890, 890);
            this.Controls.Add(this.scoresList);
            this.Controls.Add(this.panelTopMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Scores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scores";
            this.Load += new System.EventHandler(this.Scores_Load);
            this.panelTopMenu.ResumeLayout(false);
            this.panelTopMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopMenu;
        private System.Windows.Forms.Button buttonExit2;
        private System.Windows.Forms.Label labelGameTitle;
        private System.Windows.Forms.ListView scoresList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}