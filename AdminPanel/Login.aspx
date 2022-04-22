<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="~/Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CSS/login.css" rel="stylesheet" />
    <link href="../Content/CSS/all.min.css" rel="stylesheet" />
    <%--//FontAwesome--%>
    <%-- <link href="~/Content/CSS/all.min.css" rel="stylesheet" />
    <script src="~/Content/Js/all.js"></script>--%>

    <script src="~/Content/Js/bootstrap.js"></script>
    <script src="~/Content/Js/bootstrap.min.js"></script>


    <title></title>

</head>
<body>
    <%-- <nav class="navbar  navbar-expand-lg navbar-dark bg-dark header">
        <i class="fas fa-address-book" style="font-size: 30px; color: white;"></i>&nbsp;&nbsp;
            <a class="navbar-brand" href="#" style="font-size: 25px;">Address Book</a>


        <div class="collapse navbar-collapse" style="" id="navbarSupportedContent">
        </div>
    </nav>--%>
    <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div>





    <form id="form1" runat="server">


        <h3 class="display-7 fw-lighter">ADDRESS BOOK<br />
            <span class="fs-3 font-monospace ">Sign in</span></h3>


        <label for="username">Username</label>
        <asp:TextBox ID="txtUserNameLogin" class="input" runat="server" />
        <asp:RequiredFieldValidator ID="rfUserName" runat="server" Display="Dynamic" ErrorMessage="Please Enter UserName" ForeColor="Red" ValidationGroup="login" ControlToValidate="txtUserNameLogin" Font-Size="Medium"></asp:RequiredFieldValidator><br />

        <label for="password">Password</label>
        <asp:TextBox ID="txtPasswordLogin" CssClass="  input" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ID="rfPassword" runat="server" Display="Dynamic" ErrorMessage="Please Enter Password" ForeColor="Red" ValidationGroup="login" ControlToValidate="txtPasswordLogin" Font-Size="Medium"></asp:RequiredFieldValidator><br />


        <asp:Button runat="server" CssClass="button" ID="btnLogin" Text="Log In" OnClick="btnLogin_Click" ValidationGroup="login" />


        <asp:Label class="error" ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
        <div class="row col-md-12">
            <div class="col-md-6">
                <p>Not a memeber?</p>
            </div>
            <div class="col-md-6 signup">

                <asp:HyperLink ID="hlSignUp" Style="text-decoration: none;" CssClass=" hover-underline-animation" NavigateUrl="~/AdminPanel/Ragistration.aspx" runat="server">Sign up now</asp:HyperLink><br />
            </div>


        </div>

    </form>

</body>
</html>
