<%@ Page Title="Member Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetTheatres.aspx.cs" Inherits="Project5WebApp.GetTheatres" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <left>
    <br /> <br /> <br /> <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" BackColor="White" Text="Valid movies - Encanto, House of Gucci, GhostBusters: Afterlife"></asp:Label><br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" BackColor="White" Text="Please Enter the Movie name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Label ID="Label1" runat="server" BackColor="White" Text="Application Start Time"></asp:Label><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label8" runat="server" Visible="false" BackColor="White" Text="Please Enter Movie Name Again:"></asp:Label>
    <br />
    <asp:TextBox ID="movieName" runat="server" Width="202px"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go" Width="110px" />
    <br />
        
    <table visible="false" width="30%" ID="TheatreTable" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
        <tr align="center" style="background-color:#004080;color:White;">
            <td>Cinemas</td>
        </tr>

        <%=getListOfTheatres()%>

          </table>

        <br />
    <br />
    <br />

            



        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" BackColor="White" Text="Please Enter Theatre name:"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="theatreName" runat="server"  Width="202px"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Visible="false" OnClick="Button2_Click" Text="Go" Width="110px" />

            <br />
        <table visible="false" width="30%" ID="SlotTable" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
        <tr align="center" style="background-color:#004080;color:White;">
            <td>ShowTimes</td>
        </tr>

        <%=getListOfShows()%>

          </table>
        <br /><br /><br />



    <asp:Label ID="Label7" runat="server" Visible="false" BackColor="White" Text="Please Enter Show Time:"></asp:Label>
    <asp:TextBox ID="TimeSlot" runat="server" Visible="false" Width="202px"></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Visible="false" OnClick="Button3_Click" Text="Submit" Width="110px" />



        </left>
    
</asp:Content>