<%@ Page Title="Member Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="Project5WebApp.MemberLogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <left><br>
      <h2> <asp:Label ID="Label2" runat="server" Text="Member Login"></asp:Label></h2>
       <asp:TextBox ID="username" runat="server"></asp:TextBox><br /><br />
       <asp:TextBox ID="password" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="login_btn" runat="server" Text="Login" OnClick="Login_Handler" /><br>
    <h6> <asp:Label ID="Label3" runat="server" Text=" "></asp:Label></h6><br />
     <h6> <asp:Label ID="Label1" runat="server" Text="New User? Please " ></asp:Label>
    <a href="https://www.w3schools.com">Register</a> </h6>

</asp:Content>