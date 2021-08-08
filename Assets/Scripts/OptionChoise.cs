using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OptionChoise : MonoBehaviour
{
    [SerializeField]
    public OptionChoose optionChoose;
    
    public void MakeChoise(bool isCorrect,Transform cardTransform)
    {
        optionChoose?.Invoke(isCorrect, cardTransform);
    }

}
