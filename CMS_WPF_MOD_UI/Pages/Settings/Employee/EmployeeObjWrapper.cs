using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChangeManagementAppModern.Pages.Settings
{
    public class EmployeeObjWrapper : ValidatableBindableBase
    {
        #region Public Properties
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _employeeID;

        [Required, MaxLength(10)]
        public string EmployeeID
        {
            get { return _employeeID; }
            set { SetProperty(ref _employeeID, value); }
        }

        private string _givenName;

        [Required, MaxLength(100)]
        public string GivenName
        {
            get { return _givenName; }
            set { SetProperty(ref _givenName, value); }
        }

        private string _surname;

        [Required, MaxLength(100)]
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }

        private string _fullname;

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        private string _version;

        [MaxLength(150)]
        public string PositionTitle
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        private string _department;
        [MaxLength(150)]
        public string Department
        {
            get { return _department; }
            set { SetProperty(ref _department, value); }
        }

        private string _function;
        [MaxLength(150)]
        public string Function
        {
            get { return _function; }
            set { SetProperty(ref _function, value); }
        }

        public RelayCommand<String> EnterKeyCommand { get; private set; }
        public event Action Save = delegate { };
        #endregion

        #region UI Properties
        private bool _isEmployeeIDFocused;

        public bool IsEmployeeIDFocused
        {
            get { return _isEmployeeIDFocused; }
            set
            {
                if (_isEmployeeIDFocused != value)
                    SetProperty(ref _isEmployeeIDFocused, false);

                SetProperty(ref _isEmployeeIDFocused, true);
            }
        }

        private bool _isGivenNameFocused;

        public bool IsGivenNameFocused
        {
            get { return _isGivenNameFocused; }
            set
            {
                if (_isGivenNameFocused != value)
                    SetProperty(ref _isGivenNameFocused, false);

                SetProperty(ref _isGivenNameFocused, true);
            }
        }

        private bool _isSurnameFocused;

        public bool IsSurnameFocused
        {
            get { return _isSurnameFocused; }
            set
            {
                if (_isSurnameFocused != value)
                    SetProperty(ref _isSurnameFocused, false);

                SetProperty(ref _isSurnameFocused, true);
            }
        }

        private List<String> _allDepts;

        public List<String> AllDepartments
        {
            get { return _allDepts; }
            set { SetProperty(ref _allDepts, value); }
        }

        private List<String> _allFunctions;

        public List<String> AllFunctions
        {
            get { return _allFunctions; }
            set { SetProperty(ref _allFunctions, value); }
        }

        #endregion

        public EmployeeObjWrapper()
        {
            _allDepts = OEmployee.GetAllDepts();
            _allFunctions = OEmployee.GetAllFunctions();
            EnterKeyCommand = new RelayCommand<string>(OnEnterKeyPress);
        }

        private void OnEnterKeyPress(string sourceField)
        {
            if (sourceField == null) return;

            switch (sourceField.ToString())
            {
                case "EmployeeID":
                    if (String.IsNullOrWhiteSpace(this.GivenName))
                        this.IsGivenNameFocused = true;
                    else if (String.IsNullOrWhiteSpace(this.Surname))
                        this.IsSurnameFocused = true;
                    else
                        this.Save();
                    break;
                case "GivenName":
                    if (String.IsNullOrWhiteSpace(this.EmployeeID))
                        this.IsEmployeeIDFocused = true;
                    else if (String.IsNullOrWhiteSpace(this.Surname))
                        this.IsSurnameFocused = true;
                    else this.Save();
                    break;
                default: break;
            }
        }

        public void Validate()
        {
            if (this.HasErrors) return;

            if (String.IsNullOrWhiteSpace(_employeeID))
                this.InsertError("EmployeeID", "'Code' is required.");
            else if (App.UoW.Employees.IsEmpIdDuplicated(_id, _employeeID))
                this.InsertError("EmployeeID", String.Format("'{0}' code already exist.", _employeeID));

            if (String.IsNullOrWhiteSpace(_givenName))
                this.InsertError("GivenName", "'Given Name' is required.");
            else if (String.IsNullOrWhiteSpace(_surname))
                this.InsertError("Surname", "'Surname' is required.");
        }
    }
}