using DataLayer.Models;
using System;
namespace ChangeManagementAppModern.Pages.Settings
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class ChangeTypeAddEditViewModel : BindableBase
    {
        public ChangeTypeAddEditViewModel()
        {
            EnterKeyCommand = new RelayCommand(OnEnterKeyPressed);
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
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

        private OChangeType _edtChangeType = null;

        private ChangeTypeObjWrapper _changeType;

        public ChangeTypeObjWrapper WrapperObj
        {
            get { return _changeType; }
            set { SetProperty(ref _changeType, value); }
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

        public void SetChangeType(OChangeType chgType)
        {
            _edtChangeType = chgType;

            if (_isEditMode)
            {
                this.CreatedUser = chgType.CrtUsrName;
                this.CreatedDateTime = chgType.CrtDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
                this.LastModifiedUser = chgType.MdfUsrName;
                this.LastModifiedDateTime = chgType.MdfDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
            }

            if (this.WrapperObj != null)
            {
                this.WrapperObj.ErrorsChanged -= RaiseCanExecuteChanged;
                this.WrapperObj.Save -= OnSave;
            }
            this.WrapperObj = new ChangeTypeObjWrapper();
            this.WrapperObj.ErrorsChanged += RaiseCanExecuteChanged;
            this.WrapperObj.Save += OnSave;
            this.WrapperObj.IsCodeFocused = true;
            CopyChageType(chgType, this.WrapperObj);
        }

        public void ClearChangeType()
        {
            _edtChangeType = null;
            _changeType = null;
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
            ClearChangeType();
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

            UpdateChangeType(WrapperObj, _edtChangeType);

            if (this.IsEditMode)
            {
                _edtChangeType.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtChangeType.MdfDateTime = DateTime.Now;
                App.UoW.ChangeTypes.Update(_edtChangeType);
                App.UoW.Complete();
                DoneUpdating();
            }
            else
            {
                _edtChangeType.CrtUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtChangeType.CrtDateTime = DateTime.Now;
                _edtChangeType.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtChangeType.MdfDateTime = DateTime.Now;
                App.UoW.ChangeTypes.Add(_edtChangeType);
                App.UoW.Complete();
                DoneAdding();
            }
        }

        private void CopyChageType(OChangeType source, ChangeTypeObjWrapper target)
        {
            target.Id = source.Id;
            if (this.IsEditMode)
            {
                target.Code = source.Code;
                target.Name = source.Name;
            }
        }

        private void UpdateChangeType(ChangeTypeObjWrapper source, OChangeType target)
        {
            target.Code = source.Code;
            target.Name = source.Name;
        }
    }
}
