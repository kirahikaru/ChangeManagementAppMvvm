using ChangeManagementAppModern.Pages.ChangeRequest;
using DataLayer.Models;
using System;
using System.Windows.Controls;

namespace ChangeManagementAppModern.Pages
{
    /// <summary>
    /// Interaction logic for ChangeRequestSearchView.xaml
    /// </summary>
    public partial class ChgReqSearchView : UserControl
    {
        public ChgReqSearchView()
        {
            InitializeComponent();
        }

        void AddNew(object sender, EventArgs e)
        {
            var addEditDialogBox = new ChgReqAddEditView(((ChgReqSearchViewModel)this.DataContext).AddEditViewModel, new OChangeRequest());
            addEditDialogBox.ShowDialog();
        }
    }
}
