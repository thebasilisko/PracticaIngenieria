using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Rigidbody2D bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb.velocity = Vector2.up * bulletSpeed;
    }

    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
