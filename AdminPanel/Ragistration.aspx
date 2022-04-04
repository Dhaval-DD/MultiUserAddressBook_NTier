<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ragistration.aspx.cs" Inherits="AdminPanel_Ragistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="~/Content/Css/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CSS/ragistration.css" rel="stylesheet" />

    <script src="~/Content/Js/bootstrap.js"></script>
    <script src="~/Content/Js/bootstrap.min.js"></script>

    <link href="../Content/CSS/all.min.css" rel="stylesheet" />

</head>
<body>
    <nav class="navbar  navbar-expand-lg navbar-dark bg-dark header">
        <i class="fas fa-address-book" style="font-size: 30px; color: white;"></i>&nbsp;&nbsp;
    <a class="navbar-brand" href="#" style="font-size: 25px;">Address Book</a>
        <a class="navbar-brand" href="#" style="font-size: 25px; font-family: monospace">| Registration</a>



        <div class="collapse navbar-collapse" style="" id="navbarSupportedContent">
        </div>
    </nav>
    <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>

    </div>

    <form id="form1" runat="server">
        <div class="container">
            <div class="wrapper fadeInDown">
                <div id="formContent">



                    <h2 class="active">Sign Up </h2>


                    <asp:TextBox runat="server" ID="txtUserNameRegister" class="input" placeholder="User Name*"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfUserName" runat="server" Display="Dynamic" ErrorMessage="Please Enter UserName" ForeColor="Red" ValidationGroup="RUser" ControlToValidate="txtUserNameRegister" Font-Size="Small"></asp:RequiredFieldValidator><br />

                    <asp:TextBox runat="server" ID="txtPasswordRegister" class="input" placeholder="Password*"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Please Enter Password." ForeColor="Red" ValidationGroup="RUser" ControlToValidate="txtPasswordRegister" Font-Size="Small"></asp:RequiredFieldValidator><br />

                    <asp:TextBox runat="server" ID="txtDisplayName" class="input" placeholder="Display Name*"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfWhatsappNo" runat="server" Display="Dynamic" ErrorMessage="Please Enter Display Name." ForeColor="Red" ValidationGroup="RUser" ControlToValidate="txtDisplayName" Font-Size="Small"></asp:RequiredFieldValidator><br />


                    <asp:TextBox runat="server" ID="txtMobileNo" class="input" placeholder="Mobile No."></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rvMobilenumber" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Please enter Mobile No." Font-Size="Small" ForeColor="Red" Type="Integer" ValidationExpression="^[6-9][0-9]{9}$" ValidationGroup="RUser"></asp:RegularExpressionValidator><br />


                    <asp:TextBox runat="server" ID="txtEmail" class="input" placeholder="Email*"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfEmail" runat="server" Display="Dynamic" ErrorMessage="Please Enter Email." ForeColor="Red" ValidationGroup="RUser" ControlToValidate="txtEmail" Font-Size="Small"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="StdForm" Font-Size="Small"></asp:RegularExpressionValidator>
                    <br />

                    <br />
                    <asp:Button ValidationGroup="RUser" CssClass="button" runat="server" ID="btnRegister" Text="Submit" class="fadeIn six" OnClick="btnRegister_Click" /><br />
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />

                    <asp:HyperLink runat="server" class="h2 underlineHover " Style="color: lightgreen" ID="hlLogin" Text="Sign In" NavigateUrl="~/AdminPanel/Login.aspx" />



                </div>
            </div>
        </div>

    </form>
</body>
</html>
