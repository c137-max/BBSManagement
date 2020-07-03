<%@ Page Title="添加用户" Language="C#" MasterPageFile="AdminBase.master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="小型BBS管理系统.Pages.UserAdd" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder">
    <div id="q">
    <%-- <label>用 户 名：</label><asp:TextBox runat="server" ID="lblUserID"></asp:TextBox> --%>
    <label>昵   称：</label><asp:TextBox runat="server" ID="lblNickName"> </asp:TextBox><br/>
    <label>密   码：</label><asp:TextBox runat="server" ID="lblPassWord"> </asp:TextBox><br/>
    <label>性   别：</label><asp:TextBox runat="server" ID="lblSex"> </asp:TextBox><br/>
    <label>是否为管理员：</label><asp:CheckBox runat="server" ID="cekIsAdmin"> </asp:CheckBox><br/>
    <asp:Button runat="server" Text="提交"/>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="StylePlaceHolder">
    <style>
        #q {
            color: #0C0C0C;
        }
    </style>
</asp:Content>