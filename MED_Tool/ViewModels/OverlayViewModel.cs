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

namespace MED_Tool.ViewModels
{
    public class OverlayViewModel : BindableBase
    {
        private int _overlay_window_width = Properties.Settings.Default.OverlayWindowWidth;
        public int OverlayWindowWidth
        {
            get { return _overlay_window_width; }
            set { SetProperty(ref _overlay_window_width, value); }
        }
        private List<UserControl> _advancements = new List<UserControl>();
        public List<UserControl> Advancements
        {
            get { return _advancements; }
            set { SetProperty(ref _advancements, value); }
        }

        // 1秒間隔でSaveファイルを見に行く
        Timer timer = new Timer(1000);

        public OverlayViewModel()
        {
            // 実績を入れていく
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Minecraft/acquire_hardware.png", "story/smelt_iron"));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/nether.png", "nether/root"));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/those_were_the_days.png", "nether/find_bastion"));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/oh_shiny.png", "nether/distract_piglin"));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/a_terrible_fortress.png", "nether/find_fortress"));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Nether/into_fire.png", "nether/obtain_blaze_rod"));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/Minecraft/eye_spy.png", "story/follow_ender_eye"));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/End/the_end.png", "end/root"));
            Advancements.Add(new AdvancementView("/Resources/Images/Advancements/End/free_the_end.png", "end/kill_dragon"));

            // ファイルを見に行く処理
            timer.Elapsed += (sender, e) =>
            {
                Debug.WriteLine("hello!!");
                // 一番新しいディレクトリを取得
                var lastSavedDirectory = Directory.GetDirectories(Properties.Settings.Default.MinecraftSavePath)
                    .OrderByDescending(f => File.GetLastWriteTime(f)).First();

                Debug.WriteLine(lastSavedDirectory);
                try
                {
                    // 進捗情報を取得
                    var advancementsJsonData = File.ReadAllText(Directory.GetFiles(lastSavedDirectory + @"\advancements\").First());

                    foreach (var advancement in Advancements)
                    {
                        // 各タグ情報と一致があれば進捗状況の見た目を変更
                        advancement.Dispatcher.Invoke((Action)(() =>
                        {
                            if (advancementsJsonData.Contains((string)advancement.Tag))
                            {
                                ((AdvancementView)advancement).ChangedAdvancementComplete(Visibility.Visible);
                            }
                            else
                            {
                                ((AdvancementView)advancement).ChangedAdvancementComplete(Visibility.Hidden);

                            }
                        }));

                    }
                } catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

            };

            timer.Start();
        }
    }
}
