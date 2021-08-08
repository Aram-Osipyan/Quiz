using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnswerCard : MonoBehaviour
{
    [SerializeField]
    private GameObject emptyGameObject;
    [SerializeField]
    private ParticleSystem particles;
    public string CorrectAnswer { set; get; }
    public string Identifier { set; get; }
    public bool isBlocked { private set; get; } = false;
    private GameObject cardLetter;
    public void SetState(bool _isBlocked)
    {
        isBlocked = _isBlocked;
    }
    public void SetOption(string correctAnswer, string identifier)
    {
        CorrectAnswer = correctAnswer;
        Identifier = identifier;
    }
    public void InitializateCard(CardData cardData,string rightAnswer)
    {
        GetComponent<SpriteRenderer>().color = cardData.CellbackGroundColor;
        cardLetter = Instantiate(emptyGameObject, transform);
        SpriteRenderer spriteRenderer = cardLetter.AddComponent<SpriteRenderer>();
        cardLetter.AddComponent<BounceAnimation>();
        spriteRenderer.sprite = cardData.Sprite;
        spriteRenderer.sortingOrder = 1;
        SetOption(rightAnswer,cardData.Identifier);
    }
    private void OnMouseDown()
    {
        if (isBlocked)
        {
            return;
        }
        transform.parent.GetComponent<OptionChoise>().MakeChoise(CorrectAnswer == Identifier, transform);
        if (CorrectAnswer == Identifier)
        {
            cardLetter.GetComponent<BounceAnimation>().PLayBounceAnimation(0.2f);
            Instantiate(particles, transform).Play();
        }
        else
        {
            cardLetter.GetComponent<BounceAnimation>().PlayEaseInBounce();
        }
    }
}
