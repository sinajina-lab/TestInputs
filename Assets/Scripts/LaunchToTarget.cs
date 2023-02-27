using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchToTarget : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] float forcePower;

    Vector2 direction;

    Vector2 startPos;
    Vector2 endPos;

    private void Update()
    {
         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision entered!");
    }

}
