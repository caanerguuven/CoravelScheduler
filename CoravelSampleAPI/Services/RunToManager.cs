using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoravelSampleAPI.Services
{
    public class RunToManager : IRunToService
    {
        public async Task Invoke() //it is coming from Coravel -IInvocable. and you must fill it. When scheduler run, process will trigger here.
        {
            string dtNow = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            await Run(dtNow);
        }

        public async Task Run(string timeStamp) // internal method.
        {
            Console.WriteLine($"I am running. Date : {timeStamp} ");
        }
    }
}
