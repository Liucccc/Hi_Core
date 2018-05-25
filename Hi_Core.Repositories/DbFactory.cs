using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Repositories
{
    /// <summary>
    /// 数据库工厂
    /// </summary>
    public class DbFactory
    {
        /// <summary>
        /// SqlSugarClient属性
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetSqlSugarClient()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString, //必填
                DbType = DbType.MySql, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.SystemTable//默认SystemTable
            }); 
            return db;
        }
    }
}
