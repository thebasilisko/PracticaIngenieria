
using System.Collections;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public float damage = 10f;
    public float range = 100f;


    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;//Efecto de disparo del cañon
    public GameObject impactEffect;//Efecto al impactar
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//Al pulsar click dispara
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        MuzzleFlash.Play();//Cada vez que se dispara el cañon emite efecto de disparo
        RaycastHit hit;//Inicializamos el rayo que se dispara
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //Si el rayo colisiona contra algo 
        {
            Debug.Log(hit.transform.name);//Sacamos por consola el nombre

            //Enemy enemy = hit.transform.GetComponent<Enemy>(); //Enemy Damage
            /*if (Enemy != null)
            {
                enemy.TakeDamage(damage);
            }*/
            GameObject impactGO = bulletPool.Instance.RequestBullet();//El objeto accede a la lista del objectPool
            impactGO.transform.position = hit.point;//Punto de impacto
            impactGO.transform.rotation = Quaternion.LookRotation(hit.normal);//Rotación al impactar para que sea perpendicular al suelo
            impactGO.SetActive(true);
            StartCoroutine(DeactivateAfterTime(impactGO, 2f)); // Adjust the time as needed

        }

    }

    private IEnumerator DeactivateAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        bulletPool.Instance.ReturnBullet(bullet);
    }


}
