using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public CharacterInputActions characterInputActions;
    public Animator rightGripAnimation;
    public Animator leftGripAnimation;
    void Awake(){

        characterInputActions = new CharacterInputActions();
        characterInputActions.XRIRightHand.PressGrabObjects.performed += ctx => RightHandGripAnimation();
        characterInputActions.XRIRightHand.RightReleaseObject.performed += ctx => RightHandGripAnimation();
        characterInputActions.XRILeftHand.PressGrabObject.performed += ctx => LeftHandGripAnimation();
        characterInputActions.XRILeftHand.LeftReleaseObject.performed += ctx => LeftHandGripAnimation();
    }

    private void RightHandGripAnimation() { 
        if (characterInputActions.XRIRightHand.PressGrabObjects.triggered)
        {
            rightGripAnimation.SetFloat("Grip", 1.0f);
            
        }
        else 
        {
            rightGripAnimation.SetFloat("Grip", 0.0f);
        }

    }

    private void LeftHandGripAnimation() { 
        if (characterInputActions.XRILeftHand.PressGrabObject.triggered)
        {
            leftGripAnimation.SetFloat("Grip", 1.0f);
            
        }
        else
        {
            leftGripAnimation.SetFloat("Grip", 0.0f);
            
        }
    }
    private void OnEnable() => characterInputActions.Enable();
    private void OnDisable() => characterInputActions.Disable();


}
