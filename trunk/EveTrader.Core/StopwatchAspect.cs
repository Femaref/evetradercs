//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using PostSharp.Aspects;
//using System.Diagnostics;

//namespace EveTrader.Core
//{
//    [Serializable]
//    public class StopwatchAspect : OnMethodBoundaryAspect
//    {
//        private string iMethodName = "";

//        public override void CompileTimeInitialize(System.Reflection.MethodBase method, AspectInfo aspectInfo)
//        {
//            iMethodName = method.DeclaringType.Name + "." + method.Name + "()";
            
//        }

//        public override void OnEntry(MethodExecutionArgs args)
//        {
//            Stopwatch sw = new Stopwatch();
//            sw.Start();
//            args.MethodExecutionTag = sw;
//        }
//        public override void OnExit(MethodExecutionArgs args)
//        {
//            Stopwatch sw = (Stopwatch)args.MethodExecutionTag;
//            sw.Stop();
//            Debug.WriteLine(string.Format("Execution time {0}: {1}ms", this.iMethodName, sw.ElapsedMilliseconds.ToString("n")));
//        }
//    }
//}
