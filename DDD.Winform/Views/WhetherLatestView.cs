using DDD.Domain.Entities;
using DDD.Winform.ViewModels;
using DDD.Winform.Views;
using System;
using System.Windows.Forms;

namespace DDD.Winform.Views
{
    /// <summary>
    /// View
    /// </summary>
    public partial class WhetherLatestView : Form
    {
        private WeatherLastestViewModel _viewModel = new WeatherLastestViewModel();
        public WhetherLatestView()
        {
            InitializeComponent();

            this.AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreasComboBox.DataBindings.Add(
                "SelectedValue",_viewModel,nameof(_viewModel.SelectedAreaId));
            this.AreasComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);
            this.AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);
            this.DataDateLabel.DataBindings.Add(
                 "Text", _viewModel, nameof(_viewModel.DataDateText));
            this.ConditionLabel.DataBindings.Add(
                 "Text", _viewModel, nameof(_viewModel.ConditionText));
            this.TempalatureLabel.DataBindings.Add(
                 "Text", _viewModel, nameof(_viewModel.TemparatureText));
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherListView())
            {
                f.ShowDialog();
            }
        }
    }
}
