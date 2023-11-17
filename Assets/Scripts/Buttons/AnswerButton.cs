namespace Buttons
{
    public class AnswerButton : BaseButton
    {
        public int AnswerIndex { private get;  set; }
        protected override void OnClickAction()
        {
            QuizController.Instance.AnswerQuestion(AnswerIndex);
        }
    }
}
