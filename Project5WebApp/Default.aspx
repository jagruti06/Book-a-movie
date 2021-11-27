<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project5WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

   <left><br>
      <h2> <asp:Label ID="Label2" runat="server" Text="Member Login"></asp:Label></h2>
    <asp:Button ID="mem_login_btn" runat="server" Text="Member Login" OnClick="Member_Handler" /><br>
    <asp:Label ID="encrypt_ans" runat="server" Text=" "></asp:Label><br>
     <h2> <asp:Label ID="Label1" runat="server" Text="Member Registration"></asp:Label></h2>
    <asp:Button ID="mem_reg_btn" runat="server" Text="Register" OnClick="MemReg_Handler" /><br>
    <asp:Label ID="Label4" runat="server" Text=" "></asp:Label></left><br><br><br>

    <left><br>
      <h2> <asp:Label ID="Label3" runat="server" Text="Staff Login"></asp:Label></h2>
    <asp:Button ID="staff_login_btn" runat="server" Text="Staff Login" OnClick="Staff_Handler" /><br>
    <asp:Label ID="decrypt_ans" runat="server" Text=" "></asp:Label><br />
        <h2> <asp:Label ID="Label5" runat="server" Text="Staff Registration"></asp:Label></h2>
    <asp:Button ID="staff_reg_btn" runat="server" Text="Staff Register" OnClick="StaffReg_Handler" /><br>
    </left><br><br><br>
    <h4>About the application</h4>
    <asp:Button ID="About" runat="server" Text="Learn More" OnClick="About_Handler" /><br>
</asp:Content>
