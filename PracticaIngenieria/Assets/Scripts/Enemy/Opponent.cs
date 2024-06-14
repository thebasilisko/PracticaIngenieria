using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Opponent : MonoBehaviour
{
    public Transform player;
    public int health;
   // public Rigidbody bullet;
    public Transform spawner;
    bool isShoot = false;

    enemyPool enemyPool;

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
                    LookAtPlayer();
                }
                
            }
        }

    }

    void LookAtPlayer()
    {
        // Obtener la dirección hacia el jugador sin cambiar la y
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Solo cambiar la rotación en el eje y

        // Rotar hacia la dirección calculada
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }


    IEnumerator shoot() 
    {
        yield return new WaitForSeconds(0.5f);
        if (isShoot)
        {
            GameObject bulletObject = enemyPool.Instance.RequestBullet();
            if (bulletObject != null)
            {
                bulletObject.transform.position = spawner.transform.position;
                bulletObject.transform.rotation = spawner.transform.rotation;
                Rigidbody clone = bulletObject.GetComponent<Rigidbody>();
                clone.velocity = spawner.TransformDirection(Vector3.forward * 6000 * Time.deltaTime);
                StartCoroutine(DeactivateAfterTime(bulletObject, 1.5f)); // Adjust the time as needed
            }
        }
        StartCoroutine(shoot());
    }

    private IEnumerator DeactivateAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        bulletPool.Instance.ReturnBullet(bullet);
    }


   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado con: " + other.gameObject.name);

        // Comprueba si la colisión es con un objeto específico (por ejemplo, un objeto con el tag "Bullet")
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Trigger con Bullet detectado");
            // Reduce la salud del enemigo
            TakeDamage(10); // Puedes ajustar el valor del daño según sea necesario
        }
    }*/

    public void TakeDamage(int damage)
    {
        Debug.Log("Daño recibido");
        health -= damage;
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
