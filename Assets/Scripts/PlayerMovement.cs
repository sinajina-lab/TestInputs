using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public DetectInput inputManager;
    Rigidbody2D rb;
    [SerializeField] float jumpForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        inputManager.OnTapped += Jump;
    }
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        Debug.Log("Jump");
    }
}
