<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

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

        <div class="row text-left">

            <div class="col-md-4">
                Country :
                <span class="required">*</span>
            </div>
            <div class="col-md-5">
                <asp:DropDownList ID="ddlCountryID" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfState" runat="server" ErrorMessage="Please Select Country" ValidationGroup="ctForm" ControlToValidate="ddlCountryID" Display="Dynamic" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfState0" runat="server" ErrorMessage="Please Select Country" ValidationGroup="ctForm" ControlToValidate="ddlCountryID" Display="Dynamic" ForeColor="Red" InitialValue="-1" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
         


            <br />
            <br />


            <div class="col-md-4">
                State Name:
                <span class="required">*</span>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtStateName" Display="Dynamic" ErrorMessage="Please Enter State Name" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="col-md-4">
                State Code:
                <span class="required">*</span>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="txtStateCode" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStateCode" Display="Dynamic" ErrorMessage="Please Enter State Code" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>

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
            <div class="col-md-12 alert-primary d-flex justify-content-center">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="False" />
            </div>
        </div>

    </div>

</asp:Content>

