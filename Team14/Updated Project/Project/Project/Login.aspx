<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.vb" Inherits="Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="left">Customer Login<br />
        <br />
        Email<br />
        <asp:TextBox ID="txtCustomerEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ClientIDMode="Static" ControlToValidate="txtCustomerEmail" ErrorMessage="Not a proper email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Cust">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ClientIDMode="Static" ControlToValidate="txtCustomerEmail" ErrorMessage="Email Required" ValidationGroup="Cust">*</asp:RequiredFieldValidator>
        <br />
        <br />
        Password<br />
        <asp:TextBox ID="txtCustomerPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ClientIDMode="Static" ControlToValidate="txtCustomerPassword" ErrorMessage="Password Required" ValidationGroup="Cust">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblLoginCust" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblCustomerError" runat="server"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Cust" />
        <br />
        <asp:Button ID="btnCustomerLogin" runat="server" Text="Login" ValidationGroup="Cust" />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton15" runat="server">Create an Account</asp:LinkButton>
    </div>
  <div id="middle">
      <asp:Image ID="Image1" runat="server" Height="364px" ImageUrl="~/Bar.png" />
</div>
    <div id="right">
        Employee Login<br />
        <br />
        Employee ID<br />
        <asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ClientIDMode="Static" ControlToValidate="txtEmpID" ErrorMessage="Employee ID Required" ValidationGroup="Emp">*</asp:RequiredFieldValidator>
        <br />
        <br />
        Password<br />
        <asp:TextBox ID="txtEmpPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ClientIDMode="Static" ControlToValidate="txtEmpPassword" ErrorMessage="Password Required" ValidationGroup="Emp">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblLoginEmp" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblEmployeeError" runat="server"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Emp" />
        <br />
        <asp:Button ID="btnEmployeeLogin" runat="server" Text="Login" ValidationGroup="Emp" />
        <br />
        <br />
    </div>
<p>
    &nbsp;</p>
    <p>
        &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
&nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
