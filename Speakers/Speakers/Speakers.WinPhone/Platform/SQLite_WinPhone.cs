using Speakers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.WinPhone.Platform
{
    public class SQLite_WinPhone : ISQLite
    {
        public SQLite_WinPhone()
        {
            // A parameterless constructor is required for the Xamarin Forms Depenency Service
        }

        // Change return type to SQLiteDBConnection as soon as the NuGet packages have been brought in
        public bool GetConnection()
        {
            // Add the platform specific WinPhone implementation once the NuGet packages have been brought in
            // Also add the platform specific implementations for the other two platforms
            return true;
        }
    }
}
