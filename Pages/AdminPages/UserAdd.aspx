<%@ Page Title="添加用户" Language="C#" MasterPageFile="AdminBase.master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="小型BBS管理系统.Pages.UserAdd" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder">
    <div class="form">
        <div class="layui-form-item">
            <label class="layui-form-label">用户名</label>
            <div class="layui-input-block">
                <label>
                    <asp:TextBox placeholder="请输入用户名" runat="server" ID="lblUserID" CssClass="layui-input"> </asp:TextBox>
                </label>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">密码</label>
            <div class="layui-input-inline">
                <label>
                    <asp:TextBox TextMode="Password" placeholder="请输入密码" CssClass="layui-input" runat="server" ID="lblNickName"> </asp:TextBox>
                </label>
            </div>
            <div class="layui-form-mid layui-word-aux">密码应尽量复杂</div>
        </div>
        <br/>
        <div class="q">
            <label>是否为管理员：</label>
            <asp:CheckBox runat="server" ID="cbxIsAdmin"/>
        </div>
        <div class="q">
            <label>性&nbsp;&nbsp;&nbsp;别：</label>
            <asp:RadioButton GroupName="sex" runat="server" Checked="True" Text="男" />
            <asp:RadioButton GroupName="sex" runat="server" Text="女" />
        </div>
        <div class="layui-form-item">
            <div class="layui-input-block">
                <button class="layui-btn" lay-submit lay-filter="formDemo">立即提交</button>
                <button type="reset" class="layui-btn layui-btn-primary">重置</button>
            </div>
        </div>
    
        <%-- $1$ <label>用 户 名：</label><asp:TextBox runat="server" ID="lblUserID"></asp:TextBox> #1# --%>
        <%-- <label>昵 称：</label><asp:TextBox runat="server" ID="lblNickName"> </asp:TextBox><br/> --%>
        <%-- <label>密 码：</label><asp:TextBox runat="server" ID="lblPassWord"> </asp:TextBox><br/> --%>
        <%-- <label>性 别：</label><asp:TextBox runat="server" ID="lblSex"> </asp:TextBox><br/> --%>
        <%-- <label>是否为管理员：</label><asp:CheckBox runat="server" ID="cekIsAdmin"> </asp:CheckBox><br/> --%>
        <%-- <asp:Button runat="server" Text="提交"/> --%>
    </div >
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="StylePlaceHolder">
    <style>
        .q {
            color: #0C0C0C;
        }
        .form {
                    color: #0C0C0C;
                }
    </style>
</asp:Content> 
<asp:Content runat="server" ContentPlaceHolderID="JSPlaceHolder">
    <script>
        // layui.use('form', function(){
        //      var form = layui.form;
        // });
    </script>
</asp:Content>