<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project5WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

   <left><br>
      <h2> <asp:Label ID="Label2" runat="server" Text="Encrypt service test"></asp:Label></h2>
       <h6> <asp:Label ID="Label1" runat="server" Text="Enter password - "></asp:Label></h6>
       <asp:TextBox ID="password_text" runat="server"></asp:TextBox>
    <asp:Button ID="encrypt_btn" runat="server" Text="Encrypt" OnClick="Encrypt_Handler" /><br>
    <asp:Label ID="encrypt_ans" runat="server" Text=" "></asp:Label></left><br><br><br>

    <left><br>
      <h2> <asp:Label ID="Label3" runat="server" Text="Decrypt service test"></asp:Label></h2>
       <h6> <asp:Label ID="Label4" runat="server" Text="Enter password - "></asp:Label></h6>
       <asp:TextBox ID="decrypt_text" runat="server"></asp:TextBox>
    <asp:Button ID="decrypt_btn" runat="server" Text="Decrypt" OnClick="Decrypt_Handler" /><br>
    <asp:Label ID="decrypt_ans" runat="server" Text=" "></asp:Label></left><br><br><br>
    <h4>About</h4><br />
    <h5>Send Invite service - takes input string for email id of the person who you want to invite and sends them an email with details of the movie</h5><br />
    <h5>Bank service - takes credit card details and transaction amount and returns if the card is valid and has sufficient balance for payment</h5><br />
</asp:Content>
