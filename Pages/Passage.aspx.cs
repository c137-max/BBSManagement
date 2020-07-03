using System;
using System.Web.UI;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages
{
    public partial class Passage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string p_id = Request.QueryString["id"];
            
        }
    }
}