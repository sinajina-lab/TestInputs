using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallAndDie : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        SceneManager.LoadScene(1);
    }
}