using CsvHelper;

using GalytixWeb.DataAccess.Mapping;
using GalytixWeb.DataAccess.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace GalytixWeb.DataAccess
{
    public class DbSeeder
    {
        private readonly string _basePath;
        public DbSeeder(string basePath) 
        {
            _basePath = basePath;
        }
        public void Seed(ModelBuilder modelBuilder)
        {
            var testDataFilePath = Path.Combine(_basePath, "TestData/gwpByCountry.csv");
            List<GWPItem> records = new List<GWPItem>();

            using (var reader = new StreamReader(testDataFilePath))       
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<GWPItemMapping>();
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                records.AddRange(csv.GetRecords<GWPItem>());
            }

            modelBuilder.Entity<GWPItem>().HasData(records);
        }
    }
}
