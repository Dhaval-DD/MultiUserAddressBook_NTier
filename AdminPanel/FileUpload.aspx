<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="AdminPanel_FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="fuFile" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div><br/>
        <div>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"  />
        </div>
        <div>
            <asp:Label runat="server" ID="lblMsg"></asp:Label>
        </div>

    </form>
</body>
</html>
