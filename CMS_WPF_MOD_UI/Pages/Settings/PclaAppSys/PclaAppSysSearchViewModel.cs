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
    public class PclaAppSysSearchViewModel : BindableBase
    {
        private PclaAppSysAddEditViewModel _addEditViewModel;

        public PclaAppSysAddEditViewModel AddEditViewModel
        {
            get { return _addEditViewModel; }
            set { SetProperty(ref _addEditViewModel, value); }
        }

        public OPclaAppSys SelectedPclaAppSys { get; set; }

        private List<OPclaAppSys> _foundPclaSysApps;
        public List<OPclaAppSys> FoundPclaSysApps
        {
            get { return _foundPclaSysApps; }
            set { SetProperty(ref _foundPclaSysApps, value); }
        }
        private ObservableCollection<OPclaAppSys> _pclaAppSyss;

        public ObservableCollection<OPclaAppSys> PclaAppSyss
        {
            get { return _pclaAppSyss; }
            set { SetProperty(ref _pclaAppSyss, value); }
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

        public PclaAppSysSearchViewModel()
        {
            _addEditViewModel = ContainerHelper.Container.Resolve<PclaAppSysAddEditViewModel>();
            _addEditViewModel.CancelEditing += CancelEditing;
            _addEditViewModel.DoneAdding += DoneAdding;
            _addEditViewModel.DoneUpdating += DoneUpdating;
            PerformSearchCommand = new RelayCommand(PerformSearch);
            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);
            AddCommand = new RelayCommand(AddPclaAppSys);
            EditCommand = new RelayCommand(EditPclaAppSys);
        }

        public void LoadPclaSysApps()
        {
            this.FoundPclaSysApps = App.UoW.PclaSysApps.GetAll().Where(c => c.IsDeleted == false).ToList();
            //ChangeTypes = new ObservableCollection<OPclaAppSys>(_allChangeTypes);
        }

        private void FilterChangeType(string fltrCode, string fltrDesc)
        {
            if (String.IsNullOrWhiteSpace(fltrCode) && String.IsNullOrWhiteSpace(fltrDesc))
            {
                PclaAppSyss = new ObservableCollection<OPclaAppSys>(_foundPclaSysApps);
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(fltrCode))
                    PclaAppSyss = new ObservableCollection<OPclaAppSys>(_foundPclaSysApps.Where(c => c.Name.ToLower().Contains(fltrDesc.ToLower())));
                else if (String.IsNullOrWhiteSpace(fltrDesc))
                    PclaAppSyss = new ObservableCollection<OPclaAppSys>(_foundPclaSysApps.Where(c => c.Code.ToLower() == fltrCode.ToLower()));
                else
                    PclaAppSyss = new ObservableCollection<OPclaAppSys>(_foundPclaSysApps.Where(c => c.Code.ToLower() == fltrCode.ToLower() || c.Name.ToLower().Contains(fltrDesc.ToLower())));
            }
        }

        private void AddPclaAppSys()
        {
            this.IsEditing = true;
            _addEditViewModel.IsEditMode = false;
            _addEditViewModel.SetPclaAppSys(new OPclaAppSys());
        }

        private void EditPclaAppSys()
        {
            if (this.SelectedPclaAppSys == null) return;

            this.IsEditing = true;
            _addEditViewModel.IsEditMode = true;
            _addEditViewModel.SetPclaAppSys(this.SelectedPclaAppSys);
        }

        private void PerformSearch()
        {
            if (String.IsNullOrWhiteSpace(this.FilterCode) && String.IsNullOrWhiteSpace(this.FilterName))
            {
                FoundPclaSysApps = App.UoW.PclaSysApps.GetAll().Where(c => c.IsDeleted == false).ToList();
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(this.FilterCode))
                    FoundPclaSysApps = App.UoW.PclaSysApps.GetByName(this.FilterName);
                else if (String.IsNullOrWhiteSpace(this.FilterName))
                    FoundPclaSysApps = App.UoW.PclaSysApps.GetByCode(this.FilterCode);
                else
                    FoundPclaSysApps = App.UoW.PclaSysApps.GetByCodeOrName(this.FilterCode, this.FilterName);
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
            LoadPclaSysApps();
        }

        private void DoneAdding()
        {
            this.IsEditing = false;
            LoadPclaSysApps();
        }

        private void CancelEditing()
        {
            this.IsEditing = false;
        }
    }
}
