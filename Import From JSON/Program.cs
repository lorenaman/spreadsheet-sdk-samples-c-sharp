//*******************************************************************
//       ByteScout Spreadsheet SDK		                                     
//                                                                   
//       Copyright © 2016 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

using System.Diagnostics;
using System.IO;
using Bytescout.Spreadsheet;

namespace ImportFromJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Spreadsheet spreadsheet = new Spreadsheet())
            {
                // Load JSON string from file
                string jsonString = File.ReadAllText("sample.json");

            	// Import JSON
                spreadsheet.ImportFromJSON(jsonString);
                
                // Save spreadsheet
                spreadsheet.SaveAsXLS("result.xls");

				// Open the result file in default associated application
                Process.Start("result.xls");
            }
        }
    }
}
