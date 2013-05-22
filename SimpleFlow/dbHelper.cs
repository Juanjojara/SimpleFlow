using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Objects;
using System.Linq;

namespace SimpleFlow
{
    // Base repository class for entity with simple key
    //public abstract class RepositoryBase<TEntity, TKey> where TEntity : class
    //{
    //    private readonly string _entitySetName;
    //    private readonly string _keyName;

    //    protected ObjectContext Context { get; private set; }
    //    protected System.Data.Objects.ObjectSet<TEntity> ObjectSet { get; private set; }

    //    protected RepositoryBase(ObjectContext context)
    //    {
    //        if (context == null)
    //        {
    //            throw new ArgumentNullException("context");
    //        }

    //        Context = context;
    //        ObjectSet = context.CreateObjectSet<TEntity>();

    //        // Get entity set for current entity type
    //        var entitySet = ObjectSet.EntitySet;
    //        // Build full name of entity set for current entity type
    //        _entitySetName = context.DefaultContainerName + "." + entitySet.Name;
    //        // Get name of the entity's key property
    //        _keyName = entitySet.ElementType.KeyMembers.Single().Name;
    //    }

    //    public virtual TEntity GetByKey(TKey key)
    //    {
    //        // Build entity key
    //        var entityKey = new EntityKey(_entitySetName, _keyName, key);
    //        // Query first current state manager and if entity is not found query database!!!
    //        return (TEntity)Context.GetObjectByKey(entityKey);
    //    }

    //    // Rest of repository implementation
    //}

    public class dbHelper
    {
        SimpleFlowEntities model;

        public dbHelper()
        {
            model = new SimpleFlowEntities();
        }

        public void AddToModel<T>(T addedRow)
        {
            String[] tableName = addedRow.ToString().Split(new Char[] { '.' });
            if (addedRow != null && tableName[1] != null)
            {
                model.AddObject(tableName[1], addedRow);
                model.SaveChanges();
            }
        }

        public void UpdateChanges()
        {
            model.SaveChanges();
        }

        public void DeleteFlowDetailsById(int entityId)
        {
            if (model.FlowActions != null)
            {
                foreach (FlowActions details in model.FlowActions.Where(x => x.Flows.FlowId == entityId).ToList())
                {
                    model.DeleteObject(details);
                }

                foreach (FlowActionOptions details in model.FlowActionOptions.Where(x => x.Flows.FlowId == entityId).ToList())
                {
                    model.DeleteObject(details);
                }
                foreach (FlowActionInputs details in model.FlowActionInputs.Where(x => x.Flows.FlowId == entityId).ToList())
                {
                    model.DeleteObject(details);
                }
                foreach (FlowActionOutputs details in model.FlowActionOutputs.Where(x => x.Flows.FlowId == entityId).ToList())
                {
                    model.DeleteObject(details);
                }
                foreach (FlowMultiOptions details in model.FlowMultiOptions.Where(x => x.Flows.FlowId == entityId).ToList())
                {
                    model.DeleteObject(details);
                }
            }
        }

        public Users GetTestUser()
        {
            EntityKey key = new EntityKey("SimpleFlowEntities.Users", "UserId", 1);
            Users testUser = model.GetObjectByKey(key) as Users;
            return testUser;
        }

        public Users GetUserbyName(String name)
        {
            Users curUser = model.Users.Where<Users>(u => u.UserName == name).FirstOrDefault<Users>();
            return curUser;
        }

        public Actions GetActionById(String actionId)
        {
            EntityKey key = new EntityKey("SimpleFlowEntities.Actions", "ActionId", actionId);
            Actions action = model.GetObjectByKey(key) as Actions;
            return action;
        }

        public ActionOptions GetActionOptionById(int actOptId)
        {
            EntityKey key = new EntityKey("SimpleFlowEntities.ActionOptions", "ActionOptionId", actOptId);
            ActionOptions actOpt = model.GetObjectByKey(key) as ActionOptions;
            return actOpt;
        }

