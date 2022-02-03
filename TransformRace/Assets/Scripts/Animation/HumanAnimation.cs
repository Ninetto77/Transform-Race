using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetBoolRun()
    {
        animator.SetBool("Run", true);
        animator.SetBool("OnStairs", false);
    }
    public void SetBoolStairsUp()
    {
        animator.SetBool("Run", false);
        animator.SetBool("OnStairs", true);
    }

    public void Update()
    {
        if (LevelManager.Instance.GameType != GameTypes.Play)
        {
            animator.SetBool("Run", false);
            animator.SetBool("OnStairs", false);
            animator.SetBool("Stop", true);
        }
        else
        {
            animator.SetBool("Stop", false);
        }
    }
}
