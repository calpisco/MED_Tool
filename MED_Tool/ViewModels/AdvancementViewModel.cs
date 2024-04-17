using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MED_Tool.ViewModels
{
	public class AdvancementViewModel : BindableBase
    {
        private int _advancementFlg = 0;
        public int AdvancementFlg
        {
            get { return _advancementFlg; }
            set { SetProperty(ref _advancementFlg, value); }
        }
        public AdvancementViewModel()
		{

		}
	}
}
