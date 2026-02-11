using UltraEnterpriseSDLC;
class Program
{
    static void Main(string[] args)
    {
        EnterpriseSDLCEngine engine=new EnterpriseSDLCEngine();
        
        engine.AddRequirement("Sign-On",RiskLevel.High);
        engine.AddRequirement("Fraud Detection",RiskLevel.Critical);
        
        WorkItem obj1=engine.CreateWorkItem("Sign-On",SDLCStage.Design);
        WorkItem obj2=engine.CreateWorkItem("Sign-On",SDLCStage.Development);
        WorkItem obj3=engine.CreateWorkItem("Sign-On",SDLCStage.Testing);
        
        engine.AddDependency(obj2.Id,obj1.Id);
        engine.AddDependency(obj3.Id,obj2.Id);
        
        engine.RegisterTestSuite("Regression test suite");
        engine.RegisterTestSuite("Smoke test suite");
        
        engine.PlanStage(SDLCStage.Design);
        
        engine.ExecuteNext();
        engine.ExecuteNext();
        
        engine.DeployRelease("v3.4.1");
        
        engine.RecordQualityMetric("Code coverage",91.7);
        engine.RecordQualityMetric("Security",97.3);
        
        engine.RollbackRelease();
        
        engine.PrintAuditLedger();
        
        engine.PrintReleaseScoreboard();
        
    }
}