using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDestroyLoad : MonoBehaviour
{
    public static GameObject instance;
    public bool isPersistant = true;
     
    public virtual void Awake() {
        if(isPersistant) {
            if(!instance)
            {
                instance = this.gameObject;
            }
            else {
                DestroyObject(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this.gameObject;
        }
    }
}
