using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staff : MonoBehaviour {

    public static Staff Instance { get; private set; }
    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        }else{ Instance = this;} 
    }

    private Personel[] staffList;
    private Hire[] staffList;

}