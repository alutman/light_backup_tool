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
            this.configTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.descInput = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            this.sourceInput = new System.Windows.Forms.TextBox();
            this.destInput = new System.Windows.Forms.TextBox();
            this.modifyConfigButton = new System.Windows.Forms.Button();
            this.tagInput = new System.Windows.Forms.TextBox();
            this.performBackupButton = new System.Windows.Forms.Button();
            this.useDefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceOpenButton = new System.Windows.Forms.Button();
            this.destOpenButton = new System.Windows.Forms.Button();
            this.appendTagLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.discardButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // configTreeView
            // 
            this.configTreeView.Location = new System.Drawing.Point(12, 27);
            this.configTreeView.Name = "configTreeView";
            this.configTreeView.Size = new System.Drawing.Size(224, 418);
            this.configTreeView.TabIndex = 1;
            this.configTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.configTreeView_AfterSelect);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(775, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportCurrentToolStripMenuItem,
            this.importToolStripMenuItem,
            this.editToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportCurrentToolStripMenuItem
            // 
            this.exportCurrentToolStripMenuItem.Name = "exportCurrentToolStripMenuItem";
            this.exportCurrentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportCurrentToolStripMenuItem.Text = "Export Config";
            this.exportCurrentToolStripMenuItem.Click += new System.EventHandler(this.exportCurrentToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "Import Config";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Exit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConfigToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // newConfigToolStripMenuItem
            // 
            this.newConfigToolStripMenuItem.Name = "newConfigToolStripMenuItem";
            this.newConfigToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.newConfigToolStripMenuItem.Text = "New Config";
            this.newConfigToolStripMenuItem.Click += new System.EventHandler(this.addNewConfigToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupCurrentToolStripMenuItem,
            this.backupAllToolStripMenuItem});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // backupCurrentToolStripMenuItem
            // 
            this.backupCurrentToolStripMenuItem.Name = "backupCurrentToolStripMenuItem";
            this.backupCurrentToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.backupCurrentToolStripMenuItem.Text = "Backup Current";
            // 
            // backupAllToolStripMenuItem
            // 
            this.backupAllToolStripMenuItem.Name = "backupAllToolStripMenuItem";
            this.backupAllToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.backupAllToolStripMenuItem.Text = "Backup All";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDefaultsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setDefaultsToolStripMenuItem
            // 
            this.setDefaultsToolStripMenuItem.Name = "setDefaultsToolStripMenuItem";
            this.setDefaultsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.setDefaultsToolStripMenuItem.Text = "Set Defaults";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(311, 40);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(199, 20);
            this.nameInput.TabIndex = 5;
            // 
            // descInput
            // 
            this.descInput.Location = new System.Drawing.Point(311, 65);
            this.descInput.Multiline = true;
            this.descInput.Name = "descInput";
            this.descInput.Size = new System.Drawing.Size(450, 56);
            this.descInput.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(242, 43);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(242, 68);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(60, 13);
            this.descLabel.TabIndex = 8;
            this.descLabel.Text = "Description";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(245, 222);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(41, 13);
            this.sourceLabel.TabIndex = 9;
            this.sourceLabel.Text = "Source";
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Location = new System.Drawing.Point(245, 295);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(60, 13);
            this.destLabel.TabIndex = 10;
            this.destLabel.Text = "Destination";
            // 
            // sourceInput
            // 
            this.sourceInput.Location = new System.Drawing.Point(311, 222);
            this.sourceInput.Name = "sourceInput";
            this.sourceInput.Size = new System.Drawing.Size(352, 20);
            this.sourceInput.TabIndex = 11;
            // 
            // destInput
            // 
            this.destInput.Location = new System.Drawing.Point(311, 295);
            this.destInput.Name = "destInput";
            this.destInput.Size = new System.Drawing.Size(352, 20);
            this.destInput.TabIndex = 12;
            // 
            // modifyConfigButton
            // 
            this.modifyConfigButton.Location = new System.Drawing.Point(686, 36);
            this.modifyConfigButton.Name = "modifyConfigButton";
            this.modifyConfigButton.Size = new System.Drawing.Size(75, 23);
            this.modifyConfigButton.TabIndex = 14;
            this.modifyConfigButton.Text = "Save";
            this.modifyConfigButton.UseVisualStyleBackColor = true;
            this.modifyConfigButton.Click += new System.EventHandler(this.modifyConfigButton_Click);
            // 
            // tagInput
            // 
            this.tagInput.Location = new System.Drawing.Point(566, 391);
            this.tagInput.Name = "tagInput";
            this.tagInput.Size = new System.Drawing.Size(109, 20);
            this.tagInput.TabIndex = 15;
            // 
            // performBackupButton
            // 
            this.performBackupButton.Location = new System.Drawing.Point(681, 391);
            this.performBackupButton.Name = "performBackupButton";
            this.performBackupButton.Size = new System.Drawing.Size(75, 23);
            this.performBackupButton.TabIndex = 16;
            this.performBackupButton.Text = "Backup";
            this.performBackupButton.UseVisualStyleBackColor = true;
            this.performBackupButton.Click += new System.EventHandler(this.performBackupButton_Click);
            // 
            // useDefaultCheckBox
            // 
            this.useDefaultCheckBox.AutoSize = true;
            this.useDefaultCheckBox.Location = new System.Drawing.Point(681, 320);
            this.useDefaultCheckBox.Name = "useDefaultCheckBox";
            this.useDefaultCheckBox.Size = new System.Drawing.Size(82, 17);
            this.useDefaultCheckBox.TabIndex = 17;
            this.useDefaultCheckBox.Text = "Use Default";
            this.useDefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // sourceOpenButton
            // 
            this.sourceOpenButton.Location = new System.Drawing.Point(681, 222);
            this.sourceOpenButton.Name = "sourceOpenButton";
            this.sourceOpenButton.Size = new System.Drawing.Size(75, 23);
            this.sourceOpenButton.TabIndex = 18;
            this.sourceOpenButton.Text = "Open";
            this.sourceOpenButton.UseVisualStyleBackColor = true;
            this.sourceOpenButton.Click += new System.EventHandler(this.sourceOpenButton_Click);
            // 
            // destOpenButton
            // 
            this.destOpenButton.Location = new System.Drawing.Point(681, 291);
            this.destOpenButton.Name = "destOpenButton";
            this.destOpenButton.Size = new System.Drawing.Size(75, 23);
            this.destOpenButton.TabIndex = 19;
            this.destOpenButton.Text = "Open";
            this.destOpenButton.UseVisualStyleBackColor = true;
            this.destOpenButton.Click += new System.EventHandler(this.destOpenButton_Click);
            // 
            // appendTagLabel
            // 
            this.appendTagLabel.AutoSize = true;
            this.appendTagLabel.Location = new System.Drawing.Point(494, 391);
            this.appendTagLabel.Name = "appendTagLabel";
            this.appendTagLabel.Size = new System.Drawing.Size(66, 13);
            this.appendTagLabel.TabIndex = 20;
            this.appendTagLabel.Text = "Append Tag";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(311, 420);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(445, 23);
            this.progressBar.TabIndex = 21;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(605, 36);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(75, 23);
            this.discardButton.TabIndex = 22;
            this.discardButton.Text = "Discard";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 455);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.appendTagLabel);
            this.Controls.Add(this.destOpenButton);
            this.Controls.Add(this.sourceOpenButton);
            this.Controls.Add(this.useDefaultCheckBox);
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
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "Light Backup Tool";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView configTreeView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDefaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox descInput;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.TextBox sourceInput;
        private System.Windows.Forms.TextBox destInput;
        private System.Windows.Forms.Button modifyConfigButton;
        private System.Windows.Forms.TextBox tagInput;
        private System.Windows.Forms.Button performBackupButton;
        private System.Windows.Forms.CheckBox useDefaultCheckBox;
        private System.Windows.Forms.Button sourceOpenButton;
        private System.Windows.Forms.Button destOpenButton;
        private System.Windows.Forms.Label appendTagLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}

