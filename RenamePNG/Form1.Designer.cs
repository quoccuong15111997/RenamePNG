
namespace RenamePNG
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
            this.edtRootPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.edtKeyword = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelSaveAs = new System.Windows.Forms.Panel();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.edtPathSaveAs = new System.Windows.Forms.TextBox();
            this.radSaveAs = new System.Windows.Forms.RadioButton();
            this.radReplace = new System.Windows.Forms.RadioButton();
            this.brnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edtPathKewordFilter = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelSaveAs.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtRootPath
            // 
            this.edtRootPath.Location = new System.Drawing.Point(138, 90);
            this.edtRootPath.Name = "edtRootPath";
            this.edtRootPath.Size = new System.Drawing.Size(510, 20);
            this.edtRootPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PNG Folder";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(663, 88);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(114, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Select Folder";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnSelectRootPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Keywords Rename";
            // 
            // edtKeyword
            // 
            this.edtKeyword.Location = new System.Drawing.Point(138, 130);
            this.edtKeyword.Name = "edtKeyword";
            this.edtKeyword.Size = new System.Drawing.Size(510, 20);
            this.edtKeyword.TabIndex = 3;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(663, 128);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(114, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
          
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelSaveAs);
            this.groupBox1.Controls.Add(this.radSaveAs);
            this.groupBox1.Controls.Add(this.radReplace);
            this.groupBox1.Location = new System.Drawing.Point(62, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Options";
            // 
            // panelSaveAs
            // 
            this.panelSaveAs.Controls.Add(this.btnSaveAs);
            this.panelSaveAs.Controls.Add(this.label3);
            this.panelSaveAs.Controls.Add(this.edtPathSaveAs);
            this.panelSaveAs.Location = new System.Drawing.Point(21, 53);
            this.panelSaveAs.Name = "panelSaveAs";
            this.panelSaveAs.Size = new System.Drawing.Size(675, 51);
            this.panelSaveAs.TabIndex = 6;
            
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(543, 14);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(114, 23);
            this.btnSaveAs.TabIndex = 5;
            this.btnSaveAs.Text = "Select Folder";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Save as";
            // 
            // edtPathSaveAs
            // 
            this.edtPathSaveAs.Location = new System.Drawing.Point(87, 14);
            this.edtPathSaveAs.Name = "edtPathSaveAs";
            this.edtPathSaveAs.Size = new System.Drawing.Size(450, 20);
            this.edtPathSaveAs.TabIndex = 3;
            // 
            // radSaveAs
            // 
            this.radSaveAs.AutoSize = true;
            this.radSaveAs.Checked = true;
            this.radSaveAs.Location = new System.Drawing.Point(348, 19);
            this.radSaveAs.Name = "radSaveAs";
            this.radSaveAs.Size = new System.Drawing.Size(98, 17);
            this.radSaveAs.TabIndex = 1;
            this.radSaveAs.TabStop = true;
            this.radSaveAs.Text = "Save As Coppy";
            this.radSaveAs.UseVisualStyleBackColor = true;
           
            // 
            // radReplace
            // 
            this.radReplace.AutoSize = true;
            this.radReplace.Location = new System.Drawing.Point(145, 19);
            this.radReplace.Name = "radReplace";
            this.radReplace.Size = new System.Drawing.Size(65, 17);
            this.radReplace.TabIndex = 0;
            this.radReplace.Text = "Replace";
            this.radReplace.UseVisualStyleBackColor = true;
         
            // 
            // brnStart
            // 
            this.brnStart.Location = new System.Drawing.Point(479, 331);
            this.brnStart.Name = "brnStart";
            this.brnStart.Size = new System.Drawing.Size(156, 23);
            this.brnStart.TabIndex = 7;
            this.brnStart.Text = "Rename";
            this.brnStart.UseVisualStyleBackColor = true;
            this.brnStart.Click += new System.EventHandler(this.brnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(664, 331);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(156, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "RENAME PNG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "v0.0.2_snap01122020";
           
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Keywords Filter Path";
            // 
            // edtPathKewordFilter
            // 
            this.edtPathKewordFilter.Location = new System.Drawing.Point(138, 166);
            this.edtPathKewordFilter.Name = "edtPathKewordFilter";
            this.edtPathKewordFilter.Size = new System.Drawing.Size(510, 20);
            this.edtPathKewordFilter.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(663, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Select File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(829, 371);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtPathKewordFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.brnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtKeyword);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtRootPath);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Rename PNG";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelSaveAs.ResumeLayout(false);
            this.panelSaveAs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtRootPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtKeyword;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelSaveAs;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtPathSaveAs;
        private System.Windows.Forms.RadioButton radSaveAs;
        private System.Windows.Forms.RadioButton radReplace;
        private System.Windows.Forms.Button brnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtPathKewordFilter;
        private System.Windows.Forms.Button button2;
    }
}

