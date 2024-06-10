
using System.Collections;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public float damage = 10f;
    public float range = 100f;


    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject impactEffect;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        MuzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //Enemy enemy = hit.transform.GetComponent<Enemy>(); //Enemy Damage
            /*if (Enemy != null)
            {
                enemy.TakeDamage(damage);
            }*/
            GameObject impactGO = bulletPool.Instance.RequestBullet();
            impactGO.transform.position = hit.point;
            impactGO.transform.rotation = Quaternion.LookRotation(hit.normal);
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
