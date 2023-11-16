using System;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    [RequireComponent(typeof(Button))]
    public class BaseButton : MonoBehaviour
    {
        private Button baseButton;
        
        private void Awake()
        {
            baseButton = GetComponent<Button>();
        }

        private void Start()
        {
            baseButton.onClick.AddListener(OnClickAction);
        }
        
        private void OnDestroy()
        {
            baseButton.onClick.RemoveListener(OnClickAction);
        }

        protected virtual void OnClickAction()
        {
            GameHandler.Instance.NextState();
        }
    }
}
