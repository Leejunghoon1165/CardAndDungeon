using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject toObject;
    public bool Teleportflag;
    public int mapNum;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            targetObject = collision.gameObject;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TeleportCoroutine());
            
        }
           
    }

    IEnumerator TeleportCoroutine()
    {
        targetObject.transform.position = toObject.transform.position;
        Camera.main.GetComponent<TestCamera>().ChangeLimit(mapNum);
        TestCamera.check = true;
        yield return new WaitForSeconds(0.1f);
        TestCamera.check = false;
        
    }
    // Start is called before the first frame update

}
