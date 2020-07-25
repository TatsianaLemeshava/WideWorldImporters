<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="GetStockItems.aspx.cs" Inherits="WideWorldImporters.GetStockItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Show Stock Items</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="ddlStockItemName" runat="server"></asp:DropDownList>

    <br/>
    <h2>StockItem:</h2>
        <a>StockItems count</a>
        <asp:Label ID="lblStockItemsCount" runat="server" Text=""></asp:Label>
        <asp:Table ID="tblStoskItem" runat="server">
            <asp:TableRow>
                <asp:TableCell>Stock Item Name</asp:TableCell>
                <asp:TableCell>Supplier Name</asp:TableCell>
                <asp:TableCell>Package Type</asp:TableCell>
                <asp:TableCell>Unit Price</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />
        <asp:Label ID="Label1" runat="server" EnableViewState="False"></asp:Label><br />
        <p />

        <a href="Default.aspx">Go Back To Home Page</a>

</asp:Content>
