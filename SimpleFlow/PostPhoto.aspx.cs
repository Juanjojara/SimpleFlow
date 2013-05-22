using System;

namespace SimpleFlow
{
    public partial class PostPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            if (Session["currentInstance"] == null)
                Server.Transfer("Error.aspx");

            dbHelper helper = new dbHelper();
            FlowInstances currentFlow = (FlowInstances)Session["currentInstance"];
            Actions next = helper.GetNextAction(currentFlow.Flows.FlowId, currentFlow.CurrentPosition);
            if (next == null)
            {
                Server.Transfer("End.aspx");
            }
            else
            {
                currentFlow.CurrentPosition++;
                currentFlow.Actions = next;
                helper.UpdateChanges();

                Session["currentInstance"] = currentFlow;
                Server.Transfer(currentFlow.Actions.ActionPage);
            }
        }
    }
}