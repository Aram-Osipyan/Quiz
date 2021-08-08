using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBlocker : MonoBehaviour
{
    public bool isGameEnd { private set; get; } = false;
    public void SetEndGame(bool _isGameEnd)
    {
        isGameEnd = _isGameEnd;
    }
}
