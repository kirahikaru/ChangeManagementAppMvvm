using DataLayer.Models;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChangeManagementAppModern.Pages.Settings
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class EmployeeSearchViewModel : BindableBase
    {
        private EmployeeAddEditViewModel _addEditViewModel;

        public EmployeeAddEditViewModel AddEditViewModel
        {
            get { return _addEditViewModel; }
            set { SetProperty(ref _addEditViewModel, value); }
        }

        public OEmployee SelectedEmployee { get; set; }

        private List<OEmployee> _foundEmployees;
        public List<OEmployee> FoundEmployees
        {
            get { return _foundEmployees; }
            set { SetProperty(ref _foundEmployees, value); }
        }
        private ObservableCollection<OEmployee> _Employees;

        public ObservableCollection<OEmployee> Employees
        {
            get { return _Employees; }
            set { SetProperty(ref _Employees, value); }
        }

        #region *** SEARCH FILTERS ****
        private List<string> _allDepts;

        public List<string> AllDepartments
        {
            get { return _allDepts; }
            set { SetProperty(ref _allDepts, value); }
        }

        private List<string> _allFunctions;

        public List<string> AllFunctions
        {
            get { return _allFunctions; }
            set { SetProperty(ref _allFunctions, value); }
        }

        private string _fltrEmplId;

        public string FilterEmployeeID
        {
            get { return _fltrEmplId; }
            set
            {
                SetProperty(ref _fltrEmplId, value);
                //FilterChangeType(_fltrCode, FilterDesc);
            }
        }

        private string _fltrName;

        public string FilterName
        {
            get { return _fltrName; }
            set
            {
                SetProperty(ref _fltrName, value);
                //FilterChangeType(FilterCode, _fltrDesc);
            }
        }

        private string _fltrDepartment;

        public string FilterDepartment
        {
            get { return _fltrDepartment; }
            set
            {
                SetProperty(ref _fltrDepartment, value);
                //FilterChangeType(FilterCode, _fltrDesc);
            }
        }

        private string _fltrFunction;

        public string FilterFunction
        {
            get { return _fltrFunction; }
            set
            {
                SetProperty(ref _fltrFunction, value);
                //FilterChangeType(FilterCode, _fltrDesc);
            }
        }

        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set { SetProperty(ref _isEditing, value); }
        }
        #endregion

        public RelayCommand ClearSearchInputCommand { get; private set; }
        public RelayCommand PerformSearchCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }

        public EmployeeSearchViewModel()
        {
            _allDepts = OEmployee.GetAllDepts();

            _addEditViewModel = ContainerHelper.Container.Resolve<EmployeeAddEditViewModel>();
            _addEditViewModel.CancelEditing += CancelEditing;
            _addEditViewModel.DoneAdding += DoneAdding;
            _addEditViewModel.DoneUpdating += DoneUpdating;
            PerformSearchCommand = new RelayCommand(PerformSearch);
            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);
            AddCommand = new RelayCommand(AddEmployee);
            EditCommand = new RelayCommand(EditEmployee);
        }

        public async void LoadEmployees()
        {
            this.FoundEmployees = await App.UoW.Employees.SearchEmployeeAsync(null, null, null, null);
        }

        private void AddEmployee()
        {
            this.IsEditing = true;
            _addEditViewModel.IsEditMode = false;
            _addEditViewModel.SetEmployee(new OEmployee());
        }

        private void EditEmployee()
        {
            if (this.SelectedEmployee == null) return;

            this.IsEditing = true;
            _addEditViewModel.IsEditMode = true;
            _addEditViewModel.SetEmployee(this.SelectedEmployee);
        }

        private async void PerformSearch()
        {
            this.FoundEmployees = await App.UoW.Employees.SearchEmployeeAsync(
                this.FilterEmployeeID,
                this.FilterName,
                this.FilterDepartment,
                this.FilterFunction);
        }

        private void ClearSearchInput()
        {
            this.FilterEmployeeID = null;
            this.FilterName = null;
            this.FilterDepartment = "";
            this.FilterFunction = "";
            PerformSearch();
        }

        private void DoneUpdating()
        {
            this.IsEditing = false;
            LoadEmployees();
        }

        private void DoneAdding()
        {
            this.IsEditing = false;
            LoadEmployees();
        }

        private void CancelEditing()
        {
            this.IsEditing = false;
        }
    }
}
