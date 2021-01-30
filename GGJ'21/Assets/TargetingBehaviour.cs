using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingBehaviour : StateMachineBehaviour
{
    public GameObject targeting;
    private float targetTime = 1f;
    
    private float timeForShoot;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeForShoot = Time.time + targetTime;
        targeting= animator.transform.Find("Targeting").gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > timeForShoot)
        {
            animator.SetTrigger("TryToShoot");
        }
        
        RaycastHit2D raycast = Physics2D.Raycast(animator.GetComponent<Transform>().position,
            (GameObject.FindGameObjectWithTag("Player").transform.position - animator.GetComponent<Transform>().position));
        
        
        targeting.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        targeting.transform.rotation = targeting.transform.rotation *  Quaternion.Euler(0f, -90f, 0f);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("TryToShoot");
    }


}
