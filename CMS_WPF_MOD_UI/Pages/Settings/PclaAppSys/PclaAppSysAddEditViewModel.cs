using DataLayer.Models;
using System;
namespace ChangeManagementAppModern.Pages.Settings
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class PclaAppSysAddEditViewModel : BindableBase
    {
        public PclaAppSysAddEditViewModel()
        {
            EnterKeyCommand = new RelayCommand(OnEnterKeyPressed);
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        #region UI Properties
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

        private OPclaAppSys _edtPclaAppSys = null;

        private PclaAppSysObjWrapper _pclaAppSys;

        public PclaAppSysObjWrapper WrapperObj
        {
            get { return _pclaAppSys; }
            set { SetProperty(ref _pclaAppSys, value); }
        }

        public RelayCommand EnterKeyCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public event Action DoneAdding = delegate { };
        public event Action DoneUpdating = delegate { };
        public event Action CancelEditing = delegate { };

        public void LoadObject()
        {
        }

        public void SetPclaAppSys(OPclaAppSys pclaAppSys)
        {
            _edtPclaAppSys = pclaAppSys;

            if (_isEditMode)
            {
                this.CreatedUser = pclaAppSys.CrtUsrName;
                this.CreatedDateTime = pclaAppSys.CrtDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
                this.LastModifiedUser = pclaAppSys.MdfUsrName;
                this.LastModifiedDateTime = pclaAppSys.MdfDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
            }

            if (this.WrapperObj != null)
            {
                this.WrapperObj.ErrorsChanged -= RaiseCanExecuteChanged;
                this.WrapperObj.Save -= OnSave;
            }
            this.WrapperObj = new PclaAppSysObjWrapper();
            this.WrapperObj.ErrorsChanged += RaiseCanExecuteChanged;
            this.WrapperObj.Save += OnSave;
            this.WrapperObj.IsCodeFocused = true;
            CopyPclaAppSys(pclaAppSys, this.WrapperObj);
        }

        public void ClearPclaAppSys()
        {
            _edtPclaAppSys = null;
            _pclaAppSys = null;
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
            ClearPclaAppSys();
            CancelEditing();
        }

        private bool CanSave()
        {
            return !this.WrapperObj.HasErrors;
        }

        private void OnSave()
        {
            this.WrapperObj.Validate();
            if (WrapperObj.HasErrors) return;

            UpdatePclaAppSys(WrapperObj, _edtPclaAppSys);

            if (this.IsEditMode)
            {
                _edtPclaAppSys.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtPclaAppSys.MdfDateTime = DateTime.Now;
                App.UoW.PclaSysApps.Update(_edtPclaAppSys);
                App.UoW.Complete();
                DoneUpdating();
            }
            else
            {
                _edtPclaAppSys.CrtUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtPclaAppSys.CrtDateTime = DateTime.Now;
                _edtPclaAppSys.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtPclaAppSys.MdfDateTime = DateTime.Now;
                App.UoW.PclaSysApps.Add(_edtPclaAppSys);
                App.UoW.Complete();
                DoneAdding();
            }
        }

        private void CopyPclaAppSys(OPclaAppSys source, PclaAppSysObjWrapper target)
        {
            target.Id = source.Id;
            if (this.IsEditMode)
            {
                target.Code = source.Code;
                target.Name = source.Name;
                target.Remark = source.Remark;
                target.Version = source.LatestVersion;
                target.TypeCode = source.TypeCode;
            }
        }

        private void UpdatePclaAppSys(PclaAppSysObjWrapper source, OPclaAppSys target)
        {
            target.Code = source.Code;
            target.Name = source.Name;
            target.Remark = source.Remark;
            target.LatestVersion = source.Version;
            target.TypeCode = source.TypeCode;
        }
    }
}
