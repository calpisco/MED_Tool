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
