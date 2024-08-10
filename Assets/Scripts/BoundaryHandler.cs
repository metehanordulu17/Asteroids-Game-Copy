using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryHandler : MonoBehaviour
{
    [SerializeField] string position;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Saucer"))
        {
            collision.gameObject.SetActive(false);
        }
        else
        {
            if (position == "right")
            {
                collision.gameObject.transform.position = new Vector3(-collision.gameObject.transform.position.x + 0.5f, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            }
            else if (position == "left")
            {
                collision.gameObject.transform.position = new Vector3(-collision.gameObject.transform.position.x - 0.5f, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            }
            else if (position == "up")
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, -collision.gameObject.transform.position.y + 0.5f, collision.gameObject.transform.position.z);
            }
            else if (position == "down")
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, -collision.gameObject.transform.position.y - 0.5f, collision.gameObject.transform.position.z);
            }
        }
       
    }

}
