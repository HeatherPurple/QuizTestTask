using UnityEngine;

namespace Panels
{
    public class BasePanel : MonoBehaviour
    {
        [SerializeField] private GameObject showOrHide;
        [SerializeField] protected GameHandler.GameState activeState;
        
        
        protected virtual void Start()
        {
            GameHandler.OnStateChanged += GameHandler_OnStateChanged;
            showOrHide.SetActive(activeState == GameHandler.GameState.Menu);
        }

        protected virtual void GameHandler_OnStateChanged(object sender, GameHandler.OnStateChangedEventArgs e)
        {
            showOrHide.SetActive(e.state == activeState);
        }

        protected virtual void OnDestroy()
        {
            GameHandler.OnStateChanged -= GameHandler_OnStateChanged;
        }
    }
}