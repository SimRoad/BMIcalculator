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

            string category = bmi switch
            {
                < 0 => "Not possible",
                < 18.5 => "Underweight",
                < 25 => "Normal",
                < 35 => "Obese",
                _ => "Severely Obese"
            };

            ResultsLabel.Text = $"{bmi:F2}";
            BodyType.Text = $"{category}";
        }
    }
}