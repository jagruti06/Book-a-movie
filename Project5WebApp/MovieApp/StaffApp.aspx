<%@ Page Title="Staff Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffApp.aspx.cs" Inherits="Project5WebApp.StaffApp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <h3><asp:Label ID="Label8" runat="server" Text="Cuurent users registered to Movie Invite App"></asp:Label></h3>
    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td> Usernames </td>                        
        </tr>

        <%=getCreditCardsTable()%>

    </table>
</asp:Content>
