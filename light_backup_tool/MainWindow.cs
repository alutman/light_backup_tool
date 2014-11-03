using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Utils;
using System.Text.RegularExpressions;

namespace light_backup_tool
{
    public partial class MainWindow : Form
    {
        
        private ConfigContainer configs = new ConfigContainer();

        public MainWindow()
        {
            InitializeComponent();
            setEditMode(false);
            importAll();
            this.CancelButton = discardButton;

        }

        private void importAll()
        {
            try
            {
                configs.importAll();
            }
            catch (IOException)
            {
                Console.WriteLine("Default configs.xml not found");
                return;
            }

            Config[] allImported = configs.all();
            for (int i = 0; i < allImported.Length; i++)
            {
                TreeNode n = new TreeNode();
                n.Text =  allImported[i].name;
                n.Name = allImported[i].id;
                configTreeView.Nodes.Add(n);
            }
        }

        private void addTreeNode(Config c)
        {
            if (configTreeView.Nodes.Find(c.id, true).Length == 0)
            {
                TreeNode n = new TreeNode();
                n.Text = c.name;
                n.Name = c.id;
                configTreeView.Nodes.Add(n);
            }
            else
            {
                configTreeView.Nodes.Find(c.id, true)[0].Text = c.name;
            }
            configTreeView.SelectedNode = configTreeView.Nodes.Find(c.id, true)[0];
            

        }

        private void setEditMode(Boolean on)
        {
            nameInput.ReadOnly = !on;
            descInput.ReadOnly = !on;
            sourceInput.ReadOnly = !on;
            namedFolderCheckBox.Enabled = on;

            destInput.ReadOnly = !on; //|| useDefaultCheckBox.Checked;

            discardButton.Visible = on;
            sourceOpenButton.Visible = on;
            destOpenButton.Visible = on;
            //useDefaultCheckBox.Visible = on;

            performBackupButton.Enabled = !on;

            if (configTreeView.SelectedNode == null)
            {
                performBackupButton.Enabled = false;
            }

            if (on) modifyConfigButton.Text = "Save";
            else modifyConfigButton.Text = "Edit";
        }

        private void reloadConfig()
        {
            loadConfig(configs.get(configTreeView.SelectedNode.Name));
        }


        private void loadConfig(Config c)
        {
            if (c == null)
            {
                nameInput.Text = "";
                descInput.Text = "";
                sourceInput.Text = "";
                destInput.Text = "";
                lastBackupText.Text = "none";
                numBackupsText.Text = "0";
                namedFolderCheckBox.Checked = true;
                tagInput.Text = "";
                setEditMode(false);
            }
            else
            {
                nameInput.Text = c.name;
                descInput.Text = c.description;
                sourceInput.Text = c.source;
                destInput.Text = c.destination;
                namedFolderCheckBox.Checked = c.namedFolder;
                numBackupsText.Text = ""+configs.countPastBackups(c.id);
                lastBackupText.Text = configs.getLastBackup(c.id);
                tagInput.Text = "";
                setEditMode(false);
            }
        }

        private void showError(String message)
        {
            System.Windows.Forms.MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void showNotice(String message)
        {
            System.Windows.Forms.MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        /******************/
        /* CLICK HANDLERS */
        /******************/
        private void addNewConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            loadConfig(null);
            configTreeView.SelectedNode = null;
            setEditMode(true);

        }

        private void editConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modifyConfigButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            if (!nameInput.ReadOnly)
            {
                if (configTreeView.SelectedNode != null)
                {
                    Config selectedConfig = configs.get(configTreeView.SelectedNode.Name);
                    Config c = new Config(selectedConfig.id, nameInput.Text, descInput.Text, sourceInput.Text, destInput.Text, namedFolderCheckBox.Checked);
                    configs.add(c);
                    addTreeNode(c);
                }
                else
                {
                    Config c = new Config(nameInput.Text, descInput.Text, sourceInput.Text, destInput.Text, namedFolderCheckBox.Checked);
                    configs.add(c);
                    addTreeNode(c);
                }
                setEditMode(false);
                reloadConfig();
                configs.exportAll();
            }
            else
            {
                setEditMode(true);
            }

        }

        private void sourceOpenButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialogEx fbd = new FolderBrowserDialogEx();
            fbd.ShowNewFolderButton = false;
            fbd.SelectedPath = sourceInput.Text;
            fbd.ShowBothFilesAndFolders = true;


            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sourceInput.Text = fbd.SelectedPath;
            }       
        }

        private void destOpenButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                destInput.Text = folderBrowserDialog1.SelectedPath;
            }          
        }

        private void performBackupButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            try
            {
                configs.backup(configTreeView.SelectedNode.Name, tagInput.Text);
                progressBar.Value = 100;
                reloadConfig();

            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }

        }

        private void configTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            progressBar.Value = 0;
            Config selected = configs.get(e.Node.Name);
            loadConfig(selected);
        }



        private void exportCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            try
            {
                String fileName = configs.export(configTreeView.SelectedNode.Name);
                showNotice("Config exported to "+fileName);
            }
            catch (NullReferenceException ex)
            {
                showError(ex.StackTrace);
            }


        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Config c = configs.import(openFileDialog1.FileName);
                loadConfig(c);
                addTreeNode(c);
                configs.exportAll();
            }            

        }



        private void discardButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadConfig(configs.get(configTreeView.SelectedNode.Name));
            }
            catch (NullReferenceException)
            {
                setEditMode(false);
            }
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteConfig(String id)
        {
            configs.remove(id);
            configTreeView.Nodes.Remove(configTreeView.Nodes.Find(id, true)[0]);
            loadConfig(null);
            configs.exportAll();
        }

        private void deleteConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you wish to delete config " + configTreeView.SelectedNode.Text, "Delete Config", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    deleteConfig(configTreeView.SelectedNode.Name);
                }
            }
            catch (NullReferenceException)
            {
                showError("Nothing to delete");
            }

        }

        /* END CLICK HANDLERS */

        /* VALIDATION HANDLERS */

        private Boolean isValidPath(String s)
        {
            String fileName = s.Substring(s.LastIndexOf("\\") + 1);
            String path = s.Substring(0, s.LastIndexOf("\\"));

            foreach (char c in path.ToCharArray())
            {
                foreach (char h in Path.GetInvalidPathChars())
                {
                    if (c == h) return false;
                }
            }

            return isValidFileName(fileName);
        }

        private Boolean isValidFileName(String s)
        {
            foreach (char c in s.ToCharArray())
            {
                foreach (char h in Path.GetInvalidFileNameChars())
                {
                    if (c == h) return false;
                }
            }
            return true;
        }

        private Boolean checkExists(String path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return true;
                }
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }

        }

        private void sourceLabel_Click(object sender, EventArgs e)
        {
            String source = sourceInput.Text.Substring(0, sourceInput.Text.LastIndexOf("\\"));
            if (checkExists(source))
            {
                System.Diagnostics.Process.Start(source);
            }
            
        }

        private void destLabel_Click(object sender, EventArgs e)
        {
            if (checkExists(destInput.Text))
            {
                System.Diagnostics.Process.Start(destInput.Text);
            }
            
        }

        private void lastBackupLabel_Click(object sender, EventArgs e)
        {
            String source = "";
            if(namedFolderCheckBox.Checked) {
                source = destInput.Text + "\\" + nameInput.Text + "\\" + lastBackupText.Text;
            }
            else {
                source = destInput.Text + "\\" + lastBackupText.Text;
            }

            Console.WriteLine(source);
            if (checkExists(source))
            {
                System.Diagnostics.Process.Start(source);
            }
        }



    }
}
