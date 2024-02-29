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

        timeText.text = $"�p�ɾ�: {min}:{sec}";
    }

    // ���Ѥ@�Ӥ��}����k�A�Ω��ַ�e�ɶ�
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
    // ���Ѥ@�Ӥ��}����k�A�Ω������e�ɶ�
    public float GetCurrentTime()
    {
        return currentTime;
    }
}
