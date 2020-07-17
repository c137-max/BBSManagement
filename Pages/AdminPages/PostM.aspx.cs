using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages.AdminPages
{
    public partial class PostM : Page
    {
        private string uID;
        private string password;
        PostManagement p;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["userID"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            uID = Session["userID"].ToString();
            password = Session["Password"].ToString();
            try
            {
                new Users(uID, password);
            }
            catch (UserNotFound)
            {
                Response.Redirect("../login.aspx");
            }
           
            if(!IsPostBack) {
                Bind();
            }
            p = new PostManagement();
        }
         protected void gvPost_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string PostId = gvPost.DataKeys[e.RowIndex].Value.ToString();
            if (p.DeletePost(PostId)) {
                Response.Redirect("PostM.aspx");
            }
        }
         
        
        private void  Bind()
        {
            uID = Session["userID"].ToString();
            password = Session["Password"].ToString();
            Users user = new Users(uID, password);
            PostManagement p = new PostManagement();
            gvPost.DataSource = p.QueryAllPost();
            gvPost.DataBind();
        }
    }
}