using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.Base
{
    public class RepoBase
    {
        private static string _path = "C:\\MyTipDb";
        private static string _dbFilePath = _path + "\\MyTip.db";
        private static string _connectionString = $"Data Source=" + _dbFilePath;
                
        public static string GetQueryFromFile(string fileName)
        {
            return System.IO.File.ReadAllText(_path + "\\" + fileName);
        }

        /// <summary>
        /// Local DB 초기화 메서드
        /// </summary>
        private static void InitLocalDB_SQLite()
        {
            //string connStr = "Data Source=" + Environment.CurrentDirectory + "\\Local.db";

            using SqliteConnection ctx = new SqliteConnection(_connectionString);
            string query;
            query = GetQueryFromFile("CreateTable.sql");
            ctx.Execute(query);
        }

        public static void InsertSeedData()
        {
            using SqliteConnection ctx = new SqliteConnection(_connectionString);
            string query;
            query = GetQueryFromFile("InsertSeedData.sql");
            ctx.Execute(query);
        }

        protected List<ModelT> Query<ModelT>(string query, bool isSqlFile = true)
        {
            string query2;
            if (isSqlFile == true)
            {
                query2 = GetQueryFromFile(query);
            }
            else
            {
                query2 = query;
            }
            List<ModelT> data;
            using (SqliteConnection ctx = new SqliteConnection(_connectionString))
            {
                data = ctx.Query<ModelT>(query2).ToList();
            };
            return data;
        }

        protected void Execute(string query, object model, bool isSqlFile = true)
        {
            string query2;
            if (isSqlFile == true)
            {
                query2 = GetQueryFromFile(query);
            }
            else
            {
                query2 = query;
            }
            using (SqliteConnection ctx = new SqliteConnection(_connectionString))
            {
                ctx.Execute(query2, model);
            };

        }




        public static void InitLocalSqlite()
        {
            if (System.IO.File.Exists(_dbFilePath))
            {
                System.IO.File.Delete(_dbFilePath);
                InitLocalDB_SQLite();
            }
            else
            {
                InitLocalDB_SQLite();
            }
        }

        public static void CheckLocalSqliteAndCreate()
        {
            if (!System.IO.File.Exists(_dbFilePath))
            {
                InitLocalDB_SQLite();
            }
        }
    }
}
