using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SpawnScript : MonoBehaviour
{
    public GameObject poison;
    public GameObject catfood;
    public GameObject catcoin;
    public GameObject rock;
    public GameObject milk;
    public GameScript logic;
    [SerializeField] private float spawnRate;
    private float timer;
    private float coinNumber;
    public float moveSpeed;

    private float lane1;
    private float lane3;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameScript>();


        coinNumber = 0;
        lane1 = transform.position.x - 0.005f;
        lane3 = transform.position.x + 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        //for pause logic
        if (logic.isPaused == false)
        {
            //difficulty scaling
            if (spawnRate > 0.5)
            {
                spawnRate -= 0.0005f * Time.deltaTime;
            }

            if (moveSpeed < 9)
            {
                moveSpeed += 0.0005f * Time.deltaTime;
            }

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = spawnRate;
                int ra = Random.Range(1, 6);
                if (ra == 1)
                {
                    spawnPoison();
                }
                else if (ra == 2)
                {
                    spawnCatFood();
                }
                else if (ra == 3)
                {
                    spawnCatCoin();
                }
                else if (ra == 4)
                {
                    spawnRocks();
                }
                else if (ra == 5)
                {
                    spawnMilk();
                }
            }
            if (coinNumber >= 3)
            {
                CancelInvoke();
                coinNumber = 0;
            }
        }
        else
        {
            CancelInvoke();
        }
       
    }

    void spawnPoison()
    {
        int r = Random.Range(1, 4);
        if (r == 1)
        {
            Instantiate(poison, new Vector3(lane1, transform.position.y, 0), transform.rotation);
        }
        else if (r == 2)
        {
            Instantiate(poison, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
        else if (r == 3)
        {
            Instantiate(poison, new Vector3(lane3, transform.position.y, 0), transform.rotation);
        }
    }
    void spawnCatFood()
    {
        int r = Random.Range(1, 4);
        if (r == 1)
        {
            Instantiate(catfood, new Vector3(lane1, transform.position.y, 0), transform.rotation);

        }
        else if (r == 2)
        {
            Instantiate(catfood, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
        else if (r == 3)
        {
            Instantiate(catfood, new Vector3(lane3, transform.position.y, 0), transform.rotation);
        }
    }
    void spawnCatCoin()
    {
        int r = Random.Range(1, 4);
        if (r == 1)
        {
            InvokeRepeating("coin1", 0f, spawnRate/9f );
            
        }
        else if (r == 2)
        {
            InvokeRepeating("coin2", 0f, spawnRate / 9f);
        }
        else if (r == 3)
        {
            InvokeRepeating("coin3", 0f, spawnRate / 9f);
            Debug.Log(spawnRate / 3f);
        }
    }
    void coin1()
    {
        Instantiate(catcoin, new Vector3(lane1, transform.position.y, 0), transform.rotation);
        coinNumber++;
    }
    void coin2()
    {
        Instantiate(catcoin, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        coinNumber++;
    }
    void coin3()
    {
        Instantiate(catcoin, new Vector3(lane3, transform.position.y, 0), transform.rotation);
        coinNumber++;
    }

    void spawnCoin_sub()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 1;

        }
    }
    

    void spawnRocks()
    {
        int r = Random.Range(1, 4);
        if (r == 1)
        {
            Instantiate(rock, new Vector3(lane1, transform.position.y, 0), transform.rotation);
        }
        else if (r == 2)
        {
            Instantiate(rock, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
        else if (r == 3)
        {
            Instantiate(rock, new Vector3(lane3, transform.position.y, 0), transform.rotation);
        }
    }  
    void spawnMilk()
    {
        int r = Random.Range(1, 4);
        if (r == 1)
        {
            Instantiate(milk, new Vector3(lane1, transform.position.y, 0), transform.rotation);
        }
        else if (r == 2)
        {
            Instantiate(milk, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
        else if (r == 3)
        {
            Instantiate(milk, new Vector3(lane3, transform.position.y, 0), transform.rotation);
        }
    }
}
