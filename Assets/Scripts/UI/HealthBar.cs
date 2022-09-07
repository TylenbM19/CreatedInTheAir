
public class HealthBar : Bar
{
    private void OnEnable()
    {
        Player.OnChangedHealth += OnValueChanged;
    }

    private void OnDisable()
    {
        Player.OnChangedHealth += OnValueChanged;
    }

    public override void OnValueChanged(int value, int maxValue)
    {
        base.OnValueChanged(value, maxValue);
    }
}
