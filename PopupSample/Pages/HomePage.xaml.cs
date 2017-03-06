using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Interfaces.Animations;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace PopupSample.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            AnimationPicker.SelectedIndex = 0;
        }

        private async void SimplePopupClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new BasicPopup() { CloseWhenBackgroundIsClicked = true });
        }
        private async void StilizedPopupClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new StilizedPopup());
        }

        Dictionary<int, IPopupAnimation> Animations = new Dictionary<int, IPopupAnimation>()
        {
            {0, new ScaleAnimation() },
            {1, new MoveAnimation() },
            {2,new FadeAnimation() }
        };

        private async void PropertiedPopupClicked(object sender, EventArgs e)
        {
            var propertiedPopup = new PropertiesPopup();

            propertiedPopup.Animation = Animations[AnimationPicker.SelectedIndex];
            propertiedPopup.BackgroundColor = Color.FromRgba(0, 0, 0, TransparencySlider.Value);
            propertiedPopup.CloseWhenBackgroundIsClicked = CloseOnTapSwitch.IsToggled;
            propertiedPopup.HasSystemPadding = SystemPaddingSwitch.IsToggled;

            await PopupNavigation.PushAsync(propertiedPopup);
        }

        private async void CustomizedAnimationClicked(object sender, EventArgs e)
        {
            var propertiedPopup = new PropertiesPopup();

            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Top,
                PositionOut = MoveAnimationOptions.Bottom,
                ScaleIn = 1.2,
                ScaleOut = 0.8,
                DurationIn = 400,
                DurationOut = 800,
                EasingIn = Easing.BounceIn,
                EasingOut = Easing.CubicOut,
                HasBackgroundAnimation = false
            };

            propertiedPopup.Animation = scaleAnimation;
            await PopupNavigation.PushAsync(propertiedPopup);
        }
    }
}
