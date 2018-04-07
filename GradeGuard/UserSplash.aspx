<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSplash.aspx.cs" Inherits="GradeGuard.UserSplash" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GradeGuard - Welcome!</title>
    <link href="css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="sm1"></asp:ScriptManager>
        <div id="content">
            <table>
                <tbody>
                    <tr>
                        <td style="width: 600px;">Welcome, <%= Session["userName"] %>!
                        </td>
                        <td>Semester:
                        </td>
                    </tr>
                    <tr>    
                        <td>&nbsp;</td>
                        <td>
                            <asp:DropDownList runat="server" Width="150px" ID="ddlSemester" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged" AutoPostBack>
                                <asp:ListItem Text="Spring 2018" Value="Spring2018"></asp:ListItem>
                                <asp:ListItem Text="Summer 1 2018" Value="Summer12018"></asp:ListItem>
                                <asp:ListItem Text="Summer 2 2018" Value="Summer22018"></asp:ListItem>
                                <asp:ListItem Text="Fall 2018" Value="Fall2018"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum
                        </td>
                    </tr>
                    <tr>
                        <th colspan="2" style="padding-top: 25px;">Courses for semester:</th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView runat="server" ID="gvCourses" AutoGenerateColumns="false" Style="width: 100%;" DataKeyNames="CourseID" OnRowCommand="gvCourses_RowCommand">
                                <EmptyDataTemplate>
                                    <div>
                                        <p>No courses available for the selection</p>
                                    </div>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:BoundField DataField="CourseID" Visible="false" />
                                    <asp:BoundField HeaderText="Course" DataField="CourseAcronym" />
                                    <asp:BoundField HeaderText="Description" DataField="CourseDescription" />
                                    <asp:BoundField HeaderText="Submitted Grades" DataField="SubmittedGrades" />
                                    <asp:BoundField HeaderText="Current Grade" DataField="CurrentGrade" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbAddGrade" Text="Add Grade" OnClick="lbAddGrade_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="LightYellow" />
                            </asp:GridView>
                            <button runat="server" id="target" style="display: none;"></button>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_Click" Text="Refresh Table" /></td>
                        <td style="text-align: right;">
                            <asp:Button runat="server" ID="btnAddCourse" Text="Add Course" OnClick="btnAddCourse_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <cc1:ModalPopupExtender runat="server" ID="mpeAddCourse" TargetControlID="btnAddCourse" PopupControlID="panel1" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender runat="server" ID="mpeAddGrade" TargetControlID="target" PopupControlID="panel2" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
            <asp:Panel ID="panel1" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe style="width: 500px; height: 500px;" id="irm1" src="AddCourse.aspx" runat="server"></iframe>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Close" />
            </asp:Panel>
            <asp:Panel ID="panel2" runat="server" CssClass="Popup addGrade" align="center" Style="display: none">
                <iframe style="width: 400px; height: 250px;" id="Iframe1" src="AddGrade.aspx" runat="server"></iframe>
                <br />
                <asp:Button ID="Button3" runat="server" Text="Close" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
