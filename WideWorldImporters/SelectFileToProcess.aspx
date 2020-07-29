<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectFileToProcess.aspx.cs" Inherits="WideWorldImporters.SelectFileToProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Choose a file for process</h2>
        <asp:FileUpload ID="fileread" runat="server" />
        <br/>
        <br/>
        <asp:Button ID="upload" Text="Process" runat="server" Width="73px" onclick="upload_Click" />
        <br/>
        <br/>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    </div>
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
        <asp:Label ID="Label2" runat="server" EnableViewState="False"></asp:Label><br />
        <p />

       <a href="Default.aspx">Go Back To Home Page</a>
</asp:Content> 
