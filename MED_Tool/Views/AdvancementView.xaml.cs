using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MED_Tool.Views
{
    /// <summary>
    /// Interaction logic for AdvancementView
    /// </summary>
    public partial class AdvancementView : UserControl
    {
        public AdvancementView(string advancementImagePath, string tag)
        {
            InitializeComponent();
            Advancements.Source = new BitmapImage(new Uri(advancementImagePath, UriKind.Relative));
            this.Tag = tag;
            this.Advancements.Width = Properties.Settings.Default.AdovancementIconSize;
            this.Advancements.Height = Properties.Settings.Default.AdovancementIconSize;
            this.AdvancementsFrame.Width = Properties.Settings.Default.AdovancementIconSize + Properties.Settings.Default.AdovancementIconSize * 0.625;
            this.AdvancementsFrame.Height = Properties.Settings.Default.AdovancementIconSize + Properties.Settings.Default.AdovancementIconSize * 0.625;
            this.AdvancementsFrameComplete.Width = Properties.Settings.Default.AdovancementIconSize + Properties.Settings.Default.AdovancementIconSize * 0.625;
            this.AdvancementsFrameComplete.Height = Properties.Settings.Default.AdovancementIconSize + Properties.Settings.Default.AdovancementIconSize * 0.625;
        }

        /// <summary>
        /// 進捗状況を変更する
        /// </summary>
        public void ChangedAdvancementComplete(Visibility visibility)
        {
            AdvancementsFrameComplete.Visibility = visibility;
        }
    }
}
