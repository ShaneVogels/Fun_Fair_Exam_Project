using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStand : MonoBehaviour
{
    public string text;
    public string targetScene;
    public virtual void Interact()
    {
        SceneManager.LoadScene(targetScene);
    }
}
