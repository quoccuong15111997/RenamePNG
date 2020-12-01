using RenamePNG.Callback;
using RenamePNG.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RenamePNG.Controller
{
    public class FileController : FileSaveCallback
    {
        private PNGModel _model;
        private List<string> _listKeywords;
        private FileSaveCallback _fileSaveCallback;
        private RunModel _runModel;
        private int flag = 0;
        private int target = 0;
        public FileController(RunModel runModel, FileSaveCallback fileSaveCallback)
        {           
            loadListKeyword();
            this._runModel = runModel;
            this._fileSaveCallback = fileSaveCallback;
            init(_runModel.PNGModel, this);
        }

        private void loadListKeyword()
        {
            _listKeywords = new List<string>();        
            string[] lines = File.ReadAllLines("Config\\key.txt");

            foreach (string line in lines)
            {
                _listKeywords.AddRange(line.Split(','));
            }

        }

        public void init(PNGModel model, FileSaveCallback fileSaveCallback)
        {
            this._model = model;
            this._fileSaveCallback = fileSaveCallback;
            if (_model.isReplace)
            {
                doStartWithReplace();
            }
            else if (_model.isSaveAs)
            {
                doStartWithSaveAs();
            }
            

            foreach (string file in Directory.EnumerateFiles(_model.RootPath, "*.png"))
            {
                var contents = File.ReadAllText(file);
                Console.WriteLine(contents.Length + "");
            }
        }

        private void doStartWithSaveAs()
        {
            string[] entries = Directory.GetFileSystemEntries(_model.RootPath, "*.png", SearchOption.AllDirectories);
            target = entries.Length;
            foreach(string path in entries)
            {
                Thread t = new Thread(() =>
                {
                    string fileName = Path.GetFileName(path).Split('.')[0];
                    string fileNameIsMod = doModFileName(fileName) +" "+ _model.Keywords;
                    saveAsFile(path, _model.PathSaveAs + "\\" + fileNameIsMod + ".png");
                });
                t.Start();            
            }
        }

        private string doModFileName(string fileName)
        {
            string res = fileName;
            foreach(string key in _listKeywords)
            {
                res = res.Replace(key, "").Trim();
            }
            return res;
        }

        private void doStartWithReplace()
        {
            flag = 0;
            target = 0;
            string[] entries = Directory.GetFileSystemEntries(_model.RootPath, "*.png", SearchOption.AllDirectories);
            target = entries.Length;
            foreach (string path in entries)
            {
                Thread t = new Thread(() =>
                {
                    string fileName = Path.GetFileName(path).Split('.')[0];
                    string folderPath = Path.GetDirectoryName(path);
                    string fileNameIsMod = doModFileName(fileName) + " " + _model.Keywords;
                    
                    RenameFile(path, folderPath + "\\" + fileNameIsMod + ".png");
                });
                t.Start();
            }
        }

        private void saveAsFile(string pathOld, string pathNew)
        {
            try
            {
                FileInfo file = new FileInfo(pathOld);
                file.CopyTo(pathNew);
                flag += 1;
                checkStatus();
            }
            catch (Exception e)
            {
                _fileSaveCallback.onSaveFail(e.Message);
            }       
        }

        private void checkStatus()
        {
            if(flag == target - 1)
            {
                _fileSaveCallback.onSaveSuccess();
            }
        }
        private void RenameFile(string originalName, string newName)
        {
            try
            {
                File.Move(originalName, newName);
                flag += 1;
                checkStatus();
            }
            catch(Exception e)
            {
                _fileSaveCallback.onSaveFail(e.Message);
            }
        }
        int flagSort = 0;
        int targetSort = 0;
        private void Sort(string[] entries, SortModel _sortModel, FileSaveCallback fileSaveCallback)
        {
            flagSort = 0;
            targetSort = entries.Length;
            foreach (string path in entries)
            {
                string fileName = Path.GetFileName(path);
                string s = _sortModel.Keywords;
                if (fileName.Contains(s)
                    || fileName.Contains(s.ToLower())
                    || fileName.Contains(s.ToUpper()))
                {
                    string pathSave = _sortModel.PathSave;
                    if (_sortModel.IsCreateFolder)
                    {
                        if (!Directory.Exists(pathSave + "\\" + s))
                        {
                            Directory.CreateDirectory(pathSave + "\\" + s);
                        }
                        pathSave = pathSave + "\\" + s;
                    }
                    saveAsFile(path, pathSave + "\\" + fileName);
                }
                flagSort += 1;
                checkFlagSort();
            }
        }

        private void checkFlagSort()
        {
            if(flagSort == targetSort)
            {
                flag += 1;
                checkStatus();
            }
        }

        private void saveAsFileSort(string pathOld, string pathNew)
        {
            try
            {
                FileInfo file = new FileInfo(pathOld);
                file.CopyTo(pathNew);
            }
            catch (Exception e)
            {
                _fileSaveCallback.onSaveFail(e.Message);
            }
        }

        public void onSaveSuccess()
        {
            if(_runModel.SortModels.Count() > 0)
            {
                flag = 0;
                target = _runModel.SortModels.Count();
                string[] entries = Directory.GetFileSystemEntries(_runModel.PNGModel.PathSaveAs, "*.png", SearchOption.AllDirectories);
                foreach (var sortmodel in _runModel.SortModels)
                {
                    Sort(entries, sortmodel, _fileSaveCallback);
                }
            }
            else
            {
                _fileSaveCallback.onSaveSuccess();
            }
        }

        public void onSaveFail(string mess)
        {
            throw new NotImplementedException();
        }
    }
}
