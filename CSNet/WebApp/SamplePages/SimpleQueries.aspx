<%@ Page Title="Simple Queries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimpleQueries.aspx.cs" Inherits="WebApp.SamplePages.SimpleQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Simple Queries</h1>
    <table style="width: 80%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Enter Product ID:"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="SearchArg" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Product ID:"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="ProductID" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="ClearButton" runat="server" Text="Clear" CausesValidation="false" OnClick="ClearButton_Click"/>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Name:"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="ProductName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;&nbsp;
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>