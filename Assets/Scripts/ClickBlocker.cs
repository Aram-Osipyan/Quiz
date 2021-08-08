using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBlocker : MonoBehaviour
{
    public bool isGameEnd { private set; get; } = false;
    public void SetGameState(bool _isGameEnd)
    {
        BroadcastMessage("SetState", _isGameEnd);
    }
}
