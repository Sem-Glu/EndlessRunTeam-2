using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerationScript : MonoBehaviour
{
    private static ObstacleGenerationScript instance;
    public static ObstacleGenerationScript Instance { get => instance; } //Singleton!

    [Header("Obstacle Spawn Stuff:")]
    [SerializeField]
    private int rngSpawner; //This is a random value between 1 and 10000
    [SerializeField]
    private int spawnChance = 0; //This is the chance for an object to spawn the smaller the number the less chance it has to spawn
    [SerializeField]
    private int randomObject; //This gives a random value that determines what object spawns

    private int newRoadTime = 10;
    private bool roadSpawn;

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

    void Start()
    {
        gameStart = false;
        difficultyIncrease = false;
        roadSpawn = false;
        StartCoroutine(GameDifficulty());
    }
    void FixedUpdate()
    {
        if (gameStart == true)
        {
            difficultyIncrease = true;
            roadSpawn = true;
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
                    Debug.Log(spawnChance);
                }
                
            }
            yield return null;
        }
    }
}
