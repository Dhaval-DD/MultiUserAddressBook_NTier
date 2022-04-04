<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_CountryList" %>

<asp:Content ID="cph" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" runat="Server">
    <asp:Label runat="server" CssClass=" d-flex justify-content-center " ForeColor="red" ID="lblMessage" EnableViewContact="False" ViewStateMode="Inherit" />
    <br/>
    <div class="container hborder">
        <div>
            <i class="fas fa-globe-asia" style="font-size: 30px; "></i>
            <span class="listheading">Country List</span>
            <asp:HyperLink runat="server" class="col-md-12" ID="hlAddContry" Text="Add New Country" CssClass="btn btn-primary addbutton" NavigateUrl="~/AdminPanel/Country/Add" />

        </div>
        <div >



                <asp:GridView  ID="gvCountry" runat="server" OnRowCommand="gvCountry_RowCommand">
                    <Columns>
                        <%--<asp:BoundField DataField="CountryID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>

                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-sm btn-warning" NavigateUrl='<%# "~/AdminPanel/Country/Edit/" + EncryptDecrypt.Base64Encode(Eval("CountryID").ToString().Trim()) %>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>

                                <asp:Button runat="server" ID="btnDelete" OnClientClick="return confirm('Are you sure to delete?')" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID".ToString()) %>' />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            
           

               
            </div><br />
    </div>
</asp:Content>

