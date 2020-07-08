<%@ Page Title="Title" Language="C#" MasterPageFile="BasePage.master" AutoEventWireup="true" CodeBehind="PostMsg.aspx.cs" Inherits="小型BBS管理系统.Pages.PostMsg" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder">
      <div class="layui-form-item">
        <label class="layui-form-label">标题</label>
        <div class="layui-input-block">
          <asp:TextBox runat="server" ID="txbTitle"  lay-verify="required" placeholder="请输入标题" autocomplete="off" CssClass="layui-input" > </asp:TextBox>
        </div>
      </div>
  <div class="layui-form-item layui-form-text">
        <label class="layui-form-label">内容</label>
        <div class="layui-input-block">
          <asp:TextBox TextMode="MultiLine" ID="txbContent" runat="server" name="desc" placeholder="请输入内容" CssClass="layui-textarea"> </asp:TextBox>
        </div>
      </div>
      <asp:Label runat="server" ID="lblStatus" Visible="False"> </asp:Label>
      <div class="layui-form-item">
        <div class="layui-input-block">
          <asp:Button runat="server" ID="btnSummit" OnClick="BtnSummitClick" Text="立即提交" CssClass="layui-btn" lay-filter="formDemo"/>
          <button type="reset" class="layui-btn layui-btn-primary">重置</button>
        </div>
      </div>
</asp:Content>