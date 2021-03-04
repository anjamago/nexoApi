using Microsoft.Extensions.Configuration;
using Nexos.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexos.Utilities
{
    public class HelperConnection
    {

        public static string GetConnectionSQL(IConfiguration configuration, bool isDevelopment = false)
        {
            var database = KeyVault.SQLDataBase;

            if (database.Contains("Server="))
            {
                return database;
            }

            var server = $"{KeyVault.SQLServer}";
            var user = KeyVault.SQLUser;
            var pwd = KeyVault.SQLPassword;

            return string.Format(
                "Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;Encrypt=False;Persist Security Info=True;",
                server,
                database,
                user,
                pwd);
        }
    }
}
