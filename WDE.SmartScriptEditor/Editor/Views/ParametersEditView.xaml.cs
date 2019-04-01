﻿using System.Windows;
using WDE.SmartScriptEditor.Editor.ViewModels;
using WDE.Conditions.Views;
using WDE.Conditions.ViewModels;
using WDE.Common.Parameters;

namespace WDE.SmartScriptEditor.Editor.Views
{
    /// <summary>
    /// Interaction logic for ParametersEditView.xaml
    /// </summary>
    public partial class ParametersEditView : Window
    {
        private readonly IParameterFactory parameterFactory;

        public ParametersEditView(IParameterFactory parameterFactory)
        {
            InitializeComponent();
            this.parameterFactory = parameterFactory;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void editConditionsButton_Click(object sender, RoutedEventArgs e)
        {
            ParametersEditViewModel model = DataContext as ParametersEditViewModel;
            
            if (model._conditions != null)
            {
                ConditionsEditView view = new ConditionsEditView();
                ConditionsEditViewModel viewModel = new ConditionsEditViewModel(model._conditions, model.conditionDataManager, model.itemFromListProvider, parameterFactory);
                view.DataContext = viewModel;
                view.ShowDialog();
            }
        }
    }
}
