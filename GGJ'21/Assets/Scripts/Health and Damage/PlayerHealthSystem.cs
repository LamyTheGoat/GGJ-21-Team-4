using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    private GameMaster master;


    private void Start()
    {
        master = FindObjectOfType<GameMaster>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            master.ReloadScene();
        }
    }

    public override void Destroy()
    {
        master.OnDeathOfPlayer();
        base.Destroy();
    }

}
