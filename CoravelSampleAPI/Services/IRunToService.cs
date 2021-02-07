using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoravelSampleAPI.Services
{
    public interface IRunToService: IInvocable //For coravel, you have to implement IInvocable 
    {
        Task Run(string timeStamp); // it is internal method which belongs IRunToService
    }
}
