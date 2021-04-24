using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class plantControl : MonoBehaviour
{
    public float growTime = 0;
    public KeyCode interactKey;
    public bool isInRange;
    public Sprite weeds;
    public Sprite noPlantObj;
    public Sprite pars1;
    public Sprite pars2;
    public Sprite pars3;
    public Sprite pars4;
    public Sprite pars5;
    // Start is called before the first frame update
    private void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite == pars1)
        {
            growTime += Time.deltaTime;

        }
           if (growTime > 3)
            {
                GetComponent<SpriteRenderer>().sprite = pars2;
                growTime += Time.deltaTime;
            }

            if (growTime > 9 )
            {
                GetComponent<SpriteRenderer>().sprite = pars3;
                growTime += Time.deltaTime;
            }

            if (growTime > 21)
            {
                GetComponent<SpriteRenderer>().sprite = pars4;
                growTime += Time.deltaTime;
            }

            if (growTime > 45)
            {
                GetComponent<SpriteRenderer>().sprite = pars5;
            }
        
    
        if (isInRange)
        { if (GMScript.currentTool == "Hoe" && GetComponent<SpriteRenderer>().sprite == weeds)  
            {
                if (Input.GetKeyDown(interactKey))
                {
                    //do something with object
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                }
            }
            if (GMScript.currentTool == "Parsnip" && GetComponent<SpriteRenderer>().sprite == noPlantObj)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    GetComponent<SpriteRenderer>().sprite = pars1;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
        
                  

        }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }


}
   


