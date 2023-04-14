using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float shotVelocity = 5f;
    public float rateOfFire = 1f;
    float lastShotTimestamp = 0;
    public Transform bulletSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot() {
        if (lastShotTimestamp + rateOfFire < Time.time) {
            lastShotTimestamp = Time.time;
            GameObject tempBullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPos.up * shotVelocity;
            Destroy(tempBullet, 2f);
        }
    }


}
