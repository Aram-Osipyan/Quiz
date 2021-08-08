using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class FieldGeneratior : MonoBehaviour
{
    [SerializeField]
    private float tileSize = 2;
    [SerializeField]
    private GameObject cellSprite;
    [SerializeField]
    private CardBundleData cardBundleData;
    [SerializeField]
    private Text TaskText;

    private List<GameObject> cards = new List<GameObject>();
    private int cols = 3;
    private List<int> correctAnswers;
    void Start()
    {
        CorrectAnswersGenerate();        
    }

    private void CorrectAnswersGenerate()
    {
        correctAnswers = new List<int>();
        for (int i = 0; i < cardBundleData.CardDatas.Length; i++)
        {
            correctAnswers.Add(i);
        }
    }

    public void GenerateField(int rows)
    {
        int randIndex = Random.Range(0, correctAnswers.Count - 1);
        int taskNumber = correctAnswers[randIndex];
        TaskText.text = "Find " + cardBundleData.CardDatas[taskNumber].Identifier;
        correctAnswers.RemoveAt(randIndex);

        List<int> answerChoise = new List<int>();
        for (int i = 0; i < cardBundleData.CardDatas.Length; i++)
        {
            answerChoise.Add(i);
        }
        answerChoise.RemoveAt(taskNumber);
        List<int> cardsIndexes = new List<int>();
        int correctAnswerIndex = Random.Range(0, rows * cols);
        for (int i = 0; i < rows*cols; i++)
        {
            int index = Random.Range(0, answerChoise.Count);
            cardsIndexes.Add(answerChoise[index]);
            answerChoise.RemoveAt(index);
        }
        cardsIndexes[correctAnswerIndex] = taskNumber;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject cell = (GameObject)Instantiate(cellSprite, Vector3.zero,Quaternion.identity,transform);
                cards.Add(cell);                
                cell.GetComponent<AnswerCard>().InitializateCard(cardBundleData.CardDatas[cardsIndexes[row*cols+col]], 
                    cardBundleData.CardDatas[taskNumber].Identifier);       

                float posX = col * tileSize;
                float posY = row * tileSize;
                cell.transform.position = new Vector2(posX, posY);
            }
        }
        CenterPosition(rows);
    }

    public void Clear()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Destroy(cards[i]);
        }
        cards = new List<GameObject>();
    }

    private void CenterPosition(int rows)
    {
        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2(tileSize / 2 - gridW / 2, tileSize / 2 - gridH / 2);
    }

}
