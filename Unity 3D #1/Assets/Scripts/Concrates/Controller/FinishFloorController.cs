using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFloorController : MonoBehaviour
{

    [SerializeField] GameObject _finishEffect;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player == null)
        {
            return;

        }
        if (collision.GetContact(0).normal.y == -1)
        {
            _finishEffect.gameObject.SetActive(true);
            GameManager.Instance.MissionSucces();
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }
}
