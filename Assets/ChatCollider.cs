using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatCollider : MonoBehaviour
{
    public RectTransform DialogueOverlay;

    private void Start()


    {
  DialogueOverlay.gameObject.SetActive(false);      
   
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.name != "Player")
            return;
       

     DialogueOverlay.gameObject.SetActive(true);

        Debug.Log("Enter");
    

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name != "Player")
            return;

     DialogueOverlay.gameObject.SetActive(false);
        Debug.Log("Exit");
    }




}
