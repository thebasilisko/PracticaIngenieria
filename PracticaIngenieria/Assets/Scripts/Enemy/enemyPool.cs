using System.Collections.Generic;
using UnityEngine;

public class enemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> bulletList;

    private static enemyPool instance;
    public static enemyPool Instance { get { return instance; } }//Singelton

    private void Awake()
    {
        Debug.Log("Awake called");
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
            GameObject bullet = Instantiate(enemyBullet);
            bullet.SetActive(false);
            bulletList.Add(bullet);
            bullet.transform.parent = transform;
            Debug.Log("Added bullet to pool: " + i);
        }
    }

    public GameObject RequestBullet()
    {
        foreach (GameObject bullet in bulletList)
        {
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);
                Debug.Log("Bullet activated: " + bullet.name);
                return bullet;
            }
        }
        Debug.Log("No bullets available in pool");
        return null;
    }

    public void ReturnBullet(GameObject bullet)
    {
        if (bulletList.Contains(bullet))
        {
            bullet.SetActive(false);
            Debug.Log("Bullet deactivated: " + bullet.name);
        }
        else
        {
            Debug.LogWarning("Attempted to return a bullet that doesn't belong to the pool: " + bullet.name);
        }
    }
}
