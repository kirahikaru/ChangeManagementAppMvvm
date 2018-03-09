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
    public class ChangeTypeSearchViewModel : BindableBase
    {
        private ChangeTypeAddEditViewModel _addEditViewModel;

        public ChangeTypeAddEditViewModel AddEditViewModel
        {
            get { return _addEditViewModel; }
            set { SetProperty(ref _addEditViewModel, value); }
        }

        public OChangeType SelectedChangeType { get; set; }

        private List<OChangeType> _foundChangeTypes;
        public List<OChangeType> FoundChangeTypes
        {
            get { return _foundChangeTypes; }
            set { SetProperty(ref _foundChangeTypes, value); }
        }
        private ObservableCollection<OChangeType> _changeTypes;

        public ObservableCollection<OChangeType> ChangeTypes
        {
            get { return _changeTypes; }
            set { SetProperty(ref _changeTypes, value); }
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

        public ChangeTypeSearchViewModel()
        {
            _addEditViewModel = ContainerHelper.Container.Resolve<ChangeTypeAddEditViewModel>();
            _addEditViewModel.CancelEditing += CancelEditing;
            _addEditViewModel.DoneAdding += DoneAdding;
            _addEditViewModel.DoneUpdating += DoneUpdating;
            PerformSearchCommand = new RelayCommand(PerformSearch);
            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);
            AddCommand = new RelayCommand(AddChangeType);
            EditCommand = new RelayCommand(EditChangeType);
        }

        public void LoadChangeTypes()
        {
            this.FoundChangeTypes = App.UoW.ChangeTypes.GetAll().Where(c => c.IsDeleted == false).ToList();
            //ChangeTypes = new ObservableCollection<OChangeType>(_allChangeTypes);
        }

        private void FilterChangeType(string fltrCode, string fltrDesc)
        {
            if (String.IsNullOrWhiteSpace(fltrCode) && String.IsNullOrWhiteSpace(fltrDesc))
            {
                ChangeTypes = new ObservableCollection<OChangeType>(_foundChangeTypes);
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(fltrCode))
                    ChangeTypes = new ObservableCollection<OChangeType>(_foundChangeTypes.Where(c => c.Name.ToLower().Contains(fltrDesc.ToLower())));
                else if (String.IsNullOrWhiteSpace(fltrDesc))
                    ChangeTypes = new ObservableCollection<OChangeType>(_foundChangeTypes.Where(c => c.Code.ToLower() == fltrCode.ToLower()));
                else
                    ChangeTypes = new ObservableCollection<OChangeType>(_foundChangeTypes.Where(c => c.Code.ToLower() == fltrCode.ToLower() || c.Name.ToLower().Contains(fltrDesc.ToLower())));
            }
        }

        private void AddChangeType()
        {
            this.IsEditing = true;
            _addEditViewModel.IsEditMode = false;
            _addEditViewModel.SetChangeType(new OChangeType());
        }

        private void EditChangeType()
        {
            if (this.SelectedChangeType == null) return;

            this.IsEditing = true;
            _addEditViewModel.IsEditMode = true;
            _addEditViewModel.SetChangeType(this.SelectedChangeType);
        }

        private void PerformSearch()
        {
            if (String.IsNullOrWhiteSpace(this.FilterCode) && String.IsNullOrWhiteSpace(this.FilterName))
            {
                FoundChangeTypes = App.UoW.ChangeTypes.GetAll().Where(c => c.IsDeleted == false).ToList();
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(this.FilterCode))
                    FoundChangeTypes = App.UoW.ChangeTypes.GetByName(this.FilterName);
                else if (String.IsNullOrWhiteSpace(this.FilterName))
                    FoundChangeTypes = App.UoW.ChangeTypes.GetByCode(this.FilterCode);
                else
                    FoundChangeTypes = App.UoW.ChangeTypes.GetByCodeOrName(this.FilterCode, this.FilterName);
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
            LoadChangeTypes();
        }

        private void DoneAdding()
        {
            this.IsEditing = false;
            LoadChangeTypes();
        }

        private void CancelEditing()
        {
            this.IsEditing = false;
        }
    }
}
