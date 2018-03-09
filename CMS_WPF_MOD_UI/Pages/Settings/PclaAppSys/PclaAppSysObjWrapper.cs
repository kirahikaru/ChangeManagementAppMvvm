using System;
using System.ComponentModel.DataAnnotations;

namespace ChangeManagementAppModern.Pages.Settings
{
    public class PclaAppSysObjWrapper : ValidatableBindableBase
    {
        #region *** FIELDS ***
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _code;

        [Required, MaxLength(20)]
        public string Code
        {
            get { return _code; }
            set { SetProperty(ref _code, value); }
        }

        private string _name;

        [Required, MaxLength(150)]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _typeCode;

        [Required, MaxLength(20)]
        public string TypeCode
        {
            get { return _typeCode; }
            set { SetProperty(ref _typeCode, value); }
        }

        private string _version;

        [Required, MaxLength(10)]
        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { SetProperty(ref _remark, value); }
        }

        public RelayCommand<String> EnterKeyCommand { get; private set; }
        public event Action Save = delegate { };
        #endregion

        #region *** UI Properties ***
        private bool _isCodeFocused;

        public bool IsCodeFocused
        {
            get { return _isCodeFocused; }
            set
            {
                if (_isCodeFocused != value)
                    SetProperty(ref _isCodeFocused, false);

                SetProperty(ref _isCodeFocused, true);
            }
        }

        private bool _isNameFocused;

        public bool IsNameFocused
        {
            get { return _isNameFocused; }
            set
            {
                if (_isNameFocused != value)
                    SetProperty(ref _isNameFocused, false);

                SetProperty(ref _isNameFocused, true);
            }
        }

        private bool _isVersionFocused;

        public bool IsVersionFocused
        {
            get { return _isVersionFocused; }
            set
            {
                if (_isVersionFocused != value)
                    SetProperty(ref _isVersionFocused, false);

                SetProperty(ref _isVersionFocused, true);
            }
        }

        private bool _isTypeCodeFocused;

        public bool IsTypeCodeFocused
        {
            get { return _isTypeCodeFocused; }
            set
            {
                if (_isTypeCodeFocused != value)
                    SetProperty(ref _isTypeCodeFocused, false);

                SetProperty(ref _isTypeCodeFocused, true);
            }
        }
        #endregion

        public PclaAppSysObjWrapper()
        {
            EnterKeyCommand = new RelayCommand<string>(OnEnterKeyPress);
        }

        private void OnEnterKeyPress(string sourceField)
        {
            if (sourceField == null) return;

            switch (sourceField.ToString())
            {
                case "Code":
                    if (String.IsNullOrWhiteSpace(this.TypeCode))
                        this.IsTypeCodeFocused = true;
                    else if (String.IsNullOrWhiteSpace(this.Name))
                        this.IsNameFocused = true;
                    else if (String.IsNullOrWhiteSpace(this.Version))
                        this.IsVersionFocused = true;
                    else
                        this.Save();
                    break;
                case "Name":
                    if (String.IsNullOrWhiteSpace(this.Code))
                        this.IsCodeFocused = true;
                    else if (String.IsNullOrWhiteSpace(this.TypeCode))
                        this.IsTypeCodeFocused = true;
                    else if (String.IsNullOrWhiteSpace(this.Version))
                        this.IsVersionFocused = true;
                    else this.Save();
                    break;
                default: break;
            }
        }

        public void Validate()
        {
            if (this.HasErrors) return;

            if (String.IsNullOrWhiteSpace(_code))
                this.InsertError("Code", "'Code' is required.");
            else if (App.UoW.ChangeTypes.IsCodeDuplicated(_id, _code))
                this.InsertError("Code", String.Format("'{0}' code already exist.", _code));

            if (String.IsNullOrWhiteSpace(_name))
                this.InsertError("Name", "'Name' is required.");
        }
    }
}