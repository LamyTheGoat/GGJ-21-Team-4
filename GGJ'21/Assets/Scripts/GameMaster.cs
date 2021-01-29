using System.Collections;
using System.Collections.Generic;
using  UnityEngine.SceneManagement;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public void OnDeathOfPlayer()
    {
        //some code here
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
