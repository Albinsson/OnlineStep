using System.Collections.Generic;
using Xamarin.Forms;
using OnlineStep.Helpers;
using System;

namespace OnlineStep.Services
{
    public class DataCenter
    {

        //private List<(object obj, string str)> ProcedureList { get; set; }

        private static List<Data> ProcedureList { get; set; }
        
        static DataCenter()
        {
            ProcedureList = new List<Data>();
        }


        public static void CreateProcedure(string procedureName, object dataType)
        {
            CheckPrefix(procedureName);                    
            Data data = new Data { Name = ModifyName(procedureName), Obj = dataType };
            ProcedureList.Add(data);          
        }

        static string ModifyName(string procedureName)
        {
            string modifiedProcedureName = string.Empty;
            string[] prefixList = new string[2] { "Set", "Put" };

            foreach (var i in prefixList)
            {
                if (procedureName.Contains(i))
                {
                    modifiedProcedureName = procedureName.Replace(i, "Get");
                    break;
                }
            }
            return modifiedProcedureName;
        }

        static void CheckPrefix(string procedureName)
        {
            if (!procedureName.Contains("Set") || procedureName.Contains("Put")) throw new Exception("Your procedure name's prefix must contain 'Set' or 'Get'");
        }

        public static Data GetProcedure(string procedureName)
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
