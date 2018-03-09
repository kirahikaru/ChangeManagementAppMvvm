using System;
using System.ComponentModel.DataAnnotations;

namespace ChangeManagementAppModern.Pages.Settings
{
    public class ChangeTypeObjWrapper : ValidatableBindableBase
    {
        #region Public Properties
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _code;

        [Required]
        public string Code
        {
            get { return _code; }
            set { SetProperty(ref _code, value); }
        }

        private string _name;

        [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public RelayCommand<String> EnterKeyCommand { get; private set; }
        public event Action Save = delegate { };
        #endregion

        #region UI Properties
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
        #endregion

        public ChangeTypeObjWrapper()
        {
            EnterKeyCommand = new RelayCommand<string>(OnEnterKeyPress);
        }

        private void OnEnterKeyPress(string sourceField)
        {
            if (sourceField == null) return;

            switch (sourceField.ToString())
            {
                case "Code":
                    if (String.IsNullOrWhiteSpace(this.Name))
                        this.IsNameFocused = true;
                    else
                        this.Save();
                    break;
                case "Name":
                    this.Save();
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
