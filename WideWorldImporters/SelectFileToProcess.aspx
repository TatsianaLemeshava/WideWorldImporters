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
       <a href="Default.aspx">Go Back To Home Page</a>
</asp:Content> 
