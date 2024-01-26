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
            GetDrivesList();
            UpdateFilesList();
        }
        public string FullPathSrc { get; set; }
        public string FileName { get; set; }
        public string FullPathDst { get; set; }
        FileManager fm1 = new FileManager();
        List<string> systemDrivesPaths = new List<string>();

        //автообновление списка файлов для combobox
        public void UpdateFilesList()
        {

            if (IsContainSystemChapter(systemDrivesPaths, comboBox_Path.Text))
            {
                if (comboBox_Path.Text.Length >= 3)
                {
                    listBox_results.Items.Clear();
                    listBox_results.Items.AddRange(fm1.GetDirectories(comboBox_Path.Text));
                    comboBox_Path.Text = fm1.resultPath;
                    listBox_results.Items.AddRange(fm1.GetFiles());
                }
            }

        }
        //получение списка разделов жестких дисков
        public void GetDrivesList()
        {
            systemDrivesPaths = FileManager.GetSystemDrivesPaths();
            string[] listOfDrivesNamesForCombobox = new string[systemDrivesPaths.Count];
            for (int i = 0; i < systemDrivesPaths.Count; i++)
            {
                listOfDrivesNamesForCombobox[i] = systemDrivesPaths[i];
            }
            comboBox_Path.Items.AddRange(listOfDrivesNamesForCombobox);
        }

        //проверка на соответствие разделов системных дисков
        public bool IsContainSystemChapter(List<string>drives, string path)
        {
            foreach(var drive in drives)
            {
                if (path.Contains(drive.ToString()))
                {
                    return true;
                }                
            }
            return false;
        }

        //открытие файла или переход в подпапку по двойному щелчку мышью
        private void listBox_results_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Path.GetExtension(Path.Combine(comboBox_Path.Text, listBox_results.SelectedItem.ToString())) == "")
            {
                comboBox_Path.Text = Path.Combine(comboBox_Path.Text, listBox_results.SelectedItem.ToString());
                UpdateFilesList();
            }
            else
            {
                Process.Start(Path.Combine(comboBox_Path.Text, listBox_results.SelectedItem.ToString()));
            }
        }

        //переход назад по каталогу
        private void button_back_Click(object sender, EventArgs e)
        {
            if ((comboBox_Path.Text.Length > 3) && (comboBox_Path.Text[comboBox_Path.Text.Length - 1] == '\\'))
            {
                comboBox_Path.Text = comboBox_Path.Text.Remove(comboBox_Path.Text.Length - 1, 1);
                while ((comboBox_Path.Text.Length > 3) && (comboBox_Path.Text[comboBox_Path.Text.Length - 1] != '\\'))
                {
                    comboBox_Path.Text = comboBox_Path.Text.Remove(comboBox_Path.Text.Length - 1, 1);
                }
            }
            else if ((comboBox_Path.Text.Length > 3) && (comboBox_Path.Text[comboBox_Path.Text.Length - 1] != '\\'))
            {
                while ((comboBox_Path.Text.Length > 3) && (comboBox_Path.Text[comboBox_Path.Text.Length - 1] != '\\'))
                {
                    comboBox_Path.Text = comboBox_Path.Text.Remove(comboBox_Path.Text.Length - 1, 1);
                }
            }
            UpdateFilesList();
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

        //единичная очистка имени
        private async void ToolStripMenuItem_ClearName_Click(object sender, EventArgs e)
        {
            using (SongContext db = new SongContext())
            {
                FileName = listBox_results.SelectedItem.ToString();
                NameEditor musicName = new NameEditor(FileName);
                FullPathSrc = Path.Combine(comboBox_Path.Text, listBox_results.SelectedItem.ToString());
                FullPathDst = Path.Combine(comboBox_Path.Text, musicName.RenameMusic());
                if (!FullPathSrc.Equals(FullPathDst) && File.Exists(FullPathSrc) && !File.Exists(FullPathDst))
                {
                    File.Move(FullPathSrc, FullPathDst);
                    Song s1 = new Song { OldName = musicName.GetNameFromPath(FullPathSrc), NewName = musicName.GetNameFromPath(FullPathDst), DateOfChange = DateTime.UtcNow };
                    db.Songs.Add(s1);
                    await db.SaveChangesAsync();
                    File.Delete(FullPathSrc);
                }
            }
            UpdateFilesList();
        }

        // множественная очистка имён
        private async void toolStripMenuItem_ClearSelected_Click(object sender, EventArgs e)
        {
            List<Song> songsCollection = new List<Song>();
            using (SongContext db = new SongContext())
            {
                foreach (var listBoxItem in listBox_results.SelectedItems)
                {
                    FileName = listBoxItem.ToString();
                    NameEditor musicName = new NameEditor(FileName);
                    FullPathSrc = Path.Combine(comboBox_Path.Text, listBoxItem.ToString());
                    FullPathDst = Path.Combine(comboBox_Path.Text, musicName.RenameMusic());
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
            UpdateFilesList();
        }

        //переход по нажатию enter в адресной строке
        private void comboBox_Path_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                UpdateFilesList();
            }
        }
    }
}
