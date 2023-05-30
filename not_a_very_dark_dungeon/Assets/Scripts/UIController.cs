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
    public void ReadyUI(int y)
    {
        switch (y)
        {
            case 1:
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
                break;

        }
    }

}