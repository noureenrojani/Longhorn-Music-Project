<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ManageOwnAccountEmployee.aspx.vb" Inherits="Project.ManageOwnAccountEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="labels">

        <asp:Label ID="Label1" runat="server" Height="23px" Text="Address"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Height="23px" Text="Zip Code"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Height="23px" Text="Phone Number"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Height="23px" Text="Password"></asp:Label>
        <br />
        <asp:Label ID="lblEnterOldPassword" runat="server" Height="23px" Text="Enter Old Password " Visible="False"></asp:Label>
        <br />
        <br />
        <br />
        <br />

    </div>
    <div id="right">

        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtOldPassword" runat="server" Visible="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Update Information " />
        <br />

    </div>
    <p>
        <br />
    </p>
</asp:Content>
