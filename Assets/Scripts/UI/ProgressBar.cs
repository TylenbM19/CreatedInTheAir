using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    private void OnEnable()
    {
        Player.OnChangedExperience += OnValueChanged;
    }

    private void OnDisable()
    {
        Player.OnChangedExperience -= OnValueChanged;
}

    public override void OnValueChanged(int value, int maxValue)
    {
        
    }
}
