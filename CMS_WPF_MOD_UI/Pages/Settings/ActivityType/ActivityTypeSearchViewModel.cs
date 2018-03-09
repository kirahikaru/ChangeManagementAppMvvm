using DataLayer.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChangeManagementAppModern.Pages.Settings
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class ActivityTypeSearchViewModel : BindableBase
    {
        private ActivityTypeAddEditViewModel _addEditViewModel;

        public ActivityTypeAddEditViewModel AddEditViewModel
        {
            get { return _addEditViewModel; }
            set { SetProperty(ref _addEditViewModel, value); }
        }

        public OActivityType SelectedActivityType { get; set; }

        private List<OActivityType> _foundActivityTypes;
        public List<OActivityType> FoundActivityTypes
        {
            get { return _foundActivityTypes; }
            set { SetProperty(ref _foundActivityTypes, value); }
        }
        private ObservableCollection<OActivityType> _activityTypes;

        public ObservableCollection<OActivityType> ActivityTypes
        {
            get { return _activityTypes; }
            set { SetProperty(ref _activityTypes, value); }
        }

        private string _fltrCode;

        public string FilterCode
        {
            get { return _fltrCode; }
            set
            {
                SetProperty(ref _fltrCode, value);
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

        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set { SetProperty(ref _isEditing, value); }
        }

        public RelayCommand ClearSearchInputCommand { get; private set; }
        public RelayCommand PerformSearchCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }

        public ActivityTypeSearchViewModel()
        {
            _addEditViewModel = ContainerHelper.Container.Resolve<ActivityTypeAddEditViewModel>();
            _addEditViewModel.CancelEditing += CancelEditing;
            _addEditViewModel.DoneAdding += DoneAdding;
            _addEditViewModel.DoneUpdating += DoneUpdating;
            PerformSearchCommand = new RelayCommand(PerformSearch);
            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);
            AddCommand = new RelayCommand(AddActivityType);
            EditCommand = new RelayCommand(EditActivityType);
        }

        public void LoadActivityTypes()
        {
            this.FoundActivityTypes = App.UoW.ActivityTypes.GetAll().Where(c => c.IsDeleted == false).ToList();
            //ChangeTypes = new ObservableCollection<OActivityType>(_allChangeTypes);
        }

        private void FilterChangeType(string fltrCode, string fltrDesc)
        {
            if (String.IsNullOrWhiteSpace(fltrCode) && String.IsNullOrWhiteSpace(fltrDesc))
            {
                ActivityTypes = new ObservableCollection<OActivityType>(_foundActivityTypes);
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(fltrCode))
                    ActivityTypes = new ObservableCollection<OActivityType>(_foundActivityTypes.Where(c => c.Name.ToLower().Contains(fltrDesc.ToLower())));
                else if (String.IsNullOrWhiteSpace(fltrDesc))
                    ActivityTypes = new ObservableCollection<OActivityType>(_foundActivityTypes.Where(c => c.Code.ToLower() == fltrCode.ToLower()));
                else
                    ActivityTypes = new ObservableCollection<OActivityType>(_foundActivityTypes.Where(c => c.Code.ToLower() == fltrCode.ToLower() || c.Name.ToLower().Contains(fltrDesc.ToLower())));
            }
        }

        private void AddActivityType()
        {
            this.IsEditing = true;
            _addEditViewModel.IsEditMode = false;
            _addEditViewModel.SetActivityType(new OActivityType());
        }

        private void EditActivityType()
        {
            if (this.SelectedActivityType == null) return;

            this.IsEditing = true;
            _addEditViewModel.IsEditMode = true;
            _addEditViewModel.SetActivityType(this.SelectedActivityType);
        }

        private void PerformSearch()
        {
            if (String.IsNullOrWhiteSpace(this.FilterCode) && String.IsNullOrWhiteSpace(this.FilterName))
            {
                FoundActivityTypes = App.UoW.ActivityTypes.GetAll().Where(c => c.IsDeleted == false).ToList();
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(this.FilterCode))
                    FoundActivityTypes = App.UoW.ActivityTypes.GetByName(this.FilterName);
                else if (String.IsNullOrWhiteSpace(this.FilterName))
                    FoundActivityTypes = App.UoW.ActivityTypes.GetByCode(this.FilterCode);
                else
                    FoundActivityTypes = App.UoW.ActivityTypes.GetByCodeOrName(this.FilterCode, this.FilterName);
            }
        }

        private void ClearSearchInput()
        {
            this.FilterCode = null;
            this.FilterName = null;
            PerformSearch();
        }

        private void DoneUpdating()
        {
            this.IsEditing = false;
            LoadActivityTypes();
        }

        private void DoneAdding()
        {
            this.IsEditing = false;
            LoadActivityTypes();
        }

        private void CancelEditing()
        {
            this.IsEditing = false;
        }
    }
}
