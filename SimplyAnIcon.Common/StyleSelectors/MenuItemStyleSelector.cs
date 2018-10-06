using System.Windows;
using System.Windows.Controls;
using SimplyAnIcon.Plugins.Wpf.V1.MenuItemViewModels;

namespace SimplyAnIcon.Common.StyleSelectors
{
    /// <summary>
    /// MenuItemStyleSelector
    /// </summary>
    public class MenuItemStyleSelector : StyleSelector
    {
        /// <inheritdoc />
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var baseStyle = Application.Current.FindResource("SimplyAMenuItemStyle") as Style;

            var vm = item as MenuItemViewModel;
            if (vm == null)
                return baseStyle;

            return vm.ItemStyle ?? baseStyle;
        }
    }
}