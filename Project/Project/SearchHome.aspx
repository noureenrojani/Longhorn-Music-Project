<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="SearchHome.aspx.vb" Inherits="Project.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="searchhome">
    <asp:Label ID="Label1" runat="server" Text="Hi! Welcome to our search page. Please select the method that you would like to use to search."></asp:Label>
    <br />
    <br />
    <br />
    <br />

    <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="XX-Large" PostBackUrl="~/SearchSongs.aspx">Songs</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/SearchArtists.aspx" Font-Size="XX-Large">Artists</asp:LinkButton>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:LinkButton ID="LinkButton3" runat="server" Font-Size="XX-Large" PostBackUrl="~/SearchAlbums.aspx">Albums</asp:LinkButton>

</div>
</asp:Content>
