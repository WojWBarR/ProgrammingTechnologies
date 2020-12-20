using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data
{
    public static class Configuration
    {
        public static string ConnectionString => "Server=MSI\\BARTEKSQL;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
