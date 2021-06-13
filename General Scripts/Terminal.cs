using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Terminal : Base
{
    [SerializeField]
    [Tooltip("Set Terminal foundation Collider")]
    Collider _terminalFoundationObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Debug.Log("Enable Teleportation");
        }
    }

    private void ActivateTerminal()
    {

    }
}
