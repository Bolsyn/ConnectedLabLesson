using ConnectedLabLesson.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ConnectedLabLesson.Data
{
    public class ProfileDataAccess : DbDataAccess<Profile>
    {
        public override void Delete(Profile entity)
        {
            string deleteSqlScript = $"Delete From Profile where Login = {entity.Login}";
            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = deleteSqlScript;
                command.ExecuteNonQuery();
            }
        }

        public override void Insert(Profile entity)
        {
            string insertSqlScript = "Insert into Profile values (@Login, @FirstName, @LastName, @Email, @PathToImage)";

            using (var transaction = connection.BeginTransaction())
            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = insertSqlScript;

                try
                {
                    command.Transaction = transaction;

                    var loginParameter = factory.CreateParameter();
                    loginParameter.DbType = System.Data.DbType.String;
                    loginParameter.Value = entity.Login;
                    loginParameter.ParameterName = "Login";
                    command.Parameters.Add(loginParameter);

                    var firstNameParameter = factory.CreateParameter();
                    firstNameParameter.DbType = System.Data.DbType.String;
                    firstNameParameter.Value = entity.FirstName;
                    firstNameParameter.ParameterName = "FirstName";
                    command.Parameters.Add(firstNameParameter);

                    var lastNameParameter = factory.CreateParameter();
                    lastNameParameter.DbType = System.Data.DbType.String;
                    lastNameParameter.Value = entity.FirstName;
                    lastNameParameter.ParameterName = "LastName";
                    command.Parameters.Add(firstNameParameter);

                    var emailParameter = factory.CreateParameter();
                    emailParameter.DbType = System.Data.DbType.String;
                    emailParameter.Value = entity.FirstName;
                    emailParameter.ParameterName = "Email";
                    command.Parameters.Add(emailParameter);

                    var pathToImageParameter = factory.CreateParameter();
                    pathToImageParameter.DbType = System.Data.DbType.String;
                    pathToImageParameter.Value = entity.FirstName;
                    pathToImageParameter.ParameterName = "PathToImage";
                    command.Parameters.Add(pathToImageParameter);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (DbException)
                {
                    transaction.Rollback();
                }
            }
        }

        public override ICollection<Profile> Select()
        {
            var selectSqlScript = "select * from Profile";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;

            var dataReader = command.ExecuteReader();

            var profiles = new List<Profile>();

            while (dataReader.Read()) 
            {
                profiles.Add(new Profile
                {
                    Login = dataReader["Login"].ToString(),
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    Email = dataReader["Email"].ToString(),
                    PathToImage = dataReader["PathToImage"].ToString()

                });
            }

            dataReader.Close();
            command.Dispose();
            return profiles;
        }

        public override Profile Select(string value)
        {
            var selectSqlScript = $"select * from Profile where Login = {value}";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;

            var dataReader = command.ExecuteReader();

            var profile = new Profile()
            {
                Login = dataReader["Login"].ToString(),
                FirstName = dataReader["FirstName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                Email = dataReader["Email"].ToString(),
                PathToImage = dataReader["PathToImage"].ToString()
            };

            dataReader.Close();
            command.Dispose();
            return profile;
        }

        public override void Update(Profile entity)
        {
            string updateSqlScript = $"update Profile set FirstName = {entity.FirstName}, set LastName = {entity.LastName}, set Email = {entity.Email}, set PathToImage = {entity.PathToImage} where where Login = {entity.Login} ";

            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = updateSqlScript;
                command.ExecuteNonQuery();
            }
        }
    }
}
