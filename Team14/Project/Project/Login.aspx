<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.vb" Inherits="Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
</p>
<p>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
</p>
<p>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lblError" runat="server"></asp:Label>
</p>
<p>
    <asp:RadioButtonList ID="radLoginType" runat="server">
        <asp:ListItem Selected="True">Customer</asp:ListItem>
        <asp:ListItem>Employee</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
    <asp:Button ID="btnLogin" runat="server" Text="Log In" />
</p>
<p>
    <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/CreateAccount.aspx">Create an Account</asp:LinkButton>
</p>
<p>
    &nbsp;</p>
</asp:Content>
