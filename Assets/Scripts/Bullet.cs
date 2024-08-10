using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private Vector3 direction;
    private void Awake()
    {
        player=GameObject.FindWithTag("Player");
    }

    private void OnEnable()
    {
        direction = player.transform.up;
        StartCoroutine(bulletDestroyCoolDown());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction*10f * Time.fixedDeltaTime);
    }
    IEnumerator bulletDestroyCoolDown()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroids")) 
            {
                gameObject.SetActive(false);
            }
    }
}
