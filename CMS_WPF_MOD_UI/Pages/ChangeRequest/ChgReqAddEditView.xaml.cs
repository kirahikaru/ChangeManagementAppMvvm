using DataLayer.Models;
using FirstFloor.ModernUI.Windows.Controls;
using System;

namespace ChangeManagementAppModern.Pages.ChangeRequest
{
    /// <summary>
    /// Interaction logic for ChgReqAddEditView.xaml
    /// </summary>
    public partial class ChgReqAddEditView : ModernDialog
    {
        public ChgReqAddEditView()
        {
            InitializeComponent();
            this.CloseButton.Visibility = System.Windows.Visibility.Collapsed;
            // define the dialog buttons
            // this.Buttons = new Button[] { this.OkButton, this.CancelButton };
        }

        public ChgReqAddEditView(ChgReqAddEditViewModel context, OChangeRequest cr)
            : this()
        {
            context.Initialize(cr);
            this.DataContext = context;
            context.Close += Close;
        }

        void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
