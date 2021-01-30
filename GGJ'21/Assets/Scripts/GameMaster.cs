using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using  UnityEngine.SceneManagement;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject player;
    public GameData data;
    private void Awake()
    {
        player.transform.position = data.lastBonfire;
    }

    public void OnDeathOfPlayer()
    {
        Task.Delay(1500).ContinueWith(t => ReloadScene());
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RegisterBonfire(Transform bonfire)
    {
        data.lastBonfire = bonfire.position;
    }
}
