using MED_Tool.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MSAPI = Microsoft.WindowsAPICodePack;

namespace MED_Tool.ViewModels
{
    public class SettingViewModel : BindableBase
    {
        private string _minecraftSavePath = Properties.Settings.Default.MinecraftSavePath;
        public string MinecraftSavePath
        {
            get { return _minecraftSavePath; }
            set
            {
                SetProperty(ref _minecraftSavePath, value);
            }
        }
        private int _overlayWindowWidth = Properties.Settings.Default.OverlayWindowWidth;
        public int OverlayWindowWidth
        {
            get { return _overlayWindowWidth; }
            set { 
                SetProperty(ref _overlayWindowWidth, value);
            }
        }
        private int _adovancementIconSize = Properties.Settings.Default.AdovancementIconSize;
        public int AdovancementIconSize
        {
            get { return _adovancementIconSize; }
            set
            {
                SetProperty(ref _adovancementIconSize, value);
            }
        }

        private bool _overlayIsTopMost = Properties.Settings.Default.OverlayIsTopMost;
        public bool OverlayIsTopMost
        {
            get { return _overlayIsTopMost; }
            set
            {
                SetProperty(ref _overlayIsTopMost, value);
            }
        }
        private int _overlayBackgroundColorR = Properties.Settings.Default.OverlayBackgroundColor.R;
        public int OverlayBackgroundColorR
        {
            get { return _overlayBackgroundColorR; }
            set
            {
                SetProperty(ref _overlayBackgroundColorR, value);
            }
        }
        private int _overlayBackgroundColorG = Properties.Settings.Default.OverlayBackgroundColor.G;
        public int OverlayBackgroundColorG
        {
            get { return _overlayBackgroundColorG; }
            set
            {
                SetProperty(ref _overlayBackgroundColorG, value);
            }
        }
        private int _overlayBackgroundColorB = Properties.Settings.Default.OverlayBackgroundColor.B;
        public int OverlayBackgroundColorB
        {
            get { return _overlayBackgroundColorB; }
            set
            {
                SetProperty(ref _overlayBackgroundColorB, value);
            }
        }

        // startButton関連イベント
        private DelegateCommand<RoutedEventArgs> _startButton_Click;
        public DelegateCommand<RoutedEventArgs> StartButton_Click =>
            _startButton_Click ?? (_startButton_Click = new DelegateCommand<RoutedEventArgs>(ExecuteStartButton_Click));

        // overlayWidthTextBox関連イベント
        private DelegateCommand<TextCompositionEventArgs> _textBoxIntOnly_PreviewTextInput;
        public DelegateCommand<TextCompositionEventArgs> TextBoxIntOnly_PreviewTextInput =>
            _textBoxIntOnly_PreviewTextInput ?? (_textBoxIntOnly_PreviewTextInput = new DelegateCommand<TextCompositionEventArgs>(ExecuteTextBoxIntOnly_PreviewTextInput));
        private DelegateCommand<RoutedEventArgs> _overlayWidthTextBox_LostFocus;
        public DelegateCommand<RoutedEventArgs> OverlayWidthTextBox_LostFocus =>
            _overlayWidthTextBox_LostFocus ?? (_overlayWidthTextBox_LostFocus = new DelegateCommand<RoutedEventArgs>(ExecuteOverlayWidthTextBox_LostFocus));

        // ExplorerSelectButton関連イベント
        private DelegateCommand<RoutedEventArgs> _explorerSelectButton;
        public DelegateCommand<RoutedEventArgs> ExplorerSelectButton =>
            _explorerSelectButton ?? (_explorerSelectButton = new DelegateCommand<RoutedEventArgs>(ExecuteExplorerSelectButton_Click));

        // MCSavePathTextBox_LostFocus関連イベント
        private DelegateCommand<RoutedEventArgs> _mCSavePathTextBox_LostFocus;
        public DelegateCommand<RoutedEventArgs> MCSavePathTextBox_LostFocus =>
            _mCSavePathTextBox_LostFocus ?? (_mCSavePathTextBox_LostFocus = new DelegateCommand<RoutedEventArgs>(ExecuteMCSavePathTextBox_LostFocus));

        // IsTopMostCheckBo関連イベント
        private DelegateCommand<RoutedEventArgs> _isTopMostCheckBox_Changed;
        public DelegateCommand<RoutedEventArgs> IsTopMostCheckBox_Changed =>
            _isTopMostCheckBox_Changed ?? (_isTopMostCheckBox_Changed = new DelegateCommand<RoutedEventArgs>(ExecuteIsTopMostCheckBox_Changed));

