<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="SearchAlbums.aspx.vb" Inherits="Project.SearchArtists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="searchcriteria">
    <asp:Label ID="searchby" runat="server" Text="Search for Albums by:"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CellSpacing="20" CellPadding="0">
            <asp:ListItem>Album Title:</asp:ListItem>
            <asp:ListItem>Artist</asp:ListItem>
            <asp:ListItem> Average Rating:</asp:ListItem>
         </asp:CheckBoxList>
        <asp:Label ID="lblgenre" runat="server" Text="Genre(s):"></asp:Label>
     </div>

    <div id="artistsearch">
        <br />
        <br />
        <asp:TextBox ID="txtSearchAlbum" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtSearchArtist" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:DropDownList ID="ddlEquality" runat="server">
            <asp:ListItem Value="&lt;">Less </asp:ListItem>
            <asp:ListItem Value="&gt;">Greater</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text=" than "></asp:Label>
        <asp:TextBox ID="txtRating" runat="server" Width="25px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="(1-5)"></asp:Label>
        <br />
        <br />
        <asp:CheckBoxList ID="cbxList" runat="server" RepeatColumns="2" ></asp:CheckBoxList>
        
       </div>

    <br />
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="SEARCH" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Now showing "></asp:Label>
        <asp:Label ID="lblRecords" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label" runat="server" Text=" record(s)"></asp:Label>
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
        
        
        
    
    </asp:Content>

