using System;

namespace SimpleFlow
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonStart_Click(object sender, EventArgs e)
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
                FlowInstances flowInstance = helper.GetFlowInstanceById(currentFlow.FlowInstanceId);

                flowInstance.CurrentPosition++;
                flowInstance.Actions = next;
                helper.UpdateChanges();

                Session["currentInstance"] = flowInstance;
                Server.Transfer(flowInstance.Actions.ActionPage);
            }
        }
    }
}