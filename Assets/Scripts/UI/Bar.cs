using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class Bar : MonoBehaviour
{
    protected Coroutine Coroutine;
    protected Slider Slider;
    protected float ChangeValue = 1f;
    protected float SpeedChangeSlider = 1f;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    public virtual void OnValueChanged(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
        CallCoroutine();
    }

    private void CallCoroutine()
    {
        if (Coroutine != null)
            StopCoroutine(Coroutine);

        Coroutine = StartCoroutine(CoroutineSlider());
    }

    private IEnumerator CoroutineSlider()
    {
        var FixedUpdateAwaiter = new WaitForFixedUpdate();

        while (Slider.value != ChangeValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, ChangeValue, SpeedChangeSlider * Time.deltaTime);
            yield return FixedUpdateAwaiter;
        }
    }
}
