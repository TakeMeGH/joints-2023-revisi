using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bulletSpawn : MonoBehaviour
{

    public GameObject gun;
    public gunController gunController;
    [SerializeField] GameObject bullet;
    Transform gunEndPosition;
    float lastShot = 0;
    int gunType;
    handleAiming handleAiming;
   
    // Start is called before the first frame update
    void Start()
    {
        gunType = gunController.getGunIndex() % 3;
        handleAiming = GetComponent<handleAiming>();
    }

    // Update is called once per frame
    void Update()
    {
        lastShot -= Time.deltaTime;
        gunEndPosition = transform.Find("gunEndPosition");
        if(gunType == 0){
            if(Input.GetKeyDown(KeyCode.Mouse0) && lastShot <= 0){
                lastShot = 0.2f;
                Fire();
            }
        }
        else if(gunType == 1){
            if(Input.GetKey(KeyCode.Mouse0) && lastShot <= 0){
                lastShot = 0.2f;
                Fire();
            }
        }
        else if(gunType == 2){
            if(Input.GetKeyDown(KeyCode.Mouse0) && lastShot <= 0){
                lastShot = 0.2f;                
                GameObject bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
                bulletSpawn.GetComponent<bulletController>().isPlayerShooting = true; 
                bulletSpawn.GetComponent<bulletController>().setRotation(gun.transform);  
                bulletSpawn.GetComponent<bulletController>().duration = 0.25f;              
                float angle = handleAiming.angle;

                bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
                bulletSpawn.GetComponent<bulletController>().isPlayerShooting = true; 
                bulletSpawn.GetComponent<bulletController>().rotateBullet(Quaternion.Euler(0, 0, angle - 25));
                bulletSpawn.GetComponent<bulletController>().duration = 0.25f;              

                bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
                bulletSpawn.GetComponent<bulletController>().isPlayerShooting = true; 
                bulletSpawn.GetComponent<bulletController>().rotateBullet(Quaternion.Euler(0, 0, angle + 25));
                bulletSpawn.GetComponent<bulletController>().duration = 0.25f;              

            }
            
        }
    }
    void Fire(){
        GameObject bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
        bulletSpawn.GetComponent<bulletController>().setRotation(gun.transform);
        bulletSpawn.GetComponent<bulletController>().isPlayerShooting = true; 

    }
}
