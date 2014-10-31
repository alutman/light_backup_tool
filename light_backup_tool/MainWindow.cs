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

namespace light_backup_tool
{
    public partial class MainWindow : Form
    {

        private Controller configs = new Controller();

        public MainWindow()
        {
            InitializeComponent();
            setEditMode(false);
            importAll();

        }

        private void importAll()
        {
            try
            {
                configs.importAll("configs.xml");
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

        private void addNewConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nameInput.Text = "";
            descInput.Text = "";
            sourceInput.Text = "";
            destInput.Text = "";

            configTreeView.SelectedNode = null;
            setEditMode(true);

        }

        private void modifyConfigButton_Click(object sender, EventArgs e)
        {
            if (!nameInput.ReadOnly)
            {
                if (configTreeView.SelectedNode != null)
                {
                    Config selectedConfig = configs.get(configTreeView.SelectedNode.Name);
                    Config c = new Config(selectedConfig.id, nameInput.Text, descInput.Text, sourceInput.Text, destInput.Text);
                    configs.add(c);
                    addTreeNode(c);
                }
                else
                {
                    Config c = new Config(nameInput.Text, descInput.Text, sourceInput.Text, destInput.Text);
                    configs.add(c);
                    addTreeNode(c);
                }
                configs.exportAll();
                setEditMode(false);
            }
            else
            {
                setEditMode(true);
            }

        }

        private void sourceOpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceInput.Text = openFileDialog1.FileName;
            }       
        }

        private void destOpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                destInput.Text = openFileDialog1.FileName;
            }          
        }

        private void performBackupButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            String dateFolder = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            String newPath = destInput.Text+"\\"+nameInput.Text+"\\"+dateFolder;
            String filename = sourceInput.Text.Substring(sourceInput.Text.LastIndexOf('\\')+1);

            String tag = tagInput.Text;
            if (tag.Length > 0)
            {
                newPath += "_" + tag;
            }
            progressBar.Value = 20;
            try
            {
                Directory.CreateDirectory(newPath);
                progressBar.Value = 50;
                File.Copy(sourceInput.Text, newPath + "\\" + filename);
                progressBar.Value = 100;

            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }

        }

        private void configTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Config selected = configs.get(e.Node.Name);
            loadConfig(selected);
        }

        private void setEditMode(Boolean on)
        {
            nameInput.ReadOnly = !on;
            descInput.ReadOnly = !on;
            sourceInput.ReadOnly = !on;
            destInput.ReadOnly = !on;

            discardButton.Visible = on;
            sourceOpenButton.Visible = on;
            destOpenButton.Visible = on;
            useDefaultCheckBox.Visible = on;

            performBackupButton.Enabled = !on;

            if (configTreeView.SelectedNode == null)
            {
                performBackupButton.Enabled = false;
            }

            if (on) modifyConfigButton.Text = "Save";
            else modifyConfigButton.Text = "Edit";
        }


        private void loadConfig(Config c)
        {
            nameInput.Text = c.name;
            descInput.Text = c.description;
            sourceInput.Text = c.source;
            destInput.Text = c.destination;
            setEditMode(false);
        }

        private void exportCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String fileName = configs.export(configs.get(configTreeView.SelectedNode.Name));
                showNotice("Config exported to "+fileName);
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }


        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {   
                addTreeNode(configs.import(openFileDialog1.FileName));
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


        private void discardButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadConfig((Config)configTreeView.SelectedNode.Tag);
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



    }
}
