using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    [SerializeField] private Transform attackPointLow;

    [SerializeField] private Transform attackPointMed;

    [SerializeField] private Transform attackPointHigh;

    [SerializeField] private GameObject damageObject;
    



     private String currentPosition;
     private int currentPosIndex = 1;

     [SerializeField] private GameObject attackReadyIndicator;
     


    private void Start()
    {
        currentPosition = attackPointMed.name;
        damageObject.transform.position = attackPointMed.position; 
        damageObject.SetActive(false);
    }

    void Update()
    {
        GetInput();
        if (chargingAttack)
        {
            ChargeAnAttack();
        }

        if (damageObject.activeSelf && Time.time > attackDissappearTime)
        {
            damageObject.GetComponent<Damage>().damage -= heavymodifier;
            damageObject.SetActive(false);
        }

        if (Time.time > attackableTime)
        {
            attackReadyIndicator.SetActive(true);
        }
    }

    void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ChangePosition(false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangePosition(true);
        }

        if (Input.GetButtonDown("Fire1") && Time.time > attackableTime)
        {
            ChargeAnAttack();
        }
    }


    void ChangePosition(bool back)
    {
        int incrementValue = back ? -1 : 1;
        currentPosIndex = Mathf.Clamp((currentPosIndex + incrementValue), 0, 2);

        switch (currentPosIndex)
        {
            case  0:
                currentPosition = attackPointLow.name;
                damageObject.transform.position = attackPointLow.position;
                
                break;
            case 1:
                currentPosition = attackPointMed.name;
                damageObject.transform.position = attackPointMed.position;
                
                break;
            case 2:
                currentPosition = attackPointHigh.name;
                damageObject.transform.position = attackPointHigh.position;
                
                break;
        }
        Debug.Log(currentPosition);


    }
    
    [SerializeField] private float chargingTime = 1f;
    [SerializeField] private GameObject indicatorEffect;
    [SerializeField] private float heavyBonus;
    [SerializeField] private float movementInAttack = 0.7f;
    private bool chargingAttack = false;
    private bool indicator = false;
    private float reachingTime = 0f;
    private float attackDissappearTime;
    private float attackCoolDown = 0.3f;
    private float attackableTime = 0f;
    private float heavymodifier;

    void ChargeAnAttack()
    {
        bool heavyy = false;
        if (!chargingAttack)
        {
            chargingAttack = true;
            reachingTime = Time.time + chargingTime;
            GetComponent<PlayerMovement>().moveSpeed = GetComponent<PlayerMovement>().moveSpeed / 4;
        }

        if (Time.time > reachingTime)
        {
            heavyy = true;
            if (!indicator)
            {
                indicatorEffect.SetActive(true);
                indicator = true;
            }

            


        }
        if(Input.GetButtonUp("Fire1")) MakeAnAttack(heavy: heavyy);
        
    }

    void MakeAnAttack(bool heavy)
    {
        heavymodifier = heavy ? damageObject.GetComponent<Damage>().damage * heavyBonus : 0;
        damageObject.GetComponent<Damage>().damage += heavymodifier;
        GetComponent<PlayerMovement>().moveSpeed = GetComponent<PlayerMovement>().moveSpeed * 4;
        chargingAttack = false;
        indicator = false;
        reachingTime = 0;
        indicatorEffect.SetActive(false);
        
        damageObject.SetActive(true);
        float attackMovement = heavy ? movementInAttack * 2.5f : movementInAttack;
        attackDissappearTime = Time.time + 0.15f;
        float attackCooldownModifier = heavy ? 0.6f : 0;
        attackReadyIndicator.SetActive(false);
        attackableTime = Time.time + attackCoolDown +attackCooldownModifier;
        GetComponent<CharacterController2D>().Move(attackMovement * transform.localScale.x, false, false);



    }
}
