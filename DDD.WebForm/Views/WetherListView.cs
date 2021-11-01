using DDD.WebForm.ViewModels;
using System.Windows.Forms;

namespace DDD.WebForm.Views
{
    public partial class WetherListView : Form
    {
        private WheatherListViewModel _viewModel
            = new WheatherListViewModel();

        public WetherListView()
        {
            InitializeComponent();

            WeathersDataGrid.DataBindings.Add(
                "DataSource",_viewModel, nameof(_viewModel.Weathers));
        }

        
    }
}
