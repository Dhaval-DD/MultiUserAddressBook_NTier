<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" Runat="Server">
    <asp:Label runat="server" CssClass=" d-flex justify-content-center " ForeColor="red" ID="lblMessage" EnableViewContact="False" ViewStateMode="Inherit" />
    <br/>
     <div class="container  hborder">
        <div>
            <i class="fas fa-city" style="font-size: 30px; "></i>
            <span class="listheading" >City List</span>
            <asp:HyperLink runat="server" ID="hlAddCity" Text="Add New City" CssClass="btn btn-primary addbutton " NavigateUrl="~/AdminPanel/City/Add" />

        </div>
        <div>

           



            <asp:GridView ID="gvCity" runat="server" OnRowCommand="gvCity_RowCommand">
                <Columns>
                    <%--<asp:BoundField DataField="CityID" HeaderText="ID" />--%>
                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="CityName" HeaderText="City Name" />
                    <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                    <asp:BoundField DataField="PINCode" HeaderText="PIN Code" />
                    <%--<asp:BoundField DataField="CreationDate" HeaderText="Country Code" />--%>



                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>

                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-sm btn-warning" NavigateUrl='<%# "~/AdminPanel/City/Edit/" + EncryptDecrypt.Base64Encode(Eval("CityID").ToString().Trim()) %>' />

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>

                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Are you sure want to Delete?')" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID".ToString()) %>' />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
          
        </div>
         <br />
    </div>
</asp:Content>

