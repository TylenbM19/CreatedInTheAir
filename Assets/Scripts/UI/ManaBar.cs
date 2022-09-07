
public class ManaBar : Bar
{
    private void OnEnable()
    {
        Player.OnChangedForsePerSkill += OnValueChanged;
    }

    private void OnDisable()
    {
        Player.OnChangedForsePerSkill -= OnValueChanged;
    }

    public override void OnValueChanged(int value, int maxValue)
    {
        base.OnValueChanged(value, maxValue);
    }
}
