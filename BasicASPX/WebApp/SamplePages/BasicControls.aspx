<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasicControls.aspx.cs" Inherits="WebApp.SamplePages.BasicControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table align="center" style="width: 80%; background-color: #FFFFFF">
        <tr>
            <td align="right" style="height: 22px">Enter your choice (1-4):</td>
            <td style="height: 22px">
                <asp:TextBox ID="TextBoxNumericChoice" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="SubmitButton" runat="server" Text="Submit Choice" OnClick="SubmitButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="Choice (radio button list):" BackColor="White" Font-Bold="True" Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListChoice" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">COMP1008</asp:ListItem>
                    <asp:ListItem Value="2">CPSC1517</asp:ListItem>
                    <asp:ListItem Value="4">DMIT1508</asp:ListItem>
                    <asp:ListItem Value="3">DMIT2018</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Literal ID="Literal1" runat="server" Text="Programming Software (via checkbox):"></asp:Literal>
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxChoice" runat="server" Text="(Active when checked)" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="DisplayLabel:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="DisplayReadOnly" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 22px">
                <asp:Label ID="Label4" runat="server" Text="View Choice Collection:"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:DropDownList ID="CollectionList" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="OutputMessage" runat="server"></asp:Label></td>
        </tr>
    </table>

</asp:Content>
