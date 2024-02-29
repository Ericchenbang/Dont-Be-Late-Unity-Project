using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTrigger : MonoBehaviour
{
    // 定義一個靜態事件，當目的地被觸發時，通知 DestinationManager
    public static event System.Action OnDestinationReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered destination trigger");
            // 碰到玩家時，觸發目的地達成事件
            OnDestinationReached?.Invoke();
            // 停用目前的 Collider，避免多次觸發事件
            gameObject.SetActive(false);
        }
    }
}
