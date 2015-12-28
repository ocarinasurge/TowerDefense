using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

    private bool tracking = false;
    private Collider2D targetObj;
    public float fireRate;
    private float timeTillShoot;
    private bool canFire = true;
    public GameObject bulletPrefab;
    void Start()
    {
        timeTillShoot = fireRate;
    }
    void Update()
    {
        if (tracking) {
            Vector3 vecToTarget = targetObj.transform.position - transform.position;
            float angle = Mathf.Atan2(vecToTarget.y, vecToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 20);
        }
        if (canFire)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletScript>().target = targetObj.transform;
            canFire = false;
        }
        if (!canFire)
        {
            timeTillShoot -= (Time.deltaTime);
        }
        if (timeTillShoot <= 0)
        {
            canFire = true;
            timeTillShoot = fireRate;
        }
    }

    //When object enters collider, rotate to face that object
    void OnTriggerEnter2D (Collider2D other)
    {
        if (!tracking)
        {
            tracking = true;
            targetObj = other;
        }
    }

    //While object stays within collider, continue to rotate towards that object
    void OnTriggerExit2D(Collider2D other)
    {
        if (tracking)
        {
            tracking = false;
        }
    }

}
