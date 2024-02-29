using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timeText;
    private float currentTime;

    private static Timer instance;
    public static Timer Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        string min = ((int)currentTime / 60).ToString("00");
        string sec = ((int)currentTime % 60).ToString("00");

        timeText.text = $"計時器: {min}:{sec}";
    }

    // 提供一個公開的方法，用於減少當前時間
    public void DecreaseTime(float amount)
    {
        currentTime -= amount;
        if (currentTime < 0)
        {
            currentTime = 0;
        }
    }
    public void IncreaseTime(float amount)
    {
        currentTime += amount;
    }
    // 提供一個公開的方法，用於獲取當前時間
    public float GetCurrentTime()
    {
        return currentTime;
    }
}
