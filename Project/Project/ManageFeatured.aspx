<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ManageFeatured.aspx.vb" Inherits="Project.ManageFeatured" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="banner"> 
           <asp:Label ID="Label1" runat="server" Text="Manage the Featured Item"></asp:Label>
    </div>
    <div id="labels">
        <asp:Label ID="Label2" runat="server" Text="Artist" Height="21px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Height="21px" Text="Song"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Height="21px" Text="Album"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Height="21px" Text="Image URL"></asp:Label>
        <br />
        <br />
        <br />
    </div>
    <div id="right">
        <asp:TextBox ID="txtArtist" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtSong" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtAlbum" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtURL" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnFeatured" runat="server" Text="Update Featured Item" />
        <br />
    </div>
    <p>
        
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
</asp:Content>
