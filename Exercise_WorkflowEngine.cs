using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public interface IWorkflow
    {
        void Add(IActivity activity);
        void Remove(IActivity activity);
        IEnumerable<IActivity> GetActivityList();
        DateTime TodaysDate { get; }
    }

    public interface IActivity
    {
        void Execute();
    }

    public class WorkflowEngine
    {
        public void Run(IWorkflow workflow)
        {
            Console.WriteLine(workflow.TodaysDate + "'s workflow:");

            foreach (IActivity presentActivity in workflow.GetActivityList())
                presentActivity.Execute();
        }
    }

    public class Workflow : IWorkflow
    {
        private readonly IList<IActivity> Activities;
        public DateTime TodaysDate { get; }

        public Workflow()
        {
            Activities = new List<IActivity>();

            TodaysDate = DateTime.Today;
        }

        public void Add(IActivity activity)
        {
            if (activity == null)
                throw new ArgumentNullException("Activity cannot be null");

            Activities.Add(activity);
        }

        public void Remove(IActivity activity)
        {
            if (activity == null)
                throw new ArgumentNullException("Activity cannot be null");

            Activities.Remove(activity);
        }
        public IEnumerable<IActivity> GetActivityList()
        {
            return Activities;
        }
    }

    public class Running : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("I am running...");
        }
    }

    public class Drawing : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("I am drawing...");
        }
    }

    public class Coding : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("I am coding...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Workflow mondaysWorkflow = new Workflow();
            mondaysWorkflow.Add(new Running());
            mondaysWorkflow.Add(new Drawing());

            Workflow tuesdaysWorkflow = new Workflow();
            tuesdaysWorkflow.Add(new Drawing());
            tuesdaysWorkflow.Add(new Coding());

            Workflow wednesdaysWorkflow = new Workflow();
            wednesdaysWorkflow.Add(new Drawing());
            wednesdaysWorkflow.Add(new Coding());
            wednesdaysWorkflow.Add(new Running());

            WorkflowEngine workflowEngine = new WorkflowEngine();
            workflowEngine.Run(mondaysWorkflow);
            workflowEngine.Run(tuesdaysWorkflow);
            workflowEngine.Run(wednesdaysWorkflow);

        }
    }
}
