using Buttons;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Panels
{
    public class QuestionPanel : BasePanel
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image background;
        [SerializeField] private GameObject[] answerButtonArray;
        
        private void Awake()
        {
            activeState = GameHandler.GameState.Question;
        }
        
        protected override void GameHandler_OnStateChanged(object sender, GameHandler.OnStateChangedEventArgs e)
        {
            base.GameHandler_OnStateChanged(sender, e);
            if (e.state == activeState)
            {
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            Question question = QuizController.Instance.GetCurrentQuestion();
            
            text.text = question.text;
            background.sprite = Resources.Load<Sprite>(question.backgroundFilePath);

            for (int i = 0; i < answerButtonArray.Length; i++)
            {
                if (i < question.answers.Length)
                {
                    answerButtonArray[i].SetActive(true);
                    answerButtonArray[i].GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i].text;
                    answerButtonArray[i].GetComponent<AnswerButton>().AnswerIndex = i;
                }
                else
                {
                    answerButtonArray[i].SetActive(false);
                }
            }
        }
    }
}
