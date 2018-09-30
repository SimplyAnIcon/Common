﻿using SimplyAnIcon.Plugins.Wpf.Util;
using SimplyAnIcon.Plugins.Wpf.V1.MenuItemViewModels;

namespace SimplyAnIcon.Common.ViewModels.Interfaces
{
    /// <summary>
    /// ISimplyAnIconViewModel
    /// </summary>
    public interface ISimplyAnIconViewModel
    {
        /// <summary>
        /// Items
        /// </summary>
        FastObservableCollection<MenuItemViewModel> Items { get; }

        /// <summary>
        /// IsVisible
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// IconSource
        /// </summary>
        string IconSource { get; }

        /// <summary>
        /// IconName
        /// </summary>
        string IconName { get; }

        /// <summary>
        /// StayOpen
        /// </summary>
        bool StayOpen { get; }
    }
}
