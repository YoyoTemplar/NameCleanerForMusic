using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NameCleanerForMusic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string FullPathSrc { get; set; }
        public string FileName { get; set; }
        public string FullPathDst { get; set; }

        private void button_Go_Click(object sender, EventArgs e)
        {
            listBox_results.Items.Clear();
            FileManager fm1 = new FileManager();
            listBox_results.Items.AddRange(fm1.GetDirectories(textBox_Path.Text));
            listBox_results.Items.AddRange(fm1.GetFiles());
        }

        //открытие файла или переход в подпапку по двойному щелчку мышью
        private void listBox_results_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Path.GetExtension(Path.Combine(textBox_Path.Text, listBox_results.SelectedItem.ToString())) == "")
            {
                textBox_Path.Text = Path.Combine(textBox_Path.Text, listBox_results.SelectedItem.ToString());
                listBox_results.Items.Clear();
                FileManager fm2 = new FileManager();
                listBox_results.Items.AddRange(fm2.GetDirectories(textBox_Path.Text));
                listBox_results.Items.AddRange(fm2.GetFiles());
            }
            else
            {
                Process.Start(Path.Combine(textBox_Path.Text, listBox_results.SelectedItem.ToString()));
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            if (textBox_Path.Text[textBox_Path.Text.Length - 1] == '\\')
            {
                textBox_Path.Text = textBox_Path.Text.Remove(textBox_Path.Text.Length - 1, 1);
                while (textBox_Path.Text[textBox_Path.Text.Length - 1] != '\\')
                {
                    textBox_Path.Text = textBox_Path.Text.Remove(textBox_Path.Text.Length - 1, 1);
                }
            }
            else if (textBox_Path.Text[textBox_Path.Text.Length -1] != '\\')
            {
                while (textBox_Path.Text[textBox_Path.Text.Length - 1] != '\\')
                {
                    textBox_Path.Text = textBox_Path.Text.Remove(textBox_Path.Text.Length - 1, 1);
                }
            }
            listBox_results.Items.Clear();
            FileManager fm3 = new FileManager();
            listBox_results.Items.AddRange(fm3.GetDirectories(textBox_Path.Text));
            listBox_results.Items.AddRange(fm3.GetFiles());
        }

        //управление контекстным меню
        private void listBox_results_MouseUp(object sender, MouseEventArgs e)
        {          
            if (listBox_results.SelectedIndices.Count > 0 & listBox_results.SelectedIndices.Count < 2 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip_listBox_results.Enabled = true;
                ToolStripMenuItem_ClearName.Enabled = true;
                toolStripMenuItem_ClearSelected.Enabled = false;
                contextMenuStrip_listBox_results.Show(MousePosition, ToolStripDropDownDirection.Right);      
            }
            else if (listBox_results.SelectedIndices.Count > 1 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip_listBox_results.Enabled = true;
                ToolStripMenuItem_ClearName.Enabled = false;
                toolStripMenuItem_ClearSelected.Enabled = true;
                contextMenuStrip_listBox_results.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
            else
            {
                contextMenuStrip_listBox_results.Enabled = false;
            }
        }
       
        private async void ToolStripMenuItem_ClearName_Click(object sender, EventArgs e)
        {
            //единичная очистка имени
            using (SongContext db = new SongContext())
            {
                FileName = listBox_results.SelectedItem.ToString();
                NameEditor musicName = new NameEditor(FileName);
                FullPathSrc = Path.Combine(textBox_Path.Text, listBox_results.SelectedItem.ToString());
                FullPathDst = Path.Combine(textBox_Path.Text, musicName.RenameMusic());
                if (!FullPathSrc.Equals(FullPathDst) && File.Exists(FullPathSrc) && !File.Exists(FullPathDst))
                {
                    File.Move(FullPathSrc, FullPathDst);
                    Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.UtcNow };
                    db.Songs.Add(s1);
                    await db.SaveChangesAsync();
                    File.Delete(FullPathSrc);                    
                }
            }

            //автообновление страницы
            listBox_results.Items.Clear();
            FileManager fm3 = new FileManager();
            listBox_results.Items.AddRange(fm3.GetDirectories(textBox_Path.Text));
            listBox_results.Items.AddRange(fm3.GetFiles());
        }

        private async void toolStripMenuItem_ClearSelected_Click(object sender, EventArgs e)
        {
            // множественная очистка имён
            List<Song> songsCollection = new List<Song>();
            using (SongContext db = new SongContext())
            {
                foreach (var listBoxItem in listBox_results.SelectedItems)
                {
                    FileName = listBoxItem.ToString();
                    NameEditor musicName = new NameEditor(FileName);
                FullPathSrc = Path.Combine(textBox_Path.Text, listBoxItem.ToString());
                FullPathDst = Path.Combine(textBox_Path.Text, musicName.RenameMusic());
                if (!FullPathSrc.Equals(FullPathDst) && File.Exists(FullPathSrc) && !File.Exists(FullPathDst))
                    {
                        File.Move(FullPathSrc, FullPathDst);
                        Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.Now, Path = Path.GetDirectoryName(FullPathDst) };
                        songsCollection.Add(s1);
                        File.Delete(FullPathSrc);
                    }
                }
                db.Songs.AddRange(songsCollection);
                await db.SaveChangesAsync();         
            }
            songsCollection.Clear();

            //автообновление страницы
            listBox_results.Items.Clear();
            FileManager fm4 = new FileManager();
            listBox_results.Items.AddRange(fm4.GetDirectories(textBox_Path.Text));
            listBox_results.Items.AddRange(fm4.GetFiles());


            //-------------------------

            //List<string> listBoxResultsNames = new List<string>();


            //for (int i = 0; i < listBox_results.SelectedItems.Count; i++)
            //{
            //    listBoxResultsNames.Add(listBox_results.SelectedItems[i].ToString());
            //}
            //using (SongContext db = new SongContext())
            //{
            //    foreach (ListBox listBox in listBox_results.SelectedItems)
            //    {
            //        NameEditor musicName = new NameEditor(listBox.Name.ToString());
            //        FullPathSrc = Path.Combine(textBox_Path.Text, listBox.Name.ToString());
            //        FullPathDst = Path.Combine(textBox_Path.Text, musicName.RenameMusic());
            //        if (!FullPathSrc.Equals(FullPathDst) && File.Exists(FullPathSrc) && !File.Exists(FullPathDst))
            //        {
            //            File.Move(FullPathSrc, FullPathDst);
            //            Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.Now, Path = Path.GetDirectoryName(FullPathDst) };
            //            db.Songs.Add(s1);
            //            db.SaveChanges();
            //            File.Delete(FullPathSrc);
            //        }
            //    }
            //    //foreach (var listBoxResultName in listBoxResultsNames)
            //    //    {
            //    //        NameEditor musicName = new NameEditor(listBoxResultName);
            //    //        FullPathSrc = Path.Combine(textBox_Path.Text, listBoxResultName);
            //    //        FullPathDst = Path.Combine(textBox_Path.Text, musicName.RenameMusic());
            //    //        if (!FullPathSrc.Equals(FullPathDst) && File.Exists(FullPathSrc) && !File.Exists(FullPathDst))
            //    //        {
            //    //            File.Move(FullPathSrc, FullPathDst);
            //    //            Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.Now, Path = Path.GetDirectoryName(FullPathDst) };
            //    //            db.Songs.Add(s1);
            //    //            db.SaveChanges();
            //    //            File.Delete(FullPathSrc);
            //    //        }
            //    //    }
            //}

            ////using (SongContext db = new SongContext())
            ////{

            ////    foreach (var listBoxResultName in listBoxResultsNames)
            ////    {
            ////        NameEditor musicName = new NameEditor(listBoxResultName);
            ////        FullPathSrc = Path.Combine(textBox_Path.Text, listBoxResultName);
            ////        FullPathDst = Path.Combine(textBox_Path.Text, musicName.RenameMusic());
            ////        if (!FullPathSrc.Equals(FullPathDst) && File.Exists(FullPathSrc) && !File.Exists(FullPathDst))
            ////        {
            ////            File.Move(FullPathSrc, FullPathDst);
            ////            Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.Now, Path = Path.GetDirectoryName(FullPathDst) };
            ////            db.Songs.Add(s1);
            ////            db.SaveChanges();
            ////            File.Delete(FullPathSrc);
            ////            //Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.UtcNow };
            ////        }
            ////    }
            ////    //foreach (var listBoxResultName in listBoxResultsNames)
            ////    //{
            ////    //    NameEditor musicName = new NameEditor(listBoxResultName);
            ////    //    FullPathSrc = Path.Combine(textBox_Path.Text, listBoxResultName);
            ////    //    FullPathDst = Path.Combine(textBox_Path.Text, musicName.RenameMusic());
            ////    //    if (!FullPathSrc.Equals(FullPathDst) && File.Exists(FullPathSrc) && !File.Exists(FullPathDst))
            ////    //    {
            ////    //        File.Move(FullPathSrc, FullPathDst);
            ////    //        File.Delete(FullPathSrc);
            ////    //        //using (SongContext db = new SongContext())
            ////    //        //{
            ////    //        //    Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.UtcNow };
            ////    //        //    db.Songs.Add(s1);
            ////    //        //    db.SaveChanges();
            ////    //        //}
            ////    //        Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.UtcNow };
            ////    //        db.Songs.Add(s1);
            ////    //        db.SaveChanges();
            ////    //    }
            ////}

            //-------------------------
        }


    }
}
