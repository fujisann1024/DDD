using DDD.Domain.Entities;
using DDD.WebForm.ViewModels;
using DDD.WebForm.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WebForm
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel _viewModel = new WeatherLatestViewModel();

        public WeatherLatestView()
        {
            InitializeComponent();

            //バインディング
            this.AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList; //ユーザーが編集不可
            this.AreasComboBox.DataBindings.Add("SelectedValue",_viewModel, nameof(_viewModel.SelecedAreaId));
            this.AreasComboBox.DataBindings.Add("DataSource",_viewModel, nameof(_viewModel.Areas));
            this.AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);//キー
            this.AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);//値


            this.DateYmdLabel.DataBindings.Add("Text",_viewModel, nameof(_viewModel.DateYmdText));
            this.ConditionLabel.DataBindings.Add("Text",_viewModel, nameof(_viewModel.ConditionText));
            this.TemperatureLabel.DataBindings.Add("Text",_viewModel, nameof(_viewModel.TemperatureText));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var dt = WeatherSQLite.GetLatest(Convert.ToInt32(AreaIdTextBox.Text));
            //if (dt.Rows.Count > 0)
            //{
            //    DateYmdLabel.Text = dt.Rows[0]["DateYmd"].ToString();
            //    ConditionLabel.Text = dt.Rows[0]["Condition"].ToString();
            //    TemperatureLabel.Text =
            //        CommonFunc.RoundString(Convert.ToSingle(dt.Rows[0]["Temperature"]), CommonConst.TemperatureDecimalPoint)
            //         + CommonConst.TemperatureUnitName;
            //}

            _viewModel.Search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var f = new WetherListView())
            {
                f.ShowDialog();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (var f = new WeatherSaveView())
            {
                f.ShowDialog();
            }
        }
    }
}
