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
        //private static string _path = "C:\\MyTipDb";
        //private static string _path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase + "\\Models\\DbFiles";
        private static string _path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "") + "\\Models\\DbFiles";
        private static string _dbFilePath = _path + "\\MyTip.db";
        private static string _connectionString = $"Data Source=" + _dbFilePath;
        public RepoBase()
        {
            //string ff = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            //_path = System.IO.Path.GetDirectoryName(ff);
        }
        public static string GetQueryFromFile(string fileName)
        {
            return System.IO.File.ReadAllText(_path + "\\" + fileName);
        }

        /// <summary>
        /// Local DB 초기화 메서드
        /// </summary>
        private static void InitDbFile()
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

        protected List<ModelT> QueryList<ModelT>(string query, object args, bool isSqlFile)
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
                data = ctx.Query<ModelT>(query2, args).ToList();
            };
            return data;
        }

        protected ModelT QuerySingle<ModelT>(string query, object args, bool isSqlFile)
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
            ModelT data;
            using (SqliteConnection ctx = new SqliteConnection(_connectionString))
            {
                data = ctx.Query<ModelT>(query2, args).SingleOrDefault();
            };
            return data;
        }


        protected void Execute(Cud cud, string query, object model, bool isSqlFile)
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
                ctx.Execute(query2, GetParametersDisableParam(model, cud));
            };

        }

        protected static DynamicParameters GetParametersDisableParam(object model, Cud cud)
        {
            bool exsits;

            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (System.Reflection.PropertyInfo prop in model.GetType().GetProperties())
            {
                exsits = false;
                foreach (Attribute att in prop.GetCustomAttributes(true))
                {
                    if (att is DisableParamAttribute)
                    {
                        if (cud == Cud.Insert && ((DisableParamAttribute)att).Insert == true)
                        {
                            exsits = true;
                        }
                        if (cud == Cud.Update && ((DisableParamAttribute)att).Update == true)
                        {
                            exsits = true;
                        }
                        if (cud == Cud.Delete && ((DisableParamAttribute)att).Delete == true)
                        {
                            exsits = true;
                        }
                    }
                }
                if (exsits == false)
                {
                    dynamicParameters.Add(prop.Name, prop.GetValue(model));
                }
            }
            return dynamicParameters;
        }



        public static void InitLocalSqlite()
        {
            if (System.IO.File.Exists(_dbFilePath))
            {
                System.IO.File.Delete(_dbFilePath);
                InitDbFile();
            }
            else
            {
                InitDbFile();
            }
        }

        public static void CheckLocalSqliteAndCreate()
        {
            if (!System.IO.File.Exists(_dbFilePath))
            {
                InitDbFile();
            }
        }
    }
}
