using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Attack : MonoBehaviour
{

    public Animator anim;
    public Transform pos;
    public Vector2 boxSize;
    float strengh;
    bool attack, touch;

    float dist, AttackRange;

    void Awake()
    {
        anim = GetComponent<Animator>();
        strengh = this.gameObject.GetComponent<MoveManager>().Strengh;
        attack = false;
        touch = false;
    }

    void Update()
    {
        Debug.Log(touch);
        if(this.gameObject.GetComponent<Spawn>().mob_num == GameObject.Find("Main Camera").GetComponent<TestCamera>().MapNum)
        {
            dist = this.gameObject.GetComponent<MoveManager>().dist;
            AttackRange = this.gameObject.GetComponent<MoveManager>().AttackRange;

            if(dist <= AttackRange){
                anim.SetTrigger("Attack");
                Attack();
            }
        }

    }


    void Attack()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if(collider.gameObject.tag=="Player" && attack == false) {
                StartCoroutine(giveDamage());
            }
            
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    IEnumerator giveDamage()
    {
        attack = true;
        yield return new WaitForSeconds(1.13f);
        if(dist <= AttackRange + .7f)
            Player.TakeDamage(strengh);
        yield return new WaitForSeconds(.2f);
        attack = false;
    }

}
