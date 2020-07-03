using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using 小型BBS管理系统.BusinessLogicLayer;
    

namespace 小型BBS管理系统.Pages
{
    public partial class BasePage : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userID, password;
            Label lblUserName = (Label) this.FindControl("lblUser"); 
            if (Session["userID"] != null)
            {
                userID = Session["userID"].ToString();
                password = Session["password"].ToString();
                try
                {
                    if (userID == "")
                    {
                        throw new UserNotFound("session已被清除");
                    }
                    var user = new Users(userID, password);
                    var lblAdmin = this.FindControl("lblAdmin");
                    if (user.isAdmin)
                    {
                        lblAdmin.Visible = true;
                    }
                    lblUserName.Text = user._nickname;
                    Label lblIsLogin = (Label) this.FindControl("lblIsLogin");
                    lblIsLogin.Visible = true;
                }
                catch (UserNotFound)
                {
                }


            }
        }

        protected void Logout(object sender, EventArgs e)
        {
        }
    }
}