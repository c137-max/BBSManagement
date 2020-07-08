using System;
using System.Web.UI;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages
{
    public partial class PostMsg : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void BtnSummitClick(object sender, EventArgs e)
        {
            string userID = Session["userID"].ToString();
            string password = Session["password"].ToString();
            Users user = new Users(userID, password);
            string title = txbTitle.Text;
            string content = txbContent.Text;
            PostManagement p = new PostManagement();
            if (!p.AddPost(user, content, title))
            {
                lblStatus.Text = "对不起，服务器异常，暂时无法处理您的请求";
                lblStatus.Visible = true;
            }
            else
            {
                lblStatus.Text = "发布成功";
                lblStatus.Visible = true;
            }
        }
    }
}