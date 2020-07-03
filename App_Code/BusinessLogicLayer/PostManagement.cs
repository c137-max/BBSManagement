using System;
using System.Data;
using 小型BBS管理系统.DataAccessLayer;

namespace 小型BBS管理系统.BusinessLogicLayer
{
    public class PostManagement
    {

        public PostManagement()
        {
        }

        public DataTable QueryAllPost()
        {
            var sql = 
                "SELECT post.post_id, users.nickname, post.post_content, post.post_title, post.post_date  FROM post join users on users.user_id = post.user_id";
            Console.Out.Write(sql);
            var db = new ConnectDatabase();
            var tb = db.GetDataSet(sql).Tables[0];
            return tb;
        }

        public bool DeletePost(Users user, string user_id, string post_id)
        {
            if (!user.isAdmin && user_id != user.userid)
            {
                return false; // 只能删除自己的文章
            }
            var sql = $"delete from post where post_id={post_id}";
            var db = new ConnectDatabase();
            return db.UidExecuteNonQuery(sql) != -1;
        }

        public bool AddPost(Users user, string content, string title)
        {
            var date = DateTime.Now;
            var sql =
                $"INSERT INTO POST (post_id, user_id, post_content, post_title, post_date) VALUES(null, {user.userid}, '{content}', '{title}', {date})";
            var db = new ConnectDatabase();
            return db.UidExecuteNonQuery(sql) != 1;
        }

        public string[] QueryOnePost(string post_id)
        {
            string[] result = { };
            var sql = $"SELECT * FROM comments where post_id={post_id}";
            var db = new ConnectDatabase();
            var rd = db.GetDataReader(sql);
            result[0] = rd.GetString(0);
            result[1] = rd.GetString(1);
            result[2] = rd.GetString(2);
            result[3] = rd.GetString(3);
            result[4] = rd.GetString(4);
            return result;
        }
    }
}