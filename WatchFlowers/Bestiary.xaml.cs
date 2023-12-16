namespace WatchFlowers;

public partial class Bestiary : ContentPage
{
	List<Grid> ListPans = new List<Grid>();

	public Bestiary()
	{
		InitializeComponent();

		for (int i = 0; i < BestiaryPlants.Plants.Count; i++)
		{
			Grid pans = new Grid
			{
				RowDefinitions =
				{
					new RowDefinition(),
					new RowDefinition(),
				},

				ColumnDefinitions =
				{
					new ColumnDefinition(),
					new ColumnDefinition(),
				},

				Margin = 10,
			};
			PlantsList.Add(pans);
			ListPans.Add(pans);

			Button moreInfo = new Button
			{
				BackgroundColor = Color.FromArgb("#DAEFF0"),
				BorderColor = Color.FromArgb("#56B185"),
				BorderWidth = 2,
			};
			Adder(moreInfo, pans, 0, 0, 2, 2);
			moreInfo.Clicked += OpenMoreInfo;

			Label nameL = new Label
			{
				Text = BestiaryPlants.Plants[i].Name,
				TextColor = Color.FromArgb("#1E1E1E"),
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Margin = 10,
				HorizontalTextAlignment = TextAlignment.Center,
			};
            Adder(nameL, pans, 0, 0);

			Label descriptionL = new Label
			{
				Text = BestiaryPlants.Plants[i].Description,
				TextColor = Color.FromArgb("#1E1E1E"),
				FontSize = 16,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Margin = 10,
				HorizontalTextAlignment = TextAlignment.Center,
			};
            Adder(descriptionL, pans, 1, 0);

			Image ico = new Image
			{
				Source = BestiaryPlants.Plants[i].PatchToImage,
				Margin = 15,
            };
            Adder(ico, pans, 0, 1, 2);
        }
    }

    private void OpenMoreInfo(object? sender, EventArgs e)
    {
		PlantsList.IsVisible = false;

        Grid cart = (Grid)((Button)sender).Parent;
        int num = ListPans.IndexOf(cart);
        Plant plant = BestiaryPlants.Plants[num];

		LName.Text = plant.Name;
		LDescription.Text = plant.Description;
		Ico.Source = plant.PatchToImage;
		LWetSail.Text = "Полив почвы " + plant.RateWater + "/неделю";
		LLighting.Text = "Уровень освещения " + plant.PrefLighting + "ЛК";
		LTemp.Text = "Температура окражеющей среды " + plant.PrefTemp + "°";
		LWetAir.Text = "Влажность воздуха " + plant.PrefWetAir + "%";


        InfoPan.IsVisible = true;
	}

	static void Adder(View @object, Grid grid, int row, int column, int rowSpan = 0, int columnSpan = 0)
    {
        grid.Add(@object, column, row);
        Grid.SetColumnSpan(@object, columnSpan);
        Grid.SetRowSpan(@object, rowSpan);
    }

    private void CloseInfo(object sender, EventArgs e)
    {
		InfoPan.IsVisible = false;
		PlantsList.IsVisible = true;
    }
}