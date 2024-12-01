using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float BackgroundSpeed;
    public Renderer BackgroundRenderer;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BackgroundSpeed < 1)
        {
            BackgroundSpeed += 0.00001f * Time.deltaTime;
        }
        BackgroundRenderer.material.mainTextureOffset += new Vector2(BackgroundSpeed * Time.deltaTime, 0f);

    }
}