        // overlayBackgroundColorTextBox関連イベント
        private DelegateCommand<TextCompositionEventArgs> _overlayBackgroundColorTextBox_PreviewTextInput;
        public DelegateCommand<TextCompositionEventArgs> OverlayBackgroundColorTextBox_PreviewTextInput =>
            _overlayBackgroundColorTextBox_PreviewTextInput ?? (_overlayBackgroundColorTextBox_PreviewTextInput = new DelegateCommand<TextCompositionEventArgs>(ExecuteOverlayBackgroundColorTextBox_PreviewTextInput));
        private DelegateCommand<RoutedEventArgs> _overlayBackgroundColorRTextBox_LostFocus;
        public DelegateCommand<RoutedEventArgs> OverlayBackgroundColorRTextBox_LostFocus =>
            _overlayBackgroundColorRTextBox_LostFocus ?? (_overlayBackgroundColorRTextBox_LostFocus = new DelegateCommand<RoutedEventArgs>(ExecuteOverlayBackgroundColorRTextBox_LostFocus));
        private DelegateCommand<RoutedEventArgs> _overlayBackgroundColorGTextBox_LostFocus;
        public DelegateCommand<RoutedEventArgs> OverlayBackgroundColorGTextBox_LostFocus =>
            _overlayBackgroundColorGTextBox_LostFocus ?? (_overlayBackgroundColorGTextBox_LostFocus = new DelegateCommand<RoutedEventArgs>(ExecuteOverlayBackgroundColorGTextBox_LostFocus));
        private DelegateCommand<RoutedEventArgs> _overlayBackgroundColorBTextBox_LostFocus;
        public DelegateCommand<RoutedEventArgs> OverlayBackgroundColorBTextBox_LostFocus =>
            _overlayBackgroundColorBTextBox_LostFocus ?? (_overlayBackgroundColorBTextBox_LostFocus = new DelegateCommand<RoutedEventArgs>(ExecuteOverlayBackgroundColorBTextBox_LostFocus));

        // AdovancementIconSizeTextBox関連イベント
        private DelegateCommand<RoutedEventArgs> _adovancementIconSizeTextBox_LostFocus;
        public DelegateCommand<RoutedEventArgs> AdovancementIconSizeTextBox_LostFocus =>
            _adovancementIconSizeTextBox_LostFocus ?? (_adovancementIconSizeTextBox_LostFocus = new DelegateCommand<RoutedEventArgs>(ExecuteAdovancementIconSizeTextBox_LostFocus));

        private OverlayView ov = null;

        public SettingViewModel()
        {
        }
        private void ExecuteStartButton_Click(RoutedEventArgs e)
        {
            if (ov == null)
            {
                ov = new OverlayView();
                ov.Closed += (sender, args) => ov = null;
                ov.Width = OverlayWindowWidth;
                ov.Topmost = OverlayIsTopMost;
                ov.Show();
            }
        }
        private void ExecuteTextBoxIntOnly_PreviewTextInput(TextCompositionEventArgs e)
        {
            // 0-9のみ
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text);
        }
        private void ExecuteOverlayWidthTextBox_LostFocus(RoutedEventArgs e)
        {
            // 念のため最大値を4Kに固定
            if (OverlayWindowWidth > Common.Common.FOUR_K_WIDTH)
            {
                OverlayWindowWidth = Common.Common.FOUR_K_WIDTH;
            }

            // プロパティに保存
            Properties.Settings.Default.OverlayWindowWidth = OverlayWindowWidth;
            Properties.Settings.Default.Save();

            // 表示されていた場合、横幅を変更する
            if (ov != null)
            {
                ov.Width = OverlayWindowWidth;
            }
        }
        private void ExecuteAdovancementIconSizeTextBox_LostFocus(RoutedEventArgs e)
        {
            // 念のため最大値を128に固定
            if (AdovancementIconSize > Common.Common.ADVANCEMENT_ICON_SIZE_MAX)
            {
                AdovancementIconSize = Common.Common.ADVANCEMENT_ICON_SIZE_MAX;
            } else if (AdovancementIconSize < Common.Common.ADVANCEMENT_ICON_SIZE_MIN)
            {
                // 最低値も16固定
                AdovancementIconSize = Common.Common.ADVANCEMENT_ICON_SIZE_MIN;
            }

            // プロパティに保存
            Properties.Settings.Default.AdovancementIconSize = AdovancementIconSize;
            Properties.Settings.Default.Save();

            // 既に表示している場合、各進捗のサイズを変える
            if (ov != null)
            {
                foreach(AdvancementView av in ((OverlayViewModel)ov.DataContext).Advancements)
                {
                    av.Advancements.Width = AdovancementIconSize;
                    av.Advancements.Height = AdovancementIconSize;
                    av.AdvancementsFrame.Width = AdovancementIconSize + AdovancementIconSize * 0.625;
                    av.AdvancementsFrame.Height = AdovancementIconSize + AdovancementIconSize * 0.625;
                    av.AdvancementsFrameComplete.Width = AdovancementIconSize + AdovancementIconSize * 0.625;
                    av.AdvancementsFrameComplete.Height = AdovancementIconSize + AdovancementIconSize * 0.625;
                }
            }
        }

