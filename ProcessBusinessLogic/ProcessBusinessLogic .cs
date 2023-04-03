using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessBusinessLogic
{
    //public delegate void BusinessLogicDelegate();
      class ProcessBusinessLogic
    {
       // public event BusinessLogicDelegate ProcessCompleted;
       public event EventHandler <bool> ProcessCompleted;
        public   void StartProcess()

        {   

            Console.WriteLine("Process Started!");

            

             OnProcessCompleted(true);

        }

        public void bl_ProcessCompleted(object sender , bool IsCompleted )
        {
            Console.WriteLine("Method Invoked !! Process :" +( IsCompleted?   " Completed " : "Not Completed"));
        }
        protected virtual void OnProcessCompleted(bool IsSuccess) //protected virtual method

        {

            //if ProcessCompleted is not null then call delegate

            ProcessCompleted?.Invoke(this,IsSuccess);

        }

        public static void Main(string[] args)
        {
            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();
            //BusinessLogicDelegate businessLogicDelegate = new BusinessLogicDelegate(processBusinessLogic.StartProcess);
            //businessLogicDelegate();
            //processBusinessLogic.ProcessCompleted += processBusinessLogic.bl_ProcessCompleted;
            //processBusinessLogic.OnProcessCompleted();
            processBusinessLogic.ProcessCompleted += processBusinessLogic.bl_ProcessCompleted;
            processBusinessLogic.StartProcess();
        }
    }
}
