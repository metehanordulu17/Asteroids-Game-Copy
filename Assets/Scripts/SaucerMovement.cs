using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaucerMovement : MonoBehaviour
{
    private float speed = 5f;
    private bool IsShooting = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        if (!IsShooting) 
        { 
            StartCoroutine(ShootBullets());
        }
    }
    IEnumerator ShootBullets()
    {
        IsShooting = true;
        ObjectPooler.instance.SpawnObjectFromPool("Bullet", transform.position, RandomBulletDirectionMaker());
        yield return new WaitForSeconds(1);
        IsShooting = false;
    }
    private Quaternion RandomBulletDirectionMaker()
    {
        float xAngle = Random.Range(-1f, 1f);
        float yAngle = Random.Range(-1f, 1f);
        return new Quaternion(xAngle, yAngle, 0, 0).normalized;
    }
        
        
 }
