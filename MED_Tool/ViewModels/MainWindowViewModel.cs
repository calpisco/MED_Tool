using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MED_Tool.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private UserControl _settingView = new Views.SettingView();
        public UserControl SettingView
        {
            get { return _settingView; }
            set { SetProperty(ref _settingView, value); }
        }

        // close関連イベント
        private DelegateCommand<EventArgs> _Closed;
        public DelegateCommand<EventArgs> Closed =>
            _Closed ?? (_Closed = new DelegateCommand<EventArgs>(ExecuteClosed));

        public MainWindowViewModel()
        {
        }

        private void ExecuteClosed(EventArgs e)
        {
            ((SettingViewModel)SettingView.DataContext).CloseOverlay();
        }
    }
}
