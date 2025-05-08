using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostGameButtons : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    public GameObject ropeManagerObject;

    private RopePullingManager rpm;
    public void Restart()
    {
        rpm = ropeManagerObject.GetComponent<RopePullingManager>();
        rpm.ChooseRope();

        canvas.SetActive(false);
    }
    public void ReturnToMainArea()
    {
        SceneManager.LoadScene("Kscene");
    }
}
