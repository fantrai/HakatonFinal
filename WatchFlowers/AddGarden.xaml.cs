namespace WatchFlowers;

public partial class AddGarden : ContentPage
{
	public AddGarden()
	{
		InitializeComponent();
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
		slider.Value = Math.Round(slider.Value, 1);
		LabelWet.Text = "Поддерживаемая влажность " + (slider.Value * 100).ToString() + "%";
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
        _Plant plant = new _Plant
        (
            EntryNameGarden.Text, 
            (float)SliderWet.Value, 
            (float)SliderLighting.Value, 
            (float)SliderTemp.Value,
            (int)SliderRateWater.Value, 
            EntryDescriptionText.Text
        );

        _AllPlants.plants.Add(plant);
    }
}