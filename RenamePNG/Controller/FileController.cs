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
    public class FileController
    {
        private PNGModel _model;
        private List<string> _listKeywords;
        private FileSaveCallback _fileSaveCallback;
        private SortModel _sortModel;
        private int flag = 0;
        private int target = 0;
        public FileController()
        {           
            loadListKeyword();            
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
        public void Sort(SortModel sortModel, FileSaveCallback fileSaveCallback)
        {
            flag = 0;
            target = 0;
            this._sortModel = sortModel;
            this._fileSaveCallback = fileSaveCallback;
                      
            string[] entries = Directory.GetFileSystemEntries(_sortModel.RootPath, "*.png", SearchOption.AllDirectories);
            target = entries.Length;
            foreach (string path in entries)
            {
                Thread t = new Thread(() =>
                {                  
                    string fileName = Path.GetFileName(path);
                    foreach(string s in _sortModel.Keywords.Split(','))
                    {
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
                            saveAsFile(path, pathSave+ "\\" + fileName);
                        }
                    }
                    flag += 1;
                    checkStatus();
                });
                t.Start();
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
    }
}
