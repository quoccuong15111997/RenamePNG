using RenamePNG.Callback;
using RenamePNG.Model;
using RenamePNG.Utity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RenamePNG.Controller
{
    public class RenameController
    {
        private List<string> _listKeywordsRemove;
        private RunModel _runModel;
        private FileHelper _fileHelper;
        private FileSaveCallback _fileSaveCallback;
        private RunCallback _runCallback;
        private int _flagSave= 0;
        private int _targetSave= 0;
        public RenameController(RunModel runModel, RunCallback runCallback)
        {
            this._runModel = runModel;
            this._runCallback = runCallback;
            _fileHelper = new FileHelper();
            loadListKeywordRemove();
        }
        public void Start()
        {
            if (_runModel.PNGModel.isReplace)
            {
                doStartWithReplace();
            }
            else if (_runModel.PNGModel.isSaveAs)
            {
                doStartWithSaveAs();
            }
        }

        private void doStartWithSaveAs()
        {
            _flagSave = 0;
            string[] entries = Directory.GetFileSystemEntries(_runModel.PNGModel.RootPath, "*.png", SearchOption.AllDirectories);
            _targetSave= entries.Length;
            foreach (string path in entries)
            {
                Thread t = new Thread(() =>
                {
                    string fileName = Path.GetFileName(path).Split('.')[0];
                    string fileNameIsMod = doModFileName(fileName) + " " + _runModel.PNGModel.Keywords;
                    _fileHelper.FileSaveAs(path, _runModel.PNGModel.PathSaveAs + "\\" + fileNameIsMod + ".png");                   
                });             
                t.Start();
                t.Join();
                _flagSave += 1;
                checkSave();
            }
        }       
        private void doStartWithReplace()
        {
            string[] entries = Directory.GetFileSystemEntries(_runModel.PNGModel.RootPath, "*.png", SearchOption.AllDirectories);
            _flagSave= 0;
            _targetSave= entries.Length;
            foreach (string path in entries)
            {
                Thread t = new Thread(() =>
                {
                    string fileName = Path.GetFileName(path).Split('.')[0];
                    string folderPath = Path.GetDirectoryName(path);
                    string fileNameIsMod = doModFileName(fileName) + " " + _runModel.PNGModel.Keywords;

                    _fileHelper.RenameFile(path, folderPath + "\\" + fileNameIsMod + ".png");
                });
                t.Start();
                t.Join();
                _flagSave+=1;
                checkSave();
            }
        }

        private void checkSave()
        {
            if(_flagSave == _targetSave)
            {
                // Save done
                Console.WriteLine("Save Done!!!!!!!");
                if (_runModel.SortModels.Count() > 0)
                {
                    if (_runModel.PNGModel.isReplace)
                    {
                        DoFilter(_runModel.PNGModel.RootPath);
                    }
                    else if (_runModel.PNGModel.isSaveAs)
                    {
                        DoFilter(_runModel.PNGModel.PathSaveAs);
                    }
                }
                else
                {
                    _runCallback.OnRunSuccess();
                }               
            }
        }

        private void DoFilter(string rootPath)
        {
            _flagSave = 0;
            _targetSave = _runModel.SortModels.Count();
            string[] entries = Directory.GetFileSystemEntries(rootPath, "*.png", SearchOption.AllDirectories);
            foreach (var _sortModel in _runModel.SortModels)
            {
                Thread thread = new Thread(() =>
                {
                    foreach (string path in entries)
                    {
                        string fileName = Path.GetFileName(path);
                        string s = _sortModel.Keywords;
                        if (fileName.Contains(s)
                            || fileName.Contains(s.ToLower())
                            || fileName.Contains(s.ToUpper()))
                        {
                            string pathSave = rootPath;
                            if (_sortModel.IsCreateFolder)
                            {
                                if (!Directory.Exists(pathSave + "\\" + s))
                                {
                                    Directory.CreateDirectory(pathSave + "\\" + s);
                                }
                                pathSave = pathSave + "\\" + s;
                            }
                            _fileHelper.FileSaveAs(path, pathSave + "\\" + fileName + ".png");
                        }                       
                    }
                });
                thread.Start();
                thread.Join();
                _flagSave += 1;
                checkFilter();

            }
        }

        private void checkFilter()
        {
            if (_flagSave == _targetSave)
            {
                _runCallback.OnRunSuccess();
            }
        }

        private void loadListKeywordRemove()
        {
            _listKeywordsRemove = new List<string>();
            string[] lines = File.ReadAllLines("Config\\key.txt");

            foreach (string line in lines)
            {
                _listKeywordsRemove.AddRange(line.Split(','));
            }

        }
        private string doModFileName(string fileName)
        {
            string res = fileName;
            foreach (string key in _listKeywordsRemove)
            {
                res = res.Replace(key, "").Trim();
            }
            return res;
        }
    }
}
