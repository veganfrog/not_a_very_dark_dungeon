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
<<<<<<< HEAD
=======
    private bool isPrefabActive;
    private void Start()
    {
        isPrefabActive = false;
    }

>>>>>>> 28190a5b5c053ed0cd5565da456b2115204f2421
    public void ReadyUI(int y)
    {
        switch (y)
        {
            case 1:
<<<<<<< HEAD
                crusaderAbilities.SetActive(true);
                hwmAbilities.SetActive(false);
                plaguedoctorAbilities.SetActive(false);
                break;
            case 2:
                crusaderAbilities.SetActive(false);
                hwmAbilities.SetActive(true);
                plaguedoctorAbilities.SetActive(false);
                break;
            case 3:
                crusaderAbilities.SetActive(false);
                hwmAbilities.SetActive(false);
                plaguedoctorAbilities.SetActive(true);
=======
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
>>>>>>> 28190a5b5c053ed0cd5565da456b2115204f2421
                break;

        }
    }

}
