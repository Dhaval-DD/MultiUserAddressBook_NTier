<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" runat="Server">
    <div class="container hborder needs-validation " style="width: 900px" >
        <div class="row">
            <div class="col-md-12">
                <h2>
                    <asp:Label Style="color: gray; font-size: 25px;" CssClass="fw-normal " runat="server" ID="lblMessageMode" EnableViewContact="False" />
                </h2>

            </div>
        </div>
        <hr />

        <div class="row">
            <div class="col-md-3">
                Country Name:
                <span class="required">*</span>
            </div>
            <div class="col-md-7">
                <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control" />
                <%--<input type="text" class="form-control" id="validationTooltip01" placeholder="First name" value="Mark" required>--%>
               
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtCountryName" Display="Dynamic" ErrorMessage="Please Enter Country Name" ForeColor="Red" Font-Size="Small" ValidationGroup="vCountry"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />


            <div class="col-md-3">
                Country Code:
                <span class="required">*</span>
            </div>
            <div class="col-md-7">
                <asp:TextBox ID="txtCountryCode" runat="server" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCountryCode" Display="Dynamic" ErrorMessage="Please Country Code" ForeColor="Red" Font-Size="Small" ValidationGroup="vCountry"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />

        <div class="row">
            
            <div class="col-md-3">
            </div>
            <div class="col-md-8 " >
                <asp:Button runat="server" ID="btnSave" Text="Save" EnableViewState="False" ValidationGroup="vCountry" CssClass="btn btn-sm btn-dark" OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" EnableViewState="False" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />

            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12  d-flex justify-content-center">
                <asp:Label CssClass="" runat="server" ID="lblMessage" EnableViewState="False" />
            </div>
        </div>
        <br />
    </div>

</asp:Content>

