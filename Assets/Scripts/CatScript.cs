using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    private float speed;
    public Animator animator;
    public GameScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameScript>();

        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isPaused == false)
        {
            animator.speed = speed;
            speed +=0.001f * Time.deltaTime;
            animator.SetFloat("Speed", speed);
        }
        else
        {
            animator.speed = 0;
        }
    }
}
