using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{
    private TextMeshPro _tmp;
    
    
    private void OnEnable()
    {
        _tmp = gameObject.GetComponent<TextMeshPro>();
        Timer.OnTick += TickHandler;
    }
    

    public void Write(float value)
    {
        _tmp.text = $"{value:F0}";
    }

    private void TickHandler(float t)
    {
        Write(t);
    }
}
