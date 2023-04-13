using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    public GameObject gun;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 30f;

    Transform gunEndPosition;
    float lastShot = 0;
    [SerializeField] int gunType;
    EnemyHandleAiming enemyHandleAiming;
   
    // Start is called before the first frame update
    void Start()
    {
        enemyHandleAiming = GetComponent<EnemyHandleAiming>();
    }

    // Update is called once per frame
    void Update()
    {
        lastShot -= Time.deltaTime;
        gunEndPosition = transform.Find("gunEndPosition");
        if(gunType == 0){
            if(lastShot <= 0){
                lastShot = 0.4f;
                Fire(enemyHandleAiming.angle);
            }
        }
        else if(gunType == 1){
            if(lastShot <= 0){
                lastShot = 0.2f;
                Fire(enemyHandleAiming.angle);
            }
        }
        else if(gunType == 2){
            if(lastShot <= 0){
                lastShot = 0.4f;                
                Fire(enemyHandleAiming.angle, 0.5f);
                Fire(enemyHandleAiming.angle + 15, 0.5f);
                Fire(enemyHandleAiming.angle - 15, 0.5f);              
            }
            
        }
    }
    void Fire(float angle, float duration = 2f){
        GameObject bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
        bulletSpawn.GetComponent<bulletController>().rotateBullet(Quaternion.Euler(0, 0, angle));
        bulletSpawn.GetComponent<bulletController>().isPlayerShooting = false; 
        bulletSpawn.GetComponent<bulletController>().setDuration(duration);
        bulletSpawn.GetComponent<bulletController>().setSpeed(bulletSpeed);
    }
}
