using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float BackgroundSpeed;
    public Renderer BackgroundRenderer;
    public GameScript logic;
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //for pause logic
        if (logic.isPaused == false)
        {

            if (BackgroundSpeed < 1)
            {
                BackgroundSpeed += 0.00001f * Time.deltaTime;
            }
            BackgroundRenderer.material.mainTextureOffset += new Vector2(BackgroundSpeed * Time.deltaTime, 0f);
        }
    }
}
