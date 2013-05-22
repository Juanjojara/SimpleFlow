using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SimpleFlow
{
    public partial class UseCase : System.Web.UI.Page
    {
        DataTable dtUseCases;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtUseCases = new DataTable();
                MakeDataTable();
                AddUseCases();
                BindGrid();

                if (!Object.ReferenceEquals(Session["user"], null))
                {
                    Users curUser = (Users)Session["user"];
                    TextBoxUser.Text = curUser.UserName;
                }
            }
        }

        private void MakeDataTable()
        {
            dtUseCases.Columns.Add("Title");
            dtUseCases.Columns.Add("Description");
        }

        private void AddToDataTable(String title, String description)
        {
            DataRow dr = dtUseCases.NewRow();
            dr["Title"] = title;
            dr["Description"] = description;
            dtUseCases.Rows.Add(dr);
        }

        private void BindGrid()
        {
            GridView1.DataSource = dtUseCases;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Page.IsValid)
            {
                if (e.CommandName == "Select")
                {
                    Users newUser;
                    dbHelper helper = new dbHelper();
                    newUser = helper.GetUserbyName(TextBoxUser.Text);
                    if (newUser == null)
                    {
                        newUser = new Users();
                        newUser.UserName = TextBoxUser.Text;
                        newUser.UserType = "local";
                        newUser.SNUserId = "local" + TextBoxUser.Text;
                        helper.AddToModel(newUser);
                    }
                    Session["user"] = newUser;

                    WebControl wc = e.CommandSource as WebControl;
                    GridViewRow row = wc.NamingContainer as GridViewRow;
                    Session["UseCaseStartTime"] = DateTime.Now;
                    Session["UseCaseNumber"] = row.RowIndex + 1;
                    Session["UseCaseText"] = row.Cells[1].Text;

                    Server.Transfer("Design.aspx");
                }
            }
        }

        private void AddUseCases()
        {
            AddToDataTable("Free Design", "Implement a process that meet your needs. Give it a meaningful name when saving.");
            AddToDataTable("Photo Story", "The application should first ask the user to upload a photo, next add a location to it, specify the approximate date of the picture and then describe it. Finally, disseminate the task either by sharing it through Facebook or by using other means.");
            AddToDataTable("Contribute and Participate in the contest", "Implement a web application that allows users to post content on Facebook (usually a message, a photo or a video). If possible, post the content on a specific album. After that the application should use some kind of dissemination to promote the contest, for example it could post on the user’s wall that he is participating in the contest and that he needs the help of his friends to win.");
            AddToDataTable("Vote for your favorite", "Implement a web application that presents to the user with a list of objects from Facebook (messages, photos or videos) and ask him to vote for one of them according to some specific criteria. Usually this is done either by liking or commenting the selected object. After that is usually required to use some method for promoting the contest like posting something on the user’s wall or to some of his friend’s wall.");
            AddToDataTable("Pick winners for the contest", "Implement a process that takes a list of objects from Facebook (list of photos from an album or list of comments from a post) and selects the most commented or most liked object from them. This will be the winner of the contest. The process should notify the winner by posting a message on his wall. The process could also do a random pick of a given number of objects to award them secondary prizes and then repeat the notification process for these other winners.");
        }

    }
}