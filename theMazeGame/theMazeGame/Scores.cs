///ETML DemoMot
///Author : Alen Bijelic
///Date   : 18.6.2015
///Summary : Display the name, the time, the life, the level, and the date of the players.
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
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
        }




        //*********************************************************************************
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //*********************************************************************************




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



        /******************************************************/



        //The code when we move the panelTopMenu
        private void panelTopMenu_MouseDown(object sender, MouseEventArgs e)
        {
            //Move the form
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }



        /******************************************************/



        /// <summary>
        /// The code to display the scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scores_Load(object sender, EventArgs e)
        {
            if (File.Exists(Register.locationFile))
            {
                //Read the xml file
                XmlReader reader = XmlReader.Create(Register.locationFile);

                //While there's something to read it will read the file
                while (reader.Read())
                {
                    //If it founds the element "User" it display each values
                    if ((reader.Name == "User"))
                    {
                        //If it has any attributes it display it in the listbox
                        if (reader.HasAttributes)
                        {
                            //Add each item of the xml file in the listview
                            ListViewItem newListItem = new ListViewItem(reader.GetAttribute("Player"));
                            newListItem.SubItems.Add(reader.GetAttribute("ElapsedTime"));
                            newListItem.SubItems.Add(reader.GetAttribute("Life"));
                            newListItem.SubItems.Add(reader.GetAttribute("Level"));
                            newListItem.SubItems.Add(reader.GetAttribute("Date"));
                            scoresList.Items.Add(newListItem);
                        }
                    }
                }
                reader.Close();
            }
        }
    }
}
