using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimedEvent : MonoBehaviour
{
    private FunctionTimer functionTimer;

    // Start is called before the first frame update
    void Start()
    {
        functionTimer = new FunctionTimer(TestingAction, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        functionTimer.Update();
    }

    private void TestingAction()
    {
        Debug.Log("Testing timed action");
    }
}
