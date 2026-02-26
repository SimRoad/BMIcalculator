namespace BMIcalculator;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnMetricCalculate(object? sender, EventArgs e)
    {
        if (double.TryParse(MetricHeightEntry.Text, out double height) &&
            double.TryParse(MetricWeightEntry.Text, out double weight))
        {
            double toMeters = height / 100;
            double bmi = weight / (toMeters * toMeters);
            string category = "";

            // string category = bmi switch
            // {
            //     < 0 => "Not possible",
            //     < 18.5 => "Underweight",
            //     < 25 => "Normal",
            //     < 35 => "Obese",
            //     _ => "Severely Obese"
            // };

            switch (bmi)
            {
                case 0:
                    category = "Not Possible";
                    BodyType.BackgroundColor=Colors.Black;
                    break;
                case < 18.5:
                    category = "Underweight";
                    BodyType.BackgroundColor=Colors.Green;
                    break;
                case < 25:
                    category = "Normal";
                    BodyType.BackgroundColor=Colors.YellowGreen;
                    break;
                case < 30:
                    category = "Overweight";
                    BodyType.BackgroundColor = Colors.Yellow;
                    break;
                case < 35:
                    category = "Obese";
                    BodyType.BackgroundColor = Colors.Orange;
                    break;
                default:
                    category = "Extremely Obese";
                    BodyType.BackgroundColor = Colors.Red;
                    break;
            }

            ResultsLabel.Text = $"{bmi:F2}";
            BodyType.Text = $"{category}";
            ResultsLayout.IsVisible = true;
        }
    }

    private void ToggleResults(object? sender, EventArgs e)
    {
        ResultsLayout.IsVisible = !ResultsLayout.IsVisible;
        ImperialBtn.Text = (ImperialBtn.Text == "Imperial") ? "01" : "Imperial";
    }
}