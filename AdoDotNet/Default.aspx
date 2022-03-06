<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            Grid by using Web Config</div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                    <asp:BoundField DataField="salary" HeaderText="salary" SortExpression="salary" />
                </Columns>
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SampleDBConnectionString %>" SelectCommand="SELECT * FROM [tblEmployee]"></asp:SqlDataSource>
        <br />
        <br />
        Grid by giving the connection string&nbsp; in the Page - Part 1<br />
        <asp:GridView ID="grdEmployee" runat="server">
        </asp:GridView>
        <br />
        Part 2 - Using Statement<br />
        <asp:GridView ID="grdPerson" runat="server">
        </asp:GridView>
        <br />
        Part 3 - Reading connection string from Web.config<br />
        <asp:GridView ID="grdEmployeeConfig" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
