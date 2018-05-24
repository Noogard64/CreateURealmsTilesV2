using System;
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
            this.textBox_gimpLocation = new System.Windows.Forms.TextBox();
            this.label_gimpLocation = new System.Windows.Forms.Label();
            this.button_createImages = new System.Windows.Forms.Button();
            this.buttonCreateTiles = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button_OpenTempFolder = new System.Windows.Forms.Button();
            this.progressBar_CreateImages = new System.Windows.Forms.ProgressBar();
            this.progressBar_CreateTiles = new System.Windows.Forms.ProgressBar();
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
            this.button_createImages.Location = new System.Drawing.Point(129, 96);
            this.button_createImages.Name = "button_createImages";
            this.button_createImages.Size = new System.Drawing.Size(93, 56);
            this.button_createImages.TabIndex = 4;
            this.button_createImages.Text = "Create Images";
            this.button_createImages.UseVisualStyleBackColor = true;
            this.button_createImages.Click += new System.EventHandler(this.button_CreateImages_Click);
            // 
            // buttonCreateTiles
            // 
            this.buttonCreateTiles.Location = new System.Drawing.Point(129, 158);
            this.buttonCreateTiles.Name = "buttonCreateTiles";
            this.buttonCreateTiles.Size = new System.Drawing.Size(93, 54);
            this.buttonCreateTiles.TabIndex = 6;
            this.buttonCreateTiles.Text = "Create Tiles";
            this.buttonCreateTiles.UseVisualStyleBackColor = true;
            this.buttonCreateTiles.Click += new System.EventHandler(this.buttonCreateTiles_Click);
            // 
            // button_OpenTempFolder
            // 
            this.button_OpenTempFolder.Location = new System.Drawing.Point(193, 221);
            this.button_OpenTempFolder.Name = "button_OpenTempFolder";
            this.button_OpenTempFolder.Size = new System.Drawing.Size(117, 40);
            this.button_OpenTempFolder.TabIndex = 7;
            this.button_OpenTempFolder.Text = "Open Temp Folder";
            this.button_OpenTempFolder.UseVisualStyleBackColor = true;
            this.button_OpenTempFolder.Click += new System.EventHandler(this.button_OpenTempFolder_Click);
            // 
            // progressBar_CreateImages
            // 
            this.progressBar_CreateImages.Location = new System.Drawing.Point(228, 113);
            this.progressBar_CreateImages.Name = "progressBar_CreateImages";
            this.progressBar_CreateImages.Size = new System.Drawing.Size(134, 25);
            this.progressBar_CreateImages.TabIndex = 8;
            this.progressBar_CreateImages.Value = 0;
            // 
            // progressBar_CreateTiles
            // 
            this.progressBar_CreateTiles.Location = new System.Drawing.Point(228, 171);
            this.progressBar_CreateTiles.Name = "progressBar_CreateTiles";
            this.progressBar_CreateTiles.Size = new System.Drawing.Size(134, 24);
            this.progressBar_CreateTiles.TabIndex = 9;
            this.progressBar_CreateTiles.Value = 0;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 303);
            this.Controls.Add(this.progressBar_CreateTiles);
            this.Controls.Add(this.progressBar_CreateImages);
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
        public System.Windows.Forms.ProgressBar progressBar_CreateImages;
        private System.Windows.Forms.ProgressBar progressBar_CreateTiles;
    }
}

