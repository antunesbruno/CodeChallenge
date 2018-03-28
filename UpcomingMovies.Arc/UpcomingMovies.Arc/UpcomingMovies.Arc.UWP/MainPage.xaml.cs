namespace UpcomingMovies.Arc.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new UpcomingMovies.Arc.App());
        }
    }
}