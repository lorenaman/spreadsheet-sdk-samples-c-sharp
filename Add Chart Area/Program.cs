//*******************************************************************************************//
//                                                                                           //
// Download Free Evaluation Version From: https://bytescout.com/download/web-installer       //
//                                                                                           //
// Also available as Web API! Free Trial Sign Up: https://secure.bytescout.com/users/sign_up //
//                                                                                           //
// Copyright © 2017-2018 ByteScout Inc. All rights reserved.                                 //
// http://www.bytescout.com                                                                  //
//                                                                                           //
//*******************************************************************************************//


using System;
using System.Diagnostics;
using Bytescout.Spreadsheet;
using Bytescout.Spreadsheet.Charts;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
			// Create new Spreadsheet object
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.RegistrationName = "demo";
            spreadsheet.RegistrationKey = "demo";

            // Add new worksheet
            Worksheet sheet = spreadsheet.Workbook.Worksheets.Add("Sample");

            // Add few random numbers
            int length = 10;
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                sheet.Cell(i, 0).Value = rnd.Next(10);
                sheet.Cell(i, 1).Value = rnd.Next(10);
            }

            // Add charts to worksheet
            Chart areaChart = sheet.Charts.AddChartAndFitInto(1, 3, 16, 9, ChartType.Area);
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 0, length - 1, 0)));
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 1, length - 1, 1)));

            areaChart = sheet.Charts.AddChartAndFitInto(1, 10, 16, 16, ChartType.AreaStacked);
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 0, length - 1, 0)));
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 1, length - 1, 1)));

            areaChart = sheet.Charts.AddChartAndFitInto(1, 17, 16, 23, ChartType.AreaStacked100);
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 0, length - 1, 0)));
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 1, length - 1, 1)));

            areaChart = sheet.Charts.AddChartAndFitInto(17, 3, 32, 9, ChartType.Area3D);
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 0, length - 1, 0)));
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 1, length - 1, 1)));

            areaChart = sheet.Charts.AddChartAndFitInto(17, 10, 32, 16, ChartType.AreaStacked3D);
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 0, length - 1, 0)));
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 1, length - 1, 1)));

            areaChart = sheet.Charts.AddChartAndFitInto(17, 17, 32, 23, ChartType.AreaStacked1003D);
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 0, length - 1, 0)));
            areaChart.SeriesCollection.Add(new Series(sheet.Range(0, 1, length - 1, 1)));
			
            // Save it as XLS
            spreadsheet.SaveAs("Output.xls");

            // Close the document
            spreadsheet.Close();

            // Cleanup
            spreadsheet.Dispose();

            // Open generated XLS file in default associated application
            Process.Start("Output.xls");
        }
    }
}
