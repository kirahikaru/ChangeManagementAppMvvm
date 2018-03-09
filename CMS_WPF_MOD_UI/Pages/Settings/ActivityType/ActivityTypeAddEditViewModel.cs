using DataLayer.Models;
using System;
namespace ChangeManagementAppModern.Pages.Settings
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class ActivityTypeAddEditViewModel : BindableBase
    {
        public ActivityTypeAddEditViewModel()
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

        private string _mdfUsr;
        public string LastModifiedUser
        {
            get { return _mdfUsr; }
            set { SetProperty(ref _mdfUsr, value); }
        }

        private string _mdfDt;
        public string LastModifiedDateTime
        {
            get { return _mdfDt; }
            set { SetProperty(ref _mdfDt, value); }
        }
        #endregion

        private OActivityType _edtActivityType = null;

        private ActivityTypeObjWrapper _activityType;

        public ActivityTypeObjWrapper WrapperObj
        {
            get { return _activityType; }
            set { SetProperty(ref _activityType, value); }
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

        public void SetActivityType(OActivityType activityType)
        {
            _edtActivityType = activityType;

            if (_isEditMode)
            {
                this.CreatedDateTime = activityType.CrtDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
                this.LastModifiedDateTime = activityType.MdfDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
                this.CreatedUser = activityType.CrtUsrName;
                this.LastModifiedUser = activityType.MdfUsrName;
            }

            if (this.WrapperObj != null)
            {
                this.WrapperObj.ErrorsChanged -= RaiseCanExecuteChanged;
                this.WrapperObj.Save -= OnSave;
            }
            this.WrapperObj = new ActivityTypeObjWrapper();
            this.WrapperObj.ErrorsChanged += RaiseCanExecuteChanged;
            this.WrapperObj.Save += OnSave;
            this.WrapperObj.IsCodeFocused = true;
            CopyActivityType(activityType, this.WrapperObj);
        }

        public void ClearActivityType()
        {
            _edtActivityType = null;
            _activityType = null;
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
            ClearActivityType();
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

            UpdateActivityType(WrapperObj, _edtActivityType);

            if (this.IsEditMode)
            {
                _edtActivityType.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtActivityType.MdfDateTime = DateTime.Now;
                App.UoW.ActivityTypes.Update(_edtActivityType);
                App.UoW.Complete();
                DoneUpdating();
            }
            else
            {
                _edtActivityType.CrtUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtActivityType.CrtDateTime = DateTime.Now;
                _edtActivityType.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtActivityType.MdfDateTime = DateTime.Now;
                App.UoW.ActivityTypes.Add(_edtActivityType);
                App.UoW.Complete();
                DoneAdding();
            }
        }

        private void CopyActivityType(OActivityType source, ActivityTypeObjWrapper target)
        {
            target.Id = source.Id;
            if (this.IsEditMode)
            {
                target.Code = source.Code;
                target.Name = source.Name;
            }
        }

        private void UpdateActivityType(ActivityTypeObjWrapper source, OActivityType target)
        {
            target.Code = source.Code;
            target.Name = source.Name;
        }
    }
}
