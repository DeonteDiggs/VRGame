using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponsWheel : MonoBehaviour
{
    public Transform rightArmPosition;

    public float offset = 0f;
   public GameObject wheelSlots;

   public CharacterInputActions characterInputActions;

    void Awake(){
        characterInputActions = new CharacterInputActions();
        characterInputActions.XRIRightHand.WeaponWheelEnable.performed += ctx => EnableWeaponsWheel();
        characterInputActions.XRIRightHand.WeaponWheelDisable.performed += ctx => DisableWeaponsWheel();
    }

   void EnableWeaponsWheel(){

       this.transform.localPosition = rightArmPosition.localPosition;
       this.transform.localPosition = new Vector3(this.transform.localPosition.x, 
                                                  this.transform.localPosition.y, 
                                                  this.transform.localPosition.z + offset
                                                  );
       this.transform.localRotation = rightArmPosition.localRotation;
       wheelSlots.SetActive(true);
      
   }
   void DisableWeaponsWheel() =>  wheelSlots.SetActive(false);
    
    private void OnEnable() => characterInputActions.Enable();
    private void OnDisable() => characterInputActions.Disable();

    
}
