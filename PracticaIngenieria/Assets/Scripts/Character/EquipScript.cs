using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform1;
    public Transform PlayerTransform2;
    public GameObject Gun1;
    public GameObject Gun2;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    public bool equipped1 = true;
    public bool equipped2 = true;

    // Start is called before the first frame update
    void Start()
    {
        Gun1.GetComponent<Rigidbody>().isKinematic = true;
        Gun2.GetComponent<Rigidbody>().isKinematic = true;

        Gun1.SetActive(true);
        Gun2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (equipped1 = true && Input.GetKeyDown("1"))
        {
            EquipObject1();
        }

        if (equipped2 = true && Input.GetKeyDown("2"))
        {
            EquipObject2();
        }

        if ( equipped1 = true && Gun1.active && Input.GetKeyDown("f"))
        {
            UnequipObject1();
            Shoot1();
        }
        if (equipped2 = true && Gun2.active && Input.GetKeyDown("f"))
        {
            UnequipObject2();
            Shoot2();
        }
    }

    void Shoot1()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target= hit.transform.GetComponent<Target>();
            if (target != null )
            {
                EquipObject1();
            }
        }
    }

    void Shoot2()
    {
        RaycastHit hit;
        if ( Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if ( target != null)
            {
                EquipObject2();
            }
        }
    }

    void UnequipObject1()
    {
        equipped1 = false;
        PlayerTransform1.DetachChildren();
        Gun1.transform.eulerAngles = new Vector3(Gun1.transform.eulerAngles.x, Gun1.transform.eulerAngles.y, Gun1.transform.eulerAngles.z - 45);
        Gun1.GetComponent<Rigidbody>().isKinematic = false;
    }

    void UnequipObject2()
    {
        equipped2 = false;
        PlayerTransform2.DetachChildren();
        Gun2.transform.eulerAngles = new Vector3(Gun2.transform.eulerAngles.x, Gun2.transform.eulerAngles.y, Gun2.transform.eulerAngles.z - 45);
        Gun2.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject1()
    {
        equipped1 = true;
        Gun1.GetComponent<Rigidbody>().isKinematic = true;
        Gun1.transform.position = PlayerTransform1.transform.position;
        Gun1.transform.rotation = PlayerTransform1.transform.rotation;
        Gun1.transform.SetParent(PlayerTransform1);
        Gun1.SetActive(true);
        Gun2.SetActive(false);
    }

    void EquipObject2()
    {
        equipped2 = true;
        Gun2.GetComponent<Rigidbody>().isKinematic = true;
        Gun2.transform.position = PlayerTransform2.transform.position;
        Gun2.transform.rotation = PlayerTransform2.transform.rotation;
        Gun2.transform.SetParent(PlayerTransform2);
        Gun1.SetActive(false);
        Gun2.SetActive(true);
    }

}
