using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    private float speed;
    public Animator animator;
    public GameScript logic;
    public SpawnScript spawner;
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameScript>();
        spawner = GameObject.FindGameObjectWithTag("SpawnLogic").GetComponent<SpawnScript>();

        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isPaused == false)
        {
            moveSpeed = spawner.moveSpeed;
            animator.speed = speed;
            speed = 0.5f + moveSpeed/6;
            animator.SetFloat("Speed", speed);
        }
        else
        {
            animator.speed = 0;
        }
    }
}
