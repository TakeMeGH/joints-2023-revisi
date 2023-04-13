using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    public GameObject gun;
    [SerializeField] GameObject bullet;
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
                Fire();
            }
        }
        else if(gunType == 1){
            if(lastShot <= 0){
                lastShot = 0.2f;
                Fire();
            }
        }
        else if(gunType == 2){
            if(lastShot <= 0){
                lastShot = 0.4f;                
                GameObject bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
                bulletSpawn.GetComponent<bulletController>().isPlayerShooting = false; 
                bulletSpawn.GetComponent<bulletController>().setRotation(gun.transform);  
                bulletSpawn.GetComponent<bulletController>().duration = 0.25f;              
                float angle = enemyHandleAiming.angle;

                bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
                bulletSpawn.GetComponent<bulletController>().isPlayerShooting = false; 
                bulletSpawn.GetComponent<bulletController>().rotateBullet(Quaternion.Euler(0, 0, angle - 25));
                bulletSpawn.GetComponent<bulletController>().duration = 0.25f;              

                bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
                bulletSpawn.GetComponent<bulletController>().isPlayerShooting = false; 
                bulletSpawn.GetComponent<bulletController>().rotateBullet(Quaternion.Euler(0, 0, angle + 25));
                bulletSpawn.GetComponent<bulletController>().duration = 0.25f;              

            }
            
        }
    }
    void Fire(){
        GameObject bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
        bulletSpawn.GetComponent<bulletController>().setRotation(gun.transform);
        bulletSpawn.GetComponent<bulletController>().isPlayerShooting = false; 

    }
}
