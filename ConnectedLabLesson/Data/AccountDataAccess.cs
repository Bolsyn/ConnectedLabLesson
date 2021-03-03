using ConnectedLabLesson.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ConnectedLabLesson.Data
{
    public class AccountDataAccess : DbDataAccess<Account>
    {
        public override void Delete(Account entity)
        {
            string deleteSqlScript = $"Delete From Account where Login = {entity.Login}";
            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = deleteSqlScript;
                command.ExecuteNonQuery();
            }
        }

        public override void Insert(Account entity)
        {
            string insertSqlScript = "Insert into Account values (@Login, @Password)";

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

                    var passwordParameter = factory.CreateParameter();
                    passwordParameter.DbType = System.Data.DbType.String;
                    passwordParameter.Value = entity.Password;
                    passwordParameter.ParameterName = "Password";
                    command.Parameters.Add(passwordParameter);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (DbException)
                {
                    transaction.Rollback();
                }
            }
        }

        public override ICollection<Account> Select()
        {
            var selectSqlScript = "select * from Account";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;

            var dataReader = command.ExecuteReader();

            var account = new List<Account>();

            while (dataReader.Read())
            {
                account.Add(new Account
                {                    
                    Login = dataReader["Login"].ToString(),
                    Password = dataReader["Password"].ToString()
                });
            }

            dataReader.Close();
            command.Dispose();
            return account;
        }

        public override Account Select(string entity)
        {
            var selectSqlScript = $"select * from Account where Login = {entity}";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;

            var dataReader = command.ExecuteReader();

            var account = new Account()
            {
                Login = dataReader["Login"].ToString(),
                Password = dataReader["Password"].ToString()
            };

            dataReader.Close();
            command.Dispose();
            return account;
        }

        public override void Update(Account entity)
        {
            string updateSqlScript = $"update Account Set Password = {entity.Password} where Login = {entity.Login}";

            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = updateSqlScript;
                command.ExecuteNonQuery();
            }
        }
    }
}
