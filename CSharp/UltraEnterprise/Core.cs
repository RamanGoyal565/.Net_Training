using System.Linq;
namespace UltraEnterpriseSDLC
{
    class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int,WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage,List<WorkItem>> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double,QualityMetric> _releaseScoreboard;
        private int _requirementCounter=0;
        private int _workItemCounter=0;
        public EnterpriseSDLCEngine()
        {
            _requirements=new List<Requirement>();
            _workItemRegistry= new Dictionary<int,WorkItem>();
            _stageBoard=new SortedDictionary<SDLCStage,List<WorkItem>>();
            foreach(SDLCStage i in Enum.GetValues(typeof(SDLCStage)))
                _stageBoard.Add(i,new List<WorkItem>());
            _executionQueue=new Queue<WorkItem>();
            _rollbackStack=new Stack<BuildSnapshot>();
            _uniqueTestSuites=new HashSet<string>();
            _auditLedger=new LinkedList<AuditLog>();
            _releaseScoreboard=new SortedList<double,QualityMetric>();
        }
        public void AddRequirement(string title,RiskLevel risk)
        {
            Requirement obj=new Requirement(_requirementCounter++,title,risk);
            _requirements.Add(obj);
            AuditLog auditObject=new AuditLog("Added Requirement");
            _auditLedger.AddLast(auditObject);
        }
        public WorkItem CreateWorkItem(string name,SDLCStage stage)
        {
            WorkItem workObj=new WorkItem(_workItemCounter++,name,stage);
            _workItemRegistry.Add(workObj.Id,workObj);
            _stageBoard[stage].Add(workObj);
            AuditLog auditObject=new AuditLog("Added WorkItem");
            _auditLedger.AddLast(auditObject);
            return workObj;
        }
        public void AddDependency(int workItemId, int dependencyOnId)
        {
            if(!_workItemRegistry.ContainsKey(workItemId)&&!_workItemRegistry.ContainsKey(dependencyOnId))
                return;
            _workItemRegistry[workItemId].DependencyIds.Add(dependencyOnId);
            AuditLog auditObject=new AuditLog($"Added Dependecy on {workItemId} for {dependencyOnId}");
            _auditLedger.AddLast(auditObject);
        }
        public void PlanStage(SDLCStage stage)
        {
            List<WorkItem> list=_stageBoard[stage];
            foreach(var i in list)
            {
                if (i.DependencyIds.All(r => _workItemRegistry[r].Stage > stage))
                {
                    _executionQueue.Enqueue(i);
                }
            }
            AuditLog auditObject=new AuditLog($"Stage {stage} has been planned");
            _auditLedger.AddLast(auditObject);
        }
        public void ExecuteNext()
        {
            if(_executionQueue.Count==0)
                return;
            WorkItem obj=_executionQueue.Dequeue();
            SDLCStage stage=obj.Stage;
            obj.Stage++;
            _stageBoard[stage].Remove(obj);
            _stageBoard[obj.Stage].Add(obj); 
            AuditLog auditObject=new AuditLog($"WorkItem {obj.Id} moved from Stage {stage} to Stage {obj.Stage}");
            _auditLedger.AddLast(auditObject);
        }
        public void RegisterTestSuite(string suiteId)
        {
            _uniqueTestSuites.Add(suiteId);
            AuditLog auditObject=new AuditLog($"Added TestSuite {suiteId}");
            _auditLedger.AddLast(auditObject);
        }
        public void DeployRelease(string version)
        {
            BuildSnapshot obj=new BuildSnapshot(version);
            _rollbackStack.Push(obj);
            AuditLog auditObject=new AuditLog($"Added SnapShot {version}");
            _auditLedger.AddLast(auditObject);
        }
        public void RollbackRelease()
        {
            if(_rollbackStack.Count==0)
                return;
            BuildSnapshot obj=_rollbackStack.Pop();
            AuditLog auditObject=new AuditLog($"Rollback SnapShot {obj.Version}");
            _auditLedger.AddLast(auditObject);
        }
        public void RecordQualityMetric(string metricName,double score)
        {
            if(_releaseScoreboard.ContainsKey(score))
                return;
            QualityMetric obj=new QualityMetric(metricName,score);
            _releaseScoreboard.Add(score,obj);
            AuditLog auditObject=new AuditLog($"Quality Metric with score {score} added");
            _auditLedger.AddLast(auditObject);
        }
        public void PrintAuditLedger()
        {
            foreach(var i in _auditLedger)
                Console.WriteLine(i.Action+" "+i.Time);
        }
        public void PrintReleaseScoreboard()
        {
            foreach(var i in _releaseScoreboard.Reverse())
            {
                Console.WriteLine($"Metric Name {i.Value.Name} with score {i.Key:0.00}");
            }
        }
    }
}