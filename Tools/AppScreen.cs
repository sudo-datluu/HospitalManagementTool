using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Tools
{
    public static class AppScreen
    {
        internal static void Login()
        {
            string banner = @"
+-------------------+
|DL Hospital Manager|
|-------------------|
|      Login        |
+-------------------+
";
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine();
        }
    }
}
