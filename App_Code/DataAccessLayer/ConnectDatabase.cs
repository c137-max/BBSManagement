using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//添加以下引用
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace 小型BBS管理系统.DataAccessLayer
{
    /// <summary>
    ///ConnectDatabase ，用于数据访问的类
    /// </summary>
    public class ConnectDatabase
    {
        /// <summary>
        /// 只读私有变量，数据库连接字符串变量。
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// 保护变量，数据库连接对象变量。
        /// </summary>
        private SqlConnection _sqlConnection;

        private SqlCommand _sqlCommand;
        private SqlDataReader _sqlDataReader;
        private DataSet _dataSet;
        private SqlDataAdapter _sqlDataAdapter;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public ConnectDatabase() //构造函数
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["_connectionString"].ConnectionString;
        }

        public ConnectDatabase(string pDbConString) //构造函数
        {
            this._connectionString = pDbConString;
        }

        /// <summary>
        /// 保护方法，打开数据库连接。
        /// </summary>
        private void ConOpen()
        {
            if (_sqlConnection == null)
                _sqlConnection = new SqlConnection(_connectionString);
            if (_sqlConnection.State.Equals(ConnectionState.Closed))
                _sqlConnection.Open();
        }

        public void ConClose() //关闭数据库连接
        {
            if (_sqlConnection == null) return;
            else
            {
                _sqlConnection.Close();
                _sqlConnection.Dispose();
                _sqlConnection = null;
            }
        }


        /// <summary>
        /// 公有方法，用于执行Sql语句(Update、Insert、Delete)，运行成功，返回影响到的行数，否则，返回-1。
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int UidExecuteNonQuery(string strSql)
        {
            var count = -1;
            this.ConOpen();
            try
            {
                _sqlCommand = new SqlCommand(strSql, _sqlConnection);
                count = _sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                count = -1;
            }
            finally
            {
                _sqlCommand.Dispose();
                _sqlCommand = null;
                ConClose();
            }

            return count;
        }

        /// <summary>
        /// 公有方法，用于执行带参数的存储过程或者Sql语句，返回影响到的行数，运行不成功，返回为-1。
        /// </summary>
        /// <param name="sqlCommand">Sql语句</param>
        /// <returns>int</returns>
        public int ExecuteNonQueryWithPara(SqlCommand sqlCommand)
        {
            var count = -1;
            ;
            this.ConOpen();
            try
            {
                _sqlCommand = sqlCommand;
                _sqlCommand.Connection = _sqlConnection;
                count = _sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                count = -1;
            }
            finally
            {
                _sqlCommand.Dispose();
                _sqlCommand = null;
                ConClose();
            }

            return count;
        }


        /// <summary>
        ///查询单个数据，执行SQL语句(Select）
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public object SExecuteScalar(string strSql)
        {
            object result = null;
            ConOpen();
            try
            {
                _sqlCommand = new SqlCommand(strSql, _sqlConnection);
                result = _sqlCommand.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                _sqlCommand.Dispose();
                _sqlCommand = null;
                ConClose();
            }

            return result;
        }

        /// <summary>
        /// 公有方法，返回一个SqlDataReader对象，用于获取表数据。
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>_sqlDataReader</returns>
        public SqlDataReader GetDataReader(string strSql)
        {
            ConOpen();
            _sqlCommand = new SqlCommand(strSql, _sqlConnection);
            this._sqlDataReader = _sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return this._sqlDataReader;
        }

        /// <summary>
        /// 公有方法，返回一个DataSet对象（查询结果集），用于获取表数据。
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string strSql)
        {
            ConOpen();
            _sqlDataAdapter = new SqlDataAdapter(strSql, _sqlConnection);
            _dataSet = new DataSet();
            _sqlDataAdapter.Fill(_dataSet);
            ConClose();
            return _dataSet;
        }
    }
}