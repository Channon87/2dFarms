using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tools : MonoBehaviour
{
    public Transform curserObj;
    public void hoe()
    {
        GMScript.currentTool = "Hoe";
            }
    public void parsnip()
    {
        GMScript.currentTool = "Parsnip";
    }
    public void water()
    {
        GMScript.currentTool = "Water";
    }
    public void highlight()
    {
        curserObj.transform.position = transform.position;
    }
}
