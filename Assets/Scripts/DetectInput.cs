using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectInput : MonoBehaviour
{
    public event Action OnTapped;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTapped?.Invoke();
        }
    }

    
}
