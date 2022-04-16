using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Attack : MonoBehaviour
{
    float strengh;
    bool attacking;
    // Start is called before the first frame update
    void Awake()
    {
        strengh = GameObject.Find("Slime").GetComponent<MoveManager>().Strengh;
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.tag == "Player" && attacking == false)
            StartCoroutine(attck());
        } 
    }

    IEnumerator attck()
    {
        attacking = true;
        Player.TakeDamage(strengh);
        yield return new WaitForSeconds(0.33f);
        attacking = false;
    }
}
