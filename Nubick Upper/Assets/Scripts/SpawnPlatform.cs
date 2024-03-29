using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject platfrom;
    [SerializeField] private float verticalOffset = 0.5f;

    private float? lastPointPositionY = null;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        float spawnPointPositionY = lastPointPositionY == null ? randomSpawnPoint.position.y : (float)lastPointPositionY + verticalOffset;

        randomSpawnPoint.position = new Vector3(randomSpawnPoint.position.x, spawnPointPositionY, randomSpawnPoint.position.z);
        lastPointPositionY = spawnPointPositionY;

        Instantiate(platfrom, randomSpawnPoint.position, Quaternion.identity);

    }
}
