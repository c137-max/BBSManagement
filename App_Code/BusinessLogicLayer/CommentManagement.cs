using System;
using 小型BBS管理系统.DataAccessLayer;

namespace 小型BBS管理系统.BusinessLogicLayer
{
    public class CommentManagement
    {
        
        public string[][] QueryAllComment(string post_id)
        {
            string[][] data = { };
            var sql = "SELECT * FROM comments";
            var db = new ConnectDatabase();
            var tb = db.GetDataSet(sql).Tables[0];
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                data[i][0] = tb.Rows[i][0].ToString();
                data[i][1] = tb.Rows[i][1].ToString();
                data[i][2] = tb.Rows[i][2].ToString();
                data[i][3] = tb.Rows[i][3].ToString();
            }
            return data;
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

        public bool AddComment(Users user,string post_id, string content, string title)
        {
            var date = DateTime.Now;
            var sql =
                $"INSERT INTO comments (comment_id, post_id, user_id, post_content, post_title, post_date) VALUES(null, {post_id}, {user.userid}, '{content}', '{title}', {date})";
            var db = new ConnectDatabase();
            return db.UidExecuteNonQuery(sql) != 1;
        }
    }
}