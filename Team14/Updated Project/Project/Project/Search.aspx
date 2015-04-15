<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Search.aspx.vb" Inherits="Project.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="searchcriteria">
    <asp:Label ID="Label1" runat="server" Text="Search by:"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CellSpacing="20" CellPadding="0">
            <asp:ListItem>Artist</asp:ListItem>
            <asp:ListItem>Album</asp:ListItem>
            <asp:ListItem>Song</asp:ListItem>
            <asp:ListItem>Rating</asp:ListItem>
            <asp:ListItem>Genre</asp:ListItem>
         </asp:CheckBoxList>
    </div>

    <div id="artistsearch">
        <br />
        <br />
        <asp:TextBox ID="txtSearchArtist" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtSearchAlbum" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtSearchSong" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="From "></asp:Label>
        <asp:TextBox ID="txtMin" runat="server" Width="25px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text=" To "></asp:Label>
        <asp:TextBox ID="txtMax" runat="server" Width="25px"></asp:TextBox>
        <br />
        <br />
        <asp:ListBox ID="lstGenre" runat="server"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="SEARCH" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField Text="Select" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        
        
        
    </div>
    </asp:Content>
