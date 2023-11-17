using System;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    [RequireComponent(typeof(Button))]
    public class BaseButton : MonoBehaviour
    {
        private Button button;
        
        protected void Awake()
        {
            button = GetComponent<Button>();
        }

        protected void Start()
        {
            button.onClick.AddListener(OnClickAction);
        }
        
        protected void OnDestroy()
        {
            button.onClick.RemoveListener(OnClickAction);
        }

        protected virtual void OnClickAction()
        {
            GameHandler.Instance.NextState();
        }
    }
}
