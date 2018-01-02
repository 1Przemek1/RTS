using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        HandleAnimations();

    }

    private void HandleAnimations()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("MoveTrigger");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetTrigger("IdleTrigger");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("AttackTrigger");
        }
    }

    public bool CanMove()
    {
        return !animator.GetCurrentAnimatorStateInfo(0).IsName("attack");
    }
}
