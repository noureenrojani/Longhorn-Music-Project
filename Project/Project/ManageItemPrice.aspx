<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ManageItemPrice.aspx.vb" Inherits="Project.ManageItemPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Disable Discounts or Change Regular/Discount Price Here"></asp:Label>
    <br />
    <asp:GridView ID="gvSongs" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="Song" HeaderText="Song" ReadOnly="True" SortExpression="Song" />
            <asp:BoundField DataField="Artist" HeaderText="Artist" ReadOnly="True" SortExpression="Artist" />
            <asp:BoundField DataField="Album" HeaderText="Album" ReadOnly="True" SortExpression="Album" />
            <asp:BoundField DataField="PriceRegular" HeaderText="PriceRegular" ReadOnly="True" SortExpression="PriceRegular" />
            <asp:BoundField DataField="PriceDiscount" HeaderText="PriceDiscount" ReadOnly="True" SortExpression="PriceDiscount" />
            <asp:BoundField DataField="EnableDiscount" HeaderText="EnableDiscount" ReadOnly="True" SortExpression="EnableDiscount" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_20152_Team14ConnectionString %>" SelectCommand="SELECT [Song], [Artist], [PriceRegular], [PriceDiscount], [Album], [EnableDiscount] FROM [tblSong] ORDER BY [Song], [Artist], [Album]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_20152_Team14ConnectionString %>" SelectCommand="SELECT [Song], [Artist], [Album], [PriceRegular], [PriceDiscount], [EnableDiscount] FROM [tblSong] ORDER BY [Song], [Artist], [Album]"></asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
