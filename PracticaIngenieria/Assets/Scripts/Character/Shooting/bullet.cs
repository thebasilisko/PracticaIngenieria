using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 50f;
    [SerializeField] private Rigidbody bulletRb;

    private void OnEnable()
    {
        bulletRb.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter()
    {
        gameObject.SetActive(false);

    }

}
