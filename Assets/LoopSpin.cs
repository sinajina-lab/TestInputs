using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSpin : MonoBehaviour
{
    [SerializeField] float spinSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, spinSpeed);
    }
}
