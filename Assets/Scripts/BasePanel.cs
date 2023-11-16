using System;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    [SerializeField] private GameHandler.GameState activeState;
    
    private void Start()
    {
        GameHandler.OnStateChanged += GameHandler_OnStateChanged;
    }

    private void GameHandler_OnStateChanged(object sender, GameHandler.OnStateChangedEventArgs e)
    {
        gameObject.SetActive(e.state == activeState);
    }

    private void OnDestroy()
    {
        GameHandler.OnStateChanged -= GameHandler_OnStateChanged;
    }
}