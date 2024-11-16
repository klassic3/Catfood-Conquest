using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkScript : MonoBehaviour
{
    public GameObject MilkEffect;

    private float moveSpeed;
    private int lane;
    public GameScript logic;
    public SpawnScript spawner;
    private Vector3 maxSize;
    private Vector3 scaleRate;

    //for milk audio
    AudioManagerScript AudioManager;
    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameScript>();

        spawner = GameObject.FindGameObjectWithTag("SpawnLogic").GetComponent<SpawnScript>();

        moveSpeed = spawner.moveSpeed;

        if (transform.localPosition.x < 0f)
        {
            lane = 1;
        }
        else if (transform.localPosition.x == 0f)
        {
            lane = 2;
        }
        else if (transform.localPosition.x > 0f)
        {
            lane = 3;
        }

        //final size of object
        maxSize = transform.localScale;

        //sets initial size of object
        Vector3 minSize = new Vector3(0.02649468f, 0.02649468f, 0.02649468f);
        transform.localScale = minSize;

        scaleRate = new Vector3(maxSize.x - minSize.x, maxSize.y - minSize.y, maxSize.z - minSize.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isPaused == false)
        {
            Vector3 lane1 = new Vector3(-0.2f, -1.0f, 0.0f);
            Vector3 lane2 = new Vector3(0.0f, -1.0f, 0.0f);
            Vector3 lane3 = new Vector3(0.2f, -1.0f, 0.0f);
            if (lane == 1)
            {
                transform.Translate(lane1 * moveSpeed * Time.deltaTime);
            }
            else if (lane == 2)
            {
                transform.Translate(lane2 * moveSpeed * Time.deltaTime);
            }
            else if (lane == 3)
            {
                transform.Translate(lane3 * moveSpeed * Time.deltaTime);
            }

            //increases size over time
            transform.localScale += scaleRate * Time.deltaTime * moveSpeed / 12;

            if (transform.position.y < -6)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.getMilk();
        Destroy(gameObject);
        GameObject ps = (GameObject)Instantiate(MilkEffect, transform.position, transform.rotation);
        Destroy(ps, 1f);
        //adding audio to catmilk collision
        AudioManager.PlaySFX(AudioManager.foodgrab);
    }
}
