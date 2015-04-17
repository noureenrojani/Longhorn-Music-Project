<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ManageItemPrice.aspx.vb" Inherits="Project.ManageItemPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Disable Discounts or Change Regular/Discount Price Here"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Please select which song you would like to edit below"></asp:Label>
    <br />
    <br />
    <div id="left">
        <asp:Label ID="Label3" runat="server" Text="Select If you want to enable or disable a discount "></asp:Label>
        <br />
        <asp:RadioButtonList ID="radEnable" runat="server">
            <asp:ListItem Selected="True">Enable</asp:ListItem>
            <asp:ListItem>Disable</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:Label ID="lblRadError" runat="server"></asp:Label>
        <asp:Button ID="btnDisable" runat="server" Text="Enable or Disable" />
        <br />
        <br />
    </div>
    <div id="right">
        <div id="labels">
            <asp:Label ID="Label4" runat="server" Text="Song"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Artist"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Album"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Regular Price"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Disc Price"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <asp:TextBox ID="txtSong" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtArtist" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtAlbum" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtRegularPrice" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtDiscountPrice" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Update Price" />
        <br />
        <br />
    </div>
    <br />
    <asp:GridView ID="gvSongs" runat="server" AutoGenerateColumns="False" DataSourceID="SongIDManagePrice">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="SongID" HeaderText="SongID" SortExpression="SongID" />
            <asp:BoundField DataField="Song" HeaderText="Song" SortExpression="Song" />
            <asp:BoundField DataField="Artist" HeaderText="Artist" SortExpression="Artist" />
            <asp:BoundField DataField="PriceRegular" HeaderText="PriceRegular" SortExpression="PriceRegular" />
            <asp:BoundField DataField="PriceDiscount" HeaderText="PriceDiscount" SortExpression="PriceDiscount" />
            <asp:BoundField DataField="Album" HeaderText="Album" SortExpression="Album" />
            <asp:BoundField DataField="EnableDiscount" HeaderText="EnableDiscount" SortExpression="EnableDiscount" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SongIDManagePrice" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_20152_Team14ConnectionString %>" SelectCommand="SELECT [SongID], [Song], [Artist], [PriceRegular], [PriceDiscount], [Album], [EnableDiscount] FROM [tblSong] ORDER BY [Song], [Artist], [Album]"></asp:SqlDataSource>
    <br />
    <br />
   
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_20152_Team14ConnectionString %>" SelectCommand="SELECT [Song], [Artist], [PriceRegular], [PriceDiscount], [Album], [EnableDiscount] FROM [tblSong] ORDER BY [Song], [Artist], [Album]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MIS333K_20152_Team14ConnectionString %>" SelectCommand="SELECT [Song], [Artist], [Album], [PriceRegular], [PriceDiscount], [EnableDiscount] FROM [tblSong] ORDER BY [Song], [Artist], [Album]"></asp:SqlDataSource>
    

    <br />
    <br />
    <br />
</asp:Content>
