using System;
using System.Collections;
using UnityEngine;

public enum TurnState
{
    PlayerStart,
    PlayerEnd,
    EnemyStart,
    EnemyEnd,
    RoundStart,
    RoundEnd
}

public class TurnController : MonoBehaviour
{
    public static TurnController Instance { get; private set; }
    
    [SerializeField] int turnCount;
    [SerializeField] TurnState currentState;

    public event Action<string> TurnChange;
    private string turnString;

    private void Awake()
    {
        SingletonStart();
        EventsStart();
    }

    private void SingletonStart()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    private void EventsStart()
    {
        TurnChange += TurnHasChanged;
        Invoke(nameof(TempDelay), 2f);
       // TurnStateChange(TurnState.RoundStart);
    }

    void TempDelay()
    {
       TurnStateChange(TurnState.RoundStart);
    }

    public void TurnStateChange(TurnState state)
    {
        Debug.Log("State changed");
        currentState = state;
        TurnChange?.Invoke(SetTurnString(currentState));
    }
    
    private void TurnHasChanged(string turnName)
    {
        switch (currentState)
        {
            case TurnState.RoundStart:
                    Debug.Log("Round Start");
                break;  
            
            case TurnState.RoundEnd:
                    Debug.Log("Round End"); 
                break;
            
            case TurnState.PlayerStart:
                Debug.Log("Player Start");
                break;
            
            case TurnState.PlayerEnd:
                Debug.Log("Player End");
                break;
            
            case TurnState.EnemyStart:
                Debug.Log("Enemy Start");
                break;
            
            case TurnState.EnemyEnd:
                Debug.Log("Enemy Start");
                break;
        }
    }

    public static string SetTurnString(TurnState _state)
    {
        switch (_state)
        {
            case TurnState.RoundStart: return "Round Start!";
            case TurnState.RoundEnd: return "Round End!";
            case TurnState.PlayerStart: return "Player Start!";
            case TurnState.PlayerEnd: return "Player End";
            case TurnState.EnemyStart: return "Enemy Start";
            case TurnState.EnemyEnd: return "Enemy Start";
            default: return "";
        }
    }
}
