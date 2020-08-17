using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Npoi.Mapper;

namespace NETCore31
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FluentMethod����()
        {
            var mapper = new Mapper("Input.xlsx");
            mapper.Map<Employee>("LocationID", o => o.LocationId)
                  .Map<Employee>(1, o => o.DepartmentId)
                  .Ignore<Employee>(o => o.ErrorMessage)
                  .Format<Employee>("yyyy/MM/dd", o => o.Birthdaty)
                ;
            var numberOfSheets = mapper.Workbook.NumberOfSheets;
            for (var i = 0; i < numberOfSheets; i++)
            {
                var rowInfos = mapper.Take<Employee>().ToList();
                foreach (var rowInfo in rowInfos)
                {
                    Console.WriteLine(rowInfo.ErrorColumnIndex);
                    Console.WriteLine(rowInfo.ErrorMessage);
                }
            }
        }

        [TestMethod]
        public void Ū���S�w�u�@��()
        {
            var mapper    = new Mapper("Input.xlsx");
            var employees = mapper.Take<Employee>("sheet1");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ErrorColumnIndex);
                Console.WriteLine(employee.ErrorMessage);
            }
        }

        [TestMethod]
        public void Ū���ɮשҦ����u�@��()
        {
            var mapper         = new Mapper("Input.xlsx");
            var numberOfSheets = mapper.Workbook.NumberOfSheets;
            for (var i = 0; i < numberOfSheets; i++)
            {
                var rowInfos = mapper.Take<Employee>().ToList();
                foreach (var rowInfo in rowInfos)
                {
                    if (string.IsNullOrWhiteSpace(rowInfo.ErrorMessage) == false)
                    {
                        Console.WriteLine(rowInfo.ErrorColumnIndex);
                        Console.WriteLine(rowInfo.ErrorMessage);
                    }
                }
            }

            foreach (var sheetInfo in mapper.Objects)
            {
                var sheetName = sheetInfo.Key;
                foreach (var rowInfo in sheetInfo.Value)
                {
                    var rowIndex = rowInfo.Key;
                    var rowData  = rowInfo.Value as Employee;
                    Console.WriteLine(JsonConvert.SerializeObject(new
                    {
                        Index = rowIndex,
                        Data  = rowData
                    }));
                }
            }
        }

        [TestMethod]
        public void Ū���ɮ���dynamic()
        {
            var mapper   = new Mapper("Input.xlsx");
            var rowInfos = mapper.Take<dynamic>().ToList();
            foreach (var rowInfo in rowInfos)
            {
                var rowData = rowInfo.Value;
                Console.WriteLine(JsonConvert.SerializeObject(rowData));
            }
        }
    }
}