using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{

    [SerializeField]
    private FieldGeneratior fieldGenerator;
    [SerializeField, Range(1, 2)]
    private float timeBetweenLevels = 0.5f;
    [SerializeField]
    private UnityEvent gameEnd;
    [SerializeField]
    private int maxLevelCount = 3;

    private int level = 1;

    private void Start()
    {
        StartGame();
        fieldGenerator.GetComponent<BounceAnimation>().PLayBounceAnimation(0.3f);
    }
    public void ChangeLevel(bool isCorrect,Transform transform)
    {
        
        if (isCorrect)
        {
            level++;
            if (level == maxLevelCount+1)
            {
                level = 1;
                gameEnd?.Invoke();
            }
            else
            {
                StartCoroutine(ChangeLevelAfterSeconds(timeBetweenLevels));
            }
            
        }
    }
    private void DefaultFieldSettings()
    {
        fieldGenerator.Clear();
        fieldGenerator.transform.position = Vector2.zero;
        fieldGenerator.GenerateField(level);
    }
    public void StartGame()
    {

        DefaultFieldSettings();   
        
    }
    private IEnumerator ChangeLevelAfterSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        DefaultFieldSettings();
    }
}
