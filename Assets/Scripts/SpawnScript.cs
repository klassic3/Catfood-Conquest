using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject poison;
    public GameObject catfood;
    public GameObject catcoin;
    public GameObject rock;
    public GameObject milk;
    public GameScript logic;
    [SerializeField] private float spawnRate = 1.0f;
    private float timer;
    private float coinNumber = 0;
    public float moveSpeed = 3.0f;

    private float lane1;
    private float lane2;
    private float lane3;

    private int[] laneCount = new int[3]; // To track the count of lane usage
    private int previousLane = -1; // To store the previous lane picked
    private const int maxRepeatCount = 3; // Maximum times a lane can be repeated

    // Cooldown counters for rare items
    private int foodCooldown = 0;
    private int milkCooldown = 0;

    // Recent spawn tracking
    private Queue<string> recentSpawns = new Queue<string>();

    [SerializeField]private float difficultyFactor = 1.0f;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameLogic")?.GetComponent<GameScript>();
        if (logic == null)
        {
            Debug.LogError("GameLogic object or GameScript component is missing!");
        }

        lane1 = transform.position.x - 0.5f;
        lane2 = transform.position.x;
        lane3 = transform.position.x + 0.5f;

        timer = spawnRate;
    }

    void Update()
    {
        if (logic == null || logic.isPaused) return;

        // Difficulty scaling
        if (spawnRate > 0.5f)
            spawnRate -= 0.005f * difficultyFactor * Time.deltaTime;
        if (moveSpeed < 9f)
            moveSpeed += 0.01f * difficultyFactor * Time.deltaTime;


        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = spawnRate;

            SpawnRandomItem();

            // Reset coin sequence logic
            if (coinNumber >= 3)
            {
                CancelInvoke();
                coinNumber = 0;
            }
        }
    }

    private void SpawnRandomItem()
    {
        int randomValue = Random.Range(1, 101);
        string spawnType = "";

        // Decrement cooldowns
        if (foodCooldown > 0) foodCooldown--;
        if (milkCooldown > 0) milkCooldown--;

        if (randomValue <= 60)
        {
            // 40% chance for poison, rock, or coin
            int subRandom = Random.Range(1, 4);
            if (subRandom == 1) spawnType = "poison";
            else if (subRandom == 2) spawnType = "rock";
            else spawnType = "coin";
        }
        else if (randomValue <= 85 && foodCooldown == 0 && !recentSpawns.Contains("food"))
        {
            // 25% chance for food (if not on cooldown or recently spawned)
            spawnType = "food";
            foodCooldown = 9; // Set cooldown for food
        }
        else if (randomValue > 85 && milkCooldown == 0 && !recentSpawns.Contains("milk"))
        {
            // 15% chance for milk (if not on cooldown or recently spawned)
            spawnType = "milk";
            milkCooldown = 17; // Set cooldown for milk
        }

        if (string.IsNullOrEmpty(spawnType))
        {
            // If no rare item can be spawned, fallback to common items
            spawnType = Random.Range(1, 3) == 1 ? "poison" : "rock";
        }

        // Spawn the selected item
        switch (spawnType)
        {
            case "poison":
                SpawnPoison();
                break;
            case "rock":
                SpawnRocks();
                break;
            case "coin":
                SpawnCatCoin();
                break;
            case "food":
                SpawnCatFood();
                break;
            case "milk":
                SpawnMilk();
                break;
        }

        // Track recent spawns
        recentSpawns.Enqueue(spawnType);
        if (recentSpawns.Count > 3)
        {
            recentSpawns.Dequeue();
        }
    }

    private void SpawnPoison()
    {
        Instantiate(poison, GetRandomLanePosition(), Quaternion.identity);
    }

    private void SpawnCatFood()
    {
        Instantiate(catfood, GetRandomLanePosition(), Quaternion.identity);
    }

    private void SpawnCatCoin()
    {
        StartCoroutine(SpawnCoinSequence());
    }

    private IEnumerator SpawnCoinSequence()
    {
        int laneIndex = Random.Range(1, 4);
        float xPosition = laneIndex switch
        {
            1 => lane1,
            2 => lane2,
            3 => lane3,
            _ => lane2,
        };

        for (int i = 0; i < 3; i++)
        {
            Instantiate(catcoin, new Vector3(xPosition, transform.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate / 9f);
        }
    }

    private void SpawnRocks()
    {
        Instantiate(rock, GetRandomLanePosition(), Quaternion.identity);
    }

    private void SpawnMilk()
    {
        Instantiate(milk, GetRandomLanePosition(), Quaternion.identity);
    }

    private Vector3 GetRandomLanePosition()
    {
        // Try to find a lane that hasn't been repeated too many times
        int lane;
        do
        {
            lane = Random.Range(1, 4); // Randomly pick a lane between 1 and 3

        } while (lane == previousLane && laneCount[lane - 1] >= maxRepeatCount); // Prevent lane from repeating more than 3 times consecutively

        // Update the lane count and previous lane
        laneCount[lane - 1]++;
        previousLane = lane;

        // Ensure we reset lane counts if a lane is changed (to avoid high repetition)
        for (int i = 0; i < laneCount.Length; i++)
        {
            if (i != (lane - 1))
            {
                laneCount[i] = 0; // Reset other lanes if we choose a new one
            }
        }

        // Get the X position based on the selected lane
        float xPosition = lane switch
        {
            1 => lane1,
            2 => lane2,
            3 => lane3,
            _ => lane2,
        };

        return new Vector3(xPosition, transform.position.y, 0);
    }
}
    
