using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RestartLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private UnityEvent gameRestart;
    [SerializeField]
    private GameObject darkBackground;
    [SerializeField, Range(0, 2)]
    private float restartButtonAppearanceTime = 1f;
    [Header("Load Display Settings")]
    [SerializeField]
    private GameObject loadDisplay;
    [SerializeField,Range(0,5)]
    private float loadingDuration;
    void Start()
    {
        restartButton.SetActive(false);
        darkBackground.SetActive(false);
        loadDisplay.SetActive(false);
    }
    public void GameEnd()
    {
        StartCoroutine(RestartButtonAppearance());
        darkBackground.SetActive(true);
        darkBackground.GetComponent<FadeInAnimation>().FadeInPlay(1f);
    }
    public void GameRestart()
    {
        restartButton.SetActive(false);
        darkBackground.SetActive(false);
        StartCoroutine(Loading());
        
    }
    private IEnumerator Loading()
    {
        loadDisplay.SetActive(true);
        loadDisplay.GetComponent<FadeInAnimation>().FadeInPlay(0.5f);
        yield return new WaitForSeconds(loadingDuration);
        loadDisplay.SetActive(false);
        gameRestart?.Invoke();
    }
    private IEnumerator RestartButtonAppearance()
    {
        yield return new WaitForSeconds(restartButtonAppearanceTime);
        restartButton.SetActive(true);
    }
}
