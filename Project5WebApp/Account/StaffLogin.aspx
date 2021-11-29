<%@ Page Title="Staff Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="Project5WebApp.StaffLogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <left>
    <br />
    <br />
&nbsp;
    <asp:Label ID="users_label" runat="server" Text=" Users"></asp:Label>
    <br>
      <h2> <asp:Label ID="Label2" runat="server" Text="Staff Login"></asp:Label></h2>
       <h4> <asp:Label ID="Label4" runat="server" Text="You are not authorized to view this page" Visible="false"></asp:Label></h4>
       <asp:TextBox ID="username" runat="server" Visible ="false"></asp:TextBox><br /><br />
       <asp:TextBox ID="password" runat="server" Visible ="false"></asp:TextBox><br /><br />
    <asp:Button ID="login_btn" runat="server" Text="Login" OnClick="Login_Handler" Visible ="false" /><br>
    <h6> <asp:Label ID="Label3" runat="server" Text=" "></asp:Label></h6><br />
       


</asp:Content>