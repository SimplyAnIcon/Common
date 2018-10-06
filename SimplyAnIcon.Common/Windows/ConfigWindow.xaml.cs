using SimplyAnIcon.Common.ViewModels;

namespace SimplyAnIcon.Common.Windows
{
    /// <summary>
    /// ConfigWindow
    /// </summary>
    public partial class ConfigWindow
    {
        /// <summary>
        /// ConfigWindow
        /// </summary>
        public ConfigWindow( AbstractConfigViewModel abstractConfigViewModel )
        {
            InitializeComponent();
            DataContext = abstractConfigViewModel;
        }
    }
}
