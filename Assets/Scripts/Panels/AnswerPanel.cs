using System;
using TMPro;
using UnityEngine;

namespace Panels
{
    public class AnswerPanel : BasePanel
    {
        [SerializeField] private TextMeshProUGUI text;
        
        private const string CORRECT_ANSWER_TEXT = "Верно";
        private const string INCORRECT_ANSWER_TEXT = "Неверно";
        
        
        private void Awake()
        {
            activeState = GameHandler.GameState.Answer;
        }

        protected override void Start()
        {
            base.Start();
            QuizController.OnQuestionAnswered += QuizController_OnQuestionAnswered;
        }

        private void QuizController_OnQuestionAnswered(object sender, QuizController.OnQuestionAnsweredEventArgs e)
        {
            text.text = e.isCorrect ? CORRECT_ANSWER_TEXT : INCORRECT_ANSWER_TEXT;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            QuizController.OnQuestionAnswered -= QuizController_OnQuestionAnswered;
        }
    }
}
