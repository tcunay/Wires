using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private int _currentTime;
    private float _oneSecond = 1;
    private bool _isTicking;

    public event Action<int> TimeTicked;
    public event Action TickEnded;

    public IEnumerator StartCountdown(int time)
    {
        _currentTime = time;
        _isTicking = true;
        while (_isTicking)
        {
            yield return new WaitForSeconds(_oneSecond);

            _currentTime--;
            TimeTicked?.Invoke(_currentTime);

            if (_currentTime == 0)
                StopTick();
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
