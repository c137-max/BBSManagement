<%@ Page Title="详情" Language="C#" MasterPageFile="BasePage.master" AutoEventWireup="true" CodeBehind="Passage.aspx.cs" Inherits="小型BBS管理系统.Pages.Passage" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder">
        <label>楼主：</label><br/>
    <div class="layui-card">
        <b><asp:Label class="layui-card-header" runat="server" ID="setTitle" CssClass="layui-card-header">标题</asp:Label></b>
        <asp:Label class="layui-card-header" runat="server" ID="setAuthor" CssClass="layui-card-header">作者</asp:Label>
        <asp:Label class="layui-card-header" runat="server" ID="setDate" CssClass="layui-card-header">日期</asp:Label>
        <br/>
        <asp:Label runat="server" ID="setContent" CssClass="layui-card-body">内容</asp:Label>
    </div>
    <label>评论：</label><br/>
    <asp:Panel runat="server" ID="setComments" CssClass="layui-card">
    </asp:Panel>
    <div class="layui-form-item">
        <asp:TextBox TextMode="MultiLine" runat="server" ID="txbInputComment" lay-verify="required" placeholder="请输入您的评论" CssClass="layui-textarea"> </asp:TextBox>
        <br/>
        <asp:Label runat="server" ID="lblStatus" Visible="False"> </asp:Label>
        <div style="text-align: center">
            <asp:Button ID="buttonSummit" runat="server" CssClass="layui-btn" Text="请登录后再评论" Enabled="False" OnClick="buttonSummit_Click"/>
        </div>
    </div>

</asp:Content>