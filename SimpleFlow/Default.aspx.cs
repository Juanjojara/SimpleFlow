using System;
using SocialConnector;

namespace SimpleFlow
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                if (Object.ReferenceEquals(Request.QueryString["code"], null))
                {
                    if (Object.ReferenceEquals(Session["fbApi"], null))
                    {
                        InitializeApp();
                    }
                }
                else
                {
                    FacebookConnector fbApi = (FacebookConnector)Session["fbApi"];
                    if (Object.ReferenceEquals(Session["token"], null))
                    {
                        fbApi.connectApp(Request.QueryString["code"], null);
                        Session["token"] = fbApi.AccessToken;
                    }
                    else
                    {
                        fbApi.connectApp(Request.QueryString["code"], Session["token"].ToString());
                    }

                    FacebookUser fbCurrentUser = fbApi.GetUserInfo(true);
                    Users currentUser = new Users();
                    currentUser.SNUserId = fbCurrentUser.UserID;
                    currentUser.UserName = fbCurrentUser.UserName;
                    currentUser.UserType = "facebook";
                    Session["user"] = currentUser;
                    if (Object.ReferenceEquals(Session["nextPage"], null))
                    {
                        Server.Transfer("Design.aspx");
                    }
                    else
                    {
                        Server.Transfer(Session["nextPage"].ToString());
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(Session["fbApi"], null))
            {
                Server.Transfer("Error.aspx");
            }
            else
            {
                FacebookConnector fbApi = (FacebookConnector)Session["fbApi"];

                String link = @"https://www.facebook.com/dialog/oauth?client_id=" + fbApi.ApplicationID + "&redirect_uri=" +
                    fbApi.RedirectURL + "&scope=user_photos,friends_photos,user_birthday,friends_birthday,user_relationships,friends_relationships," +
                    "user_hometown,friends_hometown,user_location,friends_location,user_likes,friends_likes,publish_stream,read_stream";
                Session["token"] = null;
                Session["nextPage"] = "Design.aspx";
                Response.Redirect(link);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            dbHelper helper = new dbHelper();
            Users currentUser = new Users();
            currentUser = helper.GetTestUser();
            Session["user"] = currentUser;

            Server.Transfer("Design.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(Session["fbApi"], null))
            {
                Server.Transfer("Error.aspx");
            }
            else
            {
                FacebookConnector fbApi = (FacebookConnector)Session["fbApi"];

                String link = @"https://www.facebook.com/dialog/oauth?client_id=" + fbApi.ApplicationID + "&redirect_uri=" +
                    fbApi.RedirectURL + "&scope=user_photos,friends_photos,user_birthday,friends_birthday,user_relationships,friends_relationships," +
                    "user_hometown,friends_hometown,user_location,friends_location,user_likes,friends_likes,publish_stream,read_stream";
                Session["token"] = null;
                Session["nextPage"] = "Excel.aspx";
                Response.Redirect(link);
            }
        }

        private void InitializeApp()
        {
            dbHelper helper = new dbHelper();
            ApplicationInfo appInfo = helper.GetAppInfo();

            FacebookConnector fbApi = new FacebookConnector(appInfo.ApplicationURL, appInfo.ApplicationId, appInfo.RedirectURL, appInfo.ApplicationSecret, appInfo.PageId, appInfo.ApplicationAT, appInfo.PageOwnerId);
            Session["fbApi"] = fbApi;
        }
    }
}