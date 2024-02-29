using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class Controller : MonoBehaviour
{
    [SerializeField] Camera cam;

    public AudioClip footstepSound;
    public AudioClip jumpSound;
    [SerializeField] AudioClip falseSound;
    [SerializeField] AudioClip gameoverSound;
    public float footstepInterval = 0.8f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float nextFootstepTime;

    [SerializeField] Vector3 MovingDirection;
    [SerializeField] float MovingSpeed = 10f;
    [SerializeField] float RunningSpeed = 15f;
    private float rotationSpeed = 5.0f;
    public float JumpForce;
    Rigidbody rb;
    Animator animator;
    bool onGround = false;

    [SerializeField] GameObject bumpIntoEventText;
    [SerializeField] GameObject chooseBeerText;

    private bool isBananaEffectActive = false;
    private float bananaEffectDuration = 10f;
    private float bananaEffectTimer = 0f;
    private GameObject newTextObject;

    [SerializeField] GameObject PEclass;
    [SerializeField] GameObject JPclass;
    [SerializeField] GameObject ENGclass;

    private bool isFallIntoWater = false;
    private bool isTwoOneDoor = false;
    private bool isHeartZero = false;
    private bool isDrunk = false;
    private bool isCoin = false;
    private bool isUnderGround = false;

    [SerializeField] Image[] hearts;
    private int currentHearts = 3;

    [SerializeField] GameObject MouseVendorUI;

    [SerializeField] Timer timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        timer = GetComponent<Timer>();

        nextFootstepTime = Time.time;
        if (footstepSound == null)
        {
            Debug.LogError("footstepSound is not assigned!");
        }

        PlayerPrefs.DeleteAll();
        currentHearts = 3;
        UpdateHeartsUI();
    }

    public void ReduceHearts()
    {
        if (currentHearts > 0 )
        {
            Debug.Log("-heart");
            currentHearts--;
            UpdateHeartsUI();

            audioSource.PlayOneShot(falseSound);
        }

        if (currentHearts == 0)
        {
            audioSource.PlayOneShot(gameoverSound);
            isHeartZero = true;
            PlayerPrefs.SetInt("IsHeartZero", isHeartZero ? 1 : 0);
            SceneManager.LoadScene("GameOverScene");
        }
    }
    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHearts;
        }
    }
    private bool IsHeartZero()
    {
        return isHeartZero;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Banana"))
        {
            Destroy(other.gameObject);
            isBananaEffectActive = true;
            StartCoroutine(DisableBananaEffect());

            CreateUIText("糟糕!你踩到香蕉了!留在原地等待10秒");
        }

        else if (other.CompareTag("Water"))
        {
            isFallIntoWater = true;
            PlayerPrefs.SetInt("IsFallIntoWater", isFallIntoWater ? 1 : 0);

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("GameOverScene");
        }

        else if (other.CompareTag("TwoOneDoor"))
        {
            isTwoOneDoor = true;
            PlayerPrefs.SetInt("IsTwoOneDoor", isTwoOneDoor ? 1 : 0);

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("GameOverScene");
        }
        else if (other.CompareTag("MouseVendor"))
        {
            Destroy(other.gameObject);
            MouseVendorUI.SetActive(true);
        }
        else if (other.CompareTag("underGround"))
        {
            isUnderGround = true;
            PlayerPrefs.SetInt("IsUnderGround", isUnderGround ? 1 : 0);

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("GameOverScene");
        }

    }
    private bool IsUnderGround()
    {
        return isUnderGround;
    }



    public void chooseBeer()
    {
        Debug.Log("beer");

        isDrunk = true;
        PlayerPrefs.SetInt("IsDrunk", isDrunk ? 1 : 0);

        //timer.IncreaseTime(30f);

    }
    private bool IsDrunk()
    {
        return isDrunk;
    }
    
    public void chooseCoin()
    {
        Debug.Log("coin");

        isCoin = true;
        Debug.Log(isCoin);

    }

    public void chooseBook()
    {
        Debug.Log("book");

        //CreateUIText("你選擇了書籍! 但好像沒什麼用ㄟ...");

    }

    private void CreateUIText(string UIText)
    {
        // Instantiate the Text prefab
        newTextObject = Instantiate(bumpIntoEventText, Vector3.zero, Quaternion.identity);

        // Set the parent of the new text object to be the Canvas (or another UI element)
        newTextObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

        // Access the RectTransform component on the instantiated object
        RectTransform newTextTransform = newTextObject.GetComponent<RectTransform>();

        // Access the Text component on the instantiated object
        Text newTextComponent = newTextObject.GetComponent<Text>();

        if (newTextComponent == null)
        {
            newTextComponent = newTextObject.GetComponentInChildren<Text>();
        }

        if (newTextTransform != null && newTextComponent != null)
        {
            // Customize the RectTransform properties
            newTextTransform.anchoredPosition = new Vector2(0f, -300f);  // Set anchored position
            newTextTransform.sizeDelta = new Vector2(1000f, 150f);  // Set size

            // Customize the text properties
            newTextComponent.text = UIText;
            newTextComponent.fontSize = 50;
            newTextComponent.fontStyle = FontStyle.Bold;
            newTextComponent.color = Color.red;
        }
        else
        {
            Debug.LogError("Text component not found on the instantiated object.");
        }
    }


    IEnumerator DisableBananaEffect()
    {
        yield return new WaitForSeconds(bananaEffectDuration);
        isBananaEffectActive = false;
        bananaEffectTimer = 0f;
        Destroy(newTextObject);
    }
    public bool bumpintobanana()
    {
        return isBananaEffectActive;
    }

    public bool IsFallIntoWater()
    {
        return isFallIntoWater;
    }

    public bool IsTwoOneDoor()
    {
        return isTwoOneDoor;
    }

    void PlayFootstepSound()
    {
        if (Time.time > nextFootstepTime)
        {
            audioSource.PlayOneShot(footstepSound);
            nextFootstepTime = Time.time + footstepInterval;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = true;
            Debug.Log("onground");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = false;
            Debug.Log("not onground");
        }
    }

    private void Move()
    {
        if (!PEclass.activeSelf && !JPclass.activeSelf && !ENGclass.activeSelf)
        {
            PlayFootstepSound();
        }


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = cam.transform.forward;
        Vector3 cameraRight = cam.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        Vector3 moveDirection = (cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            // Calculate the target rotation based on the camera direction
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward, Vector3.up);

            // Smoothly interpolate between the current rotation and the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the character in the direction of the camera's forward
            float currentSpeed = (Input.GetKey(KeyCode.LeftShift) && isDrunk == false) ? RunningSpeed : MovingSpeed;
            transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);

            animator.SetFloat("Walking Speed", currentSpeed);
        }
        else
        {
            // If there is no input, stop the character immediately
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            animator.SetFloat("Walking Speed", 0);
        }

    }
    private void Jump()
    {
        if (onGround && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(JumpForce * Time.deltaTime * Vector3.up);
            animator.SetBool("Jump", true);
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void Update()
    {
        animator.SetFloat("Walking Speed", 0);
        animator.SetBool("Jump", false);

        if (!isBananaEffectActive && !PEclass.activeSelf && !JPclass.activeSelf && !ENGclass.activeSelf && !MouseVendorUI.activeSelf)
        {
            animator.SetBool("NotBanana", true);
            Move();
            Jump();
        }
        else
        {
            
            animator.SetBool("NotBanana", false);
        }
    }



}
