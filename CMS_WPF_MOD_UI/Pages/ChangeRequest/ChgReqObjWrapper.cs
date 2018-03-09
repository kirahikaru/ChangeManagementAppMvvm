using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChangeManagementAppModern
{
    public class ChgReqObjWrapper : ValidatableBindableBase
    {
        #region *** FIELDS ***
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _chgReqID;

        [Required, MaxLength(20)]
        public string ChgReqID
        {
            get { return _chgReqID; }
            set { SetProperty(ref _chgReqID, value); }
        }

        private string _remedyForceId;

        [Required, MaxLength(20)]
        public string RemedyForceId
        {
            get { return _remedyForceId; }
            set { SetProperty(ref _remedyForceId, value); }
        }

        private string _title;

        [Required, MaxLength(255)]
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _justification;

        [Required, MaxLength(500)]
        public string Justification
        {
            get { return _justification; }
            set { SetProperty(ref _justification, value); }
        }

        private string _detail;
        [Required, MaxLength(500)]
        public string Detail
        {
            get { return _detail; }
            set { SetProperty(ref _detail, value); }
        }

        private string _priority;
        [Required, MaxLength(10)]
        public string Priority
        {
            get { return _priority; }
            set { SetProperty(ref _priority, value); }
        }

        private DateTime? _requestDate;

        public DateTime? RequestDate
        {
            get { return _requestDate; }
            set { SetProperty(ref _requestDate, value); }
        }

        private DateTime? _rcvDate;

        public DateTime? ReceivedDate
        {
            get { return _rcvDate; }
            set { SetProperty(ref _rcvDate, value); }
        }

        private DateTime? _tgtCompleteDate;

        public DateTime? TargetCompleteDate
        {
            get { return _tgtCompleteDate; }
            set { SetProperty(ref _tgtCompleteDate, value); }
        }

        private DateTime? _tgtUatDate;
        public DateTime? TargetUatDate
        {
            get { return _tgtUatDate; }
            set { SetProperty(ref _tgtUatDate, value); }
        }

        private DateTime? _actCompleteDate;
        public DateTime? ActualCompleteDate
        {
            get { return _actCompleteDate; }
            set { SetProperty(ref _actCompleteDate, value); }
        }

        private DateTime? _actUatDate;
        public DateTime? ActualUatDate
        {
            get { return _actUatDate; }
            set { SetProperty(ref _actUatDate, value); }
        }

        private DateTime? _closeDate;
        public DateTime? CloseDate
        {
            get { return _closeDate; }
            set { SetProperty(ref _closeDate, value); }
        }

        private string _workUnit;
        [MaxLength(10)]
        public string WorkUnit
        {
            get { return _workUnit; }
            set { SetProperty(ref _workUnit, value); }
        }

        private string _remark;
        [MaxLength(500)]
        public string Remark
        {
            get { return _remark; }
            set { SetProperty(ref _remark, value); }
        }

        private string _status;
        [Required, MaxLength(50)]
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        private Guid? _pclaAppSysId;
        public Guid? PclaAppSysId
        {
            get { return _pclaAppSysId; }
            set { SetProperty(ref _pclaAppSysId, value); }
        }

        private Guid? _changeTypeId;
        public Guid? ChangeTypeId
        {
            get { return _changeTypeId; }
            set { SetProperty(ref _changeTypeId, value); }
        }

        private Guid? _requestorId;
        public Guid? RequestorId
        {
            get { return _requestorId; }
            set { SetProperty(ref _requestorId, value); }
        }

        private Guid? _itBaId;
        public Guid? ITBusnAnalystId
        {
            get { return _itBaId; }
            set { SetProperty(ref _itBaId, value); }
        }

        private OPclaAppSys _pclaAppSys;
        public OPclaAppSys PclaAppSys
        {
            get { return _pclaAppSys; }
            set { SetProperty(ref _pclaAppSys, value); }
        }

        private OEmployee _requestor;
        public OEmployee Requestor
        {
            get { return _requestor; }
            set { SetProperty(ref _requestor, value); }
        }

        private OEmployee _itBa;
        public OEmployee ITBusnAnalyst
        {
            get { return _itBa; }
            set { SetProperty(ref _itBa, value); }
        }

        private List<OEmployee> _assignedDevs;
        public List<OEmployee> AssignedDevelopers
        {
            get { return _assignedDevs; }
            set { SetProperty(ref _assignedDevs, value); }
        }

        private List<OEmployee> _changeType;
        public List<OEmployee> ChangeType
        {
            get { return _changeType; }
            set { SetProperty(ref _changeType, value); }
        }

        private List<OChangeRequestActivity> _activities;
        public List<OChangeRequestActivity> Activities
        {
            get { return _activities; }
            set { SetProperty(ref _activities, value); }
        }

        private List<OChangeRequestBusnReqSpec> _busnReqSpecs;
        public List<OChangeRequestBusnReqSpec> BusnReqSpecs
        {
            get { return _busnReqSpecs; }
            set { SetProperty(ref _busnReqSpecs, value); }
        }

        private List<OChangeRequestBusnReqSpec> _sdlcDocs;
        public List<OChangeRequestBusnReqSpec> SdlcDocs
        {
            get { return _sdlcDocs; }
            set { SetProperty(ref _sdlcDocs, value); }
        }
        #endregion

        #region *** UI Properties ***
        private bool _isChgReqIDFocused;

        public bool IsChgReqIDFocused
        {
            get { return _isChgReqIDFocused; }
            set
            {
                if (_isChgReqIDFocused != value)
                    SetProperty(ref _isChgReqIDFocused, false);

                SetProperty(ref _isChgReqIDFocused, value);
            }
        }

        private bool _isRemedyForceIdFocused;

        public bool IsRemedyForceIdFocused
        {
            get { return _isRemedyForceIdFocused; }
            set
            {
                if (_isRemedyForceIdFocused != value)
                    SetProperty(ref _isRemedyForceIdFocused, false);

                SetProperty(ref _isRemedyForceIdFocused, value);
            }
        }

        private bool _isTitleFocused;

        public bool IsTitleFocused
        {
            get { return _isTitleFocused; }
            set
            {
                if (_isTitleFocused != value)
                    SetProperty(ref _isTitleFocused, false);

                SetProperty(ref _isTitleFocused, value);
            }
        }

        private bool _isDetailFocused;

        public bool IsDetailFocused
        {
            get { return _isDetailFocused; }
            set
            {
                if (_isDetailFocused != value)
                    SetProperty(ref _isDetailFocused, false);

                SetProperty(ref _isDetailFocused, value);
            }
        }

        private bool _isJustificationFocused;

        public bool IsJustificationFocused
        {
            get { return _isJustificationFocused; }
            set
            {
                if (_isJustificationFocused != value)
                    SetProperty(ref _isJustificationFocused, false);

                SetProperty(ref _isJustificationFocused, value);
            }
        }
        #endregion
        public RelayCommand<String> EnterKeyCommand { get; private set; }
        public event Action Save = delegate { };

        public ChgReqObjWrapper()
        {
            EnterKeyCommand = new RelayCommand<string>(OnEnterKeyPress);
        }

        private void OnEnterKeyPress(string sourceField)
        {
            if (sourceField == null) return;

            switch (sourceField.ToString())
            {
                default: break;
            }
        }

        public void Validate()
        {
            if (this.HasErrors) return;

            if (String.IsNullOrWhiteSpace(_chgReqID))
                this.InsertError("ChgReqID", "'Change Request ID' is required.");
            else if (App.UoW.ChangeRequests.IsChgReqIdDuplicated(_id, _chgReqID))
                this.InsertError("ChgReqID", String.Format("Change Request ID '{0}' already exist.", _chgReqID));
        }
    }
}
