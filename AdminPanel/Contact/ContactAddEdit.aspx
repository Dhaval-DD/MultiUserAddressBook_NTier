<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            display: flex;
            -ms-flex-wrap: wrap;
            flex-wrap: wrap;
            margin-left: 25px;
            margin-right: -15px;
        }

        .auto-style2 {
            position: relative;
            width: 100%;
            min-height: 1px;
            -webkit-box-flex: 0;
            -ms-flex: 0 0 66.666667%;
            flex: 0 0 66.666667%;
            max-width: 66.666667%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" runat="Server">


    <asp:Label runat="server" CssClass="alert-primary  d-flex justify-content-center " ForeColor="red" ID="lblMessage" EnableViewContact="False" />
    <br />

    <div class="container hborder">
        <div class="container">
            <div class="col-md-10">
                <h2>
                    <asp:Label Style="color: gray; font-size: 25px;" CssClass="fw-normal " runat="server" ID="lblMessageMode" EnableViewContact="False" />
                </h2>
            </div>
        </div>
        <hr />

        <div class="auto-style1">
            <div class="col-md-3">
                Contact Name:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">

                <asp:TextBox placeholder="Enter your full name" ID="txtContactName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtContactName" Display="Dynamic" ErrorMessage="Please Enter Name" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>

            </div>
            <br />
            <br />


            <div class="col-md-3">
                Birthdate:
            </div>
            <div class="col-md-8">
                <asp:TextBox placeholder="Enter your BirthDate" ID="txtBirthdate" runat="server" CssClass="form-control" TextMode="Date" />

                <%--  <asp:RequiredFieldValidator ID="rfBirthDate" runat="server" Display="Dynamic" ErrorMessage="Please Select Birthdate." ForeColor="Red" ValidationGroup="ctForm" ControlToValidate="txtBirthdate" Font-Size="Small"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvBirthdate" runat="server" ControlToValidate="txtBirthdate" Display="Dynamic" ErrorMessage="Enter Valid Date " ForeColor="Red" Operator="DataTypeCheck" Type="Date" ValidationGroup="ctForm" Font-Size="Small"></asp:CompareValidator>--%>
            </div>
            <br />
            <br />

            <div class="col-md-3">
                Age:
            </div>
            <div class="col-md-8">
                <asp:TextBox placeholder="Enter your Age" ID="txtAge" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
            <br />
            <br />
            <div class="col-md-3">
                Contact category:
                <span class="required">*</span>
            </div>
            <div class="auto-style2">
                <%--<asp:DropDownList ID="ddlContactCategoryID" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                <%-- <asp:RequiredFieldValidator ControlToValidate="cblContactCategoryID" Display="Dynamic" ErrorMessage="Please select Contact Category." Font-Size="Small" ForeColor="Red" ID="rfCContact" runat="server" ValidationGroup="ctForm"></asp:RequiredFieldValidator>--%>

                <asp:CheckBoxList ID="cblContactCategoryID" runat="server" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="-1" />

            </div>
            <br />
            <br />

            <div class="col-md-3">
                Whatsapp Number:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtWhatsappNo" placeholder="Enter your Whatsapp Number (Indian)" runat="server" CssClass="form-control" MaxLength="10" TextMode="Number" />
                <asp:RegularExpressionValidator ID="rvMobilenumber" runat="server" ControlToValidate="txtWhatsappNo" Display="Dynamic" ErrorMessage="Please enter valid phone no" Font-Size="Small" ForeColor="Red" Type="Integer" ValidationExpression="^[6-9][0-9]{9}$" ValidationGroup="ctForm"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfWhatsappNo" runat="server" Display="Dynamic" ErrorMessage="Please Enter Whatsapp No." ForeColor="Red" ValidationGroup="ctForm" ControlToValidate="txtWhatsappNo" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <div class="col-md-3">
                Email:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:TextBox placeholder="Enter your Email" ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfEmail" runat="server" Display="Dynamic" ErrorMessage="Please Enter Email." ForeColor="Red" ValidationGroup="ctForm" ControlToValidate="txtEmail" Font-Size="Small"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="StdForm" Font-Size="Small"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />


            <div class="col-md-3">
                Blood Group:
            </div>
            <div class="col-md-8">
                <asp:TextBox placeholder="Enter your Blood Grop" ID="txtBloodGroup" runat="server" CssClass="form-control" />
            </div>
            <br />
            <br />
            <div class="col-md-3">
                Facebook ID:
            </div>
            <div class="col-md-8">
                <asp:TextBox placeholder="Enter your FaceBook ID" ID="txtFacebookID" runat="server" CssClass="form-control" />
            </div>
            <br />
            <br />
            <div class="col-md-3">
                LinkdIN ID:
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtLinkdINID" placeholder="Enter your LinkdIN ID" runat="server" CssClass="form-control" />
            </div>
            <br />
            <br />




            <div class="col-md-3">
                Address:
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtAddress" placeholder="Enter your Address" runat="server" CssClass="form-control" />
            </div>
            <br />
            <br />
            <div class="col-md-3">
                Country:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlCountryID" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfCContact1" runat="server" Display="Dynamic" ErrorMessage="Please select Country." ForeColor="Red" ValidationGroup="ctForm" ControlToValidate="ddlCountryID" InitialValue="-1" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="col-md-3">
                State:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlStateID" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfState" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddlStateID" Display="Dynamic" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfState0" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddlStateID" Display="Dynamic" ForeColor="Red" ValidationGroup="ctForm" InitialValue="-1" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <div class="col-md-3">
                City:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlCityID" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfCity" runat="server" Display="Dynamic" ErrorMessage="Please select City." ForeColor="Red" ValidationGroup="ctForm" ControlToValidate="ddlCityID" Font-Size="Small"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfCity0" runat="server" Display="Dynamic" ErrorMessage="Please select City." ForeColor="Red" ValidationGroup="ctForm" ControlToValidate="ddlCityID" InitialValue="-1" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <div class="row col-md-12">
                <div class="col-md-3">
                    File:
                </div>
                <div class="col-md-4">
                    <asp:FileUpload CssClass="form-control" ID="fuFile" runat="server" />
                </div>
                <div class="col-md-3">
                    <asp:Image CssClass="" AlternateText="Image dosen't uploaded or found!" Width="100" ID="imgContactFilePath" ImageUrl='<%# Eval("ContactFilePath") %>' runat="server" />
              </div>

                <br />
                <%-- <div>
                     <asp:Button runat="server" ID="btnPhotoDelete" Text="Delete" CommandArgument='<%# Eval("ContactID").ToString() %>' CommandName="DeletePhoto" CssClass="btn btn-sm btn-dark " OnClientClick="DI" />
                </div>--%>
            </div>

            <div class="col-md-11">
                <hr />
            </div>

            <div class="col-md-3">
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnSave" Text="Save" EnableViewState="False" CssClass="btn btn-sm btn-dark" OnClick="btnSave_Click" ValidationGroup="ctForm" />
                &nbsp;
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" EnableViewState="False" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />

            </div>

        </div>
        <br />



    </div>

</asp:Content>

