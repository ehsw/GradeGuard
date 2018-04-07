<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GradeGuard.Default" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>GradeGuard - Login</title>
    <link rel='stylesheet' href='http://codepen.io/assets/libs/fullpage/jquery-ui.css'>
    <link rel="stylesheet" href="css/style.css" media="screen" type="text/css" />
</head>
<body>
    <div class="login-card">
        <h1>Log-in</h1>
        <br>
        <form runat="server">
            <asp:TextBox runat="server" ID="txtUserName" placeholder="username"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="password"></asp:TextBox>
            <asp:Button runat="server" ID="btnLogin" CssClass="login login-submit" Text="login" OnClick="btnLogin_Click" />

            <div class="login-help">
                <asp:Button runat="server" ID="btnRegister" CssClass="login login-submit" Text="register" OnClick="btnRegister_Click" />
            </div>
            <div style="width:100%; text-align:center; padding:15px 0 0 0;">
                <asp:Label runat="server" ID="lblMessage" Text="" ForeColor="Gray"></asp:Label>
            </div>
        </form>
    </div>
    <script src='http://codepen.io/assets/libs/fullpage/jquery_and_jqueryui.js'></script>
</body>
</html>
