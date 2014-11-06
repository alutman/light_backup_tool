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
using System.Threading;

namespace light_backup_tool
{
    public partial class MainWindow : Form
    {

        private ConfigContainer configs;

        public MainWindow()
        {
            InitializeComponent();
            setEditMode(false);
            this.CancelButton = discardButton;
            configs = new ConfigContainer(new Controller(this));
            importAll();

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
            tagInput.ReadOnly = on;

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
            clearErrors();
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
                configTreeView.SelectedNode = null;
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
                try
                {
                    configTreeView.SelectedNode = configTreeView.Nodes.Find(c.id, true)[0];
                }
                catch (IndexOutOfRangeException) { }
                
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

        private void clearErrors()
        {
            errorProvider1.SetError(nameInput, "");
            errorProvider1.SetError(sourceInput, "");
            errorProvider1.SetError(destInput, "");
            errorProvider1.SetError(lastBackupText, "");
        }

        public void setProgressBar(int value)
        {
            progressBar.Value = Math.Min(Math.Abs(value), 100);
        }

        public void addToProgressBar(int value)
        {
            progressBar.Value = Math.Min(100, progressBar.Value + Math.Abs(value));   
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
            fbd.DontIncludeNetworkFoldersBelowDomainLevel = true;



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

        private void backupMode(Boolean b)
        {
            menuStrip.Enabled = !b;
            modifyConfigButton.Enabled = !b;
            tagInput.Enabled = !b;
            configTreeView.Enabled = !b;
            if (b)
            {                
                performBackupButton.Text = "Cancel";
            }
            else
            {
                performBackupButton.Text = "Backup";
            }
            
        }

        private void performBackupButton_Click(object sender, EventArgs e)
        {
            if (performBackupButton.Text == "Backup")
            {
                //backupMode(true);
                progressBar.Value = 0;
                try
                {
                    configs.backup(configTreeView.SelectedNode.Name, tagInput.Text);
                    progressBar.Value = 100;
                    reloadConfig();
                    //backupMode(false);

                }
                catch (Exception ex)
                {
                    showError(ex.Message);
                }
            }
            else if (performBackupButton.Text == "Cancel")
            {
                //Kill thread
                //Notify
                //backupMode(false);
            }
            

        }
        private void selectNode(String id)
        {
            clearErrors();
            progressBar.Value = 0;
            Config selected = configs.get(id);
            loadConfig(selected);
        }

        private void configTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (configTreeView.SelectedNode != null && nameInput.Text.Length == 0)
            {
                selectNode(e.Node.Name);
            }
            
        }

        private void configTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectNode(e.Node.Name);
            if (MouseButtons.Right == e.Button)
            {
                contextMenuStrip1.Show();
            }
            
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
                loadConfig(null);
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteConfig(String id)
        {
            configs.remove(id);
            configTreeView.Nodes.Remove(configTreeView.Nodes.Find(id, true)[0]);
            if (configTreeView.SelectedNode == null)
            {
                loadConfig(null);
            }
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


        private void sourceLabel_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(sourceInput, "");
            int x = sourceInput.Text.LastIndexOf("\\");

            if (x < 0)
            {
                errorProvider1.SetError(sourceInput, "Not a valid path");
                return;
            }

            String source = sourceInput.Text.Substring(0, x);

            if (configs.checkExists(source))
            {
                System.Diagnostics.Process.Start(source);
            }
            else
            {
                errorProvider1.SetError(sourceInput, "Path does not exist");
            }

        }

        private void destLabel_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(destInput, "");
            if (configs.checkExists(destInput.Text))
            {
                System.Diagnostics.Process.Start(destInput.Text);
            }
            else
            {
                errorProvider1.SetError(destInput, "Path does not exist");
            }


        }

        private void lastBackupLabel_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(lastBackupText, "");
            String source = "";
            if (namedFolderCheckBox.Checked)
            {
                source = destInput.Text + "\\" + nameInput.Text + "\\" + lastBackupText.Text;
            }
            else
            {
                source = destInput.Text + "\\" + lastBackupText.Text;
            }
            if (configs.checkExists(source))
            {
                System.Diagnostics.Process.Start(source);
            }
            else
            {
                errorProvider1.SetError(lastBackupText, "Last backup does not exist");
            }
        }

        /* END CLICK HANDLERS */

        /* VALIDATION HANDLERS */



        private Boolean isValidPath(String s)
        {
            foreach (char c in s.ToCharArray())
            {
                foreach (char h in Path.GetInvalidPathChars())
                {
                    if (c == h) return false;
                }
            }
            return true;
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

        private void nameInput_Validating(object sender, CancelEventArgs e)
        {
            if (nameInput.ReadOnly) return;
            if(!isValidFileName(nameInput.Text) || nameInput.Text.Length <= 0) {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Invalid filename/length");
            }
            
        }

        private void sourceInput_Validating(object sender, CancelEventArgs e)
        {
            if (sourceInput.ReadOnly) return;
            if (!isValidPath(sourceInput.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Invalid path");
            }
        }

        private void destInput_Validating(object sender, CancelEventArgs e)
        {
            if (destInput.ReadOnly) return;
            if (!isValidPath(destInput.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Invalid path");
            }
        }

        private void tagInput_Validating(object sender, CancelEventArgs e)
        {
            if (tagInput.ReadOnly) return;
            if (!isValidFileName(tagInput.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Invalid chars in tag");
            }
        }

        private void InputValidated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, "");
        }

    }
}
