using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCodeGenerate
{
    /// <summary>
    /// 数据库连接工厂类
    /// </summary>
    public class ConnectionFactory
    {
        public static IDbConnection CreateConnection(string dbtype, string strConn)
        {
            if (string.IsNullOrWhiteSpace(dbtype))
                throw new ArgumentNullException("dbtype缺啦");
            if (string.IsNullOrWhiteSpace(strConn))
                throw new ArgumentNullException("strConn缺啦");
            var dbType = GetDataBaseType(dbtype);
            return CreateConnection(dbtype, strConn);
        }

        public static string GetDataBaseType(string dbtype)
        {
            return string.Empty;
        }
        public enum DatabaseType
        {
            Sqlserver = 1,
            MySQL = 2,
            PostgreSQL = 3
        }

        public static IDbConnection CreateConnection(DatabaseType dbType, string strConn)
        {
            IDbConnection connection = null;
            if (string.IsNullOrWhiteSpace(strConn))
                throw new ArgumentNullException("strConn缺啦");
            switch (dbType)
            {
                case DatabaseType.Sqlserver:
                    connection = "";
                    break;
                case DatabaseType.MySQL:
                    connection = "";
                    break;
                case DatabaseType.PostgreSQL:
                    connection = "";
                    break;
                default:
                    throw new ArgumentNullException("暂不支持");
            }
            if(connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
