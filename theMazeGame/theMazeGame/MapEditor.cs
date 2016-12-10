using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace theMazeGame
{
    public partial class MapEditor : Form
    {
        public MapEditor()
        {
            InitializeComponent();
        }

        Color colorPanels = Color.Gray;

        //The position of the labels
        int positionLabel = 0;

        //The height of a label
        int PANEL_HEIGHT;

        //The height of a label
        int PANEL_WIDTH;

        //The number of panel in horizontal
        const int widthNumber = 25;

        //The number of panel in vertical
        const int heightNumber = 25;

        //The labels array
        Panel[,] panelsArray = new Panel[widthNumber, heightNumber];

        //Put i in x
        int x;

        //Put j in y
        int y;

        Boolean checkLongLine = false;

        Boolean checkColoring = false;





        /******************************************************************/




        private void MapEditor_Load(object sender, EventArgs e)
        {
            //Change the height of a panel
            PANEL_HEIGHT = panelGenerateEditor.Height / heightNumber;

            //Change the height of a panel
            PANEL_WIDTH = panelGenerateEditor.Width / widthNumber;

            CreatePanel();
        }





        /******************************************************************/




        /// <summary>
        /// The code to create panels
        /// </summary>
        private void CreatePanel()
        {
            //First for loop to make line
            for (int i = 0; i < heightNumber; i++)
            {
                if (i > 0)
                {
                    //Position the fisrt case
                    positionLabel = positionLabel + PANEL_WIDTH;
                }//End if

                //Second for loop to make column
                for (int j = 0; j < widthNumber; j++)
                {
                    //Put the button in the array
                    panelsArray[i, j] = new Panel();

                    //Change the size of buttons
                    panelsArray[i, j].Size = new Size(PANEL_WIDTH, PANEL_HEIGHT);

                    panelsArray[i, j].BackColor = Color.Gray;

                    //Change the color of the label
                    panelsArray[i, j].BorderStyle = BorderStyle.FixedSingle;

                    //Make that in all buttons the position change
                    panelsArray[i, j].Location = new Point(j * PANEL_WIDTH, i * PANEL_HEIGHT);

                    //Associate dynamically buttons on the method : chessButton_Click
                    panelsArray[i, j].Click += new System.EventHandler(panelEditor_Click);

                    //Associate dynamically buttons on the method : chessButton_Click
                    panelsArray[i, j].MouseMove += new MouseEventHandler(panelEditor_MouseMove);

                    panelGenerateEditor.Controls.Add(panelsArray[i, j]);
                }//End second for loop
            }//End first for loop

            ColorBorder();
        }





        /******************************************************************/




        private void panelEditor_Click(object sender, EventArgs e)
        {
            if (!checkBoxLongLine.Checked)
            {
                for (int i = 0; i < widthNumber; i++)
                {
                    for (int j = 0; j < widthNumber; j++)
                    {
                        if (panelsArray[i, j] == sender)
                        {
                            x = i;
                            y = j;
                        }
                    }
                }


                panelsArray[x, y].BackColor = colorPanels;
            }

            else
            { 
                checkColoring = !checkColoring;
            }
        }





        /******************************************************************/




        /// <summary>
        /// The code when we move the cursor on the panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelEditor_MouseMove(object sender, EventArgs e)
        { 
            if(checkBoxLongLine.Checked & checkColoring == true)
            {
                for (int i = 0; i < widthNumber; i++)
                {
                    for (int j = 0; j < widthNumber; j++)
                    {
                        if (panelsArray[i, j] == sender)
                        {
                            x = i;
                            y = j;
                        }
                    }
                }

                panelsArray[x, y].BackColor = colorPanels;
            }
        }





        /******************************************************************/




        /// <summary>
        /// The code to color the border of the panel
        /// </summary>
        private void ColorBorder()
        {
            for (int i = 0; i < widthNumber; i++)
            {
                //Color the bottom of the panel
                panelsArray[widthNumber - 1, i].BackColor = Color.Lime;

                panelsArray[widthNumber - 1, i].Enabled = false;

                //Color the right side of the panel
                panelsArray[i, widthNumber - 1].BackColor = Color.Lime;

                panelsArray[i, widthNumber - 1].Enabled = false;

                //Color the top of the panel
                panelsArray[0, i].BackColor = Color.Lime;

                panelsArray[0, i].Enabled = false;

                //Color the left side of the panel
                panelsArray[i, 0].BackColor = Color.Lime;

                panelsArray[i, 0].Enabled = false;
            }
        }





        /******************************************************************/




        private void buttonExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        /******************************************************************/




        /// <summary>
        /// Te code when we change the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxChooseThink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChooseThink.Text == "Wall")
            {
                colorPanels = Color.Lime;

                checkBoxLongLine.Enabled = true;

                checkLongLine = true;
            }

            if (comboBoxChooseThink.Text == "Teleporter")
            {
                colorPanels = Color.Black;

                checkBoxLongLine.Enabled = false;

                checkLongLine = false;
            }

            if (comboBoxChooseThink.Text == "Key")
            {
                colorPanels = Color.Snow;

                checkBoxLongLine.Enabled = false;

                checkLongLine = false;
            }

            if (comboBoxChooseThink.Text == "Gum")
            {
                colorPanels = Color.Gray;

                checkBoxLongLine.Enabled = true;

                checkLongLine = true;
            }
        }




        /******************************************************************/




        private void buttonClear_Click(object sender, EventArgs e)
        {
            //Clear the panelChessBoard
            panelGenerateEditor.Controls.Clear();

            CreatePanel();
        }




        /******************************************************************/




        private void checkBoxLongLine_CheckedChanged(object sender, EventArgs e)
        {
            checkLongLine = !checkLongLine;
        }
    }
}
