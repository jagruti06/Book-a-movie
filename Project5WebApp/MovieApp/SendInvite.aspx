<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendInvite.aspx.cs" Inherits="Project5WebApp.SendInvite" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <left><br>
      <h2> <asp:Label ID="Label2" runat="server" Text="Send invite"></asp:Label></h2>
       <h6> <asp:Label ID="Label1" runat="server" Text="Enter email id of the person you want to send invite "></asp:Label>
           <asp:Label ID="details" runat="server" Text=" "></asp:Label>
       </h6>
       <asp:TextBox ID="send_invite_text" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="invite_btn" runat="server" Text="Send Invite" OnClick="SendInvite_Handler" /><br>
    <asp:Label ID="invite_ans" runat="server" Text=" "></asp:Label></left><br><br><br>
</asp:Content>
