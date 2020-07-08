using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages.AdminPages
{
    public partial class UserManagement : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userID = Session["userID"].ToString();
            string password = Session["password"].ToString();
            Users user = new Users(userID, password);
            string deleteUserID = gvUser.DataKeys[e.RowIndex].Value.ToString();
            if (user.deleteUser(deleteUserID)) {
                Response.Redirect("UserManagement.aspx");
            }
        }
    }
   
}