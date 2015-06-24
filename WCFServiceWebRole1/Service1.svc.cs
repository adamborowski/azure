using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private Dictionary<DateTime, List<MaintenanceEvent>> eventsByDate = new Dictionary<DateTime, List<MaintenanceEvent>>();

        public List<MaintenanceEvent> GetTasks(DateTime date)
        {
            if (eventsByDate.ContainsKey(date))
            {
                return eventsByDate[date];
            }
            return new List<MaintenanceEvent>();
        }

        private DateTime getDayDate(DateTime d)
        {
            DateTime s = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
            return s;
        }

        public DateTime ReportTask(MaintenanceEvent e)
        {
            e.Date = DateTime.Now;
            var d = getDayDate(e.Date);
            if (!eventsByDate.ContainsKey(d))
            {
                eventsByDate[d] = new List<MaintenanceEvent>();
            }
            eventsByDate[d].Add(e);
            return e.Date;
        }

        public List<String> GetTaskTypes()
        {
            var types = new List<String>();
             foreach (string value in Enum.GetNames(typeof(MaintenanceEvent)))
        {
            types.Add(value);

        }
             return types;
        }

        public string GetData(int value)
        {
           

            return string.Format("You entered: {0}", value);
        }

        public MaintenanceEvent GetDataUsingDataContract(MaintenanceEvent composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            composite.User = "operator";
            composite.Date = DateTime.Now;
            return composite;
        }
    }
}
