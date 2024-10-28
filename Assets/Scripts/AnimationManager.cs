using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameScript logic;
    [SerializeField] private Animator animator;
    [SerializeField]private Animation anim;
    private float tempspeed;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameScript>();
        animator = GetComponent<Animator>();
        tempspeed = animator.speed;
            animator.speed = tempspeed;
            while (true)
            {
                animator.SetInteger("Random", Random.Range(0, 3));
                animator.SetBool("start", true);
            yield return new WaitForSeconds(6);
            }

    }
    void Update()
    {
        if (logic.isPaused == false)
        {
            animator.speed = tempspeed;
        }
        else
        {
            animator.speed = 0;

        }
    }
}

