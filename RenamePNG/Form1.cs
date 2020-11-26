using RenamePNG.Callback;
using RenamePNG.Controller;
using RenamePNG.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenamePNG
{
    public partial class Form1 : Form, FileSaveCallback
    {
        private string _rootPath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                   edtPathSaveAs.Text = fbd.SelectedPath;
                }
            }
        }

        private void brnStart_Click(object sender, EventArgs e)
        {
            if (edtRootPath.Text.Equals(""))
            {
                MessageBox.Show("Root Path Is Emty", "ERROR");
                return;
            }
            /*if (edtKeyword.Text.Equals(""))
            {
                MessageBox.Show("Keyword Is Emty", "ERROR");
                return;
            } */          
            if (radSaveAs.Checked)
            {
                if (edtPathSaveAs.Text.Equals(""))
                {
                    MessageBox.Show("Save Path Is Emty", "ERROR");
                    return;
                }
            }
            PNGModel model = new PNGModel();
            model.RootPath = edtRootPath.Text.ToString().Trim();
            model.isReplace = radReplace.Checked;
            model.isSaveAs = radSaveAs.Checked;
            model.Keywords = edtKeyword.Text;
            model.PathSaveAs = edtPathSaveAs.Text.ToString().Trim();
            FileController controller = new FileController();
            controller.init(model,this);
        }

        private void radReplace_CheckedChanged(object sender, EventArgs e)
        {
          
            
        }

        private void radSaveAs_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void panelSaveAs_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelectRootPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _rootPath = fbd.SelectedPath;
                    edtRootPath.Text = _rootPath;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            
           
        }

        public void onSaveSuccess()
        {
            MessageBox.Show("Process Success", "Done");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (edtRootPath.Text.Equals(""))
            {
                MessageBox.Show("Root Path Is Emty", "ERROR");
                return;
            }
            if (edtKeyword.Text.Equals(""))
            {
                MessageBox.Show("Keyword Is Emty", "ERROR");
                return;
            }
            if (radSaveAs.Checked)
            {
                if (edtPathSaveAs.Text.Equals(""))
                {
                    MessageBox.Show("Save Path Is Emty", "ERROR");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mode Run Only With Save As", "ERROR");
            }
            SortModel sortModel = new SortModel();
            sortModel.PathSave = edtPathSaveAs.Text;
            sortModel.RootPath = edtRootPath.Text;
            sortModel.Keywords = edtKeyword.Text;
            sortModel.IsCreateFolder = chkCreateNewFolder.Checked;
            FileController fileController = new FileController();
            fileController.Sort(sortModel, this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void onSaveFail(string mess)
        {
            MessageBox.Show(mess, "SAVE ERROR");
        }
    }
}
