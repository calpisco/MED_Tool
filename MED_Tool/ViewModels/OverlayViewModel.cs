using MED_Tool.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Timers;
using System.IO;
using System.Diagnostics;
using System.Windows;
using static MED_Tool.Common.Common;

namespace MED_Tool.ViewModels
{
    public class OverlayViewModel : BindableBase
    {
        private int _overlayWindowWidth = Properties.Settings.Default.OverlayWindowWidth;
        public int OverlayWindowWidth
        {
            get { return _overlayWindowWidth; }
            set { SetProperty(ref _overlayWindowWidth, value); }
        }
        private List<UserControl> _advancements = new List<UserControl>();
        public List<UserControl> Advancements
        {
            get { return _advancements; }
            set { SetProperty(ref _advancements, value); }
        }

        // 1秒間隔でSaveファイルを見に行く
        Timer timer = new Timer(1000);

        // 実績表示Listbox系イベント
        private DelegateCommand<SelectionChangedEventArgs> _listBox_SelectionChanged;
        public DelegateCommand<SelectionChangedEventArgs> ListBox_SelectionChanged =>
            _listBox_SelectionChanged ?? (_listBox_SelectionChanged = new DelegateCommand<SelectionChangedEventArgs>(ExecuteListBox_SelectionChanged));

        public OverlayViewModel()
        {
            // 実績を入れていく
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Minecraft/acquire_hardware.png", "story/smelt_iron", (int)ADVANCEMENT_FLG.ACQUIRE_HARDWARE));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/nether.png", "nether/root", (int)ADVANCEMENT_FLG.NETHER));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/those_were_the_days.png", "nether/find_bastion", (int)ADVANCEMENT_FLG.THOSE_WERE_THE_DAYS));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/oh_shiny.png", "nether/distract_piglin", (int)ADVANCEMENT_FLG.OH_SHINY));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/a_terrible_fortress.png", "nether/find_fortress", (int)ADVANCEMENT_FLG.A_TERRIBLE_FORTRESS));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/into_fire.png", "nether/obtain_blaze_rod", (int)ADVANCEMENT_FLG.INTO_FIRE));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Minecraft/eye_spy.png", "story/follow_ender_eye", (int)ADVANCEMENT_FLG.EYE_SPY));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/End/the_end.png", "end/root", (int)ADVANCEMENT_FLG.THE_END));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/End/free_the_end.png", "end/kill_dragon", (int)ADVANCEMENT_FLG.FREE_THE_END));

            // ファイルを見に行く処理
            timer.Elapsed += (sender, e) =>
            {
                // 一番新しいディレクトリを取得
                var lastSavedDirectory = Directory.GetDirectories(Properties.Settings.Default.MinecraftSavePath)
                    .OrderByDescending(f => File.GetLastWriteTime(f)).First();

                Debug.WriteLine(lastSavedDirectory);
                try
                {
                    // 進捗情報を取得
                    var advancementsJsonData = File.ReadAllText(Directory.GetFiles(lastSavedDirectory + @"\advancements\").First());

                    foreach (AdvancementView advancement in Advancements)
                    {
                        // 各タグ情報と一致があれば進捗状況の見た目を変更
                        advancement.Dispatcher.Invoke((Action)(() =>
                        {
                            if (advancementsJsonData.Contains((string)advancement.Tag))
                            {
                                advancement.ChangedAdvancementComplete(Visibility.Visible);
                            }
                            else
                            {
                                advancement.ChangedAdvancementComplete(Visibility.Hidden);
                            }
                        }));

                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            };
            timer.Start();
        }
        private void ExecuteListBox_SelectionChanged(SelectionChangedEventArgs e)
        {
            ((ListBox)e.Source).SelectedIndex = -1;
        }
    }
}
