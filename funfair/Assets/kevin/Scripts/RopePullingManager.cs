using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePullingManager : MonoBehaviour
{
    [SerializeField] private int luckyRopeNumber;
    public GameObject chosenObject;

    public List<GameObject> ropes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ChooseRope();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChooseRope()
    {
        luckyRopeNumber = Random.Range(0, 2);
        chosenObject = ropes[luckyRopeNumber];

        Debug.Log(chosenObject.name);
    }
}
