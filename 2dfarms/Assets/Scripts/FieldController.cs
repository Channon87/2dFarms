using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public bool isPlanted;
    public Sprite noPlantObj;
    public Sprite pars1;

    public void PlantField()
    {
        if (!isPlanted)
        {
            isPlanted = true;
            GetComponent<SpriteRenderer>().sprite = pars1;
        }
    }
}