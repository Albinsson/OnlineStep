using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OnlineStep.Services;

namespace OnlineStep.Helpers
{
    public static class DataCenterFactory
    {
        public static List<DataCenter> DataCenterList { get; set; }

        static DataCenterFactory()
        {
            DataCenterList = new List<DataCenter>();
        }

        public static DataCenter GetDataCenter(string centerId)
        {
            Console.WriteLine("GetDataCenter", centerId);
            DataCenter dataCenter = new DataCenter();
            foreach (var i in DataCenterList)
            {
                if(i.ContainerId.Equals(centerId))
                {
                    dataCenter = i;
                }
            }
            return dataCenter;
        }
    }
}
