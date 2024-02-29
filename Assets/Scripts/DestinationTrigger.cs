using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTrigger : MonoBehaviour
{
    // �w�q�@���R�A�ƥ�A��ت��a�QĲ�o�ɡA�q�� DestinationManager
    public static event System.Action OnDestinationReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered destination trigger");
            // �I�쪱�a�ɡAĲ�o�ت��a�F���ƥ�
            OnDestinationReached?.Invoke();
            // ���Υثe�� Collider�A�קK�h��Ĳ�o�ƥ�
            gameObject.SetActive(false);
        }
    }
}
