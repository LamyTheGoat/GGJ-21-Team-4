using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bonfire : MonoBehaviour
{
    public  UnityEvent onPressE;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            onPressE.Invoke();
        }
    }
}
