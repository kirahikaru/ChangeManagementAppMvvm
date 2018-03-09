using ChangeManagementAppModern.Pages.ChangeRequest;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace ChangeManagementAppModern
{
    public class ChgReqSearchViewModel : BindableBase
    {
        public ChgReqAddEditViewModel AddEditViewModel { get; set; }
        private List<OChangeRequest> _foundItems;
        /// <summary>
        /// [MUST-HAVE] Bind to search result
        /// </summary>
        public List<OChangeRequest> FoundList
        {
            get { return _foundItems; }
            set { SetProperty(ref _foundItems, value); }
        }

        private OChangeRequest _selectedItem;
        /// <summary>
        /// [MUST-HAVE] Selected item from search result
        /// </summary>
        public OChangeRequest SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        private List<OChangeType> _allChgType;

        public List<OChangeType> AllChangeTypes
        {
            get { return _allChgType; }
            set { SetProperty(ref _allChgType, value); }
        }

        private List<OPclaAppSys> _allPclaSysApps;

        public List<OPclaAppSys> AllPclaSysApps
        {
            get { return _allPclaSysApps; }
            set { SetProperty(ref _allPclaSysApps, value); }
        }

        private List<OEmployee> _allBusnAnalysts;

        public List<OEmployee> AllBusnAnalysts
        {
            get { return _allBusnAnalysts; }
            set { SetProperty(ref _allBusnAnalysts, value); }
        }

        private List<string> _allPriorities;

        public List<string> AllPriorities
        {
            get { return _allPriorities; }
            set { SetProperty(ref _allPriorities, value); }
        }

        #region *** SEARCH FILTERS ****
        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        private Guid? _fltrItBaId;

        public Guid? FltrItBaId
        {
            get { return _fltrItBaId; }
            set { SetProperty(ref _fltrItBaId, value); }
        }

        private string _fltrTitle;

        public string FltrTitle
        {
            get { return _fltrTitle; }
            set { SetProperty(ref _fltrTitle, value); }
        }

        private string _fltrPriority;

        public string FltrPriority
        {
            get { return _fltrPriority; }
            set { SetProperty(ref _fltrPriority, value); }
        }

        private DateTime? _fltrReqDateFrm;

        public DateTime? FltrRequestDateFrom
        {
            get { return _fltrReqDateFrm; }
            set { SetProperty(ref _fltrReqDateFrm, value); }
        }

        private DateTime? _fltrReqDateTo;

        public DateTime? FltrRequestDateTo
        {
            get { return _fltrReqDateTo; }
            set { SetProperty(ref _fltrReqDateTo, value); }
        }

        private string _fltrChangeRequestId;

        public string FltrChangeRequestId
        {
            get { return _fltrChangeRequestId; }
            set { SetProperty(ref _fltrChangeRequestId, value); }
        }

        private string _fltrRemedyForceId;

        public string FltrRemedyForceId
        {
            get { return _fltrRemedyForceId; }
            set { SetProperty(ref _fltrRemedyForceId, value); }
        }

        private Guid? _fltrPclaAppSysId;

        public Guid? FltrPclaAppSysId
        {
            get { return _fltrPclaAppSysId; }
            set { SetProperty(ref _fltrPclaAppSysId, value); }
        }

        private Guid? _fltrChangeTypeId;

        public Guid? FltrChangeTypeId
        {
            get { return _fltrChangeTypeId; }
            set { SetProperty(ref _fltrChangeTypeId, value); }
        }

        private DateTime? _fltrCloseDateFrm;

        public DateTime? FltrCloseDateFrom
        {
            get { return _fltrCloseDateFrm; }
            set { SetProperty(ref _fltrCloseDateFrm, value); }
        }

        private DateTime? _fltrCloseDateTo;

        public DateTime? FltrCloseDateTo
        {
            get { return _fltrCloseDateTo; }
            set { SetProperty(ref _fltrCloseDateTo, value); }
        }
        #endregion

        public RelayCommand ClearSearchInputCommand { get; private set; }
        public RelayCommand PerformSearchCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }

        public ChgReqSearchViewModel()
        {
            _isEnabled = true;
            _allPriorities = OChangeRequest.GetAllPriorities();
            _allBusnAnalysts = App.UoW.Employees.SearchEmployee(null, null, null, "IT Business Solution & Project");
            _allPclaSysApps = App.UoW.PclaSysApps.GetAll();
            _allChgType = App.UoW.ChangeTypes.GetAll();

            this.AddEditViewModel = new ChgReqAddEditViewModel();
            this.AddEditViewModel.IsEditMode = false;
            this.AddEditViewModel.DoneUpdating += DoneUpdating;
            this.AddEditViewModel.DoneAdding += DoneAdding;
            this.AddEditViewModel.CancelEditing += CancelEditing;

            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);
            PerformSearchCommand = new RelayCommand(PerformSearch);
        }

        public void LoadChangeRequests()
        {
            this.FoundList = App.UoW.ChangeRequests.SearchChangeRequest(null, null, null, null, null, null, null, null, null, null, null, null);
        }

        private void EditSelected()
        {
            //if (this.SelectedItem == null) return;

            //this.IsEnabled = false;

            //ChgReqAddEditView addEditView = new ChgReqAddEditView();

            //ChgReqAddEditViewModel addEditViewModel = new ChgReqAddEditViewModel();
            //addEditViewModel.IsEditMode = true;
            //addEditViewModel.Initialize(this.SelectedItem);
            //addEditViewModel.DoneUpdating += DoneUpdating;
            //addEditViewModel.DoneAdding += DoneAdding;
            //addEditViewModel.CancelEditing += CancelEditing;
            //addEditViewModel.CloseAction += new Action(() =>
            //{
            //    addEditView.DialogResult = true;
            //    addEditView.Close();
            //});
            //addEditView.DataContext = addEditViewModel;
            //addEditView.ShowDialog();
            // Doesn't seem to need this because each return function already does that.
            //if (addEditView.ShowDialog() ?? false)
            //{
            //    this.IsEnabled = true;
            //}
        }

        private void PerformSearch()
        {
            this.FoundList = App.UoW.ChangeRequests.SearchChangeRequest(
                this.FltrChangeRequestId, this.FltrRemedyForceId, this.FltrTitle, this.FltrPriority,
                this.FltrPclaAppSysId, null, this.FltrItBaId, this.FltrChangeTypeId, this.FltrCloseDateFrom, this.FltrCloseDateTo,
                this.FltrRequestDateFrom, this.FltrRequestDateTo);
        }

        private void ClearSearchInput()
        {
            this.FltrChangeRequestId = null;
            this.FltrRemedyForceId = null;
            this.FltrTitle = null;
            this.FltrPriority = null;
            this.FltrPclaAppSysId = null;
            this.FltrItBaId = null;
            this.FltrChangeTypeId = null;
            this.FltrCloseDateFrom = null;
            this.FltrCloseDateTo = null;
            this.FltrRequestDateFrom = null;
            this.FltrRequestDateTo = null;
            PerformSearch();
        }

        private void DoneUpdating()
        {
            this.IsEnabled = true;
            LoadChangeRequests();
        }

        private void DoneAdding()
        {
            this.IsEnabled = true;
            LoadChangeRequests();
        }

        private void CancelEditing()
        {
            this.IsEnabled = true;
        }
    }
}