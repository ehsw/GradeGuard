<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGrade.aspx.cs" Inherits="GradeGuard.AddGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add Grade</h1>

            <table>
                <tbody>
                    <tr>
                        <th>Category:</th>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlCategory"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th>Name:</th>
                        <td>
                            <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>Grade Received:</th>
                        <td>
                            <asp:TextBox runat="server" ID="txtReceived" Width="50px"></asp:TextBox>
                            &emsp;/&emsp;
                            <asp:TextBox runat="server" ID="txtMaximum" Width="50px" Text="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:right;"><asp:CheckBoxList runat="server" ID="cbs" RepeatDirection="Horizontal">
                            <asp:ListItem Selected Text="Actual Grade" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Forecasted Grade" Value="0"></asp:ListItem>
                                        </asp:CheckBoxList></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="text-align: right;">
                            <asp:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="Add Grade" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lblMessage"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
