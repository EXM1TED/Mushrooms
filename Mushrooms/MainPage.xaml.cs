using Mushrooms.Models;

namespace Mushrooms
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            LoadPage();
        }

        private void LoadPage()
        {
            using (ApplicationContext db = new())
            {
                List<Mushroom> mushrooms = db.Mushrooms.ToList();
                ListViewOfMushrooms.ItemsSource = mushrooms;
            }
        }

        private async void ButtonAddMushroom_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMushroom());
        }

        private async void SelectMushroom(object sender, SelectedItemChangedEventArgs e)
        {
            Mushroom mushroom = (Mushroom)e.SelectedItem;
            await Navigation.PushAsync(new PageOfMushroom(mushroom));
        }
    }
}
