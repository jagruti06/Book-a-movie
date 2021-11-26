<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <left><br>
      <h2> <asp:Label ID="Label2" runat="server" Text="Send invite service test"></asp:Label></h2>
       <h6> <asp:Label ID="Label1" runat="server" Text="Enter email id of the person you want to send invite to - "></asp:Label></h6>
       <asp:TextBox ID="send_invite_text" runat="server"></asp:TextBox>
    <asp:Button ID="invite_btn" runat="server" Text="Send Invite" OnClick="SendInvite_Handler" /><br>
    <asp:Label ID="invite_ans" runat="server" Text=" "></asp:Label></left><br><br><br>

    <h4>About</h4><br />
    <h5>Send Invite service - takes input string for email id of the person who you want to invite and sends them an email with details of the movie</h5><br />

</asp:Content>