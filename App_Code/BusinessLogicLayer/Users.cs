using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//添加以下引用
using System.Data;
using System.Data.SqlClient;
using 小型BBS管理系统.DataAccessLayer; //引用数据访问层

namespace 小型BBS管理系统.BusinessLogicLayer
{
    /// <summary>
    ///users 用户管理类
    /// </summary>
    public class Users
    {
        #region 私有成员

        public string userid; //用户名
        public string password; //用户密码
        public string sex; //性别
        public string _nickname; //用户密码
        private string _permissions; //用户密码
        public bool isAdmin; //是否是管理员

        #endregion 私有成员

        public Users(string userid, string password)
        {
            if (QueryUser(userid, password))
            {
                this.userid = userid.Replace(" ", "");
                this.password = password.Replace(" ", "");
            }
            else
            {
                throw new UserNotFound("用户不存在或者密码错误");
            }
        }


        public Users(string nickname, string password, string sex)
        {
            if (Registered(nickname, password, sex, "common"))
            {
                this._nickname = nickname.Replace(" ", "");
                this.password = password.Replace(" ", "");
                this.sex = sex.Replace(" ", "");
                this.isAdmin = false;
            }
        }

        #region 方法

        /// <summary>
        /// 查询用户是否存在，或者是否密码正确
        /// </summary>
        private bool QueryUser(string name, string password)
        {
            bool ret;
            var db = new ConnectDatabase(); //实例化一个ConnectDatabase类
            var sql =
                string.Format($"select * from users where nickname='{name}' AND password='{password}'");
            var dr = db.GetDataReader(sql);
            if (dr.HasRows)
            {
                dr.Read();
                this.isAdmin = dr["permissions"].ToString().Replace(" ", "") == "admin";
                Console.Out.Write(this.isAdmin + "  " + dr["permissions"]);
                this._nickname = dr["nickname"].ToString().Replace(" ", "");
                this.sex = dr["sex"].ToString().Replace(" ", "");
                this._permissions = dr["permissions"].ToString().Replace(" ", "");
                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        protected bool Registered(string nickname, string password, string sex, string permisson)
        {
            var db = new ConnectDatabase();
            var sql = string.Format(
                $"Insert into user (user_id, nickname, password, sex, permissions) values (null, '{nickname}', '{password}', '{sex}', {permisson})");
            return db.UidExecuteNonQuery(sql) != -1;
        }

        ///<summary>
        /// users表用户密码重置（根据给定用户名修改该用户密码）,更新成功，返回非-1
        /// </summary>
        /// <param name="strUserName, strNewPassword"></param>
        /// <return></return>
        public int UpdateUserPassword(string strUserName, string NewPassword)
        {
            if (!isAdmin)
            {
                strUserName = this.userid; //不是管理员不能改其他人的名字
            }

            var updateDb = new ConnectDatabase();
            var sql = string.Format($"update users set password='{NewPassword}' where username='{strUserName}'");
            return updateDb.UidExecuteNonQuery(sql);
        }

        ///<summary>
        /// 更新用户资料
        /// </summary>
        /// <param name="strUserName, strNewPassword"></param>
        /// <return></return>
        public int UpdateInformation(string userid, string nickname, string sex)
        {
            var updatedb = new ConnectDatabase();
            if (!this.isAdmin) // 不是管理员不能改别人的密码
                userid = this.userid;
            var sql = string.Format($"update user set nickname={nickname}, sex={sex} where user_id={userid}");
            return updatedb.UidExecuteNonQuery(sql);
        }

        public DataTable QueryAllUsers()
        {
            var sql = "SELECT * FROM users";
                Console.Out.Write(sql);
            var db = new ConnectDatabase();
            var tb = db.GetDataSet(sql).Tables[0];
            return tb;
        }
        /// <summary>
        /// 删除users表中给定的用户名记录,删除成功，返回非-1
        /// </summary>
        /// <param name="strUsername"></param>
        /// <return></return>
        public bool deleteUser(string strUsername)
        {
            if (!isAdmin)
                strUsername = this.userid;
            ConnectDatabase delete = new ConnectDatabase();
            string sql = string.Format($"delete from users  where user_id='{strUsername}'");
            return delete.UidExecuteNonQuery(sql) != -1;
        }

        #endregion 方法
    }

    public class UserNotFound : Exception
    {
        public UserNotFound(string message) : base(message)
        {
        }
    }
}