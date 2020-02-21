using System.Collections.Generic;
using Xamarin.Forms;
using OnlineStep.Helpers;

namespace OnlineStep.Services
{
    public class DataCenter
    {
        public string ContainerId { get; set; }

        //private List<(object obj, string str)> ProcedureList { get; set; }

        private List<Data> ProcedureList { get; set; }
        
        public DataCenter()
        {
            ProcedureList = new List<Data>();
            DataCenterFactory.DataCenterList.Add(this);
        }


        public void CreateProcedure(string procedureName, object dataType)
        {
            Data data = new Data { Name = procedureName, Obj = dataType };
            ProcedureList.Add(data);          
        }

        public Data GetProcedure(string procedureName)
        {
            Data data = new Data();
            foreach(var i in ProcedureList)
            {
                if (i.Name.Equals(procedureName))
                {
                    data.Name = i.Name;
                    data.Obj = i.Obj;
                }
            }
            return data;
        }

    }
}
