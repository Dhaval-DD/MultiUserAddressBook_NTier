using System;
using System.Collections.Generic;
using System.IO;

public partial class AdminPanel_FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuFile.HasFile)
        {

            //Root/UserContent   -  folderPath
            //E:\💻 COLLAGE\Project\dotNet\MultiUserAddressBook\UserContent\   - absolutePath


            lblMsg.Text = "File is selected" + fuFile.FileName.ToString().Trim();

            String folderPath = "~/UserContent/";
            String absolutePath = Server.MapPath(folderPath);

            lblMsg.Text = "File will be uploaded at the location " + absolutePath;

            if (!Directory.Exists(absolutePath))
                Directory.CreateDirectory(absolutePath);

            fuFile.SaveAs(absolutePath + fuFile.FileName.ToString().Trim());
        }
        else
        {
            lblMsg.Text = "File is not selected";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        String FilePath = "~/UserContent/andrew-riojas-JINHNZ9d9Nc-unsplash.jpg";

        FileInfo File = new FileInfo(Server.MapPath(FilePath));

        if (File.Exists)
        {
            File.Delete();
        }
        else
        {
            lblMsg.Text = "File not available";
        }
    }
}