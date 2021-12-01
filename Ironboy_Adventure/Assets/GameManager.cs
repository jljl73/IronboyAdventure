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

    // �Ŵ��� ����
    public UIManager uiManager;
    
    // �̺�Ʈ
    UnityEvent OnHeartUpdate = new UnityEvent();
    UnityEvent OnScoreUpdate = new UnityEvent();
    UnityEvent OnAdvancementUpdate = new UnityEvent();

    // UI ����
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
                // �Լ� ���ο��� ��Ʈ ����
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
        OnHeartUpdate.AddListener(uiManager.OnLifeUIUpdate);
        OnScoreUpdate.AddListener(uiManager.OnScoreUIUpdate);
        OnAdvancementUpdate.AddListener(uiManager.OnAdvancementUpdate);
    }

    public void AddHeartUpdate(UnityAction action)
    {
        OnHeartUpdate.AddListener(action);
    }

    public void AddScoreUpdate(UnityAction action)
    {
        OnScoreUpdate.AddListener(action);
    }

    public void AddAdvancementUpdate(UnityAction action)
    {
        OnAdvancementUpdate.AddListener(action);
    }

    void InitializeSetting()
    {
        HeartCount = 3;
        Score = 0;
        Advancement = 0;
    }
}
