using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        Debug.Log(interactor.gameObject.GetComponent<ActionBasedController>());
        if (interactor is XRDirectInteractor)
        {
            Debug.Log("Climb 1");
            
            ClimbInteractor.controller = interactor.GetComponent<ActionBasedController>();
        }
           
        else
            Debug.LogError("Must be a XR Direct Interactable Controller");
        
    }
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

        if (interactor is XRDirectInteractor)
        {
            if(ClimbInteractor.controller && ClimbInteractor.controller.name == interactor.name)
            {
                ClimbInteractor.controller = null;
            }
        }
    }
}
