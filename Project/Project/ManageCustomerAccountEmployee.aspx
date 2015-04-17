<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ManageCustomerAccountEmployee.aspx.vb" Inherits="Project.ManageCustomerAccountEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="left">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Please Select Which Customer You Would Like To Edit"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
        <p>
            <asp:RadioButtonList ID="radHireFire" runat="server">
                <asp:ListItem Selected="True">Disable</asp:ListItem>
                <asp:ListItem>Enable</asp:ListItem>
            </asp:RadioButtonList>
    </p>
        <p>
            <asp:Label ID="lblDisableError" runat="server"></asp:Label>
    </p>
        <p>
            <asp:Button ID="btnHireFire" runat="server" Text="Disable or Enable" />
    </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        </div>
    <div id="right">
        <div id="labels">
            <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="First Name "></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="MI"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Last Name "></asp:Label>
            <br />
            Password<br />
            <asp:Label ID="Label5" runat="server" Height="23px" Text="Address"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Height="23px" Text="Zip"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="City, State"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Height="23px" Text="Phone"></asp:Label>
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
        </div>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtMI" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TxtZip" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtCityState" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="Update Customer" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
