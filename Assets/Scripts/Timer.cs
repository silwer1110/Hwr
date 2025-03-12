using TMPro;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private bool isRunning = false;
    private Coroutine _countCoroutine;
    private int _currentTime;

    private void Start()
    {
        _text.text = _currentTime.ToString();
    }

    private void OnMouseUpAsButton()
    {
        if (isRunning)
        {
            if (_countCoroutine != null)
                StopCoroutine(_countCoroutine);
        }
        else
        {
            _countCoroutine = StartCoroutine(CountUp(0.5f, _currentTime));
        }

        isRunning = !isRunning;
    }

    private IEnumerator CountUp(float delay, int start)
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(delay);

        for (int i = start; ; i++)
        {
            _currentTime = i;
            DisplayCountUp(i);
            yield return wait;
        }
    }

    private void DisplayCountUp(int count)
    {
        _text.text = count.ToString();
    }
}