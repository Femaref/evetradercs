using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using Visifire.Charts;

namespace EveTrader.Wpf.Attached
{
    public static class ChartBehaviour
    {
        public static bool GetExecuteCommandOnDoubleClick(DependencyObject obj)
        {
            return (bool)obj.GetValue(ExecuteCommandOnDoubleClickProperty);
        }

        public static void SetExecuteCommandOnDoubleClick(DependencyObject obj, bool value)
        {
            obj.SetValue(ExecuteCommandOnDoubleClickProperty, value);
        }

        // Using a DependencyProperty as the backing store for ExecuteCommandOnDoubleClick.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExecuteCommandOnDoubleClickProperty =
            DependencyProperty.RegisterAttached("ExecuteCommandOnDoubleClick", typeof(bool), typeof(ChartBehaviour), new UIPropertyMetadata(false, ExecuteCommandOnDoubleClickChanged));

        static void ExecuteCommandOnDoubleClickChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            Visifire.Charts.Chart item = (depObj as Chart);

            if (item == null)
                return;
            if (e.NewValue is bool == false)
                return;

            if ((bool)e.NewValue)
                item.MouseDoubleClick += OnMouseDoubleClick;
            else
                item.MouseDoubleClick -= OnMouseDoubleClick;

        }

        public static ICommand GetShowHideCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ShowHideCommandProperty);
        }

        public static void SetShowHideCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ShowHideCommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for ShowHideCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowHideCommandProperty =
            DependencyProperty.RegisterAttached("ShowHideCommand", typeof(ICommand), typeof(ChartBehaviour), new PropertyMetadata());

        static void OnMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var obj = e.Source as Visifire.Charts.Chart;

            if (obj == null)
                return;

            GetShowHideCommand(obj).Execute(null);
        }
    }
}
