using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public Transform player;
    int health = 100;
    public Rigidbody bullet;
    public Transform spawner;
    bool isShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 distance = this.transform.position - player.transform.position;
        distance.y = 0;
        if (Physics.Linecast(this.transform.position, player.transform.position, out hit, -1)) 
        {
            if (hit.transform.CompareTag("Player"))
            {
                if (distance.magnitude > 5)
                {
                    //this.transform.Translate(Vector3.forward * 2f * Time.deltaTime);
                    //this.transform.LookAt(player.transform);
                    isShoot = false;
                }
                else 
                {
                    isShoot=true;
                    this.transform.LookAt(player.transform);
                }
                
            }
        }

        if (health < 1)
        {
            this.gameObject.SetActive(false);
        }

       
    }

    IEnumerator shoot() 
    { 
        yield return new WaitForSeconds(1);
        if (isShoot)
        {
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(bullet, spawner.transform.position, Quaternion.identity);
            clone.velocity = spawner.TransformDirection(Vector3.forward * 6000 * Time.deltaTime);
        }

        StartCoroutine(shoot());
    }
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            health -= 20;
        }
    }
}
