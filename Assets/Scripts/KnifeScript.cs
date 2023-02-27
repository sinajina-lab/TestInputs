using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [SerializeField] float RotatingSpeed;

    public bool canRotate = false; 

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canRotate)
        transform.Rotate(0, 0, RotatingSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        canRotate = false;

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        rb.freezeRotation = true;
    }
}
