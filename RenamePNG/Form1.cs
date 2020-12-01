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
    public partial class Form1 : Form, RunCallback
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
            List<SortModel> _listSortModel = new List<SortModel>();
            if (!edtPathKewordFilter.Text.Equals(""))
            {
                try
                {
                    string[] lines = File.ReadAllLines(edtPathKewordFilter.Text.Trim());
                    foreach (string line in lines)
                    {
                        if (!line.Equals(""))
                        {
                            SortModel _sortModel = new SortModel();
                            _sortModel.Keywords = line;
                            _sortModel.PathSave = edtPathSaveAs.Text.Trim();
                            _sortModel.RootPath = edtRootPath.Text.Trim();
                            _sortModel.IsCreateFolder = true;
                            _listSortModel.Add(_sortModel);

                        }
                    }
                }
                catch(Exception ex)
                {

                }
            }
            RunModel _runModel = new RunModel();

            PNGModel model = new PNGModel();
            model.RootPath = edtRootPath.Text.ToString().Trim();
            model.isReplace = radReplace.Checked;
            model.isSaveAs = radSaveAs.Checked;
            model.Keywords = edtKeyword.Text;
            model.PathSaveAs = edtPathSaveAs.Text.ToString().Trim();

            _runModel.SortModels = _listSortModel;
            _runModel.PNGModel = model;

            RenameController _renameController = new RenameController(_runModel, this);
            _renameController.Start();
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
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string filename = "";
            var loadDialog = new OpenFileDialog { Filter = "Text File|*.txt"};
            if (loadDialog.ShowDialog() == DialogResult.OK)
                filename = loadDialog.FileName;
            edtPathKewordFilter.Text = filename;
        }

        public void OnRunSuccess()
        {
            MessageBox.Show("Process Success", "Done");
        }

        public void OnRunFail(string mess)
        {
            MessageBox.Show(mess, "SAVE ERROR");
        }
    }
}
