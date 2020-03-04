using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStep.Helpers
{
    public class ServiceHelper
    {
        //It's better to use this interface to reach our NameOfOurAppService so the logic inside it is separated
        //Methods added here must be implemented in TestRestClientHelper
        public interface IServiceHelper
        {
            RestInterface Speculative { get; }
            RestInterface UserInitiated { get; }
            RestInterface BackGround { get; }           
        }
    }
}
