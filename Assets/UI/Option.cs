using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public GameObject MenuSet;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            MenuSet.SetActive(true);
    }
}
