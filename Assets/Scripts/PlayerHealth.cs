using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] string playerColor;
    [SerializeField] int playerHP;
    bool isDead = false;
    [SerializeField] bool isPlayer = false;
    GameObject sceneObject;
    SceneHandler sceneHandler;
    // Start is called before the first frame update
    void Start()
    {
        if(isPlayer){
            sceneObject = GameObject.FindWithTag("SceneHandler");
            sceneHandler = sceneObject.GetComponent<SceneHandler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP <= 0 && isDead == false){
            isDead = true;
            GameObject upperBody = gameObject.transform.GetChild(0).gameObject;
            for(int i = 0; i < gameObject.transform.childCount; i++){
                if(gameObject.transform.GetChild(i).name != "UpperBody"){
                    Destroy(gameObject.transform.GetChild(i).gameObject);
                }
                else{
                    upperBody = gameObject.transform.GetChild(i).gameObject;
                }
            }
            Animator animator = upperBody.GetComponent<Animator>();
            animator.SetTrigger("isDestroy");
            if(isPlayer) sceneHandler.LoadScene("LosingCondition");
            Destroy(gameObject, 1.5f);
        }
    }

    public string getPlayerColor(){
        return playerColor;
    }

    public void reducePlayerHP(int damage){
        playerHP -= damage;
    }
}
