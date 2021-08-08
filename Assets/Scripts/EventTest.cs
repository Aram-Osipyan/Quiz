using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public void Click(bool answer,Transform pos)
    {
        if (answer)
        {
            Debug.Log("Correctzzz");
        }
        else
        {
            Debug.Log("Not Correctzzz");
        }
    }
}
