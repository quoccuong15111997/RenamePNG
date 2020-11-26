using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamePNG.Model
{
    public class SortModel
    {
        public string RootPath { get; set; }
        public string Keywords { get; set; }
        public string PathSave { get; set; }
        public bool IsCreateFolder { get; set; }
    }
}
