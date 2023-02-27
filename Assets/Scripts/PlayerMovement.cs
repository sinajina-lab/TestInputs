using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public DetectInput _inputManager;

    //Attachment-Detachment variables
    private Vector2 contactNormal;
    private void OnEnable()
    {
        _inputManager.OnTapped += HandleTapInput;
    }

    private void HandleTapInput()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        var launchAngle = transform.position - transform.parent.position;
        //detach from the nut
        transform.parent = null;
        GetComponent<CircleCollider2D>().enabled = false;
        rb.isKinematic = false;
        transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        rb.AddForce(launchAngle * 40f,ForceMode2D.Impulse);
        Debug.Log($"rotation: {transform.rotation}");
        StartCoroutine(ResetPlayer());
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<CircleCollider2D>().enabled = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        var contactPoint = collision.contacts[0].point;
        
        var newGo = new GameObject("new game object");
        newGo.transform.SetParent(collision.transform);
        newGo.transform.position = contactPoint;
        transform.SetParent(newGo.transform);

        GetComponent<Rigidbody2D>().isKinematic = true;
        
    }
}
