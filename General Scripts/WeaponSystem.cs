using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    
    
    public List<GameObject> rightArmWeapons;
    public List<GameObject> leftArmWeapons;
    

    

    void RightArmWeaponSwap(){
        
        rightArmWeapons[0].SetActive(true);
    }
    void LeftArmWeaponSwap(){
        
        leftArmWeapons[0].SetActive(true);
    }


}
