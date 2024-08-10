using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject gas;
    private float speed= 4f;
    private float rotation;
    private float verticalInput;
    private bool IsGasActive = false;
    public GameObject prefab;
    public GameObject FirePoint;
    private float rotationForce = 360f;
    private AudioSource rocketSound;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rocketSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        rotation = -Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)&& !IsGasActive)
        {
            StartCoroutine(gasActivation());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        if (verticalInput > 0) 
        { 
            rb.AddForce(transform.up * speed * verticalInput * Time.fixedDeltaTime,ForceMode2D.Impulse);
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }
        }
        rb.AddTorque(rotation * rotationForce*Time.fixedDeltaTime);
        if (Mathf.Approximately(rotation, 0))
        {
            rb.angularVelocity = 0;
        }
    }
    IEnumerator gasActivation()
    {
        
        IsGasActive = true;
        gas.SetActive(true);        
        yield return new WaitForSeconds(0.5f);
        gas.SetActive(false);
        IsGasActive = false;
    }
    void Shoot()
    {
        ObjectPooler.instance.SpawnObjectFromPool("Bullet", FirePoint.transform.position,prefab.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroids"))
        {
 
            gameObject.SetActive(false);
        }
    }


}
