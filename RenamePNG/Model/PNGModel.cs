using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamePNG.Model
{
    public class PNGModel
    {
        public string RootPath { get; set; }
        public string Keywords { get; set; }
        public bool isReplace { get; set; }
        public bool isSaveAs { get; set; }
        public string PathSaveAs { get; set; }
        public string FileType { get; set; }
    }
}
