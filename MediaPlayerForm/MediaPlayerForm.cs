using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

// Jesse Lucas
// P274063
//24/07/2020
// Question 1 – You need to make a Music Player for all staff to use. You need to 
//create a program that plays audio tracks, it must have the ability to go to the start,
//go back one, go forward one and skip to the end.It must have a GUI and must use
//doubly linked LinkedLists.

namespace MediaPlayerForm
{
    public partial class AudioPlayerForm : Form
    {
        public AudioPlayerForm()
        {
            InitializeComponent();
        }
        // creating the doubly linked LinkedList
        LinkedList<string> SongLinkedList = new LinkedList<string>();


        // using the windows media player URl function 
        // we get the first value and plays using playSound()
        private void ButtonFirst_Click(object sender, EventArgs e)
        {
            try
            {
                string songPlaying = axWindowsMediaPlayer1.URL;
                PlaySound(SongLinkedList.First.Value);
                DisplaySongs(SongLinkedList.First.Value);
            }
            catch
            {
                textBoxError.Text = "No songs loaded";
            }
        }
        // using the windows mediaplayer URL function and the playSound we can get the next value and plays
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            try
            {
                string songPlaying = axWindowsMediaPlayer1.URL;
                PlaySound(SongLinkedList.Find(songPlaying).Next.Value);
                DisplaySongs(SongLinkedList.Find(songPlaying).Next.Value);
             }
            catch
            {
                textBoxError.Text = "Error can not play next";
            }            
        }

        // using the windows media player URL and the playSound method we can get the previous value and play
        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                string songPlaying = axWindowsMediaPlayer1.URL;
                PlaySound(SongLinkedList.Find(songPlaying).Previous.Value);
                DisplaySongs(SongLinkedList.Find(songPlaying).Previous.Value);
            }
            catch
            {
                textBoxError.Text = "Error can not play previous";
            }
        }

        // using the windows media player URl and the play sound method we can get the last value and play
    private void ButtonLast_Click(object sender, EventArgs e)
        {
            string songPlaying = axWindowsMediaPlayer1.URL;
            PlaySound(SongLinkedList.Last.Value);
            DisplaySongs(SongLinkedList.Last.Value);
        }

        // here we open a file dialog and we can add the songs to the mediaplayer which adds to our linked LinkedList
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;                
                SongLinkedList.AddLast(filePath.ToString());           
            }
          
        }
        // here we just stop the music
            private void ButtonStop_Click(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            catch
            {
                ErrorMsg.Text = "Can't stop won't stop";
            }
        }

        // here we use the windows media player URL with string playsong then we simply play the music
        public void PlaySound(string playsong)
        {            
            try
            {
                axWindowsMediaPlayer1.URL = playsong;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch
            {
                ErrorMsg.Text = "Can not play";
            }
            }

        // Displaying songs here we split the string pathnae and file name so it just displays the song name and not the whole path name
        public void DisplaySongs(string title)
        {
            string songPlaying = axWindowsMediaPlayer1.URL;
            PlaySound(SongLinkedList.Find(songPlaying).Value);
            string[] pathname = title.Split('\\');
            string[] filename = pathname.Last().Split('.');
            string songtitle = filename.First().ToString();
            textBoxCurrentSong.Text = songtitle;
        }

       
    }
    }

