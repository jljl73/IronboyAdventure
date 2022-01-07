using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    UnityEvent OnHeartUpdate = new UnityEvent();
    UnityEvent OnScoreUpdate = new UnityEvent();
    UnityEvent OnAdvancementUpdate = new UnityEvent();
    UnityEvent OnComboUpdate = new UnityEvent();
    UnityEvent OnGameOver = new UnityEvent();

    public bool gameOver;
    public bool GameOver {
        get => gameOver;
        set
        {
            gameOver = value;
            OnGameOver.Invoke();
        }
    }
    public bool BossMode { get; set; }

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
            print("score changed!: " + score);
            if (OnScoreUpdate != null)
            {
                print("Listener count: " + OnScoreUpdate.GetPersistentEventCount());
                OnScoreUpdate.Invoke();

                print("OnScoreUpdate.Invoke();");
            }
        }
    }
    int combo;
    public int Combo
    {
        get { return combo;}
        set
        {
            combo = value;
            if (combo > 0 && combo % 15 == 0)
            {
                // 함수 내부에서 하트 증가
                uiManager.OnTriggerHeartAquisition();
            }
            OnComboUpdate.Invoke();
        }
    }
    float advancement;
    public float Advancement
    {
        get { return advancement; }
        set
        {
            advancement = value;
            if (OnAdvancementUpdate != null)
                OnAdvancementUpdate.Invoke();
            
        }
    }

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        print("Start");
        ConnectEvents();
        InitializeSetting();
    }

    void ConnectEvents()
    {
        OnHeartUpdate.AddListener(uiManager.OnLifeUIUpdate);
        OnScoreUpdate.AddListener(uiManager.OnScoreUIUpdate);
        OnAdvancementUpdate.AddListener(uiManager.OnAdvancementUpdate);
        OnComboUpdate.AddListener(uiManager.OnComboUpdate);
    }

    public void AddAdvancementUpdate(UnityAction action)
    {
        OnAdvancementUpdate.AddListener(action);
    }

    public void RemoveAdvancementUpdate(UnityAction action)
    {
        OnAdvancementUpdate.RemoveListener(action);
    }

    public void AddGameOver(UnityAction action)
    {
        OnGameOver.AddListener(action);
    }

    void InitializeSetting()
    {
        HeartCount = 3;
        Score = 0    ;
        Advancement = 0;
        combo = 0;
        gameOver = false;
        BossMode = false;
        //OnHeartUpdate.RemoveAllListeners();
        //OnScoreUpdate.RemoveAllListeners();
        //OnAdvancementUpdate.RemoveAllListeners();
        //OnComboUpdate.RemoveAllListeners();
        //OnGameOver.RemoveAllListeners();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Invoke("ConnectEvents", 0.5f);
        Invoke("InitializeSetting", 0.5f);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
