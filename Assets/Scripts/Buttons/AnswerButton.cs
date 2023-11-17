namespace Buttons
{
    public class AnswerButton : BaseButton
    {
        public bool isCorrect { private get;  set; }
        protected override void OnClickAction()
        {
            base.OnClickAction();
            QuizController.Instance.AnswerQuestion(isCorrect);
        }
    }
}
