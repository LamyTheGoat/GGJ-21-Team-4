using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherIdleBehaviour : StateMachineBehaviour
{
    public float range;
    public GameObject targeting;
    private float idleTime;

    private float timeForWander;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idleTime = Random.Range(2, 8);
        timeForWander = Time.time + idleTime;
        targeting= animator.transform.Find("Targeting").gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > timeForWander)
        {
            animator.SetTrigger("Wander");
        }

        RaycastHit2D raycast = Physics2D.Raycast(animator.GetComponent<Transform>().position,
            (GameObject.FindGameObjectWithTag("Player").transform.position - animator.GetComponent<Transform>().position).normalized, range);
        
        
        Debug.DrawRay(animator.GetComponent<Transform>().position,
            (GameObject.FindGameObjectWithTag("Player").transform.position - animator.GetComponent<Transform>().position).normalized *range, Color.red);
        targeting.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        targeting.transform.rotation = targeting.transform.rotation *  Quaternion.Euler(0f, -90f, 0f);
        if (raycast && raycast.collider.gameObject.tag == "Player")
        {
            animator.SetTrigger("StartTargeting");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(("Wander"));
        animator.ResetTrigger("StartTargeting");
    }

 
}