        public ActionInputs GetActionInputById(int actInputId)
        {
            EntityKey key = new EntityKey("SimpleFlowEntities.ActionInputs", "InputId", actInputId);
            ActionInputs actInput = model.GetObjectByKey(key) as ActionInputs;
            return actInput;
        }
        public ActionOutputs GetActionOutputById(int actOutputId)
        {
            EntityKey key = new EntityKey("SimpleFlowEntities.ActionOutputs", "OutputId", actOutputId);
            ActionOutputs actOutput = model.GetObjectByKey(key) as ActionOutputs;
            return actOutput;
        }

        public FlowInstances GetFlowInstanceById(int instanceId)
        {
            EntityKey key = new EntityKey("SimpleFlowEntities.FlowInstances", "FlowInstanceId", instanceId);
            FlowInstances instance = model.GetObjectByKey(key) as FlowInstances;
            instance = model.FlowInstances.Include("Flows").Where<FlowInstances>(f => f.FlowInstanceId == instance.FlowInstanceId).FirstOrDefault<FlowInstances>();
            return instance;
        }

        public Flows GetFlowByName(String name, Users user)
        {
            Flows flow = model.Flows.Where<Flows>(f => f.FlowName == name && f.Users.UserId == user.UserId).FirstOrDefault<Flows>();
            return flow;
        }

        public Actions GetNextAction(int flowId, int currentStep)
        {
            FlowActions nextAction = model.FlowActions.Include("Actions").Where<FlowActions>(f => f.Flows.FlowId == flowId && f.Position == currentStep + 1).FirstOrDefault<FlowActions>();
            //Actions nextAction = model.Actions.Where<Actions>(f => f.FlowActions. .FlowId == flowId && f.Position == currentStep + 1).FirstOrDefault<Actions>();
            if (nextAction == null)
                return null;
            else
                return nextAction.Actions;
        }

        public List<ActionOptions> GetActionOptionsForAction(String actionId)
        {
            List<ActionOptions> result = new List<ActionOptions>();
            result = model.ActionOptions.Include("Options").Where<ActionOptions>(ao => ao.Actions.ActionId == actionId).ToList<ActionOptions>();
            return result;
        }

        public List<ActionInputs> GetActionInputsForAction(String actionId)
        {
            List<ActionInputs> result = new List<ActionInputs>();
            result = model.ActionInputs.Where<ActionInputs>(ao => ao.Actions.ActionId == actionId).ToList<ActionInputs>();
            return result;
        }

        public List<ActionOutputs> GetActionOutputsForAction(String actionId)
        {
            List<ActionOutputs> result = new List<ActionOutputs>();
            result = model.ActionOutputs.Where<ActionOutputs>(ao => ao.Actions.ActionId == actionId).ToList<ActionOutputs>();
            return result;
        }

        public List<Actions> GetActionsByType(String actionType)
        {
            List<Actions> result = new List<Actions>();
            result = model.Actions.Where<Actions>(aa => aa.ActionType == actionType).ToList<Actions>();
            return result;
        }

        public void GetSuggestionSummary(Flows flow)
        {
            //SuggestionsSummary result = null;

            string queryString = @"SELECT VALUE SuggestionsSummary FROM " +
            "CrowdCupidEntities.SuggestionsSummary AS SuggestionsSummary " +
            "WHERE SuggestionsSummary.MaleId = '" + flow.FlowId +
            "' AND SuggestionsSummary.FemaleId = '" + flow.FlowId + "' AND SuggestionsSummary.Sent = 0";

            ObjectQuery<Flows> SSQuery = new ObjectQuery<Flows>(queryString, model);
            ObjectQuery<DbDataRecord> SSQuerySelect = SSQuery.Select("it.Count");
            foreach (DbDataRecord queryResult in SSQuerySelect)
            {
                String a = queryResult["Count"].ToString();
            }
            //model.SuggestionsSummaries.Select()
            //return result;
        }

