///ETML DemoMot
///Author : Alen Bijelic
///Date   : 18.6.2015
///Summary : Ask to the user the username he want to play and to register the scores
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }


        //Userlogin used for the file location
        string userLogin = Environment.UserName;

        //
        public static string pathLocation = "c:\\Users\\";

        //String of the location of the file
        public static string locationFile;

        //Pseudo of player
        public static string userName;


        //*********************************************************************************
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //*********************************************************************************




        /// <summary>
        /// The code when we move the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTopMenu_MouseDown(object sender, MouseEventArgs e)
        {
            //Move the form
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }



        /*****************************************************************/



        /// <summary>
        /// The code when we click on exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit2_Click(object sender, EventArgs e)
        {
            //Close the form
            this.Close();
        }



        /*****************************************************************/



        /// <summary>
        /// The code when we click on buttonConfirm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            userName = textBoxUserName.Text;

            Register Register = new Register();
            Register.Hide();

            //Displaythe theMazeGame form
            theMazeGame theMazeGame = new theMazeGame();
            theMazeGame.Show();
        }



        /*****************************************************************/



        /// <summary>
        /// The code when the text box text has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            //Check if the lenght of the text is bigger than 6
            if (textBoxUserName.TextLength >= 6)
            {
                //Enabled the buttonConfirm
                buttonConfirm.Enabled = true;
            }
        }



        /*****************************************************************/



        /// <summary>
        /// The code when we click on enter to display the theMazeGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUserName_KeyUp(object sender, KeyEventArgs e)
        {
            //Check if the key pressed is equal to a enter key and if the lenght of the textBoxUserName is equal to 6
            if (e.KeyCode == Keys.Enter & textBoxUserName.TextLength >= 6)
            {
                Register Register = new Register();
                Register.Hide();

                //Displaythe theMazeGame form
                userName = textBoxUserName.Text;
                theMazeGame theMazeGame = new theMazeGame();
                theMazeGame.Show();
            }
        }



        /*****************************************************************/



        public void Register_Load(object sender, EventArgs e)
        {
            //Set the location for the file
            pathLocation = pathLocation + userLogin + "\\Documents\\TheMazeGameScores";

            //Location for the XML file
            locationFile = pathLocation + "\\TheMazeGame.xml";

            //Create the directory if it doesn't exists
            createDirectory();
        }



        /*****************************************************************/



        /// <summary>
        /// Method to create a directory
        /// </summary>
        static public void createDirectory()
        {
            //Check if the directory of the xml file exists and if not we create the folder.
            if (!Directory.Exists(pathLocation))
            {
                //Create the folder
                Directory.CreateDirectory(pathLocation);
            }
        }
    }
}
