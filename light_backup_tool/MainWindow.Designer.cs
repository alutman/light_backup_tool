namespace light_backup_tool
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.configTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConfigToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.descInput = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.LinkLabel();
            this.destLabel = new System.Windows.Forms.LinkLabel();
            this.sourceInput = new System.Windows.Forms.TextBox();
            this.destInput = new System.Windows.Forms.TextBox();
            this.modifyConfigButton = new System.Windows.Forms.Button();
            this.tagInput = new System.Windows.Forms.TextBox();
            this.performBackupButton = new System.Windows.Forms.Button();
            this.sourceOpenButton = new System.Windows.Forms.Button();
            this.destOpenButton = new System.Windows.Forms.Button();
            this.appendTagLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.discardButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.namedFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.restoreBackupButton = new System.Windows.Forms.Button();
            this.deleteBackupButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.numBackupsLablel = new System.Windows.Forms.Label();
            this.lastBackupLabel = new System.Windows.Forms.LinkLabel();
            this.numBackupsText = new System.Windows.Forms.Label();
            this.lastBackupText = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.destInputResolved = new System.Windows.Forms.TextBox();
            this.backupListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // configTreeView
            // 
            this.configTreeView.ContextMenuStrip = this.contextMenuStrip1;
            this.configTreeView.Location = new System.Drawing.Point(24, 52);
            this.configTreeView.Margin = new System.Windows.Forms.Padding(6);
            this.configTreeView.Name = "configTreeView";
            this.configTreeView.Size = new System.Drawing.Size(444, 800);
            this.configTreeView.TabIndex = 1;
            this.configTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.configTreeView_AfterSelect);
            this.configTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.configTreeView_NodeMouseClick);
            this.configTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.configTreeView_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 76);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(160, 36);
            this.backupToolStripMenuItem.Text = "New";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.addNewConfigToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(160, 36);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteConfigToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip.Size = new System.Drawing.Size(1550, 44);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConfigToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newConfigToolStripMenuItem1
            // 
            this.newConfigToolStripMenuItem1.Name = "newConfigToolStripMenuItem1";
            this.newConfigToolStripMenuItem1.Size = new System.Drawing.Size(216, 36);
            this.newConfigToolStripMenuItem1.Text = "New Config";
            this.newConfigToolStripMenuItem1.Click += new System.EventHandler(this.addNewConfigToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportCurrentToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(98, 36);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(249, 36);
            this.importToolStripMenuItem.Text = "Import Configs";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importAllConfigsToolStripMenuItem_Click);
            // 
            // exportCurrentToolStripMenuItem
            // 
            this.exportCurrentToolStripMenuItem.Name = "exportCurrentToolStripMenuItem";
            this.exportCurrentToolStripMenuItem.Size = new System.Drawing.Size(249, 36);
            this.exportCurrentToolStripMenuItem.Text = "Export Configs";
            this.exportCurrentToolStripMenuItem.Click += new System.EventHandler(this.exportAllConfigsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(92, 36);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(622, 77);
            this.nameInput.Margin = new System.Windows.Forms.Padding(6);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(394, 31);
            this.nameInput.TabIndex = 5;
            this.nameInput.Validating += new System.ComponentModel.CancelEventHandler(this.nameInput_Validating);
            this.nameInput.Validated += new System.EventHandler(this.InputValidated);
            // 
            // descInput
            // 
            this.descInput.Location = new System.Drawing.Point(622, 125);
            this.descInput.Margin = new System.Windows.Forms.Padding(6);
            this.descInput.Multiline = true;
            this.descInput.Name = "descInput";
            this.descInput.Size = new System.Drawing.Size(896, 104);
            this.descInput.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(484, 83);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(68, 25);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(484, 131);
            this.descLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(120, 25);
            this.descLabel.TabIndex = 8;
            this.descLabel.Text = "Description";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(490, 427);
            this.sourceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(80, 25);
            this.sourceLabel.TabIndex = 9;
            this.sourceLabel.TabStop = true;
            this.sourceLabel.Text = "Source";
            this.sourceLabel.Click += new System.EventHandler(this.sourceLabel_Click);
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Location = new System.Drawing.Point(490, 567);
            this.destLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(120, 25);
            this.destLabel.TabIndex = 10;
            this.destLabel.TabStop = true;
            this.destLabel.Text = "Destination";
            this.destLabel.Click += new System.EventHandler(this.destLabel_Click);
            // 
            // sourceInput
            // 
            this.sourceInput.Location = new System.Drawing.Point(622, 427);
            this.sourceInput.Margin = new System.Windows.Forms.Padding(6);
            this.sourceInput.Name = "sourceInput";
            this.sourceInput.Size = new System.Drawing.Size(700, 31);
            this.sourceInput.TabIndex = 11;
            this.sourceInput.Validating += new System.ComponentModel.CancelEventHandler(this.sourceInput_Validating);
            this.sourceInput.Validated += new System.EventHandler(this.InputValidated);
            // 
            // destInput
            // 
            this.destInput.Location = new System.Drawing.Point(622, 567);
            this.destInput.Margin = new System.Windows.Forms.Padding(6);
            this.destInput.Name = "destInput";
            this.destInput.Size = new System.Drawing.Size(700, 31);
            this.destInput.TabIndex = 12;
            this.destInput.Validating += new System.ComponentModel.CancelEventHandler(this.destInput_Validating);
            this.destInput.Validated += new System.EventHandler(this.InputValidated);
            // 
            // modifyConfigButton
            // 
            this.modifyConfigButton.Location = new System.Drawing.Point(1372, 69);
            this.modifyConfigButton.Margin = new System.Windows.Forms.Padding(6);
            this.modifyConfigButton.Name = "modifyConfigButton";
            this.modifyConfigButton.Size = new System.Drawing.Size(150, 44);
            this.modifyConfigButton.TabIndex = 14;
            this.modifyConfigButton.Text = "Save";
            this.modifyConfigButton.UseVisualStyleBackColor = true;
            this.modifyConfigButton.Click += new System.EventHandler(this.modifyConfigButton_Click);
            // 
            // tagInput
            // 
            this.tagInput.Location = new System.Drawing.Point(1108, 752);
            this.tagInput.Margin = new System.Windows.Forms.Padding(6);
            this.tagInput.Name = "tagInput";
            this.tagInput.Size = new System.Drawing.Size(214, 31);
            this.tagInput.TabIndex = 15;
            this.tagInput.Validating += new System.ComponentModel.CancelEventHandler(this.tagInput_Validating);
            this.tagInput.Validated += new System.EventHandler(this.InputValidated);
            // 
            // performBackupButton
            // 
            this.performBackupButton.Location = new System.Drawing.Point(1362, 752);
            this.performBackupButton.Margin = new System.Windows.Forms.Padding(6);
            this.performBackupButton.Name = "performBackupButton";
            this.performBackupButton.Size = new System.Drawing.Size(150, 44);
            this.performBackupButton.TabIndex = 16;
            this.performBackupButton.Text = "Backup";
            this.performBackupButton.UseVisualStyleBackColor = true;
            this.performBackupButton.Click += new System.EventHandler(this.performBackupButton_Click);
            // 
            // sourceOpenButton
            // 
            this.sourceOpenButton.Location = new System.Drawing.Point(1362, 423);
            this.sourceOpenButton.Margin = new System.Windows.Forms.Padding(6);
            this.sourceOpenButton.Name = "sourceOpenButton";
            this.sourceOpenButton.Size = new System.Drawing.Size(150, 44);
            this.sourceOpenButton.TabIndex = 18;
            this.sourceOpenButton.Text = "Open";
            this.sourceOpenButton.UseVisualStyleBackColor = true;
            this.sourceOpenButton.Click += new System.EventHandler(this.sourceOpenButton_Click);
            // 
            // destOpenButton
            // 
            this.destOpenButton.Location = new System.Drawing.Point(1362, 560);
            this.destOpenButton.Margin = new System.Windows.Forms.Padding(6);
            this.destOpenButton.Name = "destOpenButton";
            this.destOpenButton.Size = new System.Drawing.Size(150, 44);
            this.destOpenButton.TabIndex = 19;
            this.destOpenButton.Text = "Open";
            this.destOpenButton.UseVisualStyleBackColor = true;
            this.destOpenButton.Click += new System.EventHandler(this.destOpenButton_Click);
            // 
            // appendTagLabel
            // 
            this.appendTagLabel.AutoSize = true;
            this.appendTagLabel.Location = new System.Drawing.Point(964, 762);
            this.appendTagLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.appendTagLabel.Name = "appendTagLabel";
            this.appendTagLabel.Size = new System.Drawing.Size(129, 25);
            this.appendTagLabel.TabIndex = 20;
            this.appendTagLabel.Text = "Append Tag";
            this.toolTip1.SetToolTip(this.appendTagLabel, "Optional tag for this backup");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // discardButton
            // 
            this.discardButton.CausesValidation = false;
            this.discardButton.Location = new System.Drawing.Point(1210, 69);
            this.discardButton.Margin = new System.Windows.Forms.Padding(6);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(150, 44);
            this.discardButton.TabIndex = 22;
            this.discardButton.Text = "Discard";
            this.toolTip1.SetToolTip(this.discardButton, "Discard changes");
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // namedFolderCheckBox
            // 
            this.namedFolderCheckBox.AutoSize = true;
            this.namedFolderCheckBox.Checked = true;
            this.namedFolderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.namedFolderCheckBox.Location = new System.Drawing.Point(1362, 615);
            this.namedFolderCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.namedFolderCheckBox.Name = "namedFolderCheckBox";
            this.namedFolderCheckBox.Size = new System.Drawing.Size(179, 29);
            this.namedFolderCheckBox.TabIndex = 23;
            this.namedFolderCheckBox.Text = "Named Folder";
            this.toolTip1.SetToolTip(this.namedFolderCheckBox, "Backup into a subfolder named after the config name");
            this.namedFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // restoreBackupButton
            // 
            this.restoreBackupButton.Location = new System.Drawing.Point(1362, 269);
            this.restoreBackupButton.Name = "restoreBackupButton";
            this.restoreBackupButton.Size = new System.Drawing.Size(150, 44);
            this.restoreBackupButton.TabIndex = 29;
            this.restoreBackupButton.Text = "Restore";
            this.toolTip1.SetToolTip(this.restoreBackupButton, "Restore selected backup");
            this.restoreBackupButton.UseVisualStyleBackColor = true;
            this.restoreBackupButton.Click += new System.EventHandler(this.restoreBackupButton_Click);
            // 
            // deleteBackupButton
            // 
            this.deleteBackupButton.Location = new System.Drawing.Point(1362, 337);
            this.deleteBackupButton.Name = "deleteBackupButton";
            this.deleteBackupButton.Size = new System.Drawing.Size(150, 44);
            this.deleteBackupButton.TabIndex = 31;
            this.deleteBackupButton.Text = "Delete";
            this.toolTip1.SetToolTip(this.deleteBackupButton, "Delete selected backup");
            this.deleteBackupButton.UseVisualStyleBackColor = true;
            this.deleteBackupButton.Click += new System.EventHandler(this.deleteBackupButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(622, 808);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(890, 44);
            this.progressBar.TabIndex = 21;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // numBackupsLablel
            // 
            this.numBackupsLablel.AutoSize = true;
            this.numBackupsLablel.Location = new System.Drawing.Point(484, 269);
            this.numBackupsLablel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.numBackupsLablel.Name = "numBackupsLablel";
            this.numBackupsLablel.Size = new System.Drawing.Size(95, 25);
            this.numBackupsLablel.TabIndex = 24;
            this.numBackupsLablel.Text = "Backups";
            // 
            // lastBackupLabel
            // 
            this.lastBackupLabel.AutoSize = true;
            this.lastBackupLabel.Location = new System.Drawing.Point(484, 337);
            this.lastBackupLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lastBackupLabel.Name = "lastBackupLabel";
            this.lastBackupLabel.Size = new System.Drawing.Size(131, 25);
            this.lastBackupLabel.TabIndex = 25;
            this.lastBackupLabel.TabStop = true;
            this.lastBackupLabel.Text = "Last Backup";
            this.lastBackupLabel.Click += new System.EventHandler(this.lastBackupLabel_Click);
            // 
            // numBackupsText
            // 
            this.numBackupsText.AutoSize = true;
            this.numBackupsText.Location = new System.Drawing.Point(616, 269);
            this.numBackupsText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.numBackupsText.Name = "numBackupsText";
            this.numBackupsText.Size = new System.Drawing.Size(24, 25);
            this.numBackupsText.TabIndex = 26;
            this.numBackupsText.Text = "0";
            // 
            // lastBackupText
            // 
            this.lastBackupText.AutoSize = true;
            this.lastBackupText.Location = new System.Drawing.Point(616, 337);
            this.lastBackupText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lastBackupText.Name = "lastBackupText";
            this.lastBackupText.Size = new System.Drawing.Size(60, 25);
            this.lastBackupText.TabIndex = 27;
            this.lastBackupText.Text = "none";
            // 
            // destInputResolved
            // 
            this.destInputResolved.Location = new System.Drawing.Point(622, 567);
            this.destInputResolved.Margin = new System.Windows.Forms.Padding(6);
            this.destInputResolved.Name = "destInputResolved";
            this.destInputResolved.ReadOnly = true;
            this.destInputResolved.Size = new System.Drawing.Size(700, 31);
            this.destInputResolved.TabIndex = 28;
            // 
            // backupListBox
            // 
            this.backupListBox.FormattingEnabled = true;
            this.backupListBox.ItemHeight = 25;
            this.backupListBox.Location = new System.Drawing.Point(953, 263);
            this.backupListBox.Name = "backupListBox";
            this.backupListBox.Size = new System.Drawing.Size(368, 129);
            this.backupListBox.TabIndex = 30;
            this.backupListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.backupListBox_MouseDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1550, 875);
            this.Controls.Add(this.deleteBackupButton);
            this.Controls.Add(this.backupListBox);
            this.Controls.Add(this.restoreBackupButton);
            this.Controls.Add(this.destInputResolved);
            this.Controls.Add(this.lastBackupText);
            this.Controls.Add(this.numBackupsText);
            this.Controls.Add(this.lastBackupLabel);
            this.Controls.Add(this.numBackupsLablel);
            this.Controls.Add(this.namedFolderCheckBox);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.appendTagLabel);
            this.Controls.Add(this.destOpenButton);
            this.Controls.Add(this.sourceOpenButton);
            this.Controls.Add(this.performBackupButton);
            this.Controls.Add(this.tagInput);
            this.Controls.Add(this.modifyConfigButton);
            this.Controls.Add(this.destInput);
            this.Controls.Add(this.sourceInput);
            this.Controls.Add(this.destLabel);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.descInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.configTreeView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainWindow";
            this.Text = "Light Backup Tool";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView configTreeView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox descInput;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.LinkLabel sourceLabel;
        private System.Windows.Forms.LinkLabel destLabel;
        private System.Windows.Forms.TextBox sourceInput;
        private System.Windows.Forms.TextBox destInput;
        private System.Windows.Forms.Button modifyConfigButton;
        private System.Windows.Forms.TextBox tagInput;
        private System.Windows.Forms.Button performBackupButton;
        private System.Windows.Forms.Button sourceOpenButton;
        private System.Windows.Forms.Button destOpenButton;
        private System.Windows.Forms.Label appendTagLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCurrentToolStripMenuItem;
        private System.Windows.Forms.CheckBox namedFolderCheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lastBackupText;
        private System.Windows.Forms.Label numBackupsText;
        private System.Windows.Forms.LinkLabel lastBackupLabel;
        private System.Windows.Forms.Label numBackupsLablel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConfigToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox destInputResolved;
        private System.Windows.Forms.Button restoreBackupButton;
        private System.Windows.Forms.ListBox backupListBox;
        private System.Windows.Forms.Button deleteBackupButton;
    }
}

