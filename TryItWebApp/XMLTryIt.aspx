<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XMLTryIt.aspx.cs" Inherits="TryItWebApp.XMLTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <left><br>
    <h2> <asp:Label ID="Label2" runat="server" Text="XML add user service test"></asp:Label></h2>
        <h6> <asp:Label ID="Label3" runat="server" Text="Enter username - "></asp:Label></h6>
        <asp:TextBox ID="username_text" runat="server"></asp:TextBox><br>
    <h6> <asp:Label ID="Label1" runat="server" Text="Enter password - "></asp:Label></h6>
    <asp:TextBox ID="password_text" runat="server"></asp:TextBox><br>
    <asp:Button ID="add_btn" runat="server" Text="Add user" OnClick="Add_Handler" /><br>
        <h6> <asp:Label ID="Label7" runat="server" Text="status"></asp:Label></h6><br />

    
        <left><br>
    <h2> <asp:Label ID="Label4" runat="server" Text="XML search user service test"></asp:Label></h2>
        <h6> <asp:Label ID="Label5" runat="server" Text="Enter username - "></asp:Label></h6>
        <asp:TextBox ID="uname_text" runat="server"></asp:TextBox>
    <h6> <asp:Label ID="Label6" runat="server" Text="Enter password - "></asp:Label></h6>
    <asp:TextBox ID="pwd_text" runat="server"></asp:TextBox><br>
    <asp:Button ID="search_btn" runat="server" Text="Search user" OnClick="Search_Handler" /><br>
        <h6> <asp:Label ID="Label8" runat="server" Text="status"></asp:Label></h6>
    <br />
    <h4>About</h4>
    <h5> XML service uses XML file to store user information</h5><br />
    
</asp:Content>
