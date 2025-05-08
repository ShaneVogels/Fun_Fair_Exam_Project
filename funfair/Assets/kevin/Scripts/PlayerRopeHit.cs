using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerRopeHit : MonoBehaviour
{
    [SerializeField] private float rayLenght;

    public GameObject target;
    public GameObject ropeManagerObject;
    public InventoryManager inventoryManager;
    [SerializeField] private GameObject canvas;

    private RopePullingManager rpm;
    [SerializeField] private TMP_Text EndGameText;

    [SerializeField] private string WinText;
    [SerializeField] private string LoseText;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        rpm = ropeManagerObject.GetComponent<RopePullingManager>();
    }
    public void OnSelectRope(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLenght))
        {
                target = hit.collider.gameObject;
                Debug.DrawRay(transform.position, (transform.forward * rayLenght), Color.green);

            
            if (rpm.chosenObject.name == target.name)
            {
                Debug.Log("A winner is you");

                EndGameText.text = WinText;
                canvas.SetActive(true);

                inventoryManager.WinPrize("RopePullPrize");
                Debug.Log("Prize Added");

                target = null;
            }
            if (rpm.chosenObject.name != target.name)
            {
                Debug.Log("You lose");

                EndGameText.text = LoseText;
                canvas.SetActive(true);

                target = null;
                //rpm.ChooseRope();
            }
                //Debug.Log(hit.collider.gameObject.name);
        }
    }
}

