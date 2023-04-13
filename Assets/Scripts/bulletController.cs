using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    Animator animator;
    float speed = 30f;
    public float duration = 1f;
    int isDead = 1;
    public bool isPlayerShooting;
    // Start is called before the first frame update
    void Start()
    {
        isDead = 1;
        animator = GetComponent<Animator>();
    }
    public void setRotation(Transform bulletDir){
        transform.rotation = bulletDir.rotation;
    }
    public void rotateBullet(Quaternion bulletRotation){
        this.transform.rotation = bulletRotation;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.right * speed * Time.deltaTime * isDead;
        duration -= Time.deltaTime;
        if(duration <= 0){
            isDead = 0;
            animator.SetTrigger("isDesytroy");
            Destroy(gameObject, 0.3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if((isPlayerShooting && other.gameObject.tag == "enemy") || (other.gameObject.tag == "player" && isPlayerShooting == false)){
            isDead = 0;
            animator.SetTrigger("isDesytroy");
            Destroy(gameObject, 0.3f);
        }
    }
    
}
