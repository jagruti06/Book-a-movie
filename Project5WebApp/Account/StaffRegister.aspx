<%@ Page Title="Member Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffRegister.aspx.cs" Inherits="Project5WebApp.StaffRegister" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <left><br>
      <h2> <asp:Label ID="Label2" runat="server" Text="Staff Register"></asp:Label></h2>
       <asp:TextBox ID="username" runat="server"></asp:TextBox><br /><br />
       <asp:TextBox ID="password" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="reg_btn" runat="server" Text="Register" OnClick="Register_Handler" /><br />
       <h6> <asp:Label ID="Label3" runat="server" Text=" "></asp:Label></h6><br>
    
     <h6> <asp:Label ID="Label1" runat="server" Text="Have an account? Please " ></asp:Label>
    <a href="https://www.w3schools.com">Login</a> </h6>

</asp:Content>