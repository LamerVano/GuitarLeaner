using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarLA
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
