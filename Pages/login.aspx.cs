using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages
{
    public partial class login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Label lblUserName = (Label) Master.FindControl("lblUser");
                Label lblIsLogin = (Label) Master.FindControl("lblIsLogin");
                lblUserName.Text = "请登录";
                lblIsLogin.Visible = false;
                Session.Abandon();
            }
            
            
        }

        protected void botCommit_Click(object sender, EventArgs e)
        {
            string userID = txbUserID.Text;
            string password = txbPassword.Text;
            try
            {
                var users = new Users(userID, password);
                Session["userID"] = users.userid;
                Session["password"] = users.password;
                Response.Redirect("/Pages/index.aspx");
            }
            catch (UserNotFound)
            {
                lblMsg.Text = "用户名或密码错误";
            }

        }
    }
}