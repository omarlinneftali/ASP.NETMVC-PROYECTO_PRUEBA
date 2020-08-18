using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StoreHouse.Models;

namespace StoreHouse.Data_Layer.Repositories
{
    public class UserRepository
    {
        private SqlConnection _connection = DataBaseConnection.Connection;

        private string _userIDParameter = "@UserID";
        private string _userNameParameter = "@UserName";
        private string _emailParameter = "@Email";
        private string _passwordParameter = "@Password";
        private string _nameParameter = "@Name";


        public bool AddUser(User user)
        {
            var storeProcedureName = "Sp_Users_Create";

            SqlCommand command = new SqlCommand(storeProcedureName, _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_nameParameter, user.Name);
            command.Parameters.AddWithValue(_userNameParameter, user.UserName);
            command.Parameters.AddWithValue(_emailParameter, user.Email);
            command.Parameters.AddWithValue(_passwordParameter, user.Password);


            _connection.Open();


            

            var rowsAffected = command.ExecuteNonQuery();

            _connection.Close();

            if (rowsAffected == 0)
                return false;

            return true;


        }

        public bool UpdateUser(User user)
        {
            var storeProcedureName = "Sp_Users_Update";




            SqlCommand command = new SqlCommand(storeProcedureName, _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue(_userIDParameter, user.UserID);
            command.Parameters.AddWithValue(_nameParameter, user.Name);

            command.Parameters.AddWithValue(_userNameParameter, user.UserName);
            command.Parameters.AddWithValue(_emailParameter, user.Email);
            command.Parameters.AddWithValue(_passwordParameter, user.Password);

           


            _connection.Open();

            var rowsAffected = command.ExecuteNonQuery();

            _connection.Close();

            if (rowsAffected == 0)
                return false;

            return true;


        }



        public User GetUserByEmailAndPassword(string email, string password)
        {
            var storeProcedureName = "Sp_Users_GetByUserNameAndPassword";
            SqlCommand command = new SqlCommand(storeProcedureName, _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue(_emailParameter, email);
            command.Parameters.AddWithValue(_passwordParameter, password);
            var dataTable = new DataTable();

            _connection.Open();


            var dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            _connection.Close();


            if (dataTable.Rows.Count == 0)
                return null;

            var dataRow = dataTable.Rows[0];


            var user = new User()
            {
                UserID = Convert.ToInt32(dataRow["UserID"]),
                Name = Convert.ToString(dataRow["Name"]),
                Password = Convert.ToString(dataRow["Password"]),
                UserName = Convert.ToString(dataRow["UserName"]),
                Email = Convert.ToString(dataRow["Email"])



            };

            return user;
        }

        public User GetUserByID(int userID)
        {
            var storeProcedureName = "Sp_Users_GetByUserNameAndPassword";
            SqlCommand command = new SqlCommand(storeProcedureName, _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue(_userIDParameter, userID);
            var dataTable = new DataTable();

            _connection.Open();


            var dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            _connection.Close();


            if (dataTable.Rows.Count == 0)
                return null;

            var dataRow = dataTable.Rows[0];


            var user = new User()
            {
                UserID = Convert.ToInt32(dataRow["UserID"]),
                Name = Convert.ToString(dataRow["Name"]),
                Password = Convert.ToString(dataRow["Password"]),
                UserName = Convert.ToString(dataRow["UserName"]),
                Email = Convert.ToString(dataRow["Email"])



            };

            return user;
        }

        public User GetUserByEmailOrUsername(string emailOrUsername)
        {
            var emailOrUsernameParameter = "@EmailOrUsername";

            var storeProcedureName = "Sp_Users_GetByEmailOrUsername";

            SqlCommand command = new SqlCommand(storeProcedureName, _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue(emailOrUsernameParameter, emailOrUsername);

            var dataTable = new DataTable();

            _connection.Open();


            var dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataTable);

            _connection.Close();


            if (dataTable.Rows.Count == 0)
                return null;

            var dataRow = dataTable.Rows[0];


            var user = new User()
            {
                UserID = Convert.ToInt32(dataRow["UserID"]),
                Name = Convert.ToString(dataRow["Name"]),
                Password = Convert.ToString(dataRow["Password"]),
                UserName = Convert.ToString(dataRow["UserName"]),
                Email = Convert.ToString(dataRow["Email"])



            };

            return user;
        }




    }

}