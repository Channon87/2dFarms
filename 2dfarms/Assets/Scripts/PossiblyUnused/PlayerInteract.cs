using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class  PlayerInteract : MonoBehaviour
{
    [SerializeField] private Image EButton;
    [SerializeField] private Text interact;
    public GameObject currentIntObj = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    

    }
    void OnTriggerEnter2D(Collider2D collision)
    {// walkover on trigger item
        if (collision.CompareTag("interObject"))
        {
            Debug.Log(collision.name);
            currentIntObj = collision.gameObject;
            EButton.enabled = true;
            interact.enabled = true;

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {// reset trigger to not run script
        if (collision.CompareTag("interObject"))
        {
            if (collision.gameObject == currentIntObj)
            {
                currentIntObj = null;
                EButton.enabled = false;
                interact.enabled = false;
            }


        }
    }

}