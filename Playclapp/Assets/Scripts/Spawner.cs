using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Options")]
    public float timeToSpawn;
    public float speedStone;
    public float distanceStone;

    [Space]
    [SerializeField] private GameObject[] stones;

    [Space]
    [SerializeField] private Transform[] spawnPoints;

    #region MonoBehaviour
    private void OnValidate()
    {
        if (timeToSpawn < 0.5f)
        {
            timeToSpawn = 0.5f;
        }
        if (speedStone < 0.1f)
        {
            speedStone = 0.1f;
        }
    }
    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }
    #endregion
    #region Chagne Option
    public void ChangeSpeed(string count)
    {
        speedStone = float.Parse(count);
    }
    public void ChangeDistance(string count)
    {
        distanceStone = float.Parse(count);
    }
    public void ChangeTimeToSpawn(string count)
    {
        timeToSpawn = float.Parse(count);
    }
    #endregion
    void SpawnStone()
    {
        Instantiate(stones[Random.Range(0, stones.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);
    }
    IEnumerator SpawnTimer()
    {
        while (true)
        {
            SpawnStone();
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
