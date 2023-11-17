using UnityEngine;

namespace Panels
{
    public class BasePanel : MonoBehaviour
    {
        [SerializeField] protected GameHandler.GameState activeState;
    
        protected virtual void Start()
        {
            GameHandler.OnStateChanged += GameHandler_OnStateChanged;
            gameObject.SetActive(activeState == GameHandler.GameState.Menu);
        }

        protected virtual void GameHandler_OnStateChanged(object sender, GameHandler.OnStateChangedEventArgs e)
        {
            gameObject.SetActive(e.state == activeState);
        }

        protected virtual void OnDestroy()
        {
            GameHandler.OnStateChanged -= GameHandler_OnStateChanged;
        }
    }
}