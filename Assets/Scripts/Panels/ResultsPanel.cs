using TMPro;
using UnityEngine;

namespace Panels
{
    public class ResultsPanel : BasePanel
    {
        private const string CORRECT_ANSWERS_NUMBER = "Количество правильных ответов: ";
        [SerializeField] private TextMeshProUGUI text;
        
        private void Awake()
        {
            activeState = GameHandler.GameState.Results;
        }
        
        protected override void Start()
        {
            base.Start();
            QuizController.OnEndGame += QuizController_OnEndGame;
        }

        private void QuizController_OnEndGame(object sender, QuizController.OnEndGameEventArgs e)
        {
            text.text = CORRECT_ANSWERS_NUMBER + e.correctAnswersNumber;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            QuizController.OnEndGame -= QuizController_OnEndGame;
        }
    }
}
