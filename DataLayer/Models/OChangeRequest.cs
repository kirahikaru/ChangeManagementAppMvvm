using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class OChangeRequest : PclaAuditObjectBase
    {
        public string ChgReqID { get; set; }
        /// <summary>
        /// Remedy Force Change Request ID
        /// </summary>
        public string RemedyForceId { get; set; }
        public string Title { get; set; }
        public string Justification { get; set; }
        public string Detail { get; set; }
        public string Priority { get; set; }

        public DateTime? RequestDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? TargetCompleteDate { get; set; }
        public DateTime? TargetUatDate { get; set; }
        public DateTime? ActualCompleteDate { get; set; }
        public DateTime? ActualUatDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public int DevManday { get; set; }
        public int DocManday { get; set; }
        public int OthManday { get; set; }
        public string WorkUnit { get; set; }
        public string Remark { get; set; }

        public string Status { get; set; }
        public Guid? PclaAppSysId { get; set; }
        public Guid? ChangeTypeId { get; set; }
        public Guid? RequestorId { get; set; }
        public Guid? ITBusnAnalystId { get; set; }

        public OPclaAppSys PclaAppSys { get; set; }
        public OEmployee Requestor { get; set; }
        public OEmployee ITBusnAnalyst { get; set; }
        public List<OEmployee> AssignedDevelopers { get; set; }

        public OChangeType ChangeType { get; set; }
        public List<OChangeRequestActivity> Activities { get; set; }
        public List<OChangeRequestBusnReqSpec> BusnReqSpecs { get; set; }
        public List<OChangeRequestDoc> SdlcDocs { get; set; }

        public OChangeRequest()
            : base()
        {
            this.ChgReqID = String.Empty;
            this.RemedyForceId = String.Empty;
            this.Justification = String.Empty;
            this.Title = String.Empty;
            this.Priority = String.Empty;
            this.WorkUnit = String.Empty;
            this.Remark = String.Empty;
            this.Status = String.Empty;
        }

        public static List<String> GetAllPriorities()
        {
            List<String> list = new List<String>();
            list.Add("");
            list.Add("High");
            list.Add("Medium");
            list.Add("Low");
            list.Add("Critical");

            return list;
        }
    }
}
