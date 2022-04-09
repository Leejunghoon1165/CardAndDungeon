using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_Bullet : MonoBehaviour
{
    private Vector2 playerPos;

    public int damage;
    
    public float speed;

    void Awake()
    {
        Vector2.MoveTowards(this.transform.position, playerPos, speed);

        playerPos = new Vector2(GameObject.FindWithTag("Player").transform.position.x, GameObject.FindWithTag("Player").transform.position.y + 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, playerPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player") 
            Destroy(gameObject);
        
    }
}