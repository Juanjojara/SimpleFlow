using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace SimpleFlow
{
    public partial class Design : System.Web.UI.Page
    {
        DataTable dt;
        DataTable dtOptions;
        DataTable dtImports;
        //DataTable dtImportedResources;
        //DataTable dtFlowActionOptions;

        List<FlowActionOptions> _listFlowActOpt;
        List<FlowActionInputs> _listFlowActInput;
        List<FlowActionOutputs> _listFlowActOutput;
        List<ActionOptions> _listActOpt;
        List<FlowMultiOptions> _listFlowMultiOpt;

        int _useCaseNumber;
        DateTime _useCaseStartTime;

        Users _user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                MakeDataTable();

                String lastNode = null;
                SetActionGrid(lastNode);

                dtOptions = new DataTable();
                MakeDataTableOptions();
                AddToDataTableOptions("Add Options...");
                BindGridOptions();

                dtImports = new DataTable();
                MakeDataTableImports();

                _listFlowActOpt = new List<FlowActionOptions>();
                _listFlowActInput = new List<FlowActionInputs>();
                _listFlowActOutput = new List<FlowActionOutputs>();
                _listActOpt = new List<ActionOptions>();
                _listFlowMultiOpt = new List<FlowMultiOptions>();

                if (!Object.ReferenceEquals(Session["user"], null))
                {
                    _user = (Users)Session["user"];
                }
                else
                {
                    dbHelper helper = new dbHelper();
                    _user = helper.GetTestUser();
                }

                if (!Object.ReferenceEquals(Session["UseCaseNumber"], null))
                {
                    _useCaseNumber = (int)Session["UseCaseNumber"];
                }
                else
                {
                    _useCaseNumber = 0;
                }
                if (!Object.ReferenceEquals(Session["UseCaseStartTime"], null))
                {
                    _useCaseStartTime = (DateTime)Session["UseCaseStartTime"];
                }
                else
                {
                    _useCaseStartTime = DateTime.Now;
                }
                if (!Object.ReferenceEquals(Session["UseCaseText"], null))
                {
                    LabelUseCaseTooltip.Text = (String)Session["UseCaseText"];
                }
                else
                {
                    LabelUseCaseTooltip.Text = "Implement a process that meet your needs. Give it a meaningful name when saving.";
                }
                //Panel1.Visible = false;
            }
            else
            {
                dt = (DataTable)ViewState["MainFlow"];
                dtOptions = (DataTable)ViewState["TableOptions"];
                dtImports = (DataTable)ViewState["DataImports"];
                _listFlowActOpt = (List<FlowActionOptions>)ViewState["FlowActionOptions"];
                _listFlowActInput = (List<FlowActionInputs>)ViewState["FlowActionInputs"];
                _listFlowActOutput = (List<FlowActionOutputs>)ViewState["FlowActionOutputs"];
                _listActOpt = (List<ActionOptions>)ViewState["ActionOptions"];
                _listFlowMultiOpt = (List<FlowMultiOptions>)ViewState["FlowMultiOptions"];

                _user = (Users)Session["user"];
                _useCaseNumber = (int)Session["UseCaseNumber"];
                _useCaseStartTime = (DateTime)Session["UseCaseStartTime"];
                //Panel1.Visible = false;
            }

            ViewState["MainFlow"] = dt;
            ViewState["TableOptions"] = dtOptions;
            ViewState["DataImports"] = dtImports;
            ViewState["FlowActionOptions"] = _listFlowActOpt;
            ViewState["FlowActionInputs"] = _listFlowActInput;
            ViewState["FlowActionOutputs"] = _listFlowActOutput;
            ViewState["ActionOptions"] = _listActOpt;
            ViewState["FlowMultiOptions"] = _listFlowMultiOpt;
            //String selectedId = GridView1.DataKeys[row.RowIndex].Value.ToString();
            Session["user"] = _user;
            Session["UseCaseNumber"] = _useCaseNumber;
            Session["UseCaseStartTime"] = _useCaseStartTime;
        }

        #region DataTable Flow
        private void MakeDataTable()
        {
            dt.Columns.Add("Name");
            dt.Columns.Add("Id");
            dt.Columns.Add("Input");
            dt.Columns.Add("InputType");
            dt.Columns.Add("Step");
            dt.Columns.Add("Output");
        }

        private void AddToDataTable(String name, String id, String input, int step, String output)
        {
            String inputMsg;
            if (input != String.Empty)
            {
                inputMsg = "Select a " + input + " item";
                name = name + " [???]";
            }
            else
            {
                inputMsg = input;
            }
            DataRow dr = dt.NewRow();
            dr["Name"] = name;
            dr["Id"] = id;
            dr["Input"] = inputMsg;
            dr["InputType"] = input;
            dr["Step"] = step;
            dr["Output"] = output;
            dt.Rows.Add(dr);
        }

        private void BindGrid()
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        #endregion

        #region DataTable Options
        private void MakeDataTableOptions()
        {
            dtOptions.Columns.Add("Option");
        }

        private void AddToDataTableOptions(String opt)
        {
            DataRow drOption = dtOptions.NewRow();
            drOption["Option"] = opt;
            dtOptions.Rows.Add(drOption);
        }

        private void BindGridOptions()
        {
            GridViewOptions.DataSource = dtOptions;
            GridViewOptions.DataBind();
        }
        #endregion

        #region DataTable Imports
        private void MakeDataTableImports()
        {
            dtImports.Columns.Add("objectURL");
            dtImports.Columns.Add("objectType");
            dtImports.Columns.Add("objectPosition");
        }

        private void AddToDataTableImports(String objUrl, String objType, int objPos)
        {
            DataRow dr = dtImports.NewRow();
            dr["objectURL"] = objUrl;
            dr["objectType"] = objType;
            dr["objectPosition"] = objPos;
            dtImports.Rows.Add(dr);
        }

        private void BindGridImports()
        {
            GridViewImports.DataSource = dtImports;
            GridViewImports.DataBind();
        }
        #endregion

        protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // If multiple buttons are used in a GridView control, use the
            // CommandName property to determine which button was clicked.
            if (Page.IsValid)
            {
                if (e.CommandName == "Select")
                {
                    WebControl wc = e.CommandSource as WebControl;
                    Button pressedButton = e.CommandSource as Button;
                    GridViewRow row = wc.NamingContainer as GridViewRow;

                    String selectedId = GridView1.DataKeys[row.RowIndex].Value.ToString();

                    AddToDataTable(pressedButton.Text, selectedId, GetActionInput(selectedId), dt.Rows.Count + 1, GetActionOutput(selectedId));
                    BindGrid();

                    if (dt.Rows.Count > 1)
                    {
                        SaveActionOptions(dt.Rows.Count - 1);
                    }

                    if (GridView1.Rows.Count > 0)
                    {
                        SetActionGrid(selectedId);
                    }

                    PrepareViews(selectedId);
                    LoadActionOptions(selectedId);
                    SetRadioControlStyles();
                    ButtonRight.Text = "Show Imports";
                    MultiViewRight.SetActiveView(ViewOptions);
                }
            }
        }

        protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Image img = (Image)e.Row.FindControl("imgID");

            //    switch (img.ToolTip)
            //    {
            //        case "USER": img.ImageUrl = "Images/user-male.png";
            //            break;
            //        case "FRIEND": img.ImageUrl = "Images/users.png";
            //            break;
            //        case "START": img.ImageUrl = "Images/power.png";
            //            break;
            //        case "END": img.ImageUrl = "Images/flag.png";
            //            break;
            //        case "MONITOR": img.ImageUrl = "Images/monitor.png";
            //            break;
            //        case "PHOTO": img.ImageUrl = "Images/camera.png";
            //            break;
            //    }
            //}
        }

        private void SetActionGrid(String LastNode)
        {
            String whereClause = String.Empty;
            dbHelper helper = new dbHelper();
            List<String> nextNodes = helper.GetNextNodes(LastNode);
            foreach (String itemNode in nextNodes)
            {
                whereClause += " it.[ActionId] = '" + itemNode + "' OR";
            }
            whereClause = whereClause.Substring(0, whereClause.Length - 2);
            SimpleFlowDS.Where = whereClause;
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            BindGrid();
            SetActionGrid(null);

            dtOptions.Clear();
            AddToDataTableOptions("Add Options...");
            BindGridOptions();

            _listFlowActOpt.Clear();
            _listFlowActInput.Clear();
            _listFlowActOutput.Clear();
            _listActOpt.Clear();
            _listFlowMultiOpt.Clear();

            MultiViewGeneral.ActiveViewIndex = -1;
            ButtonRight.Text = "Show Imports";
            MultiViewRight.SetActiveView(ViewOptions);

        }

        protected void ButtonUndo_Click(object sender, EventArgs e)
        {
            if (GridView2.Rows.Count > 0)
            {
                _listFlowActOpt.RemoveAll(f => f.FlowPosition == (dt.Rows.Count));
                _listFlowActInput.RemoveAll(f => f.FlowPosition == (dt.Rows.Count));
                _listFlowActOutput.RemoveAll(f => f.FlowPosition == (dt.Rows.Count));
                if (_listFlowMultiOpt.RemoveAll(f => f.FlowPosition == (dt.Rows.Count)) > 0)
                {
                    dtOptions.Clear();
                    AddToDataTableOptions("Add Options...");
                    BindGridOptions();
                }
                dt.Rows.RemoveAt(dt.Rows.Count - 1);
                BindGrid();
            }
            //IS IMPORTANT TO KEEP IN 2 IFs, The first modifies the row number, so the second needs to check again
            if (GridView2.Rows.Count > 0)
            {
                String lastNode = dt.Rows[dt.Rows.Count - 1].Field<String>("Id");
                SetActionGrid(lastNode);
                PrepareViews(lastNode);
                LoadPreviousActionOptions(lastNode);
                SetRadioControlStyles();
            }
            ButtonRight.Text = "Show Imports";
            MultiViewRight.SetActiveView(ViewOptions);
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Flows curflow = SaveFlow();
            }
        }

        protected void ButtonPlay_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (dt.Rows.Count > 0)
                {
                    Flows playflow = SaveFlow();
                    if (playflow != null)
                    {
                        FlowInstances currentFlow = new FlowInstances();
                        dbHelper helper = new dbHelper();
                        DataRow firstRow = dt.Rows[0];
                        Actions startAction = helper.GetActionById(firstRow["Id"].ToString());

                        currentFlow.Actions = startAction;
                        currentFlow.CurrentPosition = 1;
                        currentFlow.Users = playflow.Users;
                        currentFlow.Flows = playflow;
                        helper.AddToModel(currentFlow);

                        Session["currentInstance"] = currentFlow;
                        Server.Transfer(currentFlow.Actions.ActionPage);
                    }
                }
            }
        }

        private Flows SaveFlow()
        {
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            dbHelper helper = new dbHelper();
            bool isUpdate = true;
            FlowActionOptions fao;
            FlowActionInputs faIn;
            FlowActionOutputs faOut;
            FlowMultiOptions fmo;
            ActionOptions actOpt;
            ActionInputs actInput;
            ActionOutputs actOutput;
            Users flowUser = helper.GetUserbyName(_user.UserName);
            Flows myflow = helper.GetFlowByName(TextBox1.Text, flowUser);
            if (myflow == null)
            {
                myflow = new Flows();
                myflow.FlowName = TextBox1.Text;
                myflow.Users = flowUser;
                myflow.FlowUseCaseNumber = _useCaseNumber;
                myflow.FlowStartTime = _useCaseStartTime;
                myflow.FlowEndTime = DateTime.Now;
                isUpdate = false;
            }
            else
            {
                myflow.FlowEndTime = DateTime.Now;
                helper.DeleteFlowDetailsById(myflow.FlowId);
            }

            int rowCount = 0;

            FlowActions flowAction;
            Actions curAction;
            foreach (DataRow gridRow in dt.Rows)
            {
                rowCount++;
                curAction = helper.GetActionById(gridRow["Id"].ToString());
                flowAction = new FlowActions();
                flowAction.Actions = curAction;
                flowAction.Position = rowCount;
                myflow.FlowActions.Add(flowAction);
            }

            SaveActionOptions(dt.Rows.Count);
            foreach (FlowActionOptions itemFlowActOpt in _listFlowActOpt)
            {
                fao = new FlowActionOptions();
                actOpt = helper.GetActionOptionById(itemFlowActOpt.ActionOptions.ActionOptionId);
                fao.ActionOptions = actOpt;
                fao.FlowPosition = itemFlowActOpt.FlowPosition;
                fao.Value = itemFlowActOpt.Value;
                myflow.FlowActionOptions.Add(fao);
            }
            foreach (FlowActionInputs itemFlowActIn in _listFlowActInput)
            {
                faIn = new FlowActionInputs();
                actInput = helper.GetActionInputById(itemFlowActIn.ActionInputs.InputId);
                faIn.ActionInputs = actInput;
                faIn.FlowPosition = itemFlowActIn.FlowPosition;
                faIn.Value = itemFlowActIn.Value;
                myflow.FlowActionInputs.Add(faIn);
            }
            foreach (FlowActionOutputs itemFlowActOut in _listFlowActOutput)
            {
                faOut = new FlowActionOutputs();
                actOutput = helper.GetActionOutputById(itemFlowActOut.ActionOutputs.OutputId);
                faOut.ActionOutputs = actOutput;
                faOut.FlowPosition = itemFlowActOut.FlowPosition;
                faOut.Value = itemFlowActOut.Value;
                myflow.FlowActionOutputs.Add(faOut);
            }

            foreach (FlowMultiOptions itemFlowMultiOpt in _listFlowMultiOpt)
            {
                fmo = new FlowMultiOptions();
                fmo.FlowPosition = itemFlowMultiOpt.FlowPosition;
                fmo.OptionValue = itemFlowMultiOpt.OptionValue;
                myflow.FlowMultiOptions.Add(fmo);
            }
            if (isUpdate)
            {
                helper.UpdateChanges();
            }
            else
            {
                helper.AddToModel(myflow);
            }

            return myflow;
        }

        public String GetActionInput(String actionId)
        {
            dbHelper helper = new dbHelper();
            List<ActionInputs> inputs = helper.GetActionInputsForAction(actionId);
            if (inputs.Count > 0)
                return inputs[0].InputObject;
            else
                return String.Empty;
        }

        public String GetActionOutput(String actionId)
        {
            dbHelper helper = new dbHelper();
            List<ActionOutputs> outputs = helper.GetActionOutputsForAction(actionId);
            if (outputs.Count > 0)
                return outputs[0].OutputObject;
            else
                return String.Empty;
        }

        private void PrepareViews(String taskId)
        {
            MultiViewGeneral.SetActiveView(ViewGeneral);
            switch (taskId)
            {
                case "USR001": MultiViewSpecific.SetActiveView(ViewUserProfile);
                    break;
                case "USR002": MultiViewSpecific.SetActiveView(ViewPostMessage);
                    break;
                case "USR007": MultiViewSpecific.SetActiveView(ViewPostPhotoFromAlbum);
                    break;
                case "FRN002": MultiViewSpecific.SetActiveView(ViewUserProfile);
                    break;
                case "FRN003": MultiViewSpecific.SetActiveView(ViewPostMessage);
                    break;
                case "FRN005": MultiViewSpecific.SetActiveView(ViewSelectX);
                    break;
                case "FRN006": MultiViewSpecific.SetActiveView(ViewSelectX);
                    break;
                case "FRN007": MultiViewSpecific.SetActiveView(ViewSelectX);
                    break;
                case "FRN008": MultiViewSpecific.SetActiveView(ViewPostPhotoFromAlbum);
                    break;
                case "PHT002": MultiViewSpecific.SetActiveView(ViewPostPhotoFromAlbum);
                    break;
                case "PHT003": MultiViewSpecific.SetActiveView(ViewPhotoProfile);
                    break;
                case "PHT004": MultiViewSpecific.SetActiveView(ViewPostPhotoFromAlbum);
                    break;
                case "PHT005": MultiViewSpecific.SetActiveView(ViewSelectX);
                    break;
                case "PHT006": MultiViewSpecific.SetActiveView(ViewSelectX);
                    break;
                case "PHT007": MultiViewSpecific.SetActiveView(ViewPostComment);
                    break;
                case "PHT008": MultiViewSpecific.SetActiveView(ViewLikeObject);
                    break;
                case "PHT009": MultiViewSpecific.SetActiveView(ViewTagPhoto);
                    break;
                case "ALB002": MultiViewSpecific.SetActiveView(ViewAlbumProfile);
                    break;
                case "ALB006": MultiViewSpecific.SetActiveView(ViewPostComment);
                    break;
                case "ALB007": MultiViewSpecific.SetActiveView(ViewLikeObject);
                    break;
                case "COM001": MultiViewSpecific.SetActiveView(ViewGetComments);
                    break;
                case "COM002": MultiViewSpecific.SetActiveView(ViewGetComments);
                    break;
                case "COM003": MultiViewSpecific.SetActiveView(ViewGetComments);
                    break;
                case "COM004": MultiViewSpecific.SetActiveView(ViewGetComments);
                    break;
                case "COM005": MultiViewSpecific.SetActiveView(ViewCommentProfile);
                    break;
                case "COM006": MultiViewSpecific.SetActiveView(ViewLikeObject);
                    break;
                case "COM007": MultiViewSpecific.SetActiveView(ViewSelectX);
                    break;
                case "COM008": MultiViewSpecific.SetActiveView(ViewSelectX);
                    break;
                default: MultiViewSpecific.ActiveViewIndex = -1;
                    break;

                //USR003, USR004, USR005, USR006
                //FRN001, FRN004
                //MON001, MON002
                //PHT001, PHT010, PHT011
                //ALB001, ALB003, ALB004, ALB005, ALB008, ALB009
                //COM009
            }
        }

        protected void ButtonOption_Click(object sender, EventArgs e)
        {
            if (dtOptions.Rows[0].ItemArray[0].ToString() == "Add Options...")
            {
                dtOptions.Rows.RemoveAt(0);
            }
            AddToDataTableOptions(TextBoxOption.Text);
            BindGridOptions();
            SetRadioControlStyles();
            TextBoxOption.Focus();
        }

        protected void GridViewOptions_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // If multiple buttons are used in a GridView control, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Delete")
            {
                //WebControl wcOptions = e.CommandSource as WebControl;
                int index = Convert.ToInt32(e.CommandArgument);
                //Button pressedButtonOptions = e.CommandSource as Button;
                //GridViewRow row = wcOptions.NamingContainer as GridViewRow;
                //dtOptions.Rows.RemoveAt(row.RowIndex);
                dtOptions.Rows.RemoveAt(index);

                if (dtOptions.Rows.Count == 0)
                {
                    AddToDataTableOptions("Add Options...");
                }
                BindGridOptions();
            }
            SetRadioControlStyles();
        }

        private void SaveActionOptions(int position)
        {
            FlowActionOptions fao;
            FlowActionInputs faIn;
            FlowActionOutputs faOut;
            TextBox tx;
            CheckBox ck;
            RadioButtonList rd;
            DropDownList dd;
            _listFlowActOpt.RemoveAll(f => f.FlowPosition == position);
            _listFlowActInput.RemoveAll(f => f.FlowPosition == position);
            _listFlowActOutput.RemoveAll(f => f.FlowPosition == position);

            if (MultiViewSpecific.GetActiveView() == ViewPostMessage)
                rd = RadioButtonListPostMessage;
            else
                rd = RadioButtonListPostComment;
            foreach (ActionOptions itemActOpt in _listActOpt)
            {
                if (itemActOpt.ControlName != null)
                {
                    fao = new FlowActionOptions();
                    fao.ActionOptions = itemActOpt;
                    fao.FlowPosition = position;
                    switch (itemActOpt.Options.OptionType)
                    {
                        case "textbox":
                            tx = (TextBox)FindControl(itemActOpt.ControlName);
                            if (tx != null)
                            {
                                fao.Value = tx.Text;
                            }
                            break;
                        case "check":
                            ck = (CheckBox)FindControl(itemActOpt.ControlName);
                            if (ck != null)
                            {
                                if (ck.Checked)
                                    fao.Value = "true";
                                else
                                    fao.Value = "false";
                            }
                            break;
                        case "radio":
                            if (rd.SelectedValue == itemActOpt.ControlName)
                                fao.Value = "true";
                            else
                                fao.Value = "false";

                            if (itemActOpt.ControlName == "MultOptCom" && fao.Value == "true")
                            {
                                FlowMultiOptions fmo;
                                _listFlowMultiOpt.RemoveAll(fm => fm.FlowPosition == position);
                                foreach (DataRow itemMultiOpt in dtOptions.Rows)
                                {
                                    fmo = new FlowMultiOptions();
                                    fmo.FlowPosition = position;
                                    fmo.OptionValue = itemMultiOpt["Option"].ToString();
                                    _listFlowMultiOpt.Add(fmo);
                                }
                                if (dt.Rows.Count != position)
                                {
                                    dtOptions.Clear();
                                    AddToDataTableOptions("Add Options...");
                                    BindGridOptions();
                                }
                            }
                            break;
                        case "dropdown":
                            dd = (DropDownList)FindControl(itemActOpt.ControlName);
                            if (dd != null)
                            {
                                fao.Value = dd.SelectedValue;
                            }
                            break;
                    }
                    _listFlowActOpt.Add(fao);
                }
            }
            dbHelper helper = new dbHelper();
            if (dt.Rows[position - 1].Field<String>("Input") != String.Empty)
            {
                List<ActionInputs> inputs = helper.GetActionInputsForAction(dt.Rows[position - 1].Field<String>("Id"));
                faIn = new FlowActionInputs();
                faIn.FlowPosition = position;
                faIn.ActionInputs = inputs[0];
                faIn.Value = dt.Rows[position - 1].Field<String>("Input");
                _listFlowActInput.Add(faIn);
            }
            if (dt.Rows[position - 1].Field<String>("Output") != String.Empty)
            {
                List<ActionOutputs> outputs = helper.GetActionOutputsForAction(dt.Rows[position - 1].Field<String>("Id"));
                faOut = new FlowActionOutputs();
                faOut.FlowPosition = position;
                faOut.ActionOutputs = outputs[0];
                faOut.Value = dt.Rows[position - 1].Field<String>("Output");
                _listFlowActOutput.Add(faOut);
            }
        }

        private void LoadActionOptions(String actionId)
        {
            dbHelper helper = new dbHelper();
            _listActOpt.Clear();
            _listActOpt = helper.GetActionOptionsForAction(actionId);

            TextBox tx;
            CheckBox ck;
            RadioButtonList rd;
            DropDownList dd;

            if (MultiViewSpecific.GetActiveView() == ViewPostMessage)
                rd = RadioButtonListPostMessage;
            else
                rd = RadioButtonListPostComment;
            foreach (ActionOptions itemActOpt in _listActOpt)
            {
                if (itemActOpt.ControlName != null)
                {
                    switch (itemActOpt.Options.OptionType)
                    {
                        case "textbox":
                            tx = (TextBox)FindControl(itemActOpt.ControlName);
                            if (tx != null)
                            {
                                tx.Text = itemActOpt.DefaultValue;
                            }
                            break;
                        case "check":
                            ck = (CheckBox)FindControl(itemActOpt.ControlName);
                            if (ck != null)
                            {
                                if (itemActOpt.DefaultValue == "true")
                                    ck.Checked = true;
                                else
                                    ck.Checked = false;
                            }
                            break;
                        case "radio":
                            if (itemActOpt.DefaultValue == "true")
                                rd.SelectedValue = itemActOpt.ControlName;
                            break;
                        case "dropdown":
                            dd = (DropDownList)FindControl(itemActOpt.ControlName);
                            if (dd != null)
                            {
                                dd.SelectedValue = itemActOpt.DefaultValue;
                            }
                            break;
                    }
                }
            }
            ViewState["ActionOptions"] = _listActOpt;
        }

        private void LoadPreviousActionOptions(String actionId)
        {
            dbHelper helper = new dbHelper();
            _listActOpt.Clear();
            _listActOpt = helper.GetActionOptionsForAction(actionId);

            ActionOptions itemActOpt;
            TextBox tx;
            CheckBox ck;
            RadioButtonList rd;
            DropDownList dd;

            if (MultiViewSpecific.GetActiveView() == ViewPostMessage)
                rd = RadioButtonListPostMessage;
            else
                rd = RadioButtonListPostComment;
            foreach (FlowActionOptions itemFlowActOpt in _listFlowActOpt)
            {
                if (itemFlowActOpt.FlowPosition == dt.Rows.Count)
                {
                    itemActOpt = itemFlowActOpt.ActionOptions;
                    if (itemActOpt.ControlName != null)
                    {
                        switch (itemActOpt.Options.OptionType)
                        {
                            case "textbox":
                                tx = (TextBox)FindControl(itemActOpt.ControlName);
                                if (tx != null)
                                {
                                    tx.Text = itemFlowActOpt.Value;
                                }
                                break;
                            case "check":
                                ck = (CheckBox)FindControl(itemActOpt.ControlName);
                                if (ck != null)
                                {
                                    if (itemFlowActOpt.Value == "true")
                                        ck.Checked = true;
                                    else
                                        ck.Checked = false;
                                }
                                break;
                            case "radio":
                                if (itemFlowActOpt.Value == "true")
                                    rd.SelectedValue = itemActOpt.ControlName;
                                if (itemActOpt.ControlName == "MultOptCom" && itemFlowActOpt.Value == "true")
                                {
                                    dtOptions.Clear();
                                    foreach (FlowMultiOptions itemFlowMultiOpt in _listFlowMultiOpt)
                                    {
                                        if (itemFlowMultiOpt.FlowPosition == dt.Rows.Count)
                                        {
                                            AddToDataTableOptions(itemFlowMultiOpt.OptionValue);
                                        }
                                    }
                                    BindGridOptions();
                                }

                                break;
                            case "dropdown":
                                dd = (DropDownList)FindControl(itemActOpt.ControlName);
                                if (dd != null)
                                {
                                    dd.SelectedValue = itemFlowActOpt.Value;
                                }
                                break;
                        }
                    }
                }
            }
            ViewState["ActionOptions"] = _listActOpt;
        }

        protected void GridViewOptions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btn = (Button)e.Row.FindControl("OutputAction");
                if (btn.Text == String.Empty)
                    btn.Visible = false;
                if (btn.Text != dt.Rows[dt.Rows.Count - 1].Field<String>("InputType"))
                    btn.Enabled = false;
                if (e.Row.RowIndex == dt.Rows.Count - 1)
                    btn.Enabled = false;

                if (btn.Enabled)
                {
                    btn.CssClass = "btn btn-success";
                }

                TableCell tc = e.Row.Cells[0];
                tc.BackColor = System.Drawing.Color.White;
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // If multiple buttons are used in a GridView control, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Select")
            {
                Button btnOutput = e.CommandSource as Button;
                DataRow dr = dt.Rows[dt.Rows.Count - 1];

                WebControl wc = e.CommandSource as WebControl;
                GridViewRow row = wc.NamingContainer as GridViewRow;
                dr["Input"] = "Output" + (row.RowIndex + 1).ToString();
                dr["Name"] = dr["Name"].ToString().Replace("???", "=Output" + (row.RowIndex + 1).ToString());
                //dr["Input"] = btnOutput.Text;
                BindGrid();
            }
        }

        protected void validateOptions_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (RadioButtonListPostComment.SelectedValue == "MultOptCom")
            {
                if (dtOptions.Rows.Count < 2)
                {
                    validateOptions.Text = String.Empty;
                    validateOptions.ErrorMessage = "Please add at least 2 Comment Options";
                    args.IsValid = false;
                }
            }
        }

        private void SetRadioControlStyles()
        {
            if (MultiViewSpecific.GetActiveView() == ViewPostComment)
            {
                switch (RadioButtonListPostComment.SelectedValue)
                {
                    case "MultOptCom":
                        LabelOption.Style["visibility"] = "visible";
                        LabelAppCom.Style["visibility"] = "hidden";
                        TextBoxOption.Style["visibility"] = "visible";
                        TextBoxAppCom.Style["visibility"] = "hidden";
                        ButtonOption.Style["visibility"] = "visible";
                        GridViewOptions.Style["display"] = "block";
                        break;
                    case "OnlyUsrCom":
                        LabelOption.Style["visibility"] = "hidden";
                        LabelAppCom.Style["visibility"] = "hidden";
                        TextBoxOption.Style["visibility"] = "hidden";
                        TextBoxAppCom.Style["visibility"] = "hidden";
                        ButtonOption.Style["visibility"] = "hidden";
                        GridViewOptions.Style["display"] = "none";
                        break;
                    default:
                        LabelOption.Style["visibility"] = "hidden";
                        LabelAppCom.Style["visibility"] = "visible";
                        TextBoxOption.Style["visibility"] = "hidden";
                        TextBoxAppCom.Style["visibility"] = "visible";
                        ButtonOption.Style["visibility"] = "hidden";
                        GridViewOptions.Style["display"] = "none";
                        break;
                }
            }

            if (MultiViewSpecific.GetActiveView() == ViewPostMessage)
            {
                switch (RadioButtonListPostMessage.SelectedValue)
                {
                    case "OnlyUsrMsg":
                        LabelAppMsg.Style["visibility"] = "hidden";
                        TextBoxAppMsg.Style["visibility"] = "hidden";
                        break;
                    default:
                        LabelAppMsg.Style["visibility"] = "visible";
                        TextBoxAppMsg.Style["visibility"] = "visible";
                        break;
                }
            }
        }

        protected void ButtonUseCase_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TextBox1.Text = TextBox1.Text + "NewUseCase";
                Flows curflow = SaveFlow();
                Server.Transfer("UseCase.aspx");
            }
        }

        protected void ButtonQuestionnaire_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TextBox1.Text = TextBox1.Text + "NewUseCase";
                Flows curflow = SaveFlow();
                Response.Write("<script>window.open('https://docs.google.com/spreadsheet/viewform?formkey=dDJfSEJhU0dncVBtYzZrcm0wN21KX3c6MQ','_blank');</script>");
            }
        }

        protected void ButtonObject_Click(object sender, EventArgs e)
        {
            AddToDataTableImports(TextBoxObject.Text, DropDownListObjType.SelectedValue, dtImports.Rows.Count + 1);
            BindGridImports();
        }

        protected void ButtonRight_Click(object sender, EventArgs e)
        {
            if (ButtonRight.Text == "Show Imports")
            {
                ButtonRight.Text = "Hide Imports";
                MultiViewRight.SetActiveView(ViewImports);
                BindGridImports();
            }
            else
            {
                ButtonRight.Text = "Show Imports";
                MultiViewRight.SetActiveView(ViewOptions);
            }
        }

        protected void GridViewImports_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //WebControl wcOptions = e.CommandSource as WebControl;
                int index = Convert.ToInt32(e.CommandArgument);
                //Button pressedButtonOptions = e.CommandSource as Button;
                //GridViewRow row = wcOptions.NamingContainer as GridViewRow;
                //dtOptions.Rows.RemoveAt(row.RowIndex);
                dtImports.Rows.RemoveAt(index);
                BindGridImports();
            }
            if (e.CommandName == "Select")
            {
                Button btnOutput = e.CommandSource as Button;
                DataRow dr = dt.Rows[dt.Rows.Count - 1];

                WebControl wc = e.CommandSource as WebControl;
                GridViewRow row = wc.NamingContainer as GridViewRow;
                dr["Input"] = "Import" + (row.RowIndex + 1).ToString();
                dr["Name"] = dr["Name"].ToString().Replace("???", "=Import" + (row.RowIndex + 1).ToString());
                //dr["Input"] = btnOutput.Text;
                BindGrid();
            }
        }

        protected void GridViewImports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btn = (Button)e.Row.FindControl("ImportObject");
                if (dt.Rows.Count > 0)
                {
                    if (btn.Text != dt.Rows[dt.Rows.Count - 1].Field<String>("InputType"))
                        btn.Enabled = false;
                }
                else
                {
                    btn.Enabled = false;
                }
                if (btn.Enabled)
                {
                    btn.CssClass = "btn btn-success";
                }

                //TableCell tc = e.Row.Cells[0];
                //tc.BackColor = System.Drawing.Color.White;
            }
        }
    }
}