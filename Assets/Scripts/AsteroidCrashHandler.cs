using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCrashHandler : MonoBehaviour
{
    [SerializeField] int size;
    void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        if(size == 2)
        {
            ObjectPooler.instance.SpawnObjectFromPool("Medium Asteroid", transform.position, new Quaternion(0, 0, 0, 0));
            ObjectPooler.instance.SpawnObjectFromPool("Medium Asteroid", transform.position, new Quaternion(0, 0, 0, 0));
        }
        if(size == 1)
        {
            ObjectPooler.instance.SpawnObjectFromPool("Small Asteroid", transform.position, new Quaternion(0, 0, 0, 0));
            ObjectPooler.instance.SpawnObjectFromPool("Small Asteroid", transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
