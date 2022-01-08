using DDD.Domain.Exceptions;
using DDD.Infrastructure;
using DDD.Infrastructure.Fake;
using DDD.Infrastructure.SQLite;
using DDD.WebForm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WebForm.Views
{
    public partial class LatestView : BaseForm
    {
        private LatestViewModel _viewModel = new LatestViewModel();

        public LatestView()
        {
            InitializeComponent();

            AreaIdTextBox.DataBindings.Add(
                "Text"
                ,_viewModel
                ,nameof(_viewModel.AreaIdText)
                );

            MeasureDateTextBox.DataBindings.Add(
               "Text"
               , _viewModel
               , nameof(_viewModel.MeasureDateText)
               );

            MeasureValueTextBox.DataBindings.Add(
               "Text"
               , _viewModel
               , nameof(_viewModel.MeasureValueText)
               );
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.Serch();
            }
            catch (Exception ex)
            {
                ExceptionProc(ex);
            }

        }
    }
}
