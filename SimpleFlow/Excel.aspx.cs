using System;
using SocialConnector;

namespace SimpleFlow
{
    public partial class Excel : System.Web.UI.Page
    {
        private FacebookConnector fbApi;
        private Users currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(Session["fbApi"], null))
            {
                Server.Transfer("Error.aspx");
            }

            fbApi = (FacebookConnector)Session["fbApi"];
            if (Object.ReferenceEquals(Session["user"], null))
            {
                currentUser = (Users)Session["user"];
            }

            if (IsPostBack)
            {
            }

            Label1.Text = fbApi.AccessToken;
        }
    }
}