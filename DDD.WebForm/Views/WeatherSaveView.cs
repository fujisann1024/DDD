using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;
using DDD.WebForm.ViewModels;
using System;
using System.Windows.Forms;

namespace DDD.WebForm.Views
{
    public partial class WeatherSaveView : Form
    {
        private WeatherSaveViewModel _viewModel
            = new WeatherSaveViewModel();

        public WeatherSaveView()
        {
            InitializeComponent();

            //this.button1 = new System.Windows.Forms.Button();
            //this.AreaIdComboBox = new System.Windows.Forms.ComboBox();
            //this.DateTimeTextBox = new System.Windows.Forms.DateTimePicker();
            //this.ConditionComboBox = new System.Windows.Forms.ComboBox();
            //this.TemperatureTextBox = new System.Windows.Forms.TextBox();
            //this.UnitLabel = new System.Windows.Forms.Label();

            //エリアID
            this.AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList; //ユーザーが編集不可
            this.AreaIdComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreaIdComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);//キー
            this.AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);//値

            this.DateTimeTextBox.DataBindings.Add(
                "Value",_viewModel, nameof(_viewModel.DateYmdValue));

            this.ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList; //ユーザーが編集不可
            this.ConditionComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.ConditionComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Conditions));
            this.ConditionComboBox.ValueMember = nameof(Condition.Value);//キー
            this.ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);//値

            this.TemperatureTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));

            this.UnitLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureUnitName));

            this.SaveButton.Click += (_, __) =>
            {
                try
                {
                    _viewModel.Save();
                    MessageBox.Show("保存が完了しました");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }


    }
}
