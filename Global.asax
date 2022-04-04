<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{resource}.axd/{*pathInfo}");

        routes.MapPageRoute("AdminPanelCountryList",
            "AdminPanel/Country/List",
            "~/AdminPanel/Country/CountryList.aspx");
        routes.MapPageRoute("AdminPanelCountryAdd",
            "AdminPanel/Country/Add",
            "~/AdminPanel/Country/CountryAddEdit.aspx");
        routes.MapPageRoute("AdminPanelCountryEdit",
            "AdminPanel/Country/Edit/{CountryID}",
            "~/AdminPanel/Country/CountryAddEdit.aspx");


        routes.MapPageRoute("AdminPanelStateList",
                            "AdminPanel/State/List",
                            "~/AdminPanel/State/StateList.aspx");
        routes.MapPageRoute("AdminPanelStateAdd",
            "AdminPanel/State/Add",
            "~/AdminPanel/State/StateAddEdit.aspx");
        routes.MapPageRoute("AdminPanelStateEdit",
            "AdminPanel/State/Edit/{StateID}",
            "~/AdminPanel/State/StateAddEdit.aspx");

        routes.MapPageRoute("AdminPanelCityList",
                            "AdminPanel/City/List",
                            "~/AdminPanel/City/CityList.aspx");
        routes.MapPageRoute("AdminPanelCityAdd",
            "AdminPanel/City/Add",
            "~/AdminPanel/City/CityAddEdit.aspx");
        routes.MapPageRoute("AdminPanelCityEdit",
            "AdminPanel/City/Edit/{CityID}",
            "~/AdminPanel/City/CityAddEdit.aspx");

        routes.MapPageRoute("AdminPanelContactCategoryList",
                            "AdminPanel/ContactCategory/List",
                            "~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
        routes.MapPageRoute("AdminPanelContactCategoryAdd",
            "AdminPanel/ContactCategory/Add",
            "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");
        routes.MapPageRoute("AdminPanelContactCategoryEdit",
            "AdminPanel/ContactCategory/Edit/{ContactCategoryID}",
            "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");

        routes.MapPageRoute("AdminPanelContactList",
                            "AdminPanel/Contact/List",
                            "~/AdminPanel/Contact/ContactList.aspx");
        routes.MapPageRoute("AdminPanelContactAdd",
            "AdminPanel/Contact/Add",
            "~/AdminPanel/Contact/ContactAddEdit.aspx");
        routes.MapPageRoute("AdminPanelContactEdit",
            "AdminPanel/Contact/Edit/{ContactID}",
            "~/AdminPanel/Contact/ContactAddEdit.aspx");

        //1. String - routeName : AdminPanelCountryList
        //2. string - routeURL : AdminPanel/Country/List
        //3. string - physicalFile : ~/AdminPanel/Country/CountryList.aspx

        // ~/AdminPanel/Country/CountryList.aspx
        // AdminPanel/Country/List
    }

</script>
