
namespace WatchFlowers
{
    public partial class MainPage : ContentPage
    {
        public static MainPage page;
        List<Grid> pans = new List<Grid>();

        public MainPage()
        {
            InitializeComponent();
            page = this;
            UpdatePan();
        }

        public void UpdatePan()
        {
            if (pans.Count == 0) NotFlowers.IsVisible = true;
            PlantsList.Children.Clear();
            for (int i = 0; i < _AllPlants.plants.Count; i++)
            {
                Plant plant = _AllPlants.plants[i];
                PrintPlant(plant);
            }
        }

        internal void PrintPlant(Plant plant)
        {
            NotFlowers.IsVisible = false;
            Grid plantCart = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                },

                ColumnDefinitions = 
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition{ Width = new GridLength(1.5, GridUnitType.Star) },
                },

                Margin = 10,
            };
            PlantsList.Add(plantCart);
            pans.Add(plantCart);

            Button moreInfoBut = new Button()
            {
                BackgroundColor = Color.FromArgb("#DAEFF0"),
            };
            moreInfoBut.Clicked += MoreInfo;
            Adder(moreInfoBut, plantCart, 0, 0, 3, 4);

            Label namePlant = new Label() 
            { 
                Text = plant.Name,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(5, 10),
                FontSize = 20,
                TextColor = Color.FromArgb("#1E1E1E"),
            };
            Adder(namePlant, plantCart, 0, 0, 0, 3);

            Label descriptionPlant = new Label() 
            { 
                Text = plant.Description,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(5, 10),
                FontSize = 16,
                TextColor = Color.FromArgb("#56B185"),
            };
            Adder(descriptionPlant, plantCart, 1, 0, 0, 3);

            Image drop = new Image() 
            { 
                Source = plant.WaterIsGood ? "gdrop" : "rdrop",
                Margin = new Thickness(20, 10),
                VerticalOptions = LayoutOptions.Start,
            };
            Adder(drop, plantCart, 2, 0);

            Image sun = new Image() 
            { 
                Source = plant.SunIsGood ? "gsun" : "rsun",
                Margin = new Thickness(20, 10),
                VerticalOptions = LayoutOptions.Start,
            };
            Adder(sun, plantCart, 2, 1);

            Image temp = new Image() 
            { 
                Source = plant.TempIsGood ? "gtemp" : "rtemp",
                Margin = new Thickness(20, 10),
                VerticalOptions = LayoutOptions.Start,
            };
            Adder(temp, plantCart, 2, 2);

            Image garden1 = new Image() 
            { 
                Source = "garden1",
                VerticalOptions = LayoutOptions.Start,
            };
            Adder(garden1, plantCart, 0, 3, 3);
        }

        private void MoreInfo(object? sender, EventArgs e)
        {
            PlantsList.IsVisible = false;

            Grid cart = (Grid)((Button)sender).Parent;
            int num = pans.IndexOf(cart);
            Plant plant = _AllPlants.plants[num];
            MLabelName.Text = plant.Name;
            MLabelDescription.Text = plant.Description;
            MLabelWetSoil.Text = "Влажность почвы " + plant.WetSoil + "%";
            DropIco.Source = plant.WaterIsGood ? "gdrop" : "rdrop";
            MDLWetSail.Text = plant.WaterIsGood ? "Следующий полив " + (plant.NextWet == 0 ? "сегодня" : (plant.NextWet == 1 ? "сегодня" : "через " + plant.NextWet  + " дня")) : "Система полива требует вашего внимания!";
            MDLWetSail.TextColor = plant.WaterIsGood ? Color.FromArgb("#56B185") : Color.FromArgb("#C66085");

            MLabelLighting.Text = "Уровень освещения " + plant.Lighting + "%";
            SunIco.Source = plant.SunIsGood ? "gsun" : "rsun";
            MDLLighting.Text = plant.SunIsGood ? "В пределах нормы" : "Система освещения требует вашего внимания!";
            MDLLighting.TextColor = plant.SunIsGood ? Color.FromArgb("#56B185") : Color.FromArgb("#C66085");

            MLabelTemp.Text = "Температура окружающей среды " + plant.Temp + "°";
            TempIco.Source = plant.TempIsGood ? "gtemp" : "rtemp";
            MDLTemp.Text = plant.TempIsGood ? "В пределах нормы" : "Система обогрева требует вашего внимания!";
            MDLTemp.TextColor = plant.TempIsGood ? Color.FromArgb("#56B185") : Color.FromArgb("#C66085");

            MLabelWetAir.Text = "Влажность Воздуха " + plant.WetAir + "%";
            MDLWetAir.Text = plant.WetAirIsGood ? "В пределах нормы" : "Система увлажнения требует вашего внимания!";
            MDLWetAir.TextColor = plant.WetAirIsGood ? Color.FromArgb("#56B185") : Color.FromArgb("#C66085");

            MoreInfoPan.IsVisible = true;
        }

        static void Adder(View @object, Grid grid, int row, int column, int rowSpan = 0, int columnSpan = 0)
        {
            grid.Add(@object, column, row);
            Grid.SetColumnSpan(@object, columnSpan);
            Grid.SetRowSpan(@object, rowSpan);
        }

        private void CloseMoreInfo(object sender, EventArgs e)
        {
            PlantsList.IsVisible = true;
            MoreInfoPan.IsVisible = false;
        }
    }
}
