using System;
using System.Web.UI;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages
{
    public partial class AdminBase : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else
            {
                try
                {
                    string userID = Session["userID"].ToString();
                    string password = Session["password"].ToString();
                    var user = new Users(userID, password);
                    if (!user.isAdmin)
                    {
                        Response.Redirect("../login.aspx");
                    }
                }
                catch (UserNotFound)
                {
                    Response.Redirect("../login.aspx");
                }
            }
        }
    }
}