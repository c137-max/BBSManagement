using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using 小型BBS管理系统.BusinessLogicLayer;

namespace 小型BBS管理系统.Pages
{
    public partial class ChangeInfo : Page
    {
        private string _uId;
        private string _password;
        private Users _user;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _uId = Session["userID"].ToString();
            _password = Session["Password"].ToString();
            _user = new Users(_uId, _password);
            if (!IsPostBack)
            {
                
                lblNickName.Text = _uId;
                if (_user.Sex == "男")
                {
                    rbtBoy.Checked = true;
                }
                else
                {
                    rbGirl.Checked = true;
                }
            }
            
        }

        protected void SummitButton_OnClick(object sender, EventArgs e)
        {
            string newNickName = lblNickName.Text;
            if (newNickName.Replace(" ", "") == "")
            {
                lblMsg.Text = "用户名不能为空";
            }else{
                string sex = rbtBoy.Checked?"男":"女";
                string permissions = _user.isAdmin?"admin":"common";
                if (_user.UpdateInformation(newNickName, sex, permissions, _user.Userid))
                {
                    lblMsg.Text = "更新资料成功";
                    Session["userID"] = newNickName;
                    Label lblUserName = (Label) Master.FindControl("lblUser");
                    lblUserName.Text = newNickName;
                }
                else
                {
                    lblMsg.Text = "更新资料失败";
                }
                
            }
        }

        protected void BtnChangePassword(object sender, EventArgs e)
        {
            string lblPasswordText = lblPassword.Text;
            if (lblPasswordText != _user.Password)
            {
                lblMsg.Text = _user.UpdateUserPassword(_user.Userid, lblPasswordText) ? "更新密码成功" : "，更新密码失败";
                Session["Password"] = lblPasswordText;
            }
            else
            {
                lblMsg.Text = "新旧密码一致或者新密码为空";
            }
        }
    }
}