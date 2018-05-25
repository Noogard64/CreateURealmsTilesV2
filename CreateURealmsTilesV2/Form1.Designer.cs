using System.Windows.Forms;

namespace CreateURealmsTilesV2
{
    partial class Form1
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
            this.textBox_gimpLocation = new System.Windows.Forms.TextBox();
            this.label_gimpLocation = new System.Windows.Forms.Label();
            this.button_createImages = new System.Windows.Forms.Button();
            this.buttonCreateTiles = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button_OpenTempFolder = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox_OutputLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_gimpLocation
            // 
            this.textBox_gimpLocation.Location = new System.Drawing.Point(129, 60);
            this.textBox_gimpLocation.Name = "textBox_gimpLocation";
            this.textBox_gimpLocation.ReadOnly = true;
            this.textBox_gimpLocation.Size = new System.Drawing.Size(233, 20);
            this.textBox_gimpLocation.TabIndex = 0;
            this.textBox_gimpLocation.Text = "C:\\Program Files\\GIMP 2\\bin\\gimp-2.8.exe";
            // 
            // label_gimpLocation
            // 
            this.label_gimpLocation.AutoSize = true;
            this.label_gimpLocation.Location = new System.Drawing.Point(126, 34);
            this.label_gimpLocation.Name = "label_gimpLocation";
            this.label_gimpLocation.Size = new System.Drawing.Size(78, 13);
            this.label_gimpLocation.TabIndex = 1;
            this.label_gimpLocation.Text = "GIMP Location";
            // 
            // button_createImages
            // 
            this.button_createImages.BackColor = System.Drawing.SystemColors.Control;
            this.button_createImages.Location = new System.Drawing.Point(87, 96);
            this.button_createImages.Name = "button_createImages";
            this.button_createImages.Size = new System.Drawing.Size(93, 56);
            this.button_createImages.TabIndex = 4;
            this.button_createImages.Text = "Create Images";
            this.button_createImages.UseVisualStyleBackColor = true;
            this.button_createImages.Click += new System.EventHandler(this.button_CreateImages_Click);
            // 
            // buttonCreateTiles
            // 
            this.buttonCreateTiles.Location = new System.Drawing.Point(206, 97);
            this.buttonCreateTiles.Name = "buttonCreateTiles";
            this.buttonCreateTiles.Size = new System.Drawing.Size(93, 54);
            this.buttonCreateTiles.TabIndex = 6;
            this.buttonCreateTiles.Text = "Create Tiles";
            this.buttonCreateTiles.UseVisualStyleBackColor = true;
            this.buttonCreateTiles.Click += new System.EventHandler(this.buttonCreateTiles_Click);
            // 
            // button_OpenTempFolder
            // 
            this.button_OpenTempFolder.Location = new System.Drawing.Point(327, 96);
            this.button_OpenTempFolder.Name = "button_OpenTempFolder";
            this.button_OpenTempFolder.Size = new System.Drawing.Size(93, 54);
            this.button_OpenTempFolder.TabIndex = 7;
            this.button_OpenTempFolder.Text = "Open Temp Folder";
            this.button_OpenTempFolder.UseVisualStyleBackColor = true;
            this.button_OpenTempFolder.Click += new System.EventHandler(this.button_OpenTempFolder_Click);
            // 
            // textBox_OutputLog
            // 
            this.textBox_OutputLog.Location = new System.Drawing.Point(87, 175);
            this.textBox_OutputLog.Multiline = true;
            this.textBox_OutputLog.Name = "textBox_OutputLog";
            this.textBox_OutputLog.ReadOnly = true;
            this.textBox_OutputLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_OutputLog.Size = new System.Drawing.Size(333, 116);
            this.textBox_OutputLog.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 303);
            this.Controls.Add(this.textBox_OutputLog);
            this.Controls.Add(this.button_OpenTempFolder);
            this.Controls.Add(this.buttonCreateTiles);
            this.Controls.Add(this.button_createImages);
            this.Controls.Add(this.label_gimpLocation);
            this.Controls.Add(this.textBox_gimpLocation);
            this.Name = "Form1";
            this.Text = "Create URealms Tiles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.TextBox textBox_gimpLocation;
        private System.Windows.Forms.Label label_gimpLocation;
        private System.Windows.Forms.Button button_createImages;
        private System.Windows.Forms.Button buttonCreateTiles;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button_OpenTempFolder;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox textBox_OutputLog;
    }
}

