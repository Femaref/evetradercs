﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using EveTrader.Core.Visual.ViewModel;
using EveTrader.Core.Visual.ViewModel.Display;

namespace EveTrader.Wpf.Selectors
{
    public class JournalCurrencyColorSelector : DataTemplateSelector
    {
        public DataTemplate NegativeTemplate { get; set; }
        public DataTemplate NormalTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var data = item as DisplayJournal;

            if (data == null)
                return base.SelectTemplate(item, container);

            if (data.Amount < 0m)
                return NegativeTemplate;
            return NormalTemplate;
        }
    }
}
