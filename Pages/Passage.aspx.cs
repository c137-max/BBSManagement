using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages
{
    public partial class Passage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                string userID, password;
                userID = Session["userID"].ToString();
                password = Session["password"].ToString();
                try
                {
                    Users u = new Users(userID, password);
                    buttonSummit.Text = "提交";
                    buttonSummit.Enabled = true;
                }
                catch (UserNotFound)
                {
                    // Session.Abandon();
                }
            }

            string PageID = Request.QueryString["id"];
            PostManagement p = new PostManagement();
            var dr = p.QueryOnePost(PageID);
            while (dr.Read())
            {
                setTitle.Text = dr[1].ToString();
                setContent.Text = dr[0].ToString();
                setAuthor.Text = dr[3].ToString();
                setDate.Text = dr[2].ToString();
            }

            CommentManagement c = new CommentManagement();
            DataTable tb = c.QueryComment(PageID);
            if (tb.Rows.Count != 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    var lblComment = new Label();
                    var lblDetail = new Label();
                    lblDetail.CssClass = "layui-card-header";
                    lblDetail.Text = $"作者:{tb.Rows[i]["nickname"]}&nbsp;&nbsp;&nbsp;时间:{tb.Rows[i]["date"]}</br>";
                    lblComment.CssClass = "layui-card-body";
                    lblComment.Text = tb.Rows[i]["comment"].ToString()+"</br></br><hr/>";
                    setComments.Controls.Add(lblDetail);
                    setComments.Controls.Add(lblComment);
                }
            }
            else
            {
                var lblComment = new Label();
                lblComment.CssClass = "layui-card-body";
                lblComment.Text = "还没人评论这篇文章，快来做发布第一条评论吧";
                setComments.Controls.Add(lblComment);
            }
        }

        protected void buttonSummit_Click(object sender, EventArgs e)
        {
            string userID, password;
            userID = Session["userID"].ToString();
            password = Session["password"].ToString();
            try
            {
                Users u = new Users(userID, password);
                CommentManagement c = new CommentManagement();
                string post_id = Request.QueryString["id"];
                string comment = txbInputComment.Text;
                if (!c.AddComment(u, post_id, comment))
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "对不起, 服务器发生异常，暂时不能处理您的请求";
                }
                Response.Redirect($"Passage.aspx?id={post_id}");
            }
            catch (UserNotFound)
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
        }
    }
}