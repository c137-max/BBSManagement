<%@ Page Title="小型BBS登录页面" Language="C#" MasterPageFile="BasePage.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="小型BBS管理系统.Pages.login" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder">
    <div id="c">
        <label>用户名 </label><asp:TextBox runat="server" ID="txbUserID"> </asp:TextBox><br/>
        <label>密  码 </label><asp:TextBox TextMode="Password" runat="server" ID="txbPassword"> </asp:TextBox><br/>
        <asp:Label runat="server" ID="lblMsg"> </asp:Label>
        <asp:Button runat="server" CssClass="layui-btn" ID="botCommit" OnClick="botCommit_Click" Text="提交登录"/>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="StylePlaceHolder">
    <style>
    #c {
            margin: auto;
            text-align: center;
            height: 300px;
    }
    </style>
</asp:Content>