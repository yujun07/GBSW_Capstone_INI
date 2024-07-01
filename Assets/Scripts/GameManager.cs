using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    float currentTime;
    public float minTime = 0.5f;
    public float maxTime = 1.5f;
    public float createTime = 1;
    public GameObject[] objectFactorys;
    public int poolSize = 20;
    public Transform spawnPoint;
    public List<GameObject> objectPool;
    public bool isGameOver;
    public float clearTime = 30;
    public bool isGameClear;
    int currentScore = 0;
    int clearScore = 20;
    public Text currentScoreText;
    public Text clearScoreText;
    public Text timeText;
    public bool isSpawn;
    public GameObject gameOver;
    public GameObject gameClear;

    public Sprite[] naTehyeon; //주인공
    public Sprite[] naYuNa; //여동생
    public Sprite[] aYun; //장애인

    public Sprite[] backGround;

    public Image image1;
    public Image image2;
    public Image backGroundImage;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public float Timer
    {
        get
        {
            return currentTime;
        }
        set
        {
            currentTime = value;
            timeText.text = "" + clearTime;
        }
    }
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreText.text = "현재 점수 : " + currentScore;
        }
    }
    void Start()
    {
        
        createTime = Random.Range(minTime, maxTime);
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            int ranObject = Random.Range(0, objectFactorys.Length);
            GameObject gameObject = Instantiate(objectFactorys[ranObject],spawnPoint);
            objectPool.Add(gameObject);
           gameObject.SetActive(false);
        
        }
        
        clearScoreText.text = "목표 점수 : " + clearScore;
        currentScoreText.text = "현재 점수 : " + currentScore;
    }
    void CheckClear()
    {
        if (clearTime <= 0)
        {
            isGameOver = true;
        }
        if (!isGameOver)
        {
            if(currentScore>= clearScore)
            {
                isGameClear= true;
                gameClear.SetActive(true);
            }
        }
        if (currentScore < clearScore && isGameOver)
        {
            gameOver.SetActive(true);
        }
    }
    void SpawnObject()
    {
        if (!isGameOver && !isSpawn)
        {
            if(objectPool.Count > 0)
            {
                GameObject gameObject = objectPool[0];
                objectPool.Remove(gameObject);
                gameObject.transform.position = spawnPoint.position;
                gameObject.SetActive(true);
                isSpawn = true;
            }
        }
    }
    public void Next()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (clearTime > 0)
        {
            clearTime -= Time.deltaTime;
        }
        if (currentTime > createTime && clearTime>=currentTime)
        {
            SpawnObject();
            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;
        }
        timeText.text = clearTime.ToString("F2");
        CheckClear();
    }
   
    
}
