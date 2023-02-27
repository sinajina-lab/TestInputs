using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSpin : MonoBehaviour
{
    [SerializeField] float spinSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedModifier;

    private void FixedUpdate()
    {
        rb.angularVelocity = spinSpeed * speedModifier;
    }
}
