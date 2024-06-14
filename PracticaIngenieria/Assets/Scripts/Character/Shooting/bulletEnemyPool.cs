using System.Collections.Generic;
using UnityEngine;

public class bulletEnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> bulletList;

    private static bulletEnemyPool instance;
    public static bulletEnemyPool Instance { get { return instance; } }//Singelton

    private void Awake()
    {
        if (instance == null)
        {       
            instance = this;
            Debug.Log("Instance assigned");
        }
        else 
        {
            Debug.Log("Instance already exists, destroying this gameObject");
            Destroy(this.gameObject);
        }

        bulletList = new List<GameObject>(poolSize);//*//
    }

    void Start()
    {
        AddBulletsToPool(poolSize);
    }

    private void AddBulletsToPool(int amount)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletList.Add(bullet);
            bullet.transform.parent = transform;
            Debug.Log("Added bullet to pool: " + i);
        }
    }

    public GameObject RequestBullet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!bulletList[i].activeSelf)
            {
                bulletList[i].SetActive(true);
                Debug.Log("Bullet activated: " + i);
                return bulletList[i];
            }
        }
        Debug.Log("No bullets available in pool");
        return null;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
