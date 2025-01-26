using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoamingUiHandler : MonoBehaviour
{
    [SerializeField] TMP_Text HintCount;

    private void Start()
    {
        if (HintCount == null)
        {
            Debug.LogError("HintCount TMP_Text is not assigned in the Inspector!");
        }

        if (GameStateHandler.Instance == null)
        {
            Debug.LogError("GameStateHandler.Instance is null!");
            return;
        }

        GameStateHandler.Instance.OnHintTokenUpdate += OnHintTokenUpdate;
        OnHintTokenUpdate(); // Trigger manually to update the UI at the start
    }

    private void OnDestroy()
    {
        if (GameStateHandler.Instance != null)
        {
            GameStateHandler.Instance.OnHintTokenUpdate -= OnHintTokenUpdate;
        }
    }

    private void OnHintTokenUpdate()
    {
        if (GameStateHandler.Instance != null && GameStateHandler.Instance.GameData != null)
        {
            Debug.Log("Hint Token Count Updated: " + GameStateHandler.Instance.GameData.HintTokenCount);
            HintCount.text = GameStateHandler.Instance.GameData.HintTokenCount.ToString();
        }
        else
        {
            Debug.LogError("GameStateHandler or GameData is null!");
        }
    }
}