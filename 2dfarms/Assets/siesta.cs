using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siesta : Interactable
{
    public override void Interact(Character character)
    {
        DayTimeController.time = DayTimeController.time + 7200;
    }

}
