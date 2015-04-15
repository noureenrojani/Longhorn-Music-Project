<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="CreateAccount.aspx.vb" Inherits="Project.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Please enter information to create account"></asp:Label>
    <br />
    <br />
    <div id="left">

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="#CF5300"></asp:Label>
        <br />
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CF5300" />

    </div>
    <div id="emailpw">
        <asp:Label ID="Email" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddr" ErrorMessage="Required Email" ForeColor="#CF5300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmailAddr" ErrorMessage="Required Email" ForeColor="#CF5300">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtEmailAddr" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Required Password" ForeColor="#CF5300">*</asp:RequiredFieldValidator>
        &nbsp;
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Re-enter Password"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPasswordCheck" ErrorMessage="Required Password Confirmation" ForeColor="#CF5300">*</asp:RequiredFieldValidator>
        &nbsp;
        <asp:TextBox ID="txtPasswordCheck" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="First Name"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Required First Name" ForeColor="#CF5300">*</asp:RequiredFieldValidator>
        &nbsp;
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Last Name"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLastName" ErrorMessage="Required Last Name" ForeColor="#CF5300">*</asp:RequiredFieldValidator>
        &nbsp;
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Middle Initial"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtMI" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress" ErrorMessage="Required Address" ForeColor="#CF5300">*</asp:RequiredFieldValidator>
        &nbsp;
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Zip Code"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        <br />
        <br />
        City<br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCity" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        State<br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Phone Number"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPhone" ErrorMessage="Required Phone Number" ForeColor="#CF5300">*</asp:RequiredFieldValidator>
        &nbsp;
        <asp:TextBox ID="txtPhone" runat="server" MaxLength="10"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEnabled" runat="server" Visible="False">Y</asp:TextBox>
        <br />
        <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" />
    </div>

</asp:Content>
