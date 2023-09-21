using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Tools
{
    // Class for printing table view
    public class TablePrinter
    {
        private readonly string[] Headers;
        private readonly List<int> ColumnLengths;
        private readonly List<string[]> Rows = new List<string[]>(); 

        //Initialize header of the table
        public TablePrinter(params string[] Headers)
        {
            this.Headers = Headers;
            ColumnLengths = Headers.Select(t => t.Length).ToList();
        }

        // Add 
        public void AddRow(params object[] row)
        {
            if (row.Length != Headers.Length)
            {
                throw new System.Exception($"Added row length [{row.Length}] is not equal to title row length [{Headers.Length}]");
            }
            Rows.Add(row.Select(o => o.ToString()).ToArray());
            for (int i = 0; i < Headers.Length; i++)
            {
                if (Rows.Last()[i].Length > ColumnLengths[i])
                {
                    ColumnLengths[i] = Rows.Last()[i].Length;
                }
            }
        }

        // Print a table
        public void Print()
        {
            // Print top border 
            ColumnLengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            string line = "";
            for (int i = 0; i < Headers.Length; i++)
            {
                line += "| " + Headers[i].PadRight(ColumnLengths[i]) + ' ';
            }
            System.Console.WriteLine(line + "|");

            ColumnLengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            // Print row
            foreach (var row in Rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    
                     line += "| " + row[i].PadRight(ColumnLengths[i]) + ' ';
                    
                }
                System.Console.WriteLine(line + "|");
            }

            // Print btm border
            ColumnLengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");
        }
    }

}
