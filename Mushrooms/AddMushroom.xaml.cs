using Mushrooms.Models;

namespace Mushrooms;

public partial class AddMushroom : ContentPage
{
    private string _filePath {  get; set; } = string.Empty;
	public AddMushroom()
	{
		InitializeComponent();
	}

    private async void Add_Clicked(object sender, EventArgs e)
    {
        string name = Name.Text;
        string latinName = LatinName.Text;
        string description = Description.Text;

        Mushroom mushroom = new(name,
            latinName,
            description,
            _filePath);

        using (ApplicationContext db = new())
        {
            db.Mushrooms.Add(mushroom);
            db.SaveChanges();
        }

        await DisplayAlert("Добавление", $"Гриб {name} - {latinName} добавлен", "Ок");
    }

	private async void SelectImage(object sender, EventArgs e)
	{
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Выбор изображения",
            FileTypes = FilePickerFileType.Images
        });

        if (result == null)
            return;

        var stream = await result.OpenReadAsync();

        string filePath = result.FullPath;
        this._filePath = filePath;

        SelectedImage.Source = ImageSource.FromStream(() => stream);

    }
}