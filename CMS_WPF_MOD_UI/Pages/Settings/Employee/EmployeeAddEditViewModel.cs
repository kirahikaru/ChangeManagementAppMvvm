using DataLayer.Models;
using System;
namespace ChangeManagementAppModern.Pages.Settings
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class EmployeeAddEditViewModel : BindableBase
    {
        public EmployeeAddEditViewModel()
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

        private OEmployee _edtEmployee = null;

        private EmployeeObjWrapper _Employee;

        public EmployeeObjWrapper WrapperObj
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
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

        public void SetEmployee(OEmployee emp)
        {
            _edtEmployee = emp;

            if (_isEditMode)
            {
                this.CreatedUser = emp.CrtUsrName;
                this.CreatedDateTime = emp.CrtDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
                this.LastModifiedUser = emp.MdfUsrName;
                this.LastModifiedDateTime = emp.MdfDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
            }

            if (this.WrapperObj != null)
            {
                this.WrapperObj.ErrorsChanged -= RaiseCanExecuteChanged;
                this.WrapperObj.Save -= OnSave;
            }
            this.WrapperObj = new EmployeeObjWrapper();
            this.WrapperObj.ErrorsChanged += RaiseCanExecuteChanged;
            this.WrapperObj.Save += OnSave;
            this.WrapperObj.IsEmployeeIDFocused = true;
            CopyEmployee(emp, this.WrapperObj);
        }

        public void ClearEmployee()
        {
            _edtEmployee = null;
            _Employee = null;
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
            ClearEmployee();
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

            UpdateEmployee(WrapperObj, _edtEmployee);

            if (!String.IsNullOrEmpty(_edtEmployee.Surname) && !String.IsNullOrEmpty(_edtEmployee.GivenName))
                _edtEmployee.Fullname = _edtEmployee.GivenName + " " + _edtEmployee.Surname;
            else if (!String.IsNullOrEmpty(_edtEmployee.Surname))
                _edtEmployee.Fullname = _edtEmployee.Surname;
            else if (!String.IsNullOrEmpty(_edtEmployee.GivenName))
                _edtEmployee.Fullname = _edtEmployee.GivenName;

            if (this.IsEditMode)
            {
                _edtEmployee.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtEmployee.MdfDateTime = DateTime.Now;
                App.UoW.Employees.Update(_edtEmployee);
                App.UoW.Complete();
                DoneUpdating();
            }
            else
            {
                _edtEmployee.CrtUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtEmployee.CrtDateTime = DateTime.Now;
                _edtEmployee.MdfUsrName = Environment.UserName; //App.LoggedInUser.Username;
                _edtEmployee.MdfDateTime = DateTime.Now;
                App.UoW.Employees.Add(_edtEmployee);
                App.UoW.Complete();
                DoneAdding();
            }
        }

        private void CopyEmployee(OEmployee source, EmployeeObjWrapper target)
        {
            target.Id = source.Id;
            if (this.IsEditMode)
            {
                target.EmployeeID = source.EmployeeID;
                target.GivenName = source.GivenName;
                target.Surname = source.Surname;
                target.Fullname = source.Fullname;
                target.PositionTitle = source.PositionTitle;
                target.Department = source.Department;
                target.Function = source.Function;
            }
        }

        private void UpdateEmployee(EmployeeObjWrapper source, OEmployee target)
        {
            target.EmployeeID = source.EmployeeID;
            target.GivenName = source.GivenName;
            target.Surname = source.Surname;
            target.Fullname = source.Fullname;
            target.PositionTitle = source.PositionTitle;
            target.Department = source.Department;
            target.Function = source.Function;
        }
    }
}
