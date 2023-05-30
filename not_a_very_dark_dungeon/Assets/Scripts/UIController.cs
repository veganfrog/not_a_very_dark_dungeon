using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject crusaderAbilities;
    public GameObject hwmAbilities;
    public GameObject plaguedoctorAbilities;
    private bool isPrefabActive;
    private void Start()
    {
        isPrefabActive = false;
    }

    public void ReadyUI(int y)
    {
        switch (y)
        {
            case 1:
                isPrefabActive = !isPrefabActive;
                crusaderAbilities.SetActive(isPrefabActive);
         //       hwmAbilities.SetActive(false);
            //    plaguedoctorAbilities.SetActive(false);
                break;
            case 2:
                isPrefabActive = !isPrefabActive;
 
           //     crusaderAbilities.SetActive(false);
               hwmAbilities.SetActive(isPrefabActive);
             //   plaguedoctorAbilities.SetActive(false);
                break;
            case 3:
                isPrefabActive = !isPrefabActive;
 
            //    crusaderAbilities.SetActive(false);
           //     hwmAbilities.SetActive(false);
                plaguedoctorAbilities.SetActive(isPrefabActive);
                break;

        }
    }

}
