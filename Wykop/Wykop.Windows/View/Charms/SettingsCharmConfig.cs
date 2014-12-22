using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Wykop.View.Charms
{
    public class SettingsCharmConfig
    {
        private const string AppSettingsCommandId = "AppSettingsCommand";
        private const double AppSettingsPopupWidth = 346; // guideliness says: 346 or 646


        public void SetupSettingsCharm()
        {
            SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }

        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            var windowBounds = Window.Current.Bounds;
            SettingsCommand appSettings = new SettingsCommand(AppSettingsCommandId, "Ustawienia", (x) =>
            {
                var settingsPopup = new Popup()
                {
                    Width = AppSettingsPopupWidth,
                    Height = windowBounds.Height,
                    IsLightDismissEnabled = true,
                };

                SettingsCharmUserControl settingsCharmUserControl = new SettingsCharmUserControl()
                {
                    Width = settingsPopup.Width,
                    Height = settingsPopup.Height
                };
                settingsPopup.Child = settingsCharmUserControl;
                Canvas.SetLeft(settingsPopup, windowBounds.Width - settingsPopup.Width);
                Canvas.SetTop(settingsPopup, 0);
                settingsPopup.IsOpen = true;
            });

            args.Request.ApplicationCommands.Add(appSettings);
        }
    }
}
