<%@ Page Title="Member Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffRegister.aspx.cs" Inherits="Project5WebApp.StaffRegister" %>

<%@ Register src="../ImageVerifierUserControl.ascx" tagname="ImageVerifierUserControl" tagprefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <left><br>
      <h2> <asp:Label ID="Label2" runat="server" Text="Staff Register"></asp:Label></h2>
       <asp:TextBox ID="username" runat="server"></asp:TextBox><br /><br />
       <asp:TextBox ID="password" runat="server"></asp:TextBox><br /><br />

       &nbsp;&nbsp;&nbsp; Please enter the text present in the below image in the textbox :<asp:TextBox ID="verifierText" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="image_label" runat="server" Text=" "></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;
    <uc1:ImageVerifierUserControl ID="ImageVerifierUserControl1" runat="server" />
    <br /><br />

    <asp:Button ID="reg_btn" runat="server" Text="Register" OnClick="Register_Handler" /><br />
       <h6> <asp:Label ID="Label3" runat="server" Text=" "></asp:Label></h6><br>
    


</asp:Content>