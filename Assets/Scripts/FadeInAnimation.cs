using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FadeInAnimation : MonoBehaviour
{
	private CanvasGroup canvasGroup;
	private Tween fadeTween;
	void Start()
    {
		canvasGroup = GetComponent<CanvasGroup>();
		FadeInPlay();
	}
	public void FadeIn(float duration)
	{
		Fade(1f, duration, () =>
		{
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		});
	}

	public void FadeOut(float duration)
	{
		Fade(0f, duration, () =>
		{
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		});
	}

	private void Fade(float endValue, float duration, TweenCallback onEnd)
	{
		if (fadeTween != null)
		{
			fadeTween.Kill(false);
		}

		fadeTween = canvasGroup.DOFade(endValue, duration);
		fadeTween.onComplete += onEnd;
	}
	private IEnumerator PlayFadeInAnimation(float duration = 1f)
	{
		FadeOut(0f);
		yield return new WaitForSeconds(0f);
		FadeIn(duration);
	}
	public void FadeInPlay(float duration = 1f)
    {
		StartCoroutine(PlayFadeInAnimation(duration));
	}
}
