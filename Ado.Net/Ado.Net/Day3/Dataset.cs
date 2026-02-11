using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ado.Net.Day3
{
    public class Dataset
    {
        public static void main()
        {
            DataTable dt=new DataTable();
            DataSet ds=new DataSet();
            dt.Columns.Add("Id",typeof(int));
            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Department",typeof(string));

            dt.Rows.Add(1, "Raman", "IT");
            dt.Rows.Add(2, "Sandeep", "MBA");
            dt.Rows.Add(3, "Satyam", "MCA");

            Console.WriteLine("Student Details:");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["Id"]} - {row["Name"]} - {row["Department"]}");
            }
            ds.Tables.Add(dt);
            Console.WriteLine(ds.Tables.Count);
        }
    }
}
