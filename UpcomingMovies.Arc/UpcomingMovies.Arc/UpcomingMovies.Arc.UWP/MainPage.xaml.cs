using FFImageLoading.Forms.WinUWP;

namespace UpcomingMovies.Arc.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            CachedImageRenderer.Init();

            LoadApplication(new UpcomingMovies.Arc.App());
        }
    }
}