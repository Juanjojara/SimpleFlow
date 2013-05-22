using System;
using System.Collections.Generic;
using System.Data;

namespace SimpleFlow
{
    public partial class SocialDataModel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable panelPopup = new DataTable();
            panelPopup.Columns.Add("Input");
            panelPopup.Columns.Add("Name");
            panelPopup.Columns.Add("Output");

            createActionTable("User", panelPopup);
            GridViewUser.DataSource = panelPopup;
            GridViewUser.DataBind();

            panelPopup.Clear();
            createActionTable("Friend", panelPopup);
            GridViewFriends.DataSource = panelPopup;
            GridViewFriends.DataBind();

            panelPopup.Clear();
            createActionTable("Album", panelPopup);
            GridViewAlbum.DataSource = panelPopup;
            GridViewAlbum.DataBind();

            panelPopup.Clear();
            createActionTable("Photo", panelPopup);
            GridViewPhoto.DataSource = panelPopup;
            GridViewPhoto.DataBind();

            panelPopup.Clear();
            createActionTable("Post", panelPopup);
            GridViewPost.DataSource = panelPopup;
            GridViewPost.DataBind();

            panelPopup.Clear();
            createActionTable("Video", panelPopup);
            GridViewVideo.DataSource = panelPopup;
            GridViewVideo.DataBind();

            panelPopup.Clear();
            createActionTable("Like", panelPopup);
            GridViewLike.DataSource = panelPopup;
            GridViewLike.DataBind();

            panelPopup.Clear();
            createActionTable("Comment", panelPopup);
            GridViewComment.DataSource = panelPopup;
            GridViewComment.DataBind();
        }

        private void createActionTable(String actionType, DataTable dt)
        {
            dbHelper helper = new dbHelper();
            List<ActionInputs> actionsInput;
            List<ActionOutputs> actionsOutput;

            List<Actions> actionsType = helper.GetActionsByType(actionType);
            foreach (Actions itemAction in actionsType)
            {
                actionsInput = helper.GetActionInputsForAction(itemAction.ActionId);
                actionsOutput = helper.GetActionOutputsForAction(itemAction.ActionId);
                DataRow dr = dt.NewRow();
                if (actionsInput.Count > 0)
                    dr["Input"] = actionsInput[0].InputObject;
                else
                    dr["Input"] = String.Empty;
                dr["Name"] = itemAction.ActionName;
                if (actionsOutput.Count > 0)
                    dr["Output"] = actionsOutput[0].OutputObject;
                else
                    dr["Output"] = String.Empty;
                dt.Rows.Add(dr);
            }
        }
    }
}