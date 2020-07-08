using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages
{
    public partial class index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PostManagement p = new PostManagement();
            var tb = p.QueryAllPost();
            if (tb.Rows.Count == 0 )
            {
                var lblContent = new Label();
                lblContent.Text = "对不起，还没人发帖，快来发第一个帖子吧";
                pnlContent.Controls.Add(lblContent);
            }
            else
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    var lblContent = new Label();
                    lblContent.Text = "</br><div class='layui-card' style='margin:auto;width:99%;'>" + 
                                      $"<div class='layui-card-header'><a href='/Pages/Passage.aspx?id={tb.Rows[i]["post_id"]}'>{tb.Rows[i]["post_title"]}</a></div>" + 
                                      "<div class='layui-card-body'>"+ 
                                      $"时间: {tb.Rows[i]["post_date"]}&nbsp;&nbsp;&nbsp;&nbsp;作者：{tb.Rows[i][1]}" +
                                      "</div> </div></br>";
                    pnlContent.Controls.Add(lblContent);
                }
            }

        }
    }
}