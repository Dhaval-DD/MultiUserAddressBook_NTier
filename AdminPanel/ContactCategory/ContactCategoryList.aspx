<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_CountryList" %>

<asp:Content ID="cph" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" runat="Server">
    <asp:Label runat="server" CssClass=" d-flex justify-content-center " ForeColor="red" ID="lblMessage" EnableViewContact="False" ViewStateMode="Inherit" />
    <br />
    <div class="container hborder">
        <div>
            <i class="fa-solid fa-user-group" style="font-size: 30px;"></i>
            <span class="listheading">Contact Category List</span>
            <asp:HyperLink runat="server" ID="hlAddContactCategory" Text="Add New Contact Category" CssClass="btn btn-primary addbutton" NavigateUrl="~/AdminPanel/ContactCategory/Add" />


        </div>


        <div>
            <div>

                <asp:GridView ID="gvContactCategory" runat="server" OnRowCommand="gvContactCategory_RowCommand">

                    <Columns>
                        <%--<asp:BoundField DataField="ContactCategoryID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category Name" />

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>

                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-sm btn-warning" NavigateUrl='<%# "~/AdminPanel/ContactCategory/Edit/" + EncryptDecrypt.Base64Encode(Eval("ContactCategoryID").ToString().Trim())  %>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>

                                <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure want to Delete?')" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID".ToString()) %>' />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>


            </div>
        </div>
        <br />
    </div>
</asp:Content>

