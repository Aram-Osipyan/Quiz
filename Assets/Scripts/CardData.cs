using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardData
{
    [SerializeField]
    private string _identifier;

    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private Color _cellBackgroundColor;
    public string Identifier => _identifier;

    public Sprite Sprite => _sprite;

    public Color CellbackGroundColor => _cellBackgroundColor;
}
