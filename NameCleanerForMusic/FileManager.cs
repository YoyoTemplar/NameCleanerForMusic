using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace NameCleanerForMusic
{
    public class FileManager
    {

        //public string textBoxText  {get; set;}

        DirectoryInfo directory;


        //public FileManager()
        //{
            
        //}


        public DirectoryInfo[] GetDirectories(string path)
        {
            directory = new DirectoryInfo(path);

            DirectoryInfo[] directories = directory.GetDirectories();

            return directories;
        }

        public FileInfo[] GetFiles()
        {
            FileInfo[] files = directory.GetFiles();

            return files;
        }


        public void GoClick(string text)
        {


            //DirectoryInfo directory = new DirectoryInfo(text);

            //DirectoryInfo[] directories = directory.GetDirectories();

            //foreach (var currentDirectory in directories)
            //{
            //    listBox_results.Items.Add(currentDirectory);
            //}

            //FileInfo[] files = directory.GetFiles();

            //foreach (var currentFile in files)
            //{
            //    listBox_results.Items.Add(currentFile);
            //}

            //FilePath = textBox_Path.Text.ToString();

        }

        //public void DoubleClick()
        //{
        //    if (Path.GetExtension(Path.Combine(textBox_Path.Text, listBox_results.SelectedItem.ToString())) == "")
        //    {
        //        textBox_Path.Text = Path.Combine(textBox_Path.Text, listBox_results.SelectedItem.ToString());

        //        listBox_results.Items.Clear();

        //        DirectoryInfo directory = new DirectoryInfo(textBox_Path.Text);

        //        DirectoryInfo[] directories = directory.GetDirectories();

        //        foreach (var currentDirectory in directories)
        //        {
        //            listBox_results.Items.Add(currentDirectory);
        //        }

        //        FileInfo[] files = directory.GetFiles();

        //        foreach (var currentFile in files)
        //        {
        //            listBox_results.Items.Add(currentFile);
        //        }

        //        FilePath = textBox_Path.Text.ToString();

        //    }
        //    else
        //    {
        //        Process.Start(Path.Combine(textBox_Path.Text, listBox_results.SelectedItem.ToString()));
        //    }
        //}

        //public void BackClick()
        //{
        //    if (textBox_Path.Text[textBox_Path.Text.Length - 1] == '\\')
        //    {
        //        textBox_Path.Text = textBox_Path.Text.Remove(textBox_Path.Text.Length - 1, 1);

        //        while (textBox_Path.Text[textBox_Path.Text.Length - 1] != '\\')
        //        {
        //            textBox_Path.Text = textBox_Path.Text.Remove(textBox_Path.Text.Length - 1, 1);
        //        }
        //    }
        //    else if (textBox_Path.Text[textBox_Path.Text.Length - 1] != '\\')
        //    {
        //        while (textBox_Path.Text[textBox_Path.Text.Length - 1] != '\\')
        //        {
        //            textBox_Path.Text = textBox_Path.Text.Remove(textBox_Path.Text.Length - 1, 1);
        //        }
        //    }

        //    FilePath = textBox_Path.Text.ToString();

        //    listBox_results.Items.Clear();

        //    DirectoryInfo directory = new DirectoryInfo(textBox_Path.Text);

        //    DirectoryInfo[] directories = directory.GetDirectories();

        //    foreach (var currentDirectory in directories)
        //    {
        //        listBox_results.Items.Add(currentDirectory);
        //    }

        //    FileInfo[] files = directory.GetFiles();

        //    foreach (var currentFile in files)
        //    {
        //        listBox_results.Items.Add(currentFile);
        //    }
        //}

        //public void MouseUp()
        //{
        //    if (listBox_results.SelectedIndices.Count > 0 & listBox_results.SelectedIndices.Count < 2 && e.Button == MouseButtons.Right)
        //    {
        //        contextMenuStrip_listBox_results.Enabled = true;

        //        ToolStripMenuItem_ClearName.Enabled = true;

        //        toolStripMenuItem_ClearSelected.Enabled = false;

        //        contextMenuStrip_listBox_results.Show(MousePosition, ToolStripDropDownDirection.Right);

        //        //if (e.Button == MouseButtons.Right)
        //        //{
        //        //    contextMenuStrip_listBox_results.Show(MousePosition, ToolStripDropDownDirection.Right);
        //        //}
        //    }
        //    else if (listBox_results.SelectedIndices.Count > 1 && e.Button == MouseButtons.Right)
        //    {
        //        contextMenuStrip_listBox_results.Enabled = true;

        //        ToolStripMenuItem_ClearName.Enabled = false;

        //        toolStripMenuItem_ClearSelected.Enabled = true;

        //        contextMenuStrip_listBox_results.Show(MousePosition, ToolStripDropDownDirection.Right);
        //    }

        //    else
        //    {
        //        contextMenuStrip_listBox_results.Enabled = false;
        //    }

        //}

    }
}