        public List<String> GetNextNodes(String LastNode)
        {
            List<String> result = new List<String>();
            String queryString;
            if (LastNode == null)
            {
                queryString = @"SELECT VALUE Connections FROM " +
                    "SimpleFlowEntities.Connections AS Connections " +
                    "WHERE connections.Actions.ActionId IS NULL";
            }
            else
            {
                queryString = @"SELECT VALUE Connections FROM " +
                        "SimpleFlowEntities.Connections AS Connections " +
                        "WHERE connections.Actions.ActionId='" + LastNode + "'";
            }
            ObjectQuery<Flows> SSQuery = new ObjectQuery<Flows>(queryString, model);
            ObjectQuery<DbDataRecord> SSQuerySelect = SSQuery.Select("it.Actions1.ActionId");
            foreach (DbDataRecord queryResult in SSQuerySelect)
            {
                result.Add(queryResult["ActionId"].ToString());
            }
            return result;
        }

        //public List<Experiments> GetMyExperimentList(String userId)
        //{
        //    List<Experiments> result = new List<Experiments>();

        //    string queryString = @"SELECT VALUE Experiments FROM " +
        //    "ResearchBankEntities.Experiments AS Experiments " +
        //    "WHERE (Experiments.ResearcherId = '" + userId +
        //    "' AND Experiments.ExperimentDate >= DATETIME'" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " " + DateTime.Today.Hour + ":" + DateTime.Today.Minute + "')";

        //    ObjectQuery<Experiments> SSQuery = new ObjectQuery<Experiments>(queryString, model);
        //    ObjectQuery<DbDataRecord> SSQuerySelect = SSQuery.Select("it.Title, it.ExperimentDate, it.ExperimentId");
        //    foreach (DbDataRecord queryResult in SSQuerySelect)
        //    {
        //        Experiments experiment = new Experiments();
        //        experiment.ExperimentDate = (DateTime)queryResult["ExperimentDate"];
        //        experiment.Title = queryResult["Title"].ToString();
        //        experiment.ExperimentId = (Guid)queryResult["ExperimentId"];
        //        result.Add(experiment);
        //    }
        //    return result;
        //}

        //public List<Experiments> GetMyExperimentListOld(String userId)
        //{
        //    List<Experiments> result = new List<Experiments>();

        //    string queryString = @"SELECT VALUE Experiments FROM " +
        //    "ResearchBankEntities.Experiments AS Experiments " +
        //    "WHERE (Experiments.ResearcherId = '" + userId +
        //    "' AND Experiments.ExperimentDate < DATETIME'" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " " + DateTime.Today.Hour + ":" + DateTime.Today.Minute + "')";

        //    ObjectQuery<Experiments> SSQuery = new ObjectQuery<Experiments>(queryString, model);
        //    ObjectQuery<DbDataRecord> SSQuerySelect = SSQuery.Select("it.Title, it.ExperimentDate, it.ExperimentId");
        //    foreach (DbDataRecord queryResult in SSQuerySelect)
        //    {
        //        Experiments experiment = new Experiments();
        //        experiment.ExperimentDate = (DateTime)queryResult["ExperimentDate"];
        //        experiment.Title = queryResult["Title"].ToString();
        //        experiment.ExperimentId = (Guid)queryResult["ExperimentId"];
        //        result.Add(experiment);
        //    }
        //    return result;
        //}

        public ApplicationInfo GetAppInfo()
        {
            ApplicationInfo appInfo = model.ApplicationInfo.First<ApplicationInfo>();
            return appInfo;
        }

        public static ICollection CreateDataSourceGrid(List<Actions> experimentList)
        {
            // Create sample data for the DataList control.
            DataTable dt = new DataTable();
            DataRow dr;

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("Id", typeof(String)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Description", typeof(String)));
            dt.Columns.Add(new DataColumn("Type", typeof(String)));

            Random rnd = new Random();
            foreach (Actions itemAction in experimentList)
            {
                dr = dt.NewRow();

                dr["Id"] = itemAction.ActionId;
                dr["Title"] = itemAction.ActionName;
                dr["Date"] = itemAction.ActionDescription;
                dr["Participants"] = itemAction.ActionType;
                dt.Rows.Add(dr);
            }
            // Populate the table
            DataView dv = new DataView(dt);
            return dv;
        }
    }
}