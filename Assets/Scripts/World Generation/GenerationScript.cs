using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationScript : MonoBehaviour
{
    private static GenerationScript instance;
    public static GenerationScript Instance { get => instance; } //Singleton!

    [Header("Obstacle Spawn Stuff:")]
    [SerializeField]
    private int rngSpawner; //This is a random value between 1 and 10000
    [SerializeField]
    private int spawnChance = 0; //This is the chance for an object to spawn the smaller the number the less chance it has to spawn
    [SerializeField]
    private int randomObject; //This gives a random value that determines what object spawns

    [SerializeField]
    private float tempRoadDespawnTime = 0.65f;
    [SerializeField]
    private float newRoadTime = 1.65f;
    private bool roadSpawn;
    private float roadmove;
    public List<GameObject> planeSpawnPoints;

    [Header("Wave Controller")]
    [SerializeField]
    private int waveTime = 10;
    [SerializeField]
    private int difficultyTweak = 500;

    private bool difficultyIncrease;
    [Header("PreSpawn Stuff:")]
    [SerializeField]
    private bool gameStart;
    [SerializeField]
    public List<GameObject> obstacleSpawnPoints;
    [SerializeField]
    public List<GameObject> obstacles;

    [Header("ObjectPool Stuff:")]
    [SerializeField]
    ObjectPool ObjectPool;
    private int listCount;
    Stack<GameObject> stack = new Stack<GameObject>();
    [SerializeField]
    private int waitForDespawnTime;
    void Start()
    {
        gameStart = false;
        difficultyIncrease = false;
        roadSpawn = false;
        StartCoroutine(GameDifficulty());
        StartCoroutine(RoadSpawner());
        StartCoroutine(TempReturnTimer());
    }
    void FixedUpdate()
    {
        if (gameStart == true)
        {
            difficultyIncrease = true;
            roadSpawn = true;
            waitForDespawnTime = waitForDespawnTime + 1;
        }
        else
        {
            difficultyIncrease = false;
            roadSpawn = false;
        }
        rngSpawner = Random.Range(1, 10000);
        

    }

    void ObstacleGenerator()
    {
        if (rngSpawner <= spawnChance)
        {

            randomObject = Random.Range(0, obstacles.Count);
            //Spawn random obstacle using random object
        }
    }
    IEnumerator RoadSpawner()
    {

        while (true)
        {
            if (roadSpawn == true)
            {
                yield return new WaitForSeconds(newRoadTime);
                if (roadSpawn == true)
                {
                    GameObject go = ObjectPool.GetPooledObject();
                    go.transform.position = planeSpawnPoints[listCount].transform.position;
                    listCount = listCount + 1;
                    if (listCount == planeSpawnPoints.Count)
                    {
                        listCount = 0;
                        
                    }
                    stack.Push(go);

                    ObstacleGenerator();
                }

            }
            yield return null;
        }
    }
    IEnumerator GameDifficulty()
    {
        
        while (true)
        {
            if (difficultyIncrease == true)
            {
                yield return new WaitForSeconds(waveTime);
                if (difficultyIncrease == true)
                {
                    spawnChance = spawnChance + difficultyTweak;
                }
                
            }
            yield return null;
        }
    }
    IEnumerator TempReturnTimer()
    {
        while (true)
        {
            if (roadSpawn == true && waitForDespawnTime >= 3600)
            {
                yield return new WaitForSeconds(tempRoadDespawnTime);
                if (roadSpawn == true)
                {
                    ObjectPool.ReturnPooledObject(stack.Pop());
                }

            }
            yield return null;
        }
    }
}
