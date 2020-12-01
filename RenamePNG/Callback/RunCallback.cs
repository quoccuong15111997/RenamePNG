using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamePNG.Callback
{
    public interface RunCallback
    {
        void OnRunSuccess();
        void OnRunFail(string mess);
    }
}
