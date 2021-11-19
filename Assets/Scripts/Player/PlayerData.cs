using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player_Data", menuName = "Player_Data")]
public class PlayerData : ScriptableObject
{
    public float speed;
    public Vector3 direction;
    public Vector3 spawnPoint;
}
