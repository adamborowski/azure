using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<MaintenanceEvent> GetTasks(DateTime date);
        [OperationContract]
        DateTime ReportTask(MaintenanceEvent e);
        [OperationContract]
        List<String> GetTaskTypes();
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        MaintenanceEvent GetDataUsingDataContract(MaintenanceEvent composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    public enum MaintenanceType
    {
        WYMIANA_FILTRA, ZERO_SPAN, SERWIS
    };

    [DataContract]
    public class MaintenanceEvent
    {
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public MaintenanceType Type { get; set; }
       
    }
}
