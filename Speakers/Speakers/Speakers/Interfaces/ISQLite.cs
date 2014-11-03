using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Interfaces
{
    public interface ISQLite
    {
        // Change the type to SQLiteDBConnection as soon as the NuGet package has been brought in
        bool GetConnection();
    }
}
