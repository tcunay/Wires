using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private const float _oneSecond = 1;

    private int _currentTime;
    private bool _isTicking;

    public event Action<int> TimeTicked;
    public event Action TickEnded;

    public IEnumerator StartCountdown(int time)
    {
        _currentTime = time;
        _isTicking = true;
        while (_isTicking)
        {
            TimeTicked?.Invoke(_currentTime);
            if (_currentTime == 0)
                StopTick();

            yield return new WaitForSeconds(_oneSecond);

            _currentTime--;
        }
    }

    public void StopTick()
    {
        if (_isTicking == true)
        {
            _isTicking = false;
            TickEnded?.Invoke();
        }
    }
}
