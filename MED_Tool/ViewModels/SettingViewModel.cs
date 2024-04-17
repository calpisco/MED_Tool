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
using static MED_Tool.Common.Common;

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
        private int _advancementIconSize = Properties.Settings.Default.AdvancementIconSize;
        public int AdvancementIconSize
        {
            get { return _advancementIconSize; }
            set
            {
                SetProperty(ref _advancementIconSize, value);
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

        private bool _isAcquireHardware = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.ACQUIRE_HARDWARE) != 0;
        public bool IsAcquireHardware
        {
            get { return _isAcquireHardware; }
            set
            {
                SetProperty(ref _isAcquireHardware, value);
            }
        }
        private bool _isNether = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.NETHER) != 0;
        public bool IsNether
        {
            get { return _isNether; }
            set
            {
                SetProperty(ref _isNether, value);
            }
        }
        private bool _isThoseWereTheDays = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.THOSE_WERE_THE_DAYS) != 0;
        public bool IsThoseWereTheDays
        {
            get { return _isThoseWereTheDays; }
            set
            {
                SetProperty(ref _isThoseWereTheDays, value);
            }
        }
        private bool _isOhShiny = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.OH_SHINY) != 0;
        public bool IsOhShiny
        {
            get { return _isOhShiny; }
            set
            {
                SetProperty(ref _isOhShiny, value);
            }
        }
        private bool _isATerribleFortress = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.A_TERRIBLE_FORTRESS) != 0;
        public bool IsATerribleFortress
        {
            get { return _isATerribleFortress; }
            set
            {
                SetProperty(ref _isATerribleFortress, value);
            }
        }
        private bool _isIntoFire = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.INTO_FIRE) != 0;
        public bool IsIntoFire
        {
            get { return _isIntoFire; }
            set
            {
                SetProperty(ref _isIntoFire, value);
            }
        }
        private bool _isEyeSpy = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.EYE_SPY) != 0;
        public bool IsEyeSpy
        {
            get { return _isEyeSpy; }
            set
            {
                SetProperty(ref _isEyeSpy, value);
            }
        }
        private bool _isTheEnd = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.THE_END) != 0;
        public bool IsTheEnd
        {
            get { return _isTheEnd; }
            set
            {
                SetProperty(ref _isTheEnd, value);
            }
        }
        private bool _isFreeTheEnd = (Properties.Settings.Default.AdvancementsViewFlg & (int)ADVANCEMENT_FLG.FREE_THE_END) != 0;
        public bool IsFreeTheEnd
        {
            get { return _isFreeTheEnd; }
            set
            {
                SetProperty(ref _isFreeTheEnd, value);
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

        // AdvancementIconSizeTextBox関連イベント
        private DelegateCommand<RoutedEventArgs> _advancementIconSizeTextBox_LostFocus;
        public DelegateCommand<RoutedEventArgs> AdvancementIconSizeTextBox_LostFocus =>
            _advancementIconSizeTextBox_LostFocus ?? (_advancementIconSizeTextBox_LostFocus = new DelegateCommand<RoutedEventArgs>(ExecuteAdvancementIconSizeTextBox_LostFocus));

        // Show Advancement関連イベント
        private DelegateCommand<RoutedEventArgs> _showAdvancementCheckBoxes_Changed;
        public DelegateCommand<RoutedEventArgs> ShowAdvancementCheckBoxes_Changed =>
            _showAdvancementCheckBoxes_Changed ?? (_showAdvancementCheckBoxes_Changed = new DelegateCommand<RoutedEventArgs>(ExecuteShowAdvancementCheckBoxes_Changed));

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
        private void ExecuteAdvancementIconSizeTextBox_LostFocus(RoutedEventArgs e)
        {
            // 念のため最大値を128に固定
            if (AdvancementIconSize > Common.Common.ADVANCEMENT_ICON_SIZE_MAX)
            {
                AdvancementIconSize = Common.Common.ADVANCEMENT_ICON_SIZE_MAX;
            } else if (AdvancementIconSize < Common.Common.ADVANCEMENT_ICON_SIZE_MIN)
            {
                // 最低値も16固定
                AdvancementIconSize = Common.Common.ADVANCEMENT_ICON_SIZE_MIN;
            }

            // プロパティに保存
            Properties.Settings.Default.AdvancementIconSize = AdvancementIconSize;
            Properties.Settings.Default.Save();

            // 既に表示している場合、各進捗のサイズを変える
            if (ov != null)
            {
                foreach(AdvancementView av in ((OverlayViewModel)ov.DataContext).Advancements)
                {
                    av.Advancements.Width = AdvancementIconSize;
                    av.Advancements.Height = AdvancementIconSize;
                    av.AdvancementsFrame.Width = AdvancementIconSize + AdvancementIconSize * 0.625;
                    av.AdvancementsFrame.Height = AdvancementIconSize + AdvancementIconSize * 0.625;
                    av.AdvancementsFrameComplete.Width = AdvancementIconSize + AdvancementIconSize * 0.625;
                    av.AdvancementsFrameComplete.Height = AdvancementIconSize + AdvancementIconSize * 0.625;
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
        private void ExecuteShowAdvancementCheckBoxes_Changed(RoutedEventArgs e)
        {
            // フラグを設定
            int setFlg = 0;
            setFlg |= IsAcquireHardware ? (int)ADVANCEMENT_FLG.ACQUIRE_HARDWARE : 0;
            setFlg |= IsNether ? (int)ADVANCEMENT_FLG.NETHER : 0;
            setFlg |= IsThoseWereTheDays ? (int)ADVANCEMENT_FLG.THOSE_WERE_THE_DAYS : 0;
            setFlg |= IsOhShiny ? (int)ADVANCEMENT_FLG.OH_SHINY : 0;
            setFlg |= IsATerribleFortress ? (int)ADVANCEMENT_FLG.A_TERRIBLE_FORTRESS : 0;
            setFlg |= IsIntoFire ? (int)ADVANCEMENT_FLG.INTO_FIRE : 0;
            setFlg |= IsEyeSpy ? (int)ADVANCEMENT_FLG.EYE_SPY : 0;
            setFlg |= IsTheEnd ? (int)ADVANCEMENT_FLG.THE_END : 0;
            setFlg |= IsFreeTheEnd ? (int)ADVANCEMENT_FLG.FREE_THE_END : 0;

            // プロパティに保存
            Properties.Settings.Default.AdvancementsViewFlg = (short)setFlg;
            Properties.Settings.Default.Save();

            // 既に表示している場合、各進捗の表示を変更する
            if (ov != null)
            {
                foreach (AdvancementView av in ((OverlayViewModel)ov.DataContext).Advancements)
                {
                    if ((Properties.Settings.Default.AdvancementsViewFlg & ((AdvancementViewModel)av.DataContext).AdvancementFlg) != 0)
                    {
                        av.Visibility = Visibility.Visible;
                    } else
                    {
                        av.Visibility = Visibility.Collapsed;
                    }
                }
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
