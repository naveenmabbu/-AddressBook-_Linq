﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem_Linq
{
    class AddressBookDataTable
    {
        public readonly DataTable dataTable = new DataTable();
        public DataTable CreateTable(AddrssBookModel model)
        {
            var taleColumn1 = new DataColumn("First_Name");
            dataTable.Columns.Add(taleColumn1);
            var taleColumn2 = new DataColumn("Last_Name");
            dataTable.Columns.Add(taleColumn2);
            var taleColumn3 = new DataColumn("Address");
            dataTable.Columns.Add(taleColumn3);
            var taleColumn4 = new DataColumn("City");
            dataTable.Columns.Add(taleColumn4);
            var taleColumn5 = new DataColumn("State");
            dataTable.Columns.Add(taleColumn5);
            var taleColumn6 = new DataColumn("Zip");
            dataTable.Columns.Add(taleColumn6);
            var taleColumn7 = new DataColumn("Phone_Number");
            dataTable.Columns.Add(taleColumn7);
            var taleColumn8 = new DataColumn("Email");
            dataTable.Columns.Add(taleColumn8);

            dataTable.Rows.Add("Balu", "Reddy", "Lkdkr", "Ongl", "AP", "523115", "9876543210", "vbn@gmail.com");
            dataTable.Rows.Add("Siva", "Reddy", "N.Peta", "Gunturu", "AP", "526321", "6547890567", "siava@gmail.com");
            dataTable.Rows.Add("Dipika", "Pilli", "Chennai", "mahabaliPuram", "TN", "654342", "9632154564", "dipika@gmail.com");
            dataTable.Rows.Add("Mahesh", "Babu", "Banjarahiils", "Hyderabad", "TS", "500562", "8529631523", "mb@gmail.com");
            dataTable.Rows.Add("Vishal", "Gunni", "Marthali", "Banglore", "Karanataka", "500056", "9632544570", "vishal@gmail.com");
            dataTable.Rows.Add("Ganesh", "Reddy", "vesarpadi", "Chennai", "TamilNadu", "600341", "97456321011", "reddy@gmail.com");
            return dataTable;
        }
        public void AddContact(AddrssBookModel model)
        {
            dataTable.Rows.Add(model.First_Name, model.Last_Name, model.Address, model.City,
                model.State, model.Zip, model.Phone_Number, model.Email);
            Console.WriteLine("Contact Added Succesfully...");
        }
        public void EditContact(AddrssBookModel model)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("First_Name") == model.First_Name).First();
            if (recordData != null)
            {
                recordData.SetField("Last_Name", model.Last_Name);
                recordData.SetField("Address", model.Address);
                recordData.SetField("City", model.City);
                recordData.SetField("State", model.State);
                recordData.SetField("Zip", model.Zip);
                recordData.SetField("Phone_Number", model.Phone_Number);
                recordData.SetField("Email", model.Email);
            }
        }
        public void Display()
        {
            foreach (var table in dataTable.AsEnumerable())
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name"));
                Console.WriteLine("LastName: " + table.Field<string>("Last_Name"));
                Console.WriteLine("Address: " + table.Field<string>("Address"));
                Console.WriteLine("City: " + table.Field<string>("City"));
                Console.WriteLine("State: " + table.Field<string>("State"));
                Console.WriteLine("ZipCode: " + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber: " + table.Field<string>("Phone_Number"));
                Console.WriteLine("E-mail: " + table.Field<string>("Email"));
            }
        }

        public void DeleteContact(AddrssBookModel model)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("First_Name") == model.First_Name).First();
            if (recordData != null)
            {
                recordData.Delete();
                Console.WriteLine("Contact Deleted Successfully....");
            }
        }
        public void RetrievePersonByUsingState(AddrssBookModel model)
        {
            var selectdData = from dataTable in dataTable.AsEnumerable().Where((dataTable => dataTable.Field<string>("State") == model.State)) select dataTable;
            foreach (var table in selectdData.AsEnumerable())
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name"));
                Console.WriteLine("LastName: " + table.Field<string>("Last_Name"));
                Console.WriteLine("Address: " + table.Field<string>("Address"));
                Console.WriteLine("City: " + table.Field<string>("City"));
                Console.WriteLine("State: " + table.Field<string>("State"));
                Console.WriteLine("ZipCode: " + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber: " + table.Field<string>("Phone_Number"));
                Console.WriteLine("E-mail: " + table.Field<string>("Email"));
            }
        }
        public void RetrievePersonByUsingCity(AddrssBookModel model)
        {
            var selectdData = from dataTable in dataTable.AsEnumerable().Where(dataTable => dataTable.Field<string>("City") == model.City) select dataTable;
            foreach (var table in selectdData.AsEnumerable())
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name"));
                Console.WriteLine("LastName: " + table.Field<string>("Last_Name"));
                Console.WriteLine("Address: " + table.Field<string>("Address"));
                Console.WriteLine("City: " + table.Field<string>("City"));
                Console.WriteLine("State: " + table.Field<string>("State"));
                Console.WriteLine("ZipCode: " + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber: " + table.Field<string>("Phone_Number"));
                Console.WriteLine("E-mail: " + table.Field<string>("Email"));
            }
        }
        public void CountByCityAndState()
        {
            var countByCityAndState = from row in dataTable.AsEnumerable()
                                      group row by new { City = row.Field<string>("City"), State = row.Field<string>("State") } into groups
                                      select new
                                      {
                                          City = groups.Key.City,
                                          State = groups.Key.State,
                                          Count = groups.Count()
                                      };
            foreach (var row in countByCityAndState)
            {
                Console.WriteLine(row.City + "  " + row.State + "--->" + row.Count);
            }
        }
        public void SortContactAlphabeticallyForGivenCity(AddrssBookModel model)
        {
            var records = dataTable.AsEnumerable().Where(x => x.Field<string>("City") == model.City).OrderBy(x => x.Field<string>("First_Name")).ThenBy(x => x.Field<string>("Last_Name"));
            foreach (var table in records)
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name"));
                Console.WriteLine("LastName: " + table.Field<string>("Last_Name"));
                Console.WriteLine("Address: " + table.Field<string>("Address"));
                Console.WriteLine("City: " + table.Field<string>("City"));
                Console.WriteLine("State: " + table.Field<string>("State"));
                Console.WriteLine("ZipCode: " + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber: " + table.Field<string>("Phone_Number"));
                Console.WriteLine("E-mail: " + table.Field<string>("Email"));
            }
        }
    }
}
