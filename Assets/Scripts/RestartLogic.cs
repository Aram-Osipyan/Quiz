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
    void Start()
    {
        restartButton.SetActive(false);
        darkBackground.SetActive(false);
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
        gameRestart?.Invoke();
    }
    private IEnumerator RestartButtonAppearance()
    {
        yield return new WaitForSeconds(restartButtonAppearanceTime);
        restartButton.SetActive(true);
    }
}
