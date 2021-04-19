using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemselection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (gameObject.name == "seeds")
        {


            GMScript.currentTool = "seeds";
        }
    }
}