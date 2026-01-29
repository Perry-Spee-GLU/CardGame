using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class TurnIndication : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI turnTextmesh;
    [SerializeField] CanvasGroup canvasGroup;
    
    private void Start()
    {
        //To make sure the event subscription is possible.
        Invoke(nameof(Sub), 1f);
    }

    private void Sub()
    {
        TurnController.Instance.TurnChange += ShowTurnText;
    }

    private void OnDisable()
    {
        TurnController.Instance.TurnChange -= ShowTurnText;
    }

    private void ShowTurnText(String text)
    {
        StartCoroutine(TurnText(text));
    }
    
    private IEnumerator TurnText(string text)
    {
        //Debug.Log(text);
        canvasGroup.alpha = 1;
        turnTextmesh.text = text;
        yield return new WaitForSeconds(0.5f);
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
