namespace WatchFlowers;

public partial class AddGarden : ContentPage
{
	public AddGarden()
	{
		InitializeComponent();
        SettingSliders();
	}

    void SettingSliders()
    {
        SliderRateWater.Maximum = 14;
        SliderLighting.Maximum = Detectors.MaxLighting;
        SliderTemp.Maximum = Detectors.MaxTemp;
        SliderWet.Maximum = Detectors.MaxWetAir;
    }

    private void InputNameGarden(object sender, TextChangedEventArgs e)
    {
		Entry entry = (Entry)sender;
		if (entry.Text != null && entry.Text != "") AddGardenBut.IsEnabled = true;
		else AddGardenBut.IsEnabled = false;
    }

    private void UpdWet(object sender, ValueChangedEventArgs e)
    {
		Slider slider = (Slider)sender;
		slider.Value = Math.Round(slider.Value, 0);
		LabelWet.Text = "Поддерживаемая влажность " + (slider.Value).ToString() + "%";
    }

    private void UpdLighting(object sender, ValueChangedEventArgs e)
    {
        Slider slider = (Slider)sender;
        slider.Value = Math.Round(slider.Value, 0);
        LabelLighting.Text = "Поддерживаемое освещение " + slider.Value.ToString() + "ЛК";
    }

    private void UpdTemp(object sender, ValueChangedEventArgs e)
    {
        Slider slider = (Slider)sender;
        slider.Value = Math.Round(slider.Value, 0);
        LabelTemp.Text = "Поддерживаемая температура " + slider.Value.ToString() + "°";
    }

    private void UpdRateWater(object sender, ValueChangedEventArgs e)
    {
        Slider slider = (Slider)sender;
        slider.Value = Math.Round(slider.Value, 0);
        LabelRateWater.Text = "Периодичность полива " + slider.Value.ToString() + "/неделю";
    }

    private void CreateGarden(object sender, EventArgs e)
    {
        Plant plant = new Plant
        (
            EntryNameGarden.Text, 
            (int)SliderWet.Value, 
            (int)SliderLighting.Value, 
            (int)SliderTemp.Value,
            (int)SliderRateWater.Value, 
            EntryDescriptionText.Text
        );
        _AllPlants.plants.Add(plant);
        MainPage.page.PrintPlant(plant);
        EntryNameGarden.Text = "";
        EntryDescriptionText.Text = "";

        SliderRateWater.Value = default;
        SliderLighting.Value = default;
        SliderTemp.Value = default;
        SliderWet.Value = default;

        AddPan.IsVisible = false;
        SucsCreate.IsVisible = true;

        _AllPlants.Save();
    }

    private void GoodBut(object sender, EventArgs e)
    {
        AddPan.IsVisible = true;
        SucsCreate.IsVisible = false;
    }
}