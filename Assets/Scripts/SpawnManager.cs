using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int round=0;
    int asteroidCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Asteroids").Length == 0)
        {
            SpawnAsteroids();
        }
        
    }


    void SpawnAsteroids()
    {
        if (round <= 4)
        {
            asteroidCount = 4 + round;
        }
        else
        {
            asteroidCount = 8;
        }
        for (int i = 0; i < asteroidCount; i++) 
        {
            ObjectPooler.instance.SpawnObjectFromPool("Large Asteroid", RandomPlaceMaker(), new Quaternion(0, 0, 0, 0));
        }
        round += 1;
    }
    Vector3 RandomPlaceMaker()
    {
        float xPos=Random.Range(-20, 20);
        if(Mathf.Abs(xPos) < 5)
        {
            if(xPos < 0)
            {
                xPos = -10;
            }
            else
            {
                xPos = 10;
            }
        }
        float yPos = Random.Range(-8, 8);
        if (Mathf.Abs(yPos) < 3)
        {
            if (yPos < 0)
            {
                yPos = -4;
            }
            else
            {
                yPos = 4;
            }
        }
        return new Vector3(xPos, yPos, 0);
    }
}
