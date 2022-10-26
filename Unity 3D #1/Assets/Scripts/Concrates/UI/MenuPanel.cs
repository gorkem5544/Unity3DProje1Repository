using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public void StartClick()
    {
        GameManager.Instance.LoadLevelScene(1 );
    }
    public void ExitGame()
    {
        GameManager.Instance.GameExit();
    }
}
