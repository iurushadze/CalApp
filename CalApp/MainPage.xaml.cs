namespace CalApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                int age = int.Parse(AgeEntry.Text);
                double height = double.Parse(HeightEntry.Text);
                double weight = double.Parse(WeightEntry.Text);
                string gender = GenderPicker.SelectedItem?.ToString() ?? "Male";
                string activity = ActivityPicker.SelectedItem?.ToString() ?? "Walking";
                double speed = double.Parse(SpeedEntry.Text);
                string measureType = MeasurePicker.SelectedItem?.ToString()?.ToLower() ?? "steps";

                int steps = 0;
                double distance = 0;

                if (measureType == "steps")
                    steps = string.IsNullOrWhiteSpace(StepsEntry.Text) ? 0 : int.Parse(StepsEntry.Text);
                else
                    distance = string.IsNullOrWhiteSpace(DistanceEntry.Text) ? 0 : double.Parse(DistanceEntry.Text);

                double calories = CalorieCalculator.GetCaloriesBurned(
                  age, height, weight, gender,
                  activity, speed, measureType,
                  steps, distance);

                ResultLabel.Text = $"Calories Burned: {calories:F2}";
            }
            catch (Exception ex)
            {
                ResultLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}