using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float JumpForce;
    [SerializeField] float MovingSpeed;
    [SerializeField] float RunningSpeed;
    [SerializeField] Transform player;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject groundPrefab;

    [SerializeField] float rotationSpeed = 5.0f;

    bool onGround = false;
    Rigidbody rb;
    Animator animator;

    /*/private bool isBananaEffectActive = false;
    private float bananaEffectDuration = 10f;
    private float bananaEffectTimer = 0f;
    [SerializeField] GameObject bananaText;
    private GameObject newTextObject;/*/
    private StepOnBanana stepOnBanana;
    private bool isStepOnBanana;

    bool isCoin = false;
    int CoinNum = 0;
    [SerializeField] LayerMask coinLayer;
    //[SerializeField] UIHealth uiHealth;


    /*/private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Banana"))
        {
            Destroy(other.gameObject);
            isBananaEffectActive = true;
            StartCoroutine(DisableBananaEffect());

            // Instantiate the Text prefab
            newTextObject = Instantiate(bananaText, Vector3.zero, Quaternion.identity);

            // Set the parent of the new text object to be the Canvas (or another UI element)
            newTextObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

            // Access the RectTransform component on the instantiated object
            RectTransform newTextTransform = newTextObject.GetComponent<RectTransform>();

            // Access the Text component on the instantiated object
            Text newTextComponent = newTextObject.GetComponent<Text>();

            if (newTextTransform != null && newTextComponent != null)
            {
                // Customize the RectTransform properties
                newTextTransform.anchoredPosition = new Vector2(0f, -460f);  // Set anchored position
                newTextTransform.sizeDelta = new Vector2(600f, 150f);  // Set size

                // Customize the text properties
                newTextComponent.text = "You slipped on a banana! Wait 10 sec to recovery!";
                newTextComponent.fontSize = 45;
                newTextComponent.fontStyle = FontStyle.Bold;
                newTextComponent.color = Color.red;
            }
            else
            {
                Debug.LogError("Text component not found on the instantiated object.");
            }
        }
    }/*/

    /*/IEnumerator DisableBananaEffect()
    {
        yield return new WaitForSeconds(bananaEffectDuration);
        isBananaEffectActive = false;
        bananaEffectTimer = 0f;
        Destroy(newTextObject);
    }/*/


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        stepOnBanana = GetComponent<StepOnBanana>();

        //uiHealth.CoinNumIncrease(CoinNum);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = true;
            Debug.Log("OnGround");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = false;
            Debug.Log("Not OnGround");
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;

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
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunningSpeed : MovingSpeed;
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
            animator.SetFloat("JumpForce", JumpForce);
        }
    }

    void Update()
    {
        animator.SetFloat("Walking Speed", 0);
        animator.SetFloat("JumpForce", 0);

        isStepOnBanana = stepOnBanana.IsBananaEffectActive();

        if (!isStepOnBanana)
        {
            animator.SetBool("NotBanana", true);
            Move();
            Jump();
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Check for nearby coins and pick them up
                PickUpCoins();
            }
        }
        else
        {
            animator.SetBool("NotBanana", false);
            Debug.Log("Step on banana");
        }

    }
    /*/public bool bumpintobanana()
    {
        return isBananaEffectActive;
    }/*/


    private void PickUpCoins()
    {
        float pickupRadius = 5f;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRadius, coinLayer);

        foreach (var collider in hitColliders)
        {
            // Check if the collider has the "Coin" tag
            if (collider.CompareTag("Coin"))
            {
                // Handle coin pickup logic (e.g., increase score, play sound)
                isCoin = true;
                CoinNum++;
                //uiHealth.CoinNumIncrease(CoinNum);
                Destroy(collider.gameObject);
            }
        }
    }

    public bool IsCoin()
    {
        return isCoin;
    }
}
