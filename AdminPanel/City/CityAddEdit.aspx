<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" runat="Server">

    <div class="container hborder">
        <div class="row">
            <div class="col-md-12">
                <h2>
                    <asp:Label Style="color: gray; font-size: 25px;" CssClass="fw-normal " runat="server" ID="lblMessageMode" EnableViewContact="False" />
                </h2>
            </div>
        </div>
        <hr />


        <div class="row d-flex ">
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
                <asp:DropDownList ID="ddlStateID" CssClass="form-control" runat="server" AutoPostBack="True" ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfState" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddlStateID" Display="Dynamic" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfState0" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddlStateID" Display="Dynamic" ForeColor="Red" ValidationGroup="ctForm" InitialValue="-1" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <%--<div class="col-md-4">
                <span class="required">*</span>
                State:
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlStateID" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfState" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddlStateID" Display="Dynamic" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfState0" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddlStateID" Display="Dynamic" ForeColor="Red" ValidationGroup="ctForm" InitialValue="-1" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />--%>


            <div class="col-md-3">
                City Name:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtCityName" Display="Dynamic" ErrorMessage="Please Enter city Name" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>

            </div>
            <br />
            <br />

            <div class="col-md-3">
                STD Code:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtSTDCode" runat="server" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtSTDCode" Display="Dynamic" ErrorMessage="Please Enter STD code" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>

            </div>
            <br />
            <br />

            <div class="col-md-3">
                PIN Code:
                <span class="required">*</span>
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtPINCode" runat="server" CssClass="form-control"  />
                <asp:RequiredFieldValidator ID="rfvPin" runat="server" ControlToValidate="txtPINCode" Display="Dynamic" ErrorMessage="Please Enter PIN Code" ForeColor="Red" ValidationGroup="ctForm" Font-Size="Small"></asp:RequiredFieldValidator>

            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-3">
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
                <asp:Label runat="server" ID="lblMessage" EnableViewCity="False" />
            </div>
        </div>

    </div>

</asp:Content>

