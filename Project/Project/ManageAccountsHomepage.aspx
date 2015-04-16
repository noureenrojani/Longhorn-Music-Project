<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ManageAccountsHomepage.aspx.vb" Inherits="Project.ManageAccountsHomepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="lnkManageYourOwnEmpAccount" runat="server">Manage Your Own Employee Account</asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="lnkManageCustomerAccount" runat="server">Manage Customer Account </asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="lnkManageAnEmployeeAccount" runat="server" Visible="False">Manage An Employee Account</asp:LinkButton>
</asp:Content>
