using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StoreHouse.Models;


namespace StoreHouse.Data_Layer.Repositories
{
    public class CategoryRepository
    {

        private SqlConnection _connection = DataBaseConnection.Connection;

        private string _categoryIDParameter = "@CategoryID";
        private string _categoryNameParameter = "@Name";
        private string _categoryDescriptionParameter = "@Description";
        public bool AddCategory(Category category)
        { 
            var storeProcedureName = "Sp_Categorys_Create";

            


            SqlCommand command = new SqlCommand(storeProcedureName,_connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_categoryNameParameter, category.Name);
            command.Parameters.AddWithValue(_categoryDescriptionParameter, category.Description);

            _connection.Open();

            var rowsAffected = command.ExecuteNonQuery();

            _connection.Close();

            if (rowsAffected == 0)
                return false;

            return true;


        }

        public bool UpdateCategory(Category category)
        {
            var storeProcedureName = "Sp_Categorys_Update";


            var command = new SqlCommand(storeProcedureName, _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_categoryIDParameter, category.CategoryID);

            command.Parameters.AddWithValue(_categoryNameParameter, category.Name);
            command.Parameters.AddWithValue(_categoryDescriptionParameter, category.Description);

            _connection.Open();


            var rowsAffected = command.ExecuteNonQuery();

            _connection.Close();

            if (rowsAffected == 0)
                return false;

            return true;


        }


        public bool DeleteCategory(int categoryID)
        {
            var storeProcedureName = "Sp_Categorys_Delete";


            var command = new SqlCommand(storeProcedureName, _connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_categoryIDParameter, categoryID);

            _connection.Open();

            
            var rowsAffected = command.ExecuteNonQuery();

            _connection.Close();


            if (rowsAffected == 0)
                return false;

            return true;


        }

        public Category GetCategoryByID(int categoryID)
        {
            var storeProcedureName = "Sp_Categorys_GetByID";

            var command = new SqlCommand(storeProcedureName, _connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_categoryIDParameter, categoryID);

            var dataTable = new DataTable();

            _connection.Open();


            var dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            _connection.Close();


            if (dataTable.Rows.Count == 0)
                return null;

            var dataRow = dataTable.Rows[0];

            var category = new Category()
            {
                CategoryID = Convert.ToInt32(dataRow["CategoryID"]),
                Name = Convert.ToString(dataRow["Name"]),
                Description= Convert.ToString(dataRow["Description"])
            };

            return category;


        }

        public List<Category> GetCategories(string searchQuery)
        {
            var storeProcedureName = "Sp_Categorys_GetAll";

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



            var categories = new List<Category>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var category = new Category()
                {
                    CategoryID = Convert.ToInt32(dataRow["CategoryID"]),
                    Name = Convert.ToString(dataRow["Name"]),
                    Description = Convert.ToString(dataRow["Description"])
                };

                categories.Add(category);

            }
            
            return categories;


        }



    }
}