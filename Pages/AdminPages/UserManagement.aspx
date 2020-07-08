<%@ Page Title="用户管理" Language="C#" MasterPageFile="AdminBase.master" CodeBehind="UserManagement.aspx.cs" Inherits="小型BBS管理系统.Pages.AdminPages.UserManagement" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <div style="color: #0C0C0C">
        <asp:GridView ID="gvUser" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="user_id" DataSourceID="SqlDataSource1" OnRowDeleting=" ">
            <Columns>
                <asp:BoundField DataField="user_id" HeaderText="user_id" ReadOnly="True" SortExpression="user_id" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:BoundField DataField="sex" HeaderText="sex" SortExpression="sex" />
                <asp:BoundField DataField="nickname" HeaderText="nickname" SortExpression="nickname" />
                <asp:BoundField DataField="permissions" HeaderText="permissions" SortExpression="permissions" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:_connectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
    </div>

</asp:Content>