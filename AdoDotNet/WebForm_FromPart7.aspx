<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_FromPart7.aspx.cs" Inherits="WebApplication1.WebForm_Part7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="border: 1px solid black; font-family: Arial">
                <tr>
                    <td>Employee Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Salary
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" />
                    </td>

                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        Part 8, Sql DataReader<br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        Part 9,Sql DataReader NextResult<br />
        <asp:GridView ID="ProductsGridView" runat="server">
        </asp:GridView>
        <br />
        <asp:GridView ID="CategoriesGridView" runat="server">
        </asp:GridView>
        <br />
        <br />
        Part 10, SqlDataAdapter<br />
        <asp:GridView ID="gridViewProduct" runat="server">
        </asp:GridView>
        <br />
        <asp:GridView ID="gridViewProductsp" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        Part 11, DataSet<br />
        <asp:GridView ID="GridViewProducts" runat="server">
        </asp:GridView>
        <br />
        <asp:GridView ID="GridViewCategories" runat="server">
        </asp:GridView>
        <br />
        Part 12, Cache Dataset<br />
        <br />
        <asp:Button ID="btnLoadData" runat="server" OnClick="btnLoadData_Click" Text="LoadData" />
&nbsp;&nbsp;
        <asp:Button ID="btnClearData" runat="server" OnClick="btnClearData_Click" Text="ClearData" />
        <br />
        <asp:GridView ID="gridViewProductsCache" runat="server">
        </asp:GridView>
        <asp:Label ID="lblMessageCache" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
    </form>
</body>
</html>
