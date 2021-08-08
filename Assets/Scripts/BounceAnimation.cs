using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BounceAnimation : MonoBehaviour
{
    [SerializeField] float durationEaseInBounceAnimation = 0.1f;
    public void PLayBounceAnimation(float showTime)
    {
        Sequence sequence = DOTween.Sequence()
                    .OnStart(() =>
                    {
                        transform.localScale = Vector3.zero;
                    })
                    .Append(transform.DOScale(1.2f, showTime))
                    .Append(transform.DOScale(0.95f, showTime))
                    .Append(transform.DOScale(1, showTime));
        sequence.Play();
    }
    public void PlayEaseInBounce()
    {
        float maxScale = 0.2f;
        Sequence sequence = DOTween.Sequence()
                    .OnStart(() => { })
                    .Append(transform.DOLocalMoveX(maxScale * 0f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(-maxScale * 0.98f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(maxScale * 0.99f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(-maxScale * 0.94f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(maxScale * 0.98f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(-maxScale * 0.75f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(maxScale * 0.98f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(-maxScale * 0.44f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(maxScale * 0.11f, durationEaseInBounceAnimation))
                    .Append(transform.DOLocalMoveX(maxScale * 0f, durationEaseInBounceAnimation));
                    
        sequence.Play();
    }
}
