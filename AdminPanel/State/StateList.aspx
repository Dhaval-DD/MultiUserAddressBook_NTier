<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_CountryList" %>

<asp:Content ID="cph" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" runat="Server">
    <asp:Label runat="server" CssClass="alert-primary d-flex justify-content-center " ForeColor="red" ID="lblMessage" EnableViewContact="False" ViewStateMode="Inherit" />
    <br/>
    <div class="container hborder">
        <div >
            <i class="fa-solid fa-flag-usa" style="font-size: 30px; "></i>
            <span class="listheading" >State List</span>
            <asp:HyperLink runat="server" ID="hlAddState" Text="Add New State" CssClass="btn btn-primary addbutton" NavigateUrl="~/AdminPanel/State/Add" />

        </div>
        <div >

          
                <asp:GridView ID="gvState" runat="server" OnRowCommand="gvState_RowCommand" en>
                    <Columns>
                        <%--<asp:BoundField DataField="StateID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="StateCode" HeaderText="State Code" />

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>

                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-sm btn-warning" NavigateUrl='<%# "~/AdminPanel/State/Edit/" + EncryptDecrypt.Base64Encode(Eval("StateID").ToString()).Trim() %>' />

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>

                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Are you sure want to Delete?')" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID".ToString()) %>' />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
              
            </div><br />

    </div>


</asp:Content>

