<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Homepage.aspx.vb" Inherits="Project.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblEmail" runat="server" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblFeatured" runat="server"></asp:Label>
        <br />
    <br />
        <br />
        <br />
        <asp:Image ID="FeatImage" runat="server" />
        <br />
</asp:Content>
