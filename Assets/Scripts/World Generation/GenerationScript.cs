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
    private bool roadSpawn;
    public List<GameObject> planeSpawnPoints;

    [Header("Wave Controller")]
    [SerializeField]
    private int waveTime = 10;
    [SerializeField]
    private int difficultyTweak = 500;

    private bool difficultyIncrease;
    [Header("PreSpawn Stuff:")]
    [SerializeField]
    public bool gameStart;
    [SerializeField]
    public List<GameObject> obstacleSpawnPoints;
    [SerializeField]
    public List<GameObject> obstacles;

    [Header("ObjectPool Stuff:")]
    [SerializeField]
    ObjectPool ObjectPool;
    private int listCount;
    [SerializeField]
    List<GameObject> list = new List<GameObject>();
    [SerializeField]
    private int despawnPos;

    private int startPlanes;
    private Vector3 newPlanesPosition;
    private Transform lastSpawned;

    private void Awake()
    {
        if (GenerationScript.instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        despawnPos = 500;
        startPlanes = 50;
        gameStart = false;
        difficultyIncrease = false;
        roadSpawn = false;
        StartCoroutine(GameDifficulty());
        StartCoroutine(RoadSpawner());
        
        newPlanesPosition = new Vector3(-10, 0, 0);
        for (int i = 0; i < startPlanes; i++)
        {
            GameObject go = ObjectPool.GetPooledObject();
            newPlanesPosition.x = newPlanesPosition.x + 10;
            go.transform.position = newPlanesPosition;
            list.Add(go);
            go.name = i.ToString();
            ObstacleGenerator();
        }
        lastSpawned = list[0].transform;
        StartCoroutine(TempReturnTimer());
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStart = true;
        }
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
                
                if (lastSpawned.position.x >= 10)
                {
                    GameObject go = ObjectPool.GetPooledObject();
                    //go.transform.position = planeSpawnPoints[listCount].transform.position;
                    go.transform.position = lastSpawned.position + Vector3.left * 10;
                    //listCount = listCount + 1;
                    //if (listCount == planeSpawnPoints.Count)
                    //{
                    //    listCount = 0;
                    //}
                    list.Add(go);
                    ObstacleGenerator();
                    lastSpawned = go.transform;
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
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].transform.position.x >= despawnPos)
                    {
                        ObjectPool.ReturnPooledObject(list[i]);
                        list.Remove(list[i]);
                    }
                    
                }
            yield return null;
        }
    }
}
