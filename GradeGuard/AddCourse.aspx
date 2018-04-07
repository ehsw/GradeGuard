<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="GradeGuard.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="sm1"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="up1">
            <ContentTemplate>
                <div>
                    <h1>Add Course</h1>
                    <table id="addCourseTable" style="margin:0 auto;">
                        <tbody>
                            <tr>
                                <th>User:</th>
                                <td><%= Session["userName"].ToString() %></td>
                            </tr>
                            <tr>
                                <th>Semester:</th>
                                <td><%= Session["selectedSemester"].ToString() %></td>
                            </tr>
                            <tr>
                                <th>Course ID:
                                </th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCourseID" placeholder="CS101"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Course Description:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCourseDescription" placeholder="Computer Concepts"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="text-align: right;">
                                    <asp:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="Add Course" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label runat="server" ID="lblMessage"></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                    <h2>Course Grading</h2>
                    <table id="courseGradingTable" style="margin:0 auto;">
                        <tbody>
                            <tr>
                                <th>Letter Grade
                                </th>
                                <th>Min Grade
                                </th>
                            </tr>
                            <tr>
                                <th>A</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtA"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>A-</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtAMinus"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>B+</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtBPlus"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>B</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtB"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>B-</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtBMinus"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>C+</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtCPlus"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>C</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>C-</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtCMinus"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>D</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtD"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>F</th>
                                <td>
                                    <asp:TextBox CssClass="gradeEntry" runat="server" ID="txtF"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button runat="server" ID="btnUpdateRubric" Text="Update Rubric" OnClick="btnUpdateRubric_Click" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label runat="server" ID="lblRubricMessage"></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:HiddenField runat="server" ID="hfCourseID" />
                    <h2>Grading Criteria</h2>
                    <asp:GridView ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false" Width="100%" style="margin:0 auto;">
                        <Columns>
                            <asp:TemplateField HeaderText="Category">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Assignments, Quizzes, etc..." Width="95%"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <FooterTemplate>
                                    <asp:Button ID="ButtonAdd" runat="server" Text="Add New Category" OnClick="ButtonAdd_Click" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Weight (%)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" placeholder="15, 25, etc..." Width="100px" style="text-align:center;"></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label runat="server" ID="lblTotal"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div style="text-align: right;">
                        <asp:Button runat="server" ID="btnUpdateCriteria" Text="Update Grading" OnClick="btnUpdateCriteria_Click" />
                    </div>
                    <div>
                        <asp:Label runat="server" ID="lblGradingMessage"></asp:Label>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
