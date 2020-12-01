using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpawner : MonoBehaviour
{
    [SerializeField] private int maxGearCount = 0;
    [SerializeField] private float minTime = 0f, maxTime = 0f;
    [SerializeField] private float gearSpawnMinXPos = 0f, gearSpawnMaxXPos = 0f,
                                   gearSpawnMinYPos = 0f, gearSpawnMaxYPos = 0f;
    [SerializeField] private GameObject gearPrefab = null;

    //private GearController gc;

    private float liveTime = 0f;
    internal static int count = 0;

    private void Start()
    {
        count = 0;
        liveTime = Random.Range(minTime, maxTime);
        //gc = GameObject.FindGameObjectWithTag("Respawn").GetComponent<GearController>();
    }

    private void Update()
    {
        if (count < maxGearCount && liveTime <= 0f)
        {
            //SpawnEnemy();
            //Spawning enemy
            GameObject temp = Instantiate(gearPrefab,
                                          new Vector2(Random.Range(gearSpawnMinXPos, gearSpawnMaxXPos),
                                                      Random.Range(gearSpawnMinYPos, gearSpawnMaxYPos)),
                                          Quaternion.identity);
            liveTime = Random.Range(minTime, maxTime);
            count++;
        }
        else if(maxGearCount > count)
        {
            liveTime -= Time.deltaTime;
        }
    }
    void SpawnEnemy()
    {
    }

}
