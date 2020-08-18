using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StoreHouse.Models;

namespace StoreHouse.Data_Layer.Repositories
{
    public class ProductRepository
    {
        private SqlConnection _connection = DataBaseConnection.Connection;

        private  CategoryRepository _categoryRepository= new CategoryRepository();

        private string _productIDParameter = "@productID";
        private string _productNameParameter = "@Name";
        private string _productDescriptionParameter = "@Description";
        private string _productPriceParameter = "@Price";
        private string _productStockParameter = "@Stock";
        private string _productCategoryIDParameter = "@CategoryID";



        public bool AddProduct(Product product)
        {
            var storeProcedureName = "Sp_Products_Create";




            SqlCommand command = new SqlCommand(storeProcedureName, _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_productNameParameter, product.Name);
            command.Parameters.AddWithValue(_productDescriptionParameter, product.Description);
            command.Parameters.AddWithValue(_productPriceParameter, product.Price);
            command.Parameters.AddWithValue(_productStockParameter, product.Stock);
            command.Parameters.AddWithValue(_productCategoryIDParameter, product.CategoryID);




            _connection.Open();

            var rowsAffected = command.ExecuteNonQuery();

            _connection.Close();

            if (rowsAffected == 0)
                return false;

            return true;


        }

        public bool UpdateProduct(Product product)
        {
            var storeProcedureName = "Sp_Products_Update";


            var command = new SqlCommand(storeProcedureName, _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_productIDParameter, product.ProductID);

            command.Parameters.AddWithValue(_productNameParameter, product.Name);
            command.Parameters.AddWithValue(_productDescriptionParameter, product.Description);
            command.Parameters.AddWithValue(_productPriceParameter, product.Price);
            command.Parameters.AddWithValue(_productStockParameter, product.Stock);
            command.Parameters.AddWithValue(_productCategoryIDParameter, product.CategoryID);

            _connection.Open();


            var rowsAffected = command.ExecuteNonQuery();

            _connection.Close();

            if (rowsAffected == 0)
                return false;

            return true;


        }


        public bool DeleteProduct(int productID)
        {
            var storeProcedureName = "Sp_Products_Delete";


            var command = new SqlCommand(storeProcedureName, _connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_productIDParameter, productID);

            _connection.Open();


            var rowsAffected = command.ExecuteNonQuery();

            _connection.Close();


            if (rowsAffected == 0)
                return false;

            return true;


        }

        public Product GetProductByID(int productID)
        {
            var storeProcedureName = "Sp_Products_GetByID";

            var command = new SqlCommand(storeProcedureName, _connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_productIDParameter, productID);

            var dataTable = new DataTable();

            _connection.Open();


            var dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            _connection.Close();


            if (dataTable.Rows.Count == 0)
                return null;

            var dataRow = dataTable.Rows[0];


            var product = new Product()
            {
                ProductID = Convert.ToInt32(dataRow["ProductID"]),
                Name = Convert.ToString(dataRow["Name"]),
                Description = Convert.ToString(dataRow["Description"]),
                Stock = Convert.ToInt32(dataRow["Stock"]),
                Price = Convert.ToDouble(dataRow["Price"]),
                CategoryID = Convert.ToInt32(dataRow["CategoryID"]),



            };

            product.Category = _categoryRepository.GetCategoryByID(product.CategoryID);


            return product;


        }

        public List<Product> GetProducts(string searchQuery)
        {
            var storeProcedureName = "Sp_Products_GetAll";

            var command = new SqlCommand(storeProcedureName, _connection);

            command.CommandType = CommandType.StoredProcedure;

            var searchQueryParameter = "@SearchQuery";

            _connection.Open();


            if (!string.IsNullOrWhiteSpace(searchQuery))
                command.Parameters.AddWithValue(searchQueryParameter, searchQuery);
            else
            {
                command.Parameters.AddWithValue(searchQueryParameter, "");

            }


            var dataAdapter = new SqlDataAdapter(command);

            var dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            _connection.Close();


            if (dataTable.Rows.Count == 0)
                return null;



            var products = new List<Product>();

            


            foreach (DataRow dataRow in dataTable.Rows)
            {
                var categoryID = Convert.ToInt32(dataRow["CategoryID"]);
                var category = _categoryRepository.GetCategoryByID(categoryID);

                var product = new Product()
                {
                    ProductID = Convert.ToInt32(dataRow["ProductID"]),
                    Name = Convert.ToString(dataRow["Name"]),
                    Description = Convert.ToString(dataRow["Description"]),
                    Stock = Convert.ToInt32(dataRow["Stock"]),
                    Price = Convert.ToDouble(dataRow["Price"]),
                    CategoryID = categoryID,
                    Category = category
                };

                products.Add(product);

            }

            return products;


        }

        public List<Product> GetProductsByCategoryID(int categoryIDFilter)
        {
            var storeProcedureName = "Sp_Products_GetByCategory";

            var command = new SqlCommand(storeProcedureName, _connection);

            command.CommandType = CommandType.StoredProcedure;

            var searchQueryParameter = "@CategoryID";

            _connection.Open();


          
                command.Parameters.AddWithValue(searchQueryParameter, categoryIDFilter);
           

            var dataAdapter = new SqlDataAdapter(command);

            var dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            _connection.Close();


            if (dataTable.Rows.Count == 0)
                return null;



            var products = new List<Product>();




            foreach (DataRow dataRow in dataTable.Rows)
            {
                var categoryID = Convert.ToInt32(dataRow["CategoryID"]);
                var category = _categoryRepository.GetCategoryByID(categoryID);

                var product = new Product()
                {
                    ProductID = Convert.ToInt32(dataRow["ProductID"]),
                    Name = Convert.ToString(dataRow["Name"]),
                    Description = Convert.ToString(dataRow["Description"]),
                    Stock = Convert.ToInt32(dataRow["Stock"]),
                    Price = Convert.ToDouble(dataRow["Price"]),
                    CategoryID = categoryID,
                    Category = category
                };

                products.Add(product);

            }

            return products;


        }



    }



}
