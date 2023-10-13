using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using ORM_Dapper;

namespace ORM_Dapper
{
    class Program
    {
        static IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        static string connString = config.GetConnectionString("DefaultConnection");

        static IDbConnection conn = new MySqlConnection(connString);

        static void Main(string[] args)
        {
            var repo = new DapperProductRepository(conn);

            Console.WriteLine("What is the name of the new product?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the category ID?");
            var prodCat = int.Parse(Console.ReadLine());

            repo.CreateProduct(prodName, prodPrice, prodCat);

            var prodList = repo.GetAllProducts();

            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name}");
            }

            Console.WriteLine("What is the product ID to be updated?");
            var prodID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the updated product name?");
            var newName = Console.ReadLine();

            repo.UpdateProduct(prodID, newName);

            Console.WriteLine("What is the product ID to be deleted?");
            prodID = int.Parse(Console.ReadLine());

            repo.DeleteProduct(prodID);
        }
    }
}


