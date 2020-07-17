<%@ Page Title="帖子管理" Language="C#" MasterPageFile="AdminBase.master" CodeBehind="Post.aspx.cs" Inherits="小型BBS管理系统.Pages.AdminPages.PostManagement" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <div style="color: #0C0C0C">
        <asp:GridView ID="gvPost" CssClass="layui-table" runat="server" AllowSorting="True" OnRowUpdating="gvPost_RowUpdating" AutoGenerateColumns="False" OnRowCancelingEdit="gvPost_RowCancelingEdit" OnRowEditing="gvPost_RowEditing" DataKeyNames="post_id"  OnRowDeleting="gvPost_RowDeleting">
            <Columns>
                <asp:BoundField DataField="post_id" HeaderText="帖子ID" ReadOnly="True" SortExpression="post_id" />
                <asp:BoundField DataField="nickname" HeaderText="用户名" SortExpression="nickname" />
                <asp:BoundField DataField="post_content" HeaderText="文章内容" SortExpression="post_content" />
                <asp:BoundField DataField="post_title" HeaderText="文章标题" SortExpression="post_title" />
                <asp:BoundField DataField="post_date" HeaderText="发表日期" SortExpression="post_date" />
                <asp:CommandField ShowDeleteButton="True" HeaderText="删除" />
                <asp:CommandField ShowEditButton="True" HeaderText="编辑" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>