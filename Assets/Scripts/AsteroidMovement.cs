using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidMovement : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] int scoreWorth;
    [SerializeField] int size;
    void Awake()
    {
        direction= RandomDirectionMaker();
    }
    void FixedUpdate()
    {
        transform.Translate(2*direction*Time.fixedDeltaTime);
    }

    Vector3 RandomDirectionMaker()
    {
        direction = Random.insideUnitCircle.normalized;
        return direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            ObjectPooler.instance.UpdateScore(scoreWorth);
            AudioManager.instance.OnCrashPlaySound(size);
        }
        else if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            AudioManager.instance.OnCrashPlaySound(size);
        }
    }

}
