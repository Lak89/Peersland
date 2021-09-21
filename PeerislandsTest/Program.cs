using PeerislandsTest.Builder;
using PeerislandsTest.Services;
using System;

namespace PeerislandsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to query generator app \n\n");
            var jsonData = new JsonFileReadService().ReadFile();
            var queryBuilder = new QueryBuilder(new MessageService(),new QueryGenerator());
            Console.WriteLine(queryBuilder.Select("ID,Name,Age").FromTable("Employee").Where(jsonData.Columns).GenerateQuery());
            Console.WriteLine(queryBuilder.Select("ID,Name,Age").FromTable("Employee").Join("inner join", "salary").On("Employee.Id", "Salary.EmpId").And().GreaterThen("age", "30").GenerateQuery());
            Console.WriteLine(queryBuilder.Select("ID,Name,Age").FromTable("Employee").Where("Id").In(new QueryBuilder(new MessageService(), new QueryGenerator()).Select("EmpId").FromTable("Salary").Where("").GreaterThen("age", "30").GenerateQuery()).GenerateQuery());
            Console.ReadLine();
        }
    }
}
