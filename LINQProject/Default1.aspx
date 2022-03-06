<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="LINQProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SampleDBConnectionString1 %>" DeleteCommand="DELETE FROM [tblPerson] WHERE [Id] = @Id" InsertCommand="INSERT INTO [tblPerson] ([Id], [Name], [Email], [GenderId], [Age]) VALUES (@Id, @Name, @Email, @GenderId, @Age)" ProviderName="<%$ ConnectionStrings:SampleDBConnectionString1.ProviderName %>" SelectCommand="SELECT [Id], [Name], [Email], [GenderId], [Age] FROM [tblPerson]" UpdateCommand="UPDATE [tblPerson] SET [Name] = @Name, [Email] = @Email, [GenderId] = @GenderId, [Age] = @Age WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="GenderId" Type="Int32" />
                <asp:Parameter Name="Age" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="GenderId" Type="Int32" />
                <asp:Parameter Name="Age" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