        private void ExecuteExplorerSelectButton_Click(RoutedEventArgs e)
        {
            var dlg = new MSAPI::Dialogs.CommonOpenFileDialog();

            // フォルダ選択ダイアログを表示
            dlg.IsFolderPicker = true;
            dlg.Title = "Saveフォルダを選択";
            dlg.InitialDirectory = MinecraftSavePath;

            // ダイアログを出力し、OKが押されるまで
            if (dlg.ShowDialog() == MSAPI::Dialogs.CommonFileDialogResult.Ok)
            {
                MinecraftSavePath = dlg.FileName;
                Properties.Settings.Default.MinecraftSavePath = MinecraftSavePath;
                Properties.Settings.Default.Save();
            }
        }
        private void ExecuteMCSavePathTextBox_LostFocus(RoutedEventArgs e)
        {
            // プロパティに保存
            Properties.Settings.Default.MinecraftSavePath = MinecraftSavePath;
            Properties.Settings.Default.Save();
        }
        private void ExecuteIsTopMostCheckBox_Changed(RoutedEventArgs e)
        {
            // プロパティに保存
            Properties.Settings.Default.OverlayIsTopMost = OverlayIsTopMost;
            Properties.Settings.Default.Save();

            // 表示されていた場合、最前面に固定化する
            if (ov != null)
            {
                ov.Topmost = OverlayIsTopMost;
            }
        }
        private void ExecuteOverlayBackgroundColorTextBox_PreviewTextInput(TextCompositionEventArgs e)
        {
            // 0-9でかつ0～255の範囲のみ
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text);
            if(!e.Handled)
            {
                var text = ((TextBox)e.Source).Text + e.Text;
                if(text == "")
                {
                    text = "0";
                }
                e.Handled = !(int.Parse(text) >= 0 && int.Parse(text) <= 255);
            }
        }
        private void ExecuteOverlayBackgroundColorRTextBox_LostFocus(RoutedEventArgs e)
        {
            if(OverlayBackgroundColorR > 255) OverlayBackgroundColorR = 255;
            // プロパティに保存
            Properties.Settings.Default.OverlayBackgroundColor = System.Drawing.Color.FromArgb(OverlayBackgroundColorR, Properties.Settings.Default.OverlayBackgroundColor.G, Properties.Settings.Default.OverlayBackgroundColor.B);
            Properties.Settings.Default.Save();

            // 表示されていた場合、横幅を変更する
            if (ov != null)
            {
                ov.Background =  new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(Properties.Settings.Default.OverlayBackgroundColor.R, Properties.Settings.Default.OverlayBackgroundColor.G, Properties.Settings.Default.OverlayBackgroundColor.B));
            }
        }
        private void ExecuteOverlayBackgroundColorGTextBox_LostFocus(RoutedEventArgs e)
        {
            if (OverlayBackgroundColorG > 255) OverlayBackgroundColorG = 255;
            // プロパティに保存
            Properties.Settings.Default.OverlayBackgroundColor = System.Drawing.Color.FromArgb(Properties.Settings.Default.OverlayBackgroundColor.R, OverlayBackgroundColorG, Properties.Settings.Default.OverlayBackgroundColor.B);
            Properties.Settings.Default.Save();

            // 表示されていた場合、横幅を変更する
            if (ov != null)
            {
                ov.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(Properties.Settings.Default.OverlayBackgroundColor.R, Properties.Settings.Default.OverlayBackgroundColor.G, Properties.Settings.Default.OverlayBackgroundColor.B));
            }
        }
        private void ExecuteOverlayBackgroundColorBTextBox_LostFocus(RoutedEventArgs e)
        {
            if (OverlayBackgroundColorB > 255) OverlayBackgroundColorB = 255;
            // プロパティに保存
            Properties.Settings.Default.OverlayBackgroundColor = System.Drawing.Color.FromArgb(Properties.Settings.Default.OverlayBackgroundColor.R, Properties.Settings.Default.OverlayBackgroundColor.G, OverlayBackgroundColorB);
            Properties.Settings.Default.Save();

            // 表示されていた場合、横幅を変更する
            if (ov != null)
            {
                ov.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(Properties.Settings.Default.OverlayBackgroundColor.R, Properties.Settings.Default.OverlayBackgroundColor.G, Properties.Settings.Default.OverlayBackgroundColor.B));
            }
        }


        /// <summary>
        /// overlayを閉じる
        /// </summary>
        public void CloseOverlay()
        {
            // overlayをクローズ
            if(ov != null)
            {
                ov.Close();
            }
        }
    }
}
