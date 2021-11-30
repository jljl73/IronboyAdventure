using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newGameObject = new GameObject("GameManager");
                _instance = newGameObject.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    // 매니저 관리
    public UIManager uiManager;

    // 이벤트
    UnityEvent OnHeartUpdate;
    UnityEvent OnScoreUpdate;
    UnityEvent OnAdvancementUpdate;

    // UI 정보
    int heartCount;
    public int HeartCount 
    { 
        get { return heartCount; }
        set
        {
            if (heartCount <= 0)
                heartCount = 0;
            if (heartCount < 5)
                heartCount = value;
            OnHeartUpdate.Invoke();
        }
    }
    int score;
    public int Score 
    {
        get { return score; }
        set
        {
            score = value;
            if (score <= 0)
                score = 0;
            if (OnScoreUpdate != null)
                OnScoreUpdate.Invoke();
        }
    }
    int combo;
    public int Combo
    {
        get { return combo;}
        set
        {
            combo = value;
            if (combo % 15 == 0)
            {
                // 함수 내부에서 하트 증가
                uiManager.OnTriggerHeartAquisition();
            }
        }
    }
    int advancement;
    public int Advancement
    {
        get { return advancement; }
        set
        {
            advancement = value;
            if (OnAdvancementUpdate != null)
                OnAdvancementUpdate.Invoke();
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        ConnectEvents();
        InitializeSetting();
    }

    void ConnectEvents()
    {
        OnHeartUpdate = new UnityEvent();
        OnScoreUpdate = new UnityEvent();
        OnAdvancementUpdate = new UnityEvent();

        OnHeartUpdate.AddListener(uiManager.OnLifeUIUpdate);
        OnScoreUpdate.AddListener(uiManager.OnScoreUIUpdate);
        OnAdvancementUpdate.AddListener(uiManager.OnAdvancementUpdate);
    }
    void InitializeSetting()
    {
        HeartCount = 3;
        Score = 0;
        Advancement = 0;
    }
}
