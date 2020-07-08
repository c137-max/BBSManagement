using System;
using System.Data;
using 小型BBS管理系统.DataAccessLayer;

namespace 小型BBS管理系统.BusinessLogicLayer
{
    public class CommentManagement
    {
        
        public DataTable QueryComment(string post_id)
        {
            var sql = "SELECT comment, date, users.nickname " +
                            "FROM comments " +
                            "JOIN users " +
                            "on users.user_id=comments.user_id " +
                            $"where post_id={post_id} ";
            var db = new ConnectDatabase();
            var tb = db.GetDataSet(sql).Tables[0];
            return tb;
        }

        public bool DeleteComment(Users user, string user_id, string comment_id)
        {
            if (!user.isAdmin && user_id != user.userid)
            {
                return false; // 只能删除自己的文章
            }

            var sql = $"delete from comments where comment_id={comment_id}";
            var db = new ConnectDatabase();
            return db.UidExecuteNonQuery(sql) != -1;
        }

        public bool AddComment(Users user,string post_id, string content)
        {
            var date = DateTime.Now;
            var sql =
                $"INSERT INTO comments (post_id, user_id, comment, date) VALUES({post_id}, {user.userid}, '{content}', '{date}')";
            
            var db = new ConnectDatabase();
            return db.UidExecuteNonQuery(sql) != -1;
        }
    }
}