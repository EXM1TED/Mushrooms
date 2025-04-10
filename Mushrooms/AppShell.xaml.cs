namespace Mushrooms
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(PageOfMushroom), typeof(PageOfMushroom));
        }
    }
}
