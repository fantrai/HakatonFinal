namespace WatchFlowers
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void PrintPlant(string name, string description)
        {
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

            Button moreInfoBut = new Button()
            {
                BackgroundColor = Color.FromArgb("#DAEFF0"),
            };
            Adder(moreInfoBut, plantCart, 0, 0, 3, 4);

            Label namePlant = new Label() 
            { 
                Text = name,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(5, 10),
                FontSize = 20,
                TextColor = Color.FromArgb("#1E1E1E"),
            };
            Adder(namePlant, plantCart, 0, 0, 0, 3);

            Label descriptionPlant = new Label() 
            { 
                Text = description,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(5, 10),
                FontSize = 16,
                TextColor = Color.FromArgb("#56B185"),
            };
            Adder(descriptionPlant, plantCart, 1, 0, 0, 3);

            Image drop = new Image() 
            { 
                Source = "gdrop",
                Margin = new Thickness(20, 10),
                VerticalOptions = LayoutOptions.Start,
            };
            Adder(drop, plantCart, 2, 0, 0, 3);
        }

        static void Adder(View @object, Grid grid, int row, int column, int rowSpan = 0, int columnSpan = 0)
        {
            grid.Add(@object, column, row);
            Grid.SetColumnSpan(@object, columnSpan);
            Grid.SetRowSpan(@object, rowSpan);
        }
    }
}
