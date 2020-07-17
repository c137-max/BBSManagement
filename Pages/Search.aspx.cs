using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages
{
    public partial class Search : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Summit(object sender, EventArgs e)
        {
            PostManagement p = new PostManagement();
            DataTable tb = p.SearchPostAndComment(txbContent.Text);
            if (tb.Rows.Count == 0 )
            {
                var lblContent = new Label();
                lblContent.Text = "对不起，检索不到任何内容，请换一个关键词";
                pnlSearchResult.Controls.Add(lblContent);
            }else
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    string ContentType = tb.Rows[i]["type"] == "POST" ? "用户文章" : "用户评论";
                    var lblContent = new Label();
                    lblContent.Text = "<div class='layui-card' style='margin:auto;width:99%;'>" + 
                                      $"<div class='layui-card-header'>文章：<a href='/Pages/Passage.aspx?id={tb.Rows[i]["post_id"]}'>{tb.Rows[i]["post_title"]}" +
                                      $"&nbsp;内容类型：{ContentType}&nbsp;&nbsp;&nbsp;发表时间：{tb.Rows[i]["date"]}</a></div>" + 
                                      "<div class='layui-card-body'>"+ 
                                      $"内容: {tb.Rows[i]["content"]}" +
                                      "</div> </div></br>";
                    pnlSearchResult.Controls.Add(lblContent);
                }
            }
        }
    }
}