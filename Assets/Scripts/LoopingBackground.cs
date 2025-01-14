using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float BackgroundSpeed;
    public Renderer BackgroundRenderer;
    public GameScript logic;
    public SpawnScript spawner;

    private float moveSpeed;
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameScript>();

        spawner = GameObject.FindGameObjectWithTag("SpawnLogic").GetComponent<SpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //for pause logic
        if (logic.isPaused == false)
        {
            moveSpeed = spawner.moveSpeed;
            if (BackgroundSpeed < 1)
            {
                BackgroundSpeed = 0.001f + moveSpeed/32;
                //Debug.Log(BackgroundSpeed);
            }
            BackgroundRenderer.material.mainTextureOffset += new Vector2(BackgroundSpeed * Time.deltaTime, 0f);
        }
    }
}
