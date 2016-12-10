///ETML DemoMot
///Author : Alen Bijelic
///Date   : 3.6.2015
///Summary : The maze game is a game where we need to cross the maze without touching the wall. If we touch the wall the mouse is reposition in the begin of the game.
///
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace theMazeGame
{
    public partial class theMazeGame : Form
    {
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

        //The varible to contain the position of the cursor
        Point startingPoint;

        //The checker to create the maze
        Boolean checkCreateMaze = false;

        //The checker to lose the maze
        Boolean checkLoseGame = false;

        //The checker to lose the maze
        Boolean checkDisableMouse = false;

        //The variable to display and hide the richTextBox
        Boolean checkInstructions = true;

        //The variable to display and hide the panel
        Boolean checkOptions = true;

        //The variable to display or to hide the timer
        Boolean changeDisplayTimer = true;

        //The variable to generate a random boolean
        Random randomNumber = new Random();

        //The variable to generate a random boolean
        Boolean checkRedArea;

        //The variable to launch the flashPanels
        Boolean checkSnowArea1 = false;

        //The variable to launch the flashPanels
        Boolean checkSnowArea2 = false;

        //The variable to display the message of the level 10
        Boolean checkRedLvl10 = false;

        //The value to disable the message
        Boolean checkReplayLvl = false;

        //The code to change the mouse sensitivity
        uint mouseSensitivity = 0;

        //The counter for level
        int levelCount = 1;

        //the variable to count life
        int countLife = 3;

        //Checker for flashing panel
        Boolean flashPanel = true;

        Boolean winAllGame = false;

        System.TimeSpan currentElapsedTime2;

        int moveCursor = 0;

        //Put i in x
        int x;

        //Put j in y
        int y;

        //*********************************************************************************
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //*********************************************************************************


        /// <summary>
        /// Method to check who has won.
        /// </summary>
        private void registerScores()
        {
            //Recall the scoresInfos classe
            scoresInfos scoresInfos = new scoresInfos();

            //Check if player X won and if yes display a messagebox
            if (winAllGame == true)
            {
                //get the time for the xml file
                scoresInfos.time = labelChrono.Text;

                //Set the pseudos of players in the xml
                scoresInfos.player = Register.userName;

                //Set the pseudos of players in the xml
                scoresInfos.life = Convert.ToString(countLife);

                //Set the pseudos of players in the xml
                scoresInfos.level = Convert.ToString(levelCount);

                //Set the pseudos of players in the xml
                scoresInfos.date = System.DateTime.Now.ToString("dd.MM.yyyy");

                //Add the time duration of the match to the xml file
                newScores(scoresInfos);
            }
            else
            {
                //Check if player O won and if yes display a messagebox
                if (winAllGame == false)
                {
                    //get the time for the xml file
                    scoresInfos.time = labelChrono.Text;

                    //Set the pseudos of players in the xml
                    scoresInfos.player = Register.userName;

                    //Set the pseudos of players in the xml
                    scoresInfos.life = Convert.ToString(countLife);

                    //Set the pseudos of players in the xml
                    scoresInfos.level = Convert.ToString(levelCount);

                    //Set the pseudos of players in the xml
                    scoresInfos.date = System.DateTime.Now.ToString("dd.MM.yyyy");

                    //Add the time duration of the match to the xml file
                    newScores(scoresInfos);
                }
            }
        }


        /******************************************************************/




        public theMazeGame()
        {
            InitializeComponent();

            //Create a timer
            timerCount = new Timer();

            //Set the interval of the timer
            timerCount.Interval = 1000;

            //Associate dynamically timer with the method : timerCount_Tick
            timerCount.Tick += new EventHandler(timerCount_Tick);
        }




        /******************************************************************/




        /// <summary>
        /// The code when the form is load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void theMazeGame_Load(object sender, EventArgs e)
        {
            //Put the mouse sensitivity in trackbar mouse sensitivity
            mouseSensitivity = Convert.ToUInt16(trackBarMouseSensitivity.Value);

            //Change the speed of the mouse cursor
            WinAPI.SystemParametersInfo(113, 0, mouseSensitivity, 0);

            //Change the height of a panel
            PANEL_HEIGHT = panelGeneratePanel.Height / heightNumber;

            //Change the height of a panel
            PANEL_WIDTH = panelGeneratePanel.Width / widthNumber;

            //Check if changeDisplayTimer is true
            if (changeDisplayTimer == true)
            {
                //Put label chrono to the beggining format
                labelChrono.Text = "00:00:00";
            }
        }




        /************************Creating the timer***********************/




        // The last time the timer was started
        private DateTime startTime = DateTime.MinValue;

        // Time between now and when the timer was started last
        private TimeSpan currentElapsedTime = TimeSpan.Zero;

        // Time between now and the first time timer was started after a reset
        private TimeSpan totalElapsedTime = TimeSpan.Zero;

        // Whether or not the timer is currently running
        private bool timerRunning = false;




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
                        panelsArray[i, j].BorderStyle = BorderStyle.None;

                    //Make that in all buttons the position change
                    panelsArray[i, j].Location = new Point(j * PANEL_WIDTH, i * PANEL_HEIGHT);

                    //Associate the mouse move to a method
                    panelsArray[i, j].MouseEnter += new System.EventHandler(panelGrate_MouseEnter);

                    //Associate the mouse move to a method
                    panelsArray[i, j].MouseDown += new MouseEventHandler(panelGrate_MouseDown);

                    panelsArray[i, j].DragEnter += new DragEventHandler(panelGrate_DragEnter);

                    panelsArray[i, j].DragOver += new DragEventHandler(panelGrate_DragEnter);

                    //panelsArray[i, j].DragLeave += new DragEventHandler(panelGrate_DragLeave);

                    //Display all buttons in the panel
                    panelGeneratePanel.Controls.Add(panelsArray[i, j]);
                }//End second for loop
            }//End first for loop
        }




        /******************************************************************/




        /// <summary>
        /// The method to display the message
        /// </summary>
        private void displayMessage()
        {
            //Stop the timer
            stopTimer();

            //Check if checkReplayLvl is false
            if(checkReplayLvl == false)
            {
                //Check if levelCount is equal to 10
                if (levelCount < 10 & countLife > 0)
                {
                    //Display a winner message
                    const string message = "Do you want to play the next level?";//Text 
                    const string caption = "Restart game";//Title
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,//Yes / No button
                                                 MessageBoxIcon.Question);//Question icon

                    // If the result is yes
                    if (result == DialogResult.Yes)
                    {
                        //Clear the panel
                        clearPanel();
                    }
                    // If the result is no
                    if (result == DialogResult.No)
                    {
                        //Chaneg checkDisableMouse in false
                        checkDisableMouse = false;

                        //Chaneg checkRedLvl10 in false
                        checkRedLvl10 = false;

                        //Show the panelMainMenu
                        panelMainMenu.Visible = true;
                    }
                }

                //Check if the color is red and levelCount is 10
                if(panelsArray[x, y].BackColor == Color.Red & levelCount == 10 & countLife > 0)
                {
                    //
                    if(checkRedLvl10 == true & checkReplayLvl == false)
                    {
                        //Display a winner message
                        const string message = "Do you want to go on the main menu";
                        const string caption = "Finish";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                        // If the resullt is yes
                        if (result == DialogResult.Yes)
                        {
                            //Enregistrer les score + afficher dans Scores.cs

                            panelMainMenu.Visible = true;
                        }
                        // If the result is no
                        if (result == DialogResult.No)
                        {
                            checkDisableMouse = false;

                            checkRedLvl10 = false;
                        }
                    }
                }

                if(countLife == 0)
                {
                    //Display a winner message
                    const string message = "Your score will be register. Do you want to see it?";
                    const string caption = "Finish";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    // If the resullt is yes
                    if (result == DialogResult.Yes)
                    {
                        panelMainMenu.Visible = true;

                        //Enregistrer les score + afficher dans Scores.cs
                    }
                    // If the result is no
                    if (result == DialogResult.No)
                    {
                        checkDisableMouse = false;

                        checkRedLvl10 = false;

                        panelMainMenu.Visible = true;
                    }
                }

            }

            if (checkReplayLvl == true)
            {
                //Display a winner message
                const string message = "Do you want to replay this level";
                const string caption = "Replay";
                var result = MessageBox.Show(message, caption,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

                // If the resullt is yes
                if (result == DialogResult.Yes)
                {
                    restartAll();
                }

                // If the result is no
                if (result == DialogResult.No)
                {
                    checkDisableMouse = false;

                    checkRedLvl10 = false;

                    panelMainMenu.Visible = true;
                }
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

                //Color the right side of the panel
                panelsArray[i, widthNumber - 1].BackColor = Color.Lime;

                //Color the top of the panel
                panelsArray[0, i].BackColor = Color.Lime;

                //Color the left side of the panel
                panelsArray[i, 0].BackColor = Color.Lime;
            }
        }





        /******************************************************************/




        /// <summary>
        /// The method to clear the panel
        /// </summary>
        private void clearPanel()
        {
            buttonStart.Enabled = true;

            buttonRestart.Enabled = false;

            checkDisableMouse = false;

            levelCount++;

            //Clear the panelChessBoard
            panelGeneratePanel.Controls.Clear();

            CreatePanel();

            checkLevelOrder();
        }





        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl1()
        {
            //Color the border of the maze
            ColorBorder();

            //Loop for to color the line
            for (int i = 0; i < heightNumber; i++)
            {


                //Check if i is a multiplier of 2 and if the results have not rests
                if (i % 2 == 0)
                {
                    //Change the boolean checkCreateMaze in to opposite
                    checkCreateMaze = !checkCreateMaze;

                    //Check if checkCreateMaze is true
                    if (checkCreateMaze == true)
                    {
                        //Loop for to color the line
                        for (int j = 0; j < widthNumber - 2; j++)
                        {
                            //Color panels in Lime
                            panelsArray[i, j].BackColor = Color.Lime;
                        }//End second loop
                    }//End if: check if checkCreateMaze is true

                    //Check if checkCreateMaze is false
                    if (checkCreateMaze == false)
                    {
                        //Loop for to color the line
                        for (int j = 0; j < widthNumber - 1; j++)
                        {
                            //Color panels in Lime
                            panelsArray[i, j].BackColor = Color.Lime;

                            //Color panels in control color
                            panelsArray[i, 1].BackColor = Color.Gray;
                        }//End third loop
                    }//End if: check if checkCreateMaze is false

                }//End if: control the line
            }//End first loop

            checkCreateMaze = false;

            //Color the begining of the game
            panelsArray[1, widthNumber - 2].BackColor = Color.Blue;

            //Color the begining of the game
            panelsArray[widthNumber - 2, widthNumber - 2].BackColor = Color.Red;
        }





        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl2()
        {
            //Color the border of the maze
            ColorBorder();

            //Loop for to color the line
            for (int i = 0; i < widthNumber - 2; i++)
            {
                //Color panels in Lime
                panelsArray[2, i].BackColor = Color.Lime;

                //Color panels in Lime
                panelsArray[8, i].BackColor = Color.Lime;
            }//End second loop



            //Loop for to color the line
            for (int i = 0; i < widthNumber - 1; i++)
            {
                i++;

                //Color panels in Lime
                panelsArray[6, i].BackColor = Color.Lime;
            }


            for (int i = 0; i < widthNumber - 1; i++)
            {
                //Color panels in Lime
                panelsArray[4, i].BackColor = Color.Lime;

                //Color panels in control color
                panelsArray[4, 1].BackColor = Color.Gray;

                //Color panels in Lime
                panelsArray[10, i].BackColor = Color.Lime;

                //Color panels in control color
                panelsArray[10, 1].BackColor = Color.Gray;
            }//End second loop

            //Color in green
            for (int i = 0; i < 12; i++)
            {
                //Color panels in Lime
                panelsArray[11 + i, 2].BackColor = Color.Lime;
            }

            //Color in green
            for (int i = 0; i < 18; i++)
            {
                //Color panels in Lime
                panelsArray[12, 5 + i].BackColor = Color.Lime;
            }

            //Color in green
            for (int i = 0; i < 12; i++)
            {
                //Color panels in Lime
                panelsArray[12 + i, 4].BackColor = Color.Lime;

            }

            //Color in green
            for (int i = 0; i < 8; i++)
            {
                //Color panels in Lime
                panelsArray[13 + i, 22].BackColor = Color.Lime;
            }

            //Color in green
            for (int i = 0; i < 9; i++)
            {
                //Color panels in Lime
                panelsArray[14 + i, 20].BackColor = Color.Lime;

                //Color panels in Lime
                panelsArray[12 + i, 7].BackColor = Color.Lime;
            }

            //Color in green
            for (int i = 0; i < 17; i++)
            {
                //Color panels in Lime
                panelsArray[22, 7 + i].BackColor = Color.Lime;
            }

            //Color in green
            for (int i = 0; i < 10; i++)
            {
                i++;

                for (int j = 0; j < 10; j++)
                {
                    j++;

                    //Color panels in Lime
                    panelsArray[j + 12, 8 + i].BackColor = Color.Lime;
                }
            }

            //Color the begining of the game
            panelsArray[1, 1].BackColor = Color.Blue;

            //Color the begining of the game
            panelsArray[widthNumber - 2, widthNumber - 2].BackColor = Color.Red;
        }




        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl3()
        {
            //Color the border of the maze
            ColorBorder();

            checkRedArea = Convert.ToBoolean(randomNumber.Next() % 2);

            //Loop for to color the line
            for (int i = 0; i < widthNumber; i++)
            {
                if(i < widthNumber - 2)
                {
                    //Color panels in Lime
                    panelsArray[2, i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[10, i].BackColor = Color.Lime;
                }

                if(i < widthNumber - 1)
                {
                    //Color panels in Lime
                    panelsArray[4, i].BackColor = Color.Lime;

                    //Color panels in control color
                    panelsArray[4, 1].BackColor = Color.Gray;
                }

                if(i < 4)
                {
                    //Color panels in Lime
                    panelsArray[i + 5, 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[i + 6, 22].BackColor = Color.Lime;
                }

                if (i < 3)
                {
                    //Color panels in Lime
                    panelsArray[i + 6, 4].BackColor = Color.Lime;
                }

                if(i < 16)
                {
                    //Color panels in Lime
                    panelsArray[8, 5 + i].BackColor = Color.Lime;
                }

                if(i < 17)
                {
                    //Color panels in Lime
                    panelsArray[6, 5 + i].BackColor = Color.Lime;
                }

                if(i < 21)
                {
                    //Color panels in Lime
                    panelsArray[12, i + 2].BackColor = Color.Lime;
                }

                if (i < 10)
                {
                    //Color panels in Lime
                    panelsArray[13 + i, 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 4].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 22].BackColor = Color.Lime;
                }

                if (i < 14)
                {
                    //Color panels in Lime
                    panelsArray[14, 8 + i].BackColor = Color.Lime;
                }

                if (i < 8)
                {
                    //Color panels in Lime
                    panelsArray[14 + i, 5 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 21 - i].BackColor = Color.Lime;
                }

                if (i < 9)
                {
                    //Color panels in Lime
                    panelsArray[16, 8 + i].BackColor = Color.Lime;
                }

                if (i < 5)
                {
                    //Color panels in Lime
                    panelsArray[18, 12 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[18 + i, 6 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19 + i, 6 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[18 + i, 20 - i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19 + i, 20 - i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[23, 11 + i].BackColor = Color.Lime;
                }

            }//End second loop

            //Color panels in Snow
            panelsArray[7, 5].BackColor = Color.Snow;

            //Color panels in Lime
            panelsArray[21, 13].BackColor = Color.Lime;

            //Color panels in control color
            panelsArray[23, 9].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[23, 17].BackColor = Color.Gray;

            //Color the begining of the game
            panelsArray[1, 1].BackColor = Color.Blue;
        }




        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl4()
        {
            //Color the border of the maze
            ColorBorder();

            for (int i = 0; i < widthNumber - 2; i++)
            { 
                if(i < 10)
                {
                    //Color panels in Lime
                    panelsArray[i,i + 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[i + 2, i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13 + i, 9 - i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[15 + i, 11 - i].BackColor = Color.Lime;
                }

                if(i > 12)
                {
                    //Color panels in Lime
                    panelsArray[i, i + 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[i + 2, i ].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[22 - i, i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[24 - i, i + 2].BackColor = Color.Lime;

                }

                if(i % 2 == 1 & i > 1 & i < 10)
                {
                    //Color panels in Lime
                    panelsArray[i, i + 1].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[i, i - 1].BackColor = Color.Lime;
                }

                if (i % 2 == 1 & i < 22 & i < 8)
                {
                    //Color panels in Lime
                    panelsArray[10 - i, 13 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[10 - i, 15 + i].BackColor = Color.Lime;
                }

                if (i % 2 == 0 & i > 1 & i < 10)
                {
                    //Color panels in Lime
                    panelsArray[24 - i, i + 1].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[22 - i, i + 1].BackColor = Color.Lime;
                }

                if (i % 2 == 0 & i < 22 & i < 8)
                {
                    //Color panels in Lime
                    panelsArray[14 + i, 15 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[16 + i, 15 + i].BackColor = Color.Lime;
                }

                if(i < 13)
                {
                    //Color panels in Lime
                    panelsArray[2, 5 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[7 + i, 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[4 + i, 22].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[22, 8 + i].BackColor = Color.Lime;
                }

                if(i < 9)
                {
                    //Color panels in Lime
                    panelsArray[4, 9 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[7 + i, 4].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[9 + i, 20].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[20, 6 + i].BackColor = Color.Lime;
                }

                if (i < 5)
                {
                    //Color panels in Lime
                    panelsArray[6, 9 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[11 + i, 6].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[9 + i, 18].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[18, 11 + i].BackColor = Color.Lime;
                }
            }

            //Color panels in Lime
            panelsArray[9, 12].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[15, 12].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[12, 9].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[12, 15].BackColor = Color.Lime;

            //Color panels in Black
            panelsArray[12, 12].BackColor = Color.Black;

            //Color panels in Snow
            panelsArray[8, 12].BackColor = Color.Snow;

            //Color panels in Snow
            panelsArray[16, 12].BackColor = Color.Snow;

            //Color panels in Snow
            panelsArray[12, 8].BackColor = Color.Snow;

            //Color panels in Snow
            panelsArray[12, 16].BackColor = Color.Snow;

            //Color the begining of the game
            panelsArray[1, 1].BackColor = Color.Blue;
        }




        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl5()
        {
            //Color the border of the maze
            ColorBorder();

            for (int i = 0; i < widthNumber - 1; i++ )
            {
                if(i < 4)
                {
                    //Color panels in Lime
                    panelsArray[i + 1, 2].BackColor = Color.Lime;
                }

                if(i < 18)
                {
                    //Color panels in Lime
                    panelsArray[2, i + 4].BackColor = Color.Lime;
                }

                if(i < 17)
                {
                    //Color panels in Lime
                    panelsArray[4, 3 + i].BackColor = Color.Lime;
                }

                if (i < 15)
                {
                    //Color panels in Lime
                    panelsArray[6, i + 2].BackColor = Color.Lime;
                }

                if(i < 14)
                {
                    //Color panels in Lime
                    panelsArray[8, i + 1].BackColor = Color.Lime;
                }

                if(i < 11)
                {
                    //Color panels in Lime
                    panelsArray[10, i + 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[12, i + 4].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[18, 6 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[7 + i, 16].BackColor = Color.Lime;
                }

                if(i < 8)
                {
                    //Color panels in Lime
                    panelsArray[14, i + 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[9 + i, 14].BackColor = Color.Lime;
                }

                if(i < 5)
                {
                    //Color panels in Lime
                    panelsArray[16, 4 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[16 + i, 4].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 12].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 10].BackColor = Color.Lime;
                }

                if (i < 16)
                {
                    //Color panels in Lime
                    panelsArray[20, 4 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[5 + i, 18].BackColor = Color.Lime;
                }

                if (i < 21)
                {
                    //Color panels in Lime
                    panelsArray[22, 2 + i].BackColor = Color.Lime;
                }

                if (i < 13)
                {
                    //Color panels in Lime
                    panelsArray[i + 10, 2].BackColor = Color.Lime;
                }

                if (i < 19)
                {
                    //Color panels in Lime
                    panelsArray[3 + i, 21].BackColor = Color.Lime;
                }

                if(i % 2 == 0 & i < 10)
                {
                    //Color panels in Lime
                    panelsArray[(1 + i) * 2, 20].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[(2 + i) * 2, 23].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[(2 + i) * 2, 19].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[(1 + i) * 2, 22].BackColor = Color.Lime;
                }
            }

            //Color panels in Lime
            panelsArray[1, 12].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[1, 18].BackColor = Color.Lime;

            //Color panels in Black
            panelsArray[17, 11].BackColor = Color.Black;

            //Color panels in Snow
            panelsArray[1, 19].BackColor = Color.Snow;

            //Color the begining of the game
            panelsArray[1, 1].BackColor = Color.Blue;

            //Color the begining of the game
            panelsArray[1, 15].BackColor = Color.Red;
        }




        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl6()
        {
            for (int i = 0; i < widthNumber - 1; i++)
            {
                for (int j = 0; j < widthNumber - 1; j++)
                {
                    if (i % 4 == 0)
                    {
                        //Color panels in Lime
                        panelsArray[i, j].BackColor = Color.Lime;

                        //Color panels in Lime
                        panelsArray[j, i].BackColor = Color.Lime;

                        //Color panels in control color
                        panelsArray[i, 2].BackColor = Color.Gray;

                        if(i < 13)
                        {
                            //Color panels in control color
                            panelsArray[2, i].BackColor = Color.Gray;
                            
                        }
                    }
                }
            }

            //Color panels in control color
            panelsArray[2, 20].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[4, 6].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[4, 14].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[4, 18].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[4, 22].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[6, 4].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[6, 8].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[6, 16].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[8, 10].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[8, 22].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[10, 20].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[14, 8].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[14, 12].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[16, 6].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[16, 14].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[16, 14].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[16, 18].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[2, 20].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[4, 6].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[4, 14].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[4, 18].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[4, 22].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[6, 4].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[6, 8].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[6, 16].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[8, 10].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[8, 22].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[10, 20].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[12, 14].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[12, 18].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[14, 8].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[14, 12].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[16, 6].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[16, 14].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[16, 18].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[16, 22].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[18, 8].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[18, 20].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[20, 10].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[20, 14].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[22, 8].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[22, 16].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[22, 20].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[18, 8].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[18, 20].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[20, 10].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[20, 14].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[22, 8].BackColor = Color.Gray;
            
            //Color panels in control color
            panelsArray[22, 16].BackColor = Color.Gray;

            //Color panels in control color
            panelsArray[22, 20].BackColor = Color.Gray;

            //Color the border of the maze
            ColorBorder();

            //Color the key in Snow
            panelsArray[14, 22].BackColor = Color.Snow;

            //Color the begining of the game
            panelsArray[1, 1].BackColor = Color.Blue;

            //Color the begining of the game
            panelsArray[widthNumber - 2, widthNumber - 2].BackColor = Color.Red;
        }




        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl7()
        {
            for (int i = 0; i < widthNumber - 1; i++ )
            {
                if(i < 21)
                {
                    //Color panels in Lime
                    panelsArray[2, 2 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2 + i, 2].BackColor = Color.Lime;
                }

                if(i < 12)
                {
                    //Color panels in Lime
                    panelsArray[4, 9 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[6, 6 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[9 + i, 4].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[6 + i, 6].BackColor = Color.Lime;
                }

                if (i < 7)
                {
                    //Color panels in Lime
                    panelsArray[8, 10 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[10 + i, 8].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[9 + i, 16].BackColor = Color.Lime;
                }

                if (i < 10)
                {
                    //Color panels in Lime
                    panelsArray[18, 6 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[6 + i, 18].BackColor = Color.Lime;
                }

                if(i < 4)
                {
                    //Color panels in Lime
                    panelsArray[18, 20 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[20 + i, 18].BackColor = Color.Lime;
                }

                if(i < 17)
                {
                    //Color panels in Lime
                    panelsArray[20, 4 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[4 + i, 20].BackColor = Color.Lime;
                }

                if(i < 14)
                {
                    //Color panels in Lime
                    panelsArray[22, 2 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2 + i, 22].BackColor = Color.Lime;
                }

                if (i < 9)
                {
                    //Color panels in Lime
                    panelsArray[16, 8 + i].BackColor = Color.Lime;
                }

                if(i % 2 == 0 & i < 8)
                {
                    //Color panels in Lime
                    panelsArray[i + 9, 12].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[12, i + 9].BackColor = Color.Lime;
                }

                if (i % 4 == 0 & i < 8)
                {
                    //Color panels in Lime
                    panelsArray[i + 10, 14].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[i + 10, 10].BackColor = Color.Lime;
                }

            }

            //Color panels in Lime
            ColorBorder();

            //Color panels in Snow
            panelsArray[15, 15].BackColor = Color.Snow;

            //Color panels in Snow
            panelsArray[12, 12].BackColor = Color.Snow;

            //Color panels in Blue
            panelsArray[1, 1].BackColor = Color.Blue;

            //Color panels in Red
            panelsArray[widthNumber - 2, widthNumber - 2].BackColor = Color.Red;
        }




        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl8()
        {
            for (int i = 0; i < widthNumber - 1; i++)
            {

                if (i < 15)
                {
                    //Color panels in Lime
                    panelsArray[5, i + 5].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19, i + 5].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[5 + i, 5].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[5 + i, 19].BackColor = Color.Lime;
                }

                if (i < 4)
                {
                    //Color panels in Lime
                    panelsArray[11, i + 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[11, i + 19].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13, i + 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13, i + 19].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2 + i, 11].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19 + i, 11].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[7 + i, 11].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 11].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[11, 7 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[11, 14 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2 + i, 13].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19 + i, 13].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[7 + i, 13].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 13].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13, 7 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13, 14 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[5 + i, 8].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[16 + i, 8].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[5 + i, 16].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[16 + i, 16].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[8, 5 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[8, 16 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[16, 5 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[16, 16 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[10, 10].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[10, 14].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14, 10].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14, 14].BackColor = Color.Lime;
                }

                if (i < 21)
                {
                    //Color panels in Lime
                    panelsArray[2, i + 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[22, i + 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2 + i, 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2 + i, 22].BackColor = Color.Lime;
                }
            }

            for (int i = 0; i < 21; i++)
            {
                //Color panels in control color
                panelsArray[2 + i, 12].BackColor = Color.Gray;

                //Color panels in control color
                panelsArray[12, 2 + i].BackColor = Color.Gray;
            }

            //Color panels in Lime
            panelsArray[11, 18].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[11, 23].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[18, 13].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[23, 11].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[7, 12].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[17, 12].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[12, 7].BackColor = Color.Lime;

            //Color panels in Lime
            panelsArray[12, 17].BackColor = Color.Lime;

            //Color panels in Snow
            panelsArray[10, 18].BackColor = Color.Snow;


            //Color the border of the maze
            ColorBorder();

            //Color the begining of the game
            panelsArray[1, 1].BackColor = Color.Blue;

            //Color the begining of the game
            panelsArray[12, 12].BackColor = Color.Red;
        }




        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl9()
        {
            for (int i = 0; i < widthNumber - 1; i++)
            {
                if (i < 3)
                {
                    //Color panels in Lime
                    panelsArray[2 + i, 22].BackColor = Color.Lime;
                }

                if (i < 4)
                {
                    //Color panels in Lime
                    panelsArray[1 + i, 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[11, 20 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13, 19 + i].BackColor = Color.Lime;
                }

                if (i < 7)
                {
                    //Color panels in Lime
                    panelsArray[12 + i, 6].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[12 + i, 10].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[12 + i, 14].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[12 + i, 18].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 4].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 8].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 12].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[14 + i, 16].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13 + i, 20].BackColor = Color.Lime;
                }

                if (i < 10)
                {
                    //Color panels in Lime
                    panelsArray[13 + i, 22].BackColor = Color.Lime;
                }

                if (i < 11)
                {
                    //Color panels in Lime
                    panelsArray[10 + i, 4].BackColor = Color.Lime;
                }

                if (i < 13)
                {
                    //Color panels in Lime
                    panelsArray[12, 6 + i].BackColor = Color.Lime;
                }

                if (i < 15)
                {
                    //Color panels in Lime
                    panelsArray[8 + i, 2].BackColor = Color.Lime;
                }

                if (i < 16)
                {
                    //Color panels in Lime
                    panelsArray[10, 5 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[20, 5 + i].BackColor = Color.Lime;
                }

                if (i < 19)
                {
                    //Color panels in Lime
                    panelsArray[4, 3 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2, 4 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[8, 3 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[22, 3 + i].BackColor = Color.Lime;
                }

                if (i < 20)
                {
                    //Color panels in Lime
                    panelsArray[8, 3 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[9, 22].BackColor = Color.Lime;
                }

                if (i < 23)
                {
                    //Color panels in Lime
                    panelsArray[6, 1 + i].BackColor = Color.Lime;
                }

            }

            //Color the border of the maze
            ColorBorder();

            panelsArray[3, 21].BackColor = Color.Black;

            //Color the begining of the game
            panelsArray[1, 1].BackColor = Color.Blue;

            //Color the begining of the game
            panelsArray[14, 19].BackColor = Color.Red;
        }




        /******************************************************************/




        /// <summary>
        /// The code to create the maze
        /// </summary>
        private void CreateMazeLvl10()
        {
            for (int i = 0; i < widthNumber - 1; i++)
            {
                if (i < 17)
                {
                    //Color panels in Lime
                    panelsArray[2 + i, 2].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[4, 4 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[8, 6 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2 + i, 2].BackColor = Color.Lime;
                }

                if (i < 13)
                {
                    //Color panels in Lime
                    panelsArray[10, 8 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[4 + i, 4].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[12, 6 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[16, 4 + i].BackColor = Color.Lime;
                }

                if (i < 5)
                {
                    //Color panels in Lime
                    panelsArray[8 + i, 6].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[10 + i, 20].BackColor = Color.Lime;
                }

                if (i < 15)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i % 2 == 0)
                        {
                            //Color panels in Lime
                            panelsArray[5 + j, 6 + i].BackColor = Color.Lime;
                        }
                    }
                }

                if (i < 4)
                {
                    //Color panels in Lime
                    panelsArray[1 + i, 14].BackColor = Color.Lime;

                }

                if (i < 7)
                {
                    //Color panels in Lime
                    panelsArray[16 + i, 16].BackColor = Color.Lime;
                }

                if (i < 11)
                {
                    //Color panels in Lime
                    panelsArray[2 + i, 22].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[2, 2 + i].BackColor = Color.Lime;
                }

                if (i < 8)
                {
                    //Color panels in Lime
                    panelsArray[2, 16 + i].BackColor = Color.Lime;
                }

                if (i < 18)
                {
                    //Color panels in Lime
                    panelsArray[14, 6 + i].BackColor = Color.Lime;
                }

                if (i < 15)
                {
                    //Color panels in Lime
                    panelsArray[18, 2 + i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[20, i].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[22, 2 + i].BackColor = Color.Lime;
                }

                if (i < 7)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            //Color panels in Lime
                            panelsArray[16 + i, j + 17].BackColor = Color.Lime;
                        }
                    }
                }
            }

            //Color the border of the maze
            ColorBorder();

            panelsArray[3, 23].BackColor = Color.Snow;

            panelsArray[17, 15].BackColor = Color.Snow;

            //Color the begining of the game
            panelsArray[1, 1].BackColor = Color.Blue;

            //Color the begining of the game
            panelsArray[1, 23].BackColor = Color.Red;
        }




        /******************************************************************/




        /// <summary>
        /// The code when we click startbutton and when we touch the wall of the maze
        /// </summary>
        private void ReturnMouse()
        {
            if (levelCount == 1)
            {
                //Put the point where the cursor will apear if the game restarts or the user touch the border of the maze
                startingPoint = new Point(745, 185);

                //Put 10px down and 10 px left
                startingPoint.Offset(10, 10);

                //Replace the cursor
                Cursor.Position = PointToScreen(startingPoint);
            }

            if (levelCount == 2 || levelCount == 3 || levelCount == 4 || levelCount == 5 || levelCount == 6 || levelCount == 7 || levelCount == 8 || levelCount == 9 || levelCount == 10)
            {
                //Put the point where the cursor will apear if the game restarts or the user touch the border of the maze
                startingPoint = new Point(125, 185);

                //Put 10px down and 10 px left
                startingPoint.Offset(10, 10);

                //Replace the cursor
                Cursor.Position = PointToScreen(startingPoint);
            }
        }




        /******************************************************************/




        private void restartAll()
        {
            checkLevelOrder();

            //Close tha application
            ReturnMouse();

            labelChrono.Text = "00:00:00";

            stopTimer();

            //Start the timer
            timerCount.Start();
            timerRunning = true;

            checkDisableMouse = true;

            //The variable to generate a random boolean
            checkRedArea = Convert.ToBoolean(null);

            //The variable to launch the flashPanels
            checkSnowArea1 = false;

            //The variable to launch the flashPanels
            checkSnowArea2 = false;

            //The variable to display the message of the level 10
            checkRedLvl10 = false;

            //Checker for flashing panel
            flashPanel = true;

            labelLife.Text = "♥♥♥";

            countLife = 3;
        }




        /******************************************************************/




        private void stopTimer()
        {
            // Stop and reset the timer if it was running
            timerCount.Stop();
            timerRunning = false;

            // Reset the elapsed time TimeSpan objects
            totalElapsedTime = TimeSpan.Zero;
            currentElapsedTime = TimeSpan.Zero;


            // Set the start time to Now
            startTime = DateTime.Now;

            // Store the total elapsed time so far
            totalElapsedTime = currentElapsedTime;
        }




        /******************************************************************/




        private void theMazeGame_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    if (panelMenu.Visible == true)
            //    {
            //        panelMenu.Visible = false;
            //    }
            //    else
            //    {
            //        panelMenu.Visible = true;
            //    }
            //}
        }




        /******************************************************************/




        /// <summary>
        /// Thge code when the timer has begin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timerCount_Tick(object sender, EventArgs e)
        {
            timerCounter();
        }




        /******************************************************************/




        /// <summary>
        /// The method to make count the timer
        /// </summary>
        private void timerCounter()
        {
            // We do this to chop off any stray milliseconds resulting from 
            // the Timer's inherent inaccuracy, with the bonus that the 
            // TimeSpan.ToString() method will now show correct HH:MM:SS format
            var timeSinceStartTime = DateTime.Now - startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours,
                                              timeSinceStartTime.Minutes,
                                              timeSinceStartTime.Seconds);

            //Calculate the elapsed time to display thge chronometer
            currentElapsedTime = timeSinceStartTime + totalElapsedTime;

            currentElapsedTime2 = currentElapsedTime;

            //Display the chronometer
            labelChrono.Text = currentElapsedTime2.ToString();
        }




        /******************************************************************/




        private void MouseEvent()
        {
            //Check if the backcolor of the cursor position is Green
            if (panelsArray[x, y].BackColor == Color.Lime)
            {
                //Return the cursor at the begginig of the game
                ReturnMouse();

                //******The code for life******/

                //Check if countLife is equal to 1
                if (countLife == 1)
                {
                    //Change the text of labelLife
                    labelLife.Text = "";

                    //Put countlife to 0
                    countLife = 0;

                    //Display a message
                    displayMessage();

                    registerScores();
                }

                //Check if countLife is equal to 2
                if(countLife == 2)
                {
                    //Change the text of labelLife
                    labelLife.Text = "♥";

                    //Put countlife to 1
                    countLife = 1;
                }

                //Check if countLife is equal to 3
                if (countLife == 3)
                {
                    //Change the text of labelLife
                    labelLife.Text = "♥♥";

                    //Put countlife to 2
                    countLife = 2;
                }
            }

            //Check if the backcolor of the cursor backcolor is red
            if (panelsArray[x, y].BackColor == Color.Red)
            {
                checkRedLvl10 = true;

                displayMessage();

                if(levelCount == 10)
                {
                    winAllGame = true;

                    registerScores();
                }

            }

            if (levelCount == 3)
            {
                if (panelsArray[x, y].BackColor == Color.Snow)
                {
                    //Color panels in control color
                    panelsArray[7, 5].BackColor = Color.Gray;

                    //Color the begining of the game
                    if (checkRedArea == true)
                    {
                        panelsArray[widthNumber - 2, 17].BackColor = Color.Red;
                    }

                    if (checkRedArea == false)
                    {
                        panelsArray[widthNumber - 2, 9].BackColor = Color.Red;
                    }

                    //Color panels in control color
                    panelsArray[21, 13].BackColor = Color.Gray;
                }
            }

            if (levelCount == 4)
            {
                if (panelsArray[x, y].BackColor == Color.Black)
                {
                    if (moveCursor == 3)
                    {
                        //Put the point where the cursor will apear if the game restarts or the user touch the border of the maze
                        startingPoint = new Point(670, 805);

                        //Put 10px down and 10 px left
                        startingPoint.Offset(10, 10);

                        //Replace the cursor
                        Cursor.Position = PointToScreen(startingPoint);
                    }

                    if (moveCursor == 2)
                    {
                        //Put the point where the cursor will apear if the game restarts or the user touch the border of the maze
                        startingPoint = new Point(250, 185);

                        //Put 10px down and 10 px left
                        startingPoint.Offset(10, 10);

                        //Replace the cursor
                        Cursor.Position = PointToScreen(startingPoint);
                    }

                    if (moveCursor == 1)
                    {
                        //Put the point where the cursor will apear if the game restarts or the user touch the border of the maze
                        startingPoint = new Point(125, 685);

                        //Put 10px down and 10 px left
                        startingPoint.Offset(10, 10);

                        //Replace the cursor
                        Cursor.Position = PointToScreen(startingPoint);
                    }

                    if (moveCursor == 0)
                    {
                        //Put the point where the cursor will apear if the game restarts or the user touch the border of the maze
                        startingPoint = new Point(745, 285);

                        //Put 10px down and 10 px left
                        startingPoint.Offset(10, 10);

                        //Replace the cursor
                        Cursor.Position = PointToScreen(startingPoint);
                    }
                }

                if (panelsArray[x, y].BackColor == Color.Snow)
                {
                    if (panelsArray[x, y] == panelsArray[12, 16])
                    {
                        //Color panels in control color
                        panelsArray[12, 15].BackColor = Color.Gray;

                        //Color panels in control color
                        panelsArray[12, 16].BackColor = Color.Gray;

                        moveCursor++;
                    }

                    if (panelsArray[x, y] == panelsArray[12, 8])
                    {
                        //Color panels in control color
                        panelsArray[12, 9].BackColor = Color.Gray;

                        //Color panels in control color
                        panelsArray[12, 8].BackColor = Color.Gray;

                        moveCursor++;
                    }

                    if (panelsArray[x, y] == panelsArray[8, 12])
                    {
                        //Color panels in control color
                        panelsArray[9, 12].BackColor = Color.Gray;

                        //Color panels in control color
                        panelsArray[8, 12].BackColor = Color.Gray;

                        moveCursor++;
                    }

                    if (panelsArray[x, y] == panelsArray[16, 12])
                    {
                        //Color panels in control color
                        panelsArray[15, 12].BackColor = Color.Gray;

                        //Color panels in control color
                        panelsArray[16, 12].BackColor = Color.Gray;

                        moveCursor++;
                    }
                }

                if (moveCursor == 4)
                {
                    panelsArray[12, 12].BackColor = Color.Red;
                }
            }

            //Check if levelCount is equal to 5
            if (levelCount == 5)
            {
                //Check if the case where is the mouse is Snow and if the case is 1, 19
                if (panelsArray[x, y] == panelsArray[1, 19] & panelsArray[1, 19].BackColor == Color.Snow)
                {
                    panelsArray[1, 12].BackColor = Color.Gray;
                }

                //Check if the case where is the mouse is black
                if (panelsArray[x, y].BackColor == Color.Black)
                {
                    //Put the point where the cursor will apear if the game restarts or the user touch the border of the maze
                    startingPoint = new Point(125, 650);

                    //Put 10px down and 10 px left
                    startingPoint.Offset(10, 10);

                    //Replace the cursor
                    Cursor.Position = PointToScreen(startingPoint);
                }//End if
            }//End if

            if (levelCount == 6)
            {
                if (panelsArray[x, y].BackColor == Color.Snow)
                {
                    //Color panels in control color
                    panelsArray[22, 4].BackColor = Color.Gray;
                }
            }

            if (levelCount == 7)
            {
                if (panelsArray[x, y].BackColor == Color.Snow & panelsArray[x, y] == panelsArray[15, 15])
                {
                    panelsArray[15, 15].BackColor = Color.Gray;

                    panelsArray[11, 12].BackColor = Color.Gray;
                }

                if (panelsArray[x, y].BackColor == Color.Snow & panelsArray[x, y] == panelsArray[12, 12])
                {
                    panelsArray[12, 12].BackColor = Color.Gray;

                    panelsArray[18, 22].BackColor = Color.Gray;

                    panelsArray[22, 18].BackColor = Color.Gray;
                }
            }

            if (levelCount == 8)
            {
                if (panelsArray[x, y].BackColor == Color.Snow)
                {
                    //Color panels in control color
                    panelsArray[12, 17].BackColor = Color.Gray;
                }
            }

            if (levelCount == 9)
            {
                if (panelsArray[x, y].BackColor == Color.Black)
                {
                    //Put the point where the cursor will apear if the game restarts or the user touch the border of the maze
                    startingPoint = new Point(125, 360);

                    //Put 10px down and 10 px left
                    startingPoint.Offset(10, 10);

                    //Replace the cursor
                    Cursor.Position = PointToScreen(startingPoint);
                }
            }

            if(levelCount == 10)
            {
                if (panelsArray[x, y] == panelsArray[17, 15] & panelsArray[x, y].BackColor == Color.Snow)
                {
                    //Color panels in control color
                    panelsArray[17, 15].BackColor = Color.Gray;

                    checkSnowArea1 = true;
                }

                if (panelsArray[x, y] == panelsArray[3, 23] & panelsArray[x, y].BackColor == Color.Snow)
                {
                    //Color panels in control color
                    panelsArray[3, 23].BackColor = Color.Gray;

                    checkSnowArea2 = true;
                }
            }
        }




        /******************************************************************/




        private void panelGrate_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkDisableMouse == true)
            {

                //check if checkLoseGame is true
                if (checkLoseGame == true)
                {
                    //When the user click on the chess button that put it in the clickButton
                    Panel clickButton = sender as Panel;

                    //for loop line
                    for (int i = 0; i < heightNumber; i++)
                    {
                        //for loop column
                        for (int j = 0; j < widthNumber; j++)
                        {
                            //Put i in x and j in y
                            if (sender.Equals(panelsArray[i, j]))
                            {
                                //Put i in x
                                x = i;

                                //Put j in y
                                y = j;
                            }//End if
                        }//End second for loop
                    }//End first for loop

                    MouseEvent();

                }//End if
            }//End if
        }

        //private void panelGrate_DragLeave(object sender, System.Windows.Forms.DragEventHandler e)
        //{
        //    if (checkDisableMouse == true)
        //    {

        //        //check if checkLoseGame is true
        //        if (checkLoseGame == true)
        //        {
        //            //When the user click on the chess button that put it in the clickButton
        //            Panel clickButton = sender as Panel;

        //            //for loop line
        //            for (int i = 0; i < heightNumber; i++)
        //            {
        //                //for loop column
        //                for (int j = 0; j < widthNumber; j++)
        //                {
        //                    //Put i in x and j in y
        //                    if (sender.Equals(panelsArray[i, j]))
        //                    {
        //                        //Put i in x
        //                        x = i;

        //                        //Put j in y
        //                        y = j;
        //                    }//End if
        //                }//End second for loop
        //            }//End first for loop

        //            MouseEvent();

        //        }//End if
        //    }//End if
        //}

        private void panelGrate_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (checkDisableMouse == true)
            {

                //check if checkLoseGame is true
                if (checkLoseGame == true)
                {
                    //When the user click on the chess button that put it in the clickButton
                    Panel clickButton = sender as Panel;

                    //for loop line
                    for (int i = 0; i < heightNumber; i++)
                    {
                        //for loop column
                        for (int j = 0; j < widthNumber; j++)
                        {
                            //Put i in x and j in y
                            if (sender.Equals(panelsArray[i, j]))
                            {
                                //Put i in x
                                x = i;

                                //Put j in y
                                y = j;
                            }//End if
                        }//End second for loop
                    }//End first for loop

                    MouseEvent();

                }//End if
            }//End if
        }




        /******************************************************************/




        /// <summary>
        /// The code when we are in the green area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelGrate_MouseEnter(object sender, EventArgs e)
        {
            if (checkDisableMouse == true)
            {

                //check if checkLoseGame is true
                if (checkLoseGame == true)
                {
                    //When the user click on the chess button that put it in the clickButton
                    Panel clickButton = sender as Panel;

                    //for loop line
                    for (int i = 0; i < heightNumber; i++)
                    {
                        //for loop column
                        for (int j = 0; j < widthNumber; j++)
                        {
                            //Put i in x and j in y
                            if (sender.Equals(panelsArray[i, j]))
                            {
                                //Put i in x
                                x = i;

                                //Put j in y
                                y = j;
                            }//End if
                        }//End second for loop
                    }//End first for loop

                    MouseEvent();

                }//End if
            }//End if
        }//End panelGrate_MouseEnter




        /******************************************************************/




        /// <summary>
        /// The method to check the order of mazes
        /// </summary>
        private void checkLevelOrder()
        {
            //Check if levelCount is equal to 1
            if ((comboBoxChooseLevel.Text == "" || comboBoxChooseLevel.Text == "All level" || comboBoxChooseLevel.Text == "Level 1") & levelCount == 1)
            {
                levelCount = 1;

                //Make the 1 maze
                CreateMazeLvl1();
            }//End if

            //Check if levelCount is equal to 2
            if (comboBoxChooseLevel.Text == "Level 2" || levelCount == 2)
            {
                levelCount = 2;

                //Make the 2 maze
                CreateMazeLvl2();
            }//End if

            //Check if levelCount is equal to 3
            if (levelCount == 3 || comboBoxChooseLevel.Text == "Level 3")
            {
                levelCount = 3;

                //Make the 3 maze
                CreateMazeLvl3();
            }//End if

            //Check if levelCount is equal to 4
            if (levelCount == 4 || comboBoxChooseLevel.Text == "Level 4")
            {
                levelCount = 4;

                //Make the 4 maze
                CreateMazeLvl4();
            }//End if

            //Check if levelCount is equal to 5
            if (levelCount == 5 || comboBoxChooseLevel.Text == "Level 5")
            {
                levelCount = 5;

                //Make the 5 maze
                CreateMazeLvl5();
            }//End if

            //Check if levelCount is equal to 6
            if (levelCount == 6 || comboBoxChooseLevel.Text == "Level 6")
            {
                levelCount = 6;

                //Make the 6 maze
                CreateMazeLvl6();
            }//End if

            //Check if levelCount is equal to 7
            if (levelCount == 7 || comboBoxChooseLevel.Text == "Level 7")
            {
                levelCount = 7;

                //Make the 7 maze
                CreateMazeLvl7();
            }//End if

            //Check if levelCount is equal to 8
            if (levelCount == 8 || comboBoxChooseLevel.Text == "Level 8")
            {
                levelCount = 8;

                //Make the 8 maze
                CreateMazeLvl8();
            }//End if

            //Check if levelCount is equal to 9
            if (levelCount == 9 || comboBoxChooseLevel.Text == "Level 9")
            {
                levelCount = 9;

                //Make the 9 maze
                CreateMazeLvl9();
            }//End if

            //Check if levelCount is equal to 10
            if (levelCount == 10 || comboBoxChooseLevel.Text == "Level 10")
            {
                levelCount = 10;

                //Make the 10 maze
                CreateMazeLvl10();
            }//End if
        }




        /******************************************************************/




        /// <summary>
        /// When we scroll the trackbar the programm change the mouse sensitivity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarMouseSensitivity_Scroll(object sender, EventArgs e)
        {
            //take the value of the trackBar and put it in mouseSensitivity
            mouseSensitivity = Convert.ToUInt16(trackBarMouseSensitivity.Value);

            int res = WinAPI.SystemParametersInfo(113, 0, mouseSensitivity, 0);
        }

        public class WinAPI
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto),]
            public static extern int SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
        }




        /******************************************************************/




        /// <summary>
        /// The code when we click on start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //Change the text of the chrono
            labelChrono.Text = "00:00:00";

            //Make the method to create panel
            CreatePanel();

            //Make the method to check level order
            checkLevelOrder();

            //Hide the panelMainMenu
            panelMainMenu.Visible = false;

            buttonStart.Enabled = true;

            buttonRestart.Enabled = false;

            //Enabled the timerFlash
            timerFlash.Enabled = true;
        }//End buttonStart_Click




        /******************************************************************/




        /// <summary>
        /// The code when we click the start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            //Enabled the buttonRestart
            buttonRestart.Enabled = true;

            //Disable the buttonStart
            buttonStart.Enabled = false;

            //Put true in checkDisableMouse
            checkDisableMouse = true;

            //Return the cursor at the begginig of the game
            ReturnMouse();

            //Put checkloseGame in true
            checkLoseGame = true;

            // If the timer isn't already running
            if (!timerRunning)
            {
                // Set the start time to Now
                startTime = DateTime.Now;

                // Store the total elapsed time so far
                totalElapsedTime = currentElapsedTime2;

                //Start the timer
                timerCount.Start();
                timerRunning = true;
            }
        }




        /******************************************************************/




        /// <summary>
        /// The code when we click on restart button6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            //Make the method to reset all
            restartAll();
        }




        /******************************************************************/




        /// <summary>
        /// The code when we click on option button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOptions_Click(object sender, EventArgs e)
        {
            //Change the text of the button instruction
            buttonInstructions.Text = "Instructions";

            //Hide the rich text box
            PanelInstructions.Visible = false;

            //Put checkinstructions in true
            checkInstructions = true;

            //Check if checkoptions is true
            if (checkOptions == true)
            {
                //Display the panelOptions
                panelOptions.Visible = true;
            }//End if
            else
            {
                //Hide the panelOptions
                panelOptions.Visible = false;
            }//End else

            //Check if panelOptions is visible
            if (panelOptions.Visible == true)
            {
                //Change the text of the buttonOptions
                buttonOptions.Text = "Previous";
            }//End if
            else
            {
                //Change the text of the buttonOptions
                buttonOptions.Text = "Options";
            }//End else

            //Change the checkOptions in his opposite
            checkOptions = !checkOptions;
        }




        /******************************************************************/




        /// <summary>
        /// The code when we click on instructions button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInstructions_Click(object sender, EventArgs e)
        {
            //Change the text of the buttonOption
            buttonOptions.Text = "Options";

            //Hide the panelOptions
            panelOptions.Visible = false;

            //Put true in checkOptions
            checkOptions = true;

            if (checkInstructions == true)
            {
                //Display the rich text box
                PanelInstructions.Visible = true;
            }//End if
            else
            {
                //Hide the rich text box
                PanelInstructions.Visible = false;
            }//End else

            if (PanelInstructions.Visible == true)
            {
                buttonInstructions.Text = "Previous";
            }//End if
            else
            {
                buttonInstructions.Text = "Instructions";
            }//End else

            //Change the checkInstructions in his opposite
            checkInstructions = !checkInstructions;
        }//End buttonInstructions_Click




        /******************************************************************/




        /// <summary>
        /// The code when we click on exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            //Close the application
            Application.Exit();

        }




        /******************************************************************/




        /// <summary>
        /// The code when we click on exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit2_Click(object sender, EventArgs e)
        {
            //Close the application
            Application.Exit();
        }




        /******************************************************************/




        /// <summary>
        /// The code the timer do all seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerFlash_Tick(object sender, EventArgs e)
        {
            if (levelCount == 8)
            {
                
                for (int i = 0; i < 23; i++)
                {
                    if (i == 2 || i == 5 || i == 19 || i == 22)
                    {
                        if (flashPanel == true)
                        {
                            //Color panels in Lime
                            panelsArray[12, i].BackColor = Color.Lime;

                            //Color panels in Lime
                            panelsArray[i, 12].BackColor = Color.Lime;
                        }

                        if (flashPanel == false)
                        {
                            //Color panels in control color
                            panelsArray[12, i].BackColor = Color.Gray;

                            //Color panels in control color
                            panelsArray[i, 12].BackColor = Color.Gray;
                        }
                    }
                }


                flashPanel = !flashPanel;
            }

            if(levelCount == 9)
            {
                
                if (flashPanel == true)
                {
                    //Color panels in Lime
                    panelsArray[3, 20].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13, 16].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[10, 22].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[12, 22].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19, 6].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19, 10].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19, 14].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[19, 18].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13, 8].BackColor = Color.Lime;

                    //Color panels in Lime
                    panelsArray[13, 12].BackColor = Color.Lime;
                }

                if (flashPanel == false)
                {
                    //Color panels in control color
                    panelsArray[3, 20].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[13, 16].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[10, 22].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[12, 22].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[19, 6].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[19, 10].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[19, 14].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[19, 18].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[13, 8].BackColor = Color.Gray;

                    //Color panels in control color
                    panelsArray[13, 12].BackColor = Color.Gray;
                }

                flashPanel = !flashPanel;
            }

            if (levelCount == 10)
            {

                if (flashPanel == true)
                {
                    if (checkSnowArea1 == true)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            //Color panels in control color
                            panelsArray[16, 17 + i].BackColor = Color.Gray;

                            //Color panels in control color
                            panelsArray[18, 17 + i].BackColor = Color.Gray;

                            //Color panels in Lime
                            panelsArray[20, 17 + i].BackColor = Color.Lime;

                            //Color panels in Lime
                            panelsArray[22, 17 + i].BackColor = Color.Lime;
                        }
                    }

                    if (checkSnowArea2 == true)
                    {
                        for (int i = 0; i < 14; i++)
                        {
                            if (i % 4 == 0)
                            {
                                //Color panels in control color
                                panelsArray[5, 6 + i].BackColor = Color.Gray;

                                //Color panels in Lime
                                panelsArray[7, 8 + i].BackColor = Color.Lime;
                            }
                        }
                    }
                }

                if (flashPanel == false)
                {
                    if(checkSnowArea1 == true)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            //Color panels in Lime
                            panelsArray[16, 17 + i].BackColor = Color.Lime;

                            //Color panels in Lime
                            panelsArray[18, 17 + i].BackColor = Color.Lime;

                            //Color panels in control color
                            panelsArray[20, 17 + i].BackColor = Color.Gray;

                            //Color panels in control color
                            panelsArray[22, 17 + i].BackColor = Color.Gray;
                        }
                    }

                    if (checkSnowArea2 == true)
                    {
                        for (int i = 0; i < 14; i++)
                        {
                            if (i % 4 == 0)
                            {
                                //Color panels in Lime
                                panelsArray[5, 6 + i].BackColor = Color.Lime;

                                //Color panels in control color
                                panelsArray[7, 8 + i].BackColor = Color.Gray;
                            }//End if
                        }//End for
                    }//End if
                }//End if

                //Change in opposite the flashPanel
                flashPanel = !flashPanel;
            }
        }




        /******************************************************************/




        /// <summary>
        /// The code when we move the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTopMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }




        /******************************************************************/




        /// <summary>
        /// The code when we change the choice in the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxChooseLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonPlay.Enabled = true;

            switch (comboBoxChooseLevel.SelectedIndex)
            {
                case 0:
                    pictureBoxDisplayLevel.Image = Properties.Resources.All_Level;

                    checkReplayLvl = false;

                    levelCount = 1;
                    break;
                case 1:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_1;

                    checkReplayLvl = true;

                    levelCount= 1;
                    break;
                case 2:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_2;

                    checkReplayLvl = true;

                    levelCount = 2;
                    break;
                case 3:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_3;

                    checkReplayLvl = true;

                    levelCount = 3;
                    break;
                case 4:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_4;

                    checkReplayLvl = true;

                    levelCount = 4;
                    break;
                case 5:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_5;

                    checkReplayLvl = true;

                    levelCount = 5;
                    break;
                case 6:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_6;

                    checkReplayLvl = true;

                    levelCount = 6;
                    break;
                case 7:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_7;

                    checkReplayLvl = true;

                    levelCount = 7;
                    break;
                case 8:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_8;

                    checkReplayLvl = true;

                    levelCount = 8;
                    break;
                case 9:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_9;

                    checkReplayLvl = true;

                    levelCount = 9;
                    break;
                case 10:
                    pictureBoxDisplayLevel.Image = Properties.Resources.Level_10;

                    checkReplayLvl = true;

                    levelCount = 10;
                    break;

            }

            if(comboBoxChooseLevel.Text == "")
            {
                levelCount = 1;
            }
        }




        /******************************************************************/




        /// <summary>
        /// The code when we change the choice of the radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonTimerEasy_CheckedChanged(object sender, EventArgs e)
        {
            timerFlash.Interval = 900;
        }




        /******************************************************************/




        /// <summary>
        /// The code when we change the choice of the radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonTimerRegular_CheckedChanged(object sender, EventArgs e)
        {
            timerFlash.Interval = 600;
        }




        /******************************************************************/




        /// <summary>
        /// The code when we change the choice of the radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonTimerHard_CheckedChanged(object sender, EventArgs e)
        {
            timerFlash.Interval = 300;
        }

        private void buttonDisplayScores_Click(object sender, EventArgs e)
        {
            Scores Scores = new Scores();
            Scores.Show();
        }

        /// <summary>
        /// Creation of the xml files with table and his elements
        /// </summary>
        /// <param name="scoresInfos"></param>
        static public void newScores(scoresInfos scoresInfos)
        {
            //Check the folder if the XML file isn't already there
            if (!File.Exists(Register.locationFile))
            {
                //Create a new XML file and declare a writer object
                XmlTextWriter writer = new XmlTextWriter(Register.locationFile, null);

                //Create the "title" of the XML file
                writer.WriteStartElement("TheMazeGame");

                //End the title element
                writer.WriteEndElement();

                //Close the writer
                writer.Close();
            }

            //**************  NEW SCORE *******************

            // Load existing scores and add new 
            XElement xml = XElement.Load(Register.locationFile);

            //New Element (new Score)
            xml.Add(new XElement("User",

            //User's pseudos
            new XAttribute("Player", scoresInfos.player),

            //Elapsed time of the match
            new XAttribute("ElapsedTime", scoresInfos.time),

            //Get in how much clicks he has won
            new XAttribute("Life", scoresInfos.life),

            //Get in how much clicks he has won
            new XAttribute("Level", scoresInfos.level),

            //Get in how much clicks he has won
            new XAttribute("Date", scoresInfos.date)));

            //Save the new score
            xml.Save(Register.locationFile);

            //**********************************************

            Scores Scores = new Scores();

            Scores.Show();
        }




        /// <summary>
        /// Class of the infos of each player and party for the database
        /// </summary>
        public class scoresInfos
        {
            //Get the player 1 pseudo
            public string player
            {
                get;
                set;
            }

            //Get the elapsed time of the match
            public string time
            {
                get;
                set;
            }

            //Get nb of victory for each player
            public string life
            {
                get;
                set;
            }

            //Get who has won
            public string level
            {
                get;
                set;
            }

            //Get who has won
            public string date
            {
                get;
                set;
            }
        }
    }
}