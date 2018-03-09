using DataLayer.Models;
using System;

namespace ChangeManagementAppModern
{
    public class ChgReqAddEditViewModel : BindableBase
    {
        public ChgReqAddEditViewModel()
        {
            EnterKeyCommand = new RelayCommand(OnEnterKeyPressed);
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private OChangeRequest _actualObj = null;

        private ChgReqObjWrapper _wrapperObj;

        public ChgReqObjWrapper WrapperObj
        {
            get { return _wrapperObj; }
            set { SetProperty(ref _wrapperObj, value); }
        }

        #region *** SEARCH FILTERS ****
        public string WindowTitle
        {
            get { return _isEditMode ? "Editing Existing Change Request" : "Adding New Change Request"; }
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value); }
        }

        private string _crtDt;

        public string CreatedDateTime
        {
            get { return _crtDt; }
            set { SetProperty(ref _crtDt, value); }
        }

        private string _crtUsr;
        public string CreatedUser
        {
            get { return _crtUsr; }
            set { SetProperty(ref _crtUsr, value); }
        }

        private string _mdfDt;
        public string LastModifiedDateTime
        {
            get { return _mdfDt; }
            set { SetProperty(ref _mdfDt, value); }
        }

        private string _mdfUsr;
        public string LastModifiedUser
        {
            get { return _mdfUsr; }
            set { SetProperty(ref _mdfUsr, value); }
        }
        #endregion

        public RelayCommand EnterKeyCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public event Action DoneAdding = delegate { };
        public event Action DoneUpdating = delegate { };
        public event Action CancelEditing = delegate { };
        public event EventHandler Close;


        public void ClearChangeRequest()
        {
            _actualObj = null;
            _wrapperObj = null;
        }

        public void Initialize(OChangeRequest cr)
        {
            _actualObj = cr;

            if (_isEditMode)
            {
                this.CreatedUser = cr.CrtUsrName;
                this.CreatedDateTime = cr.CrtDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
                this.LastModifiedUser = cr.MdfUsrName;
                this.LastModifiedDateTime = cr.MdfDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
            }

            if (this.WrapperObj != null)
            {
                this.WrapperObj.ErrorsChanged -= RaiseCanExecuteChanged;
                this.WrapperObj.Save -= OnSave;
            }
            this.WrapperObj = new ChgReqObjWrapper();
            this.WrapperObj.ErrorsChanged += RaiseCanExecuteChanged;
            this.WrapperObj.Save += OnSave;
            this.WrapperObj.IsChgReqIDFocused = true;
            CopyActualObjToWrapperObj(cr, this.WrapperObj);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void OnEnterKeyPressed()
        {

        }

        private void OnCancel()
        {
            ClearChangeRequest();
            CancelEditing();
            this.Close(this, new EventArgs());
        }

        private bool CanSave()
        {
            return !this.WrapperObj.HasErrors;
        }

        private void OnSave()
        {
            this.WrapperObj.Validate();
            if (this.WrapperObj.HasErrors) return;

            UpdateActualObjFromWrapperObj(this.WrapperObj, _actualObj);

            if (this.IsEditMode)
            {
                _actualObj.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _actualObj.MdfDateTime = DateTime.Now;
                App.UoW.ChangeRequests.Update(_actualObj);
                App.UoW.Complete();
            }
            else
            {
                _actualObj.CrtUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _actualObj.CrtDateTime = DateTime.Now;
                _actualObj.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _actualObj.MdfDateTime = DateTime.Now;
                App.UoW.ChangeRequests.Add(_actualObj);
                App.UoW.Complete();
            }

            DoneAdding();
            this.Close(this, new EventArgs());
        }

        private void CopyActualObjToWrapperObj(OChangeRequest source, ChgReqObjWrapper target)
        {
            target.Id = source.Id;
            if (this.IsEditMode)
            {
                target.ChgReqID = source.ChgReqID;
                target.RemedyForceId = source.RemedyForceId;
                target.Title = source.Title;
                target.Remark = source.Remark;
                target.Justification = source.Justification;
                target.Detail = source.Detail;
                target.Priority = source.Priority;
                target.RequestDate = source.RequestDate;
                target.ReceivedDate = source.ReceivedDate;
                target.TargetCompleteDate = source.TargetCompleteDate;
                target.TargetUatDate = source.TargetUatDate;
                target.ActualCompleteDate = source.TargetUatDate;
                target.ActualUatDate = source.ActualUatDate;
                target.CloseDate = source.CloseDate;
                target.WorkUnit = source.WorkUnit;
                target.Status = source.Status;
                target.PclaAppSysId = source.PclaAppSysId;
                target.ChangeTypeId = source.ChangeTypeId;
                target.RequestorId = source.RequestorId;
                target.ITBusnAnalystId = source.ITBusnAnalystId;
            }
        }

        private void UpdateActualObjFromWrapperObj(ChgReqObjWrapper source, OChangeRequest target)
        {
            target.ChgReqID = source.ChgReqID;
            target.RemedyForceId = source.RemedyForceId;
            target.Title = source.Title;
            target.Remark = source.Remark;
            target.Justification = source.Justification;
            target.Detail = source.Detail;
            target.Priority = source.Priority;
            target.RequestDate = source.RequestDate;
            target.ReceivedDate = source.ReceivedDate;
            target.TargetCompleteDate = source.TargetCompleteDate;
            target.TargetUatDate = source.TargetUatDate;
            target.ActualCompleteDate = source.TargetUatDate;
            target.ActualUatDate = source.ActualUatDate;
            target.CloseDate = source.CloseDate;
            target.WorkUnit = source.WorkUnit;
            target.Status = source.Status;
            target.PclaAppSysId = source.PclaAppSysId;
            target.ChangeTypeId = source.ChangeTypeId;
            target.RequestorId = source.RequestorId;
            target.ITBusnAnalystId = source.ITBusnAnalystId;
        }
    }
}
