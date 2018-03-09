
using System.Collections.Generic;
namespace DataLayer.Models
{
    public class OPclaAppSys : PclaAuditObjectBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// System / Application Type
        /// </summary>
        /// <remarks>
        /// </remarks>
        public string TypeCode { get; set; }
        public string LatestVersion { get; set; }
        public string Remark { get; set; }

        public string TypeCodeText
        {
            get { return AppTypeCodes.GetAppTypeDisplayText(this.TypeCode); }
        }

        public List<OChangeRequest> ChangeRequests { get; set; }
    }

    public class AppTypeCodes
    {
        public const string InHseLocWebApp = "WEB-INHSE-LOC";
        public const string InHseLocWinApp = "WIN-INHSE-LOC";
        public const string OutSrcRegnWebApp = "WEB-OUTSRC-RT";
        public const string OutSrcRegnWinApp = "WIN-OUTSRC-RT";
        public const string InHseRegnWebApp = "WEB-INHSE-RT";
        public const string InHseRegnWinApp = "WIN-INHSE-RT";
        public const string InHseRegnMobApp = "APP-INHSE-RT";
        public const string InHseLocMobApp = "APP-INHSE-LOC";
        public const string OutSrcRegnMobApp = "APP-OUTSRC-RT";
        public const string OutSrcLocMobApp = "APP-OUTSRC-LOC";
        public const string CoreSystem = "CORE-SYS";

        public static string GetAppTypeDisplayText(string appTypeCode)
        {
            switch (appTypeCode)
            {
                case InHseLocWebApp: return "In-House Web Application (Local Infra)";
                case InHseLocWinApp: return "In-House Windows Application (Local Infra)";
                case OutSrcRegnWebApp: return "Out-Source Web Application (Regional Infra)";
                case OutSrcRegnWinApp: return "Out-Source Windows Application (Reginoal Infra)";
                case InHseRegnWebApp: return "In-House Web Application (Regional Infra)";
                case InHseRegnWinApp: return "In-House Window Application (Regional Infra)";
                default: return "";
            }
        }
    }
}
