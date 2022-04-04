<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_ContactList" %>

<asp:Content ID="cph" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContant" runat="Server">
        <asp:Label runat="server" CssClass="alert-primary d-flex justify-content-center " ForeColor="red" ID="lblMessage" EnableViewContact="False" ViewStateMode="Inherit" />
    <br/>
    <div style="padding-left: 20px; padding-right: 20px;">

        <div class=" hborder">
            <div class="row">
                <div class="">
                    <i class="fas fa-contact-card" style="font-size: 30px; padding-left: 20px"></i>
                    <span class="listheadingcontact">Contact List</span>
                    <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" NavigateUrl="~/AdminPanel/Contact/Add" Font-Size="Large" CssClass="btn btn-primary btn-sm addbuttoncontact" />
                </div>

            </div>
            <div>
                <div>
                    
                
                    <div class="scrollmenu " style="margin-right: 20px; margin-left: 20px;">
                        <asp:GridView ID="gvContact" runat="server" Width="515px" class="col-md-12  d-flex justify-content-center " OnRowCommand="gvContact_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">

                            <Columns>

                                <asp:TemplateField  HeaderText="Edit">
                                    <ItemTemplate>

                                        <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-sm btn-warning" NavigateUrl='<%# "~/AdminPanel/Contact/Edit/" + EncryptDecrypt.Base64Encode(Eval("ContactID").ToString().Trim())  %>' />

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure want to Delete ?')" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID".ToString()) %>' />

                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <%--//------------------Img------------------------//--%>
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>

                                        <asp:Image CssClass="" AlternateText="Image dosen't upload or found!  " Width="100" ID="imgContactFilePath" ImageUrl='<%# Eval("ContactFilePath") %>' runat="server" />
                                       

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete Image">
                                    <ItemTemplate>

                                       
                                        <asp:Button runat="server" ID="btnPhotoDelete" Text="Delete" OnClientClick="return confirm('Are you sure want to Delete Image?')" CommandArgument='<%# Eval("ContactID").ToString() %>' CommandName="DeletePhoto" CssClass="btn btn-sm btn-dark " />

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:BoundField DataField="ContactID" HeaderText="ID" />--%>


                                <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                                <asp:BoundField DataField="ContactCategoryNames" HeaderText="ContactCategory Name" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="WhatsappNo" HeaderText="Whatsapp No" />
                                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
                                <asp:BoundField DataField="Age" HeaderText="Age" />
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                                <asp:BoundField DataField="StateName" HeaderText="State Name" />
                                <asp:BoundField DataField="CityName" HeaderText="City Name" />
                                <asp:BoundField DataField="FacebookID" HeaderText="Facebook ID" />
                                <asp:BoundField DataField="LinkdlNID" HeaderText="LinkedIN ID" />
                                <asp:BoundField DataField="Address" HeaderText="Address" />

                                <%--<asp:BoundField DataField="ContactFilePath" HeaderText="File"/>--%>
                                <%--<asp:BoundField DataField ="CreationDate" HeaderText ="Creation Date" />--%>

                                
                                <asp:BoundField DataField="FileSize" HeaderText="File Size" />
                                <asp:BoundField DataField="FileType" HeaderText="File Type" />

                            </Columns>

                          

                        </asp:GridView>
                    </div>


                    <br />
                </div>
            </div>

        </div>

    </div>
</asp:Content>

