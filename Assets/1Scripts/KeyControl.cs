using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    public bool keyIsOn;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void GetOnOff()
    {
        keyIsOn = !keyIsOn;
        if (keyIsOn)
            animator.SetTrigger("Key");
        else
            animator.SetTrigger("KeyExit");
    }
}
