<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" runat="Server">
    <div class="container hborder">
        <div class="row">
            <div class="col-md-12">
                <h2>
                    <asp:Label Style="color: gray; font-size: 25px;" CssClass="fw-normal" runat="server" ID="lblMessageMode" EnableViewContact="False" />
                </h2>
            </div>
        </div>
       <hr />

        <div class="row">
            <div class="col-md-4">
                Contact Category Name:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtContactCategoryName" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvPin" runat="server" ControlToValidate="txtContactCategoryName" Display="Dynamic" ErrorMessage="Please Enter Contact Category" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>

            </div>


        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnSave" Text="Save" EnableViewState="False" CssClass="btn btn-sm btn-dark" OnClick="btnSave_Click" ValidationGroup="ctForm" />
                &nbsp;
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" EnableViewState="False" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />

            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12  d-flex justify-content-center">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="False" />
            </div>
        </div>

    </div>

</asp:Content>

