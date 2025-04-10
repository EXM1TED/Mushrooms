using Mushrooms.Models;
namespace Mushrooms;

public partial class PageOfMushroom : ContentPage
{
    private string _filePath {  get; set; } = string.Empty;
    private Mushroom _mushroom { get; set; }
    
    private string _oldName = string.Empty;
    private string _oldLatinName = string.Empty;


    public PageOfMushroom(Mushroom mushroom)
	{
		InitializeComponent();
        this._mushroom = mushroom;
        this._oldName = mushroom.Name;
        this._oldLatinName = mushroom.LatinName;
		this.LatinNameLabel.Text = $"({mushroom.LatinName})";
		this.BindingContext = mushroom;
	}

    private async void GoBack_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void Update_Clicked(object sender, EventArgs e)
    {
        _mushroom.Name = NameOfMushroom.Text;
        _mushroom.LatinName = LatinNameLabel.Text;
        _mushroom.Description = Description.Text;
        _mushroom.Image = _filePath;

        using (ApplicationContext db = new())
        {
            db.Mushrooms.Update(_mushroom);
            db.SaveChanges();
        }

        await DisplayAlert("Обновление", $"Гриб {_oldName} - {_oldLatinName} обновлен", "Ок");
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

        ImageOfMushroom.Source = ImageSource.FromStream(() => stream);

    }

    private async void ButtonDelete_Clicked(object sender, EventArgs e)
    {
        using(ApplicationContext db = new())
        {
            db.Mushrooms.Remove(_mushroom);
            db.SaveChanges();
            await Navigation.PopAsync();
            await DisplayAlert("Удаление", $"Гриб {_mushroom.Name} - {_mushroom.LatinName} удален", "Ок");
        }
    }
}