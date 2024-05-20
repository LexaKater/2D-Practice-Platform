public class HealthViewSlider : SliderShifter
{
    protected override void ShiftSlider() => HealthSlider.value = GetCurrentHealth();
}