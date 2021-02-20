using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TickEvent : UnityEvent<float>
{
}

public class Timer : MonoBehaviour
{
    public float time = 0.0f;
    public float tickDelay = 1.0f;
    public float maxTime = 999.0f;
    
    private float _t = 0.0f;
    private float _t0 = 0.0f;

    public delegate void Tick(float t);
    public static event Tick OnTick;

    private int _lastSecond = 0;


    private void OnEnable()
    {
        GetTime();
    }

    private void OnDisable()
    {
        StopCoroutine(Ticker());
    }


    public void Reset()
    {
        time = 0.0f;
        _t0 = Time.time;
        _t = _t0;
        StartCoroutine(Ticker());
    }
    
    public void GetTime()
    {
        _t = Time.time;
        time = Mathf.Floor(_t - _t0);
    }

    private IEnumerator Ticker()
    {
        while(time < maxTime)
        {
            GetTime();
            EmitTime();
            yield return new WaitForSeconds(tickDelay);
        }
    }

    private void EmitTime()
    {
        if (OnTick != null)
        {
            OnTick(time);
        }
    }
}
