using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    [SerializeField]float followSpeed = 0.125f;
    Rigidbody2D rb;
    bool alreadyHover = false;

    private void OnMouseOver() {
        if(Input.GetMouseButton(1)){
            alreadyHover = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
            if(alreadyHover){
                rb.velocity =  followSpeed * (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            }
        }
        else{
            alreadyHover = false;
            rb.velocity = Vector2.zero;
        }
        
        

    }
}
