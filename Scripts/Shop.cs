using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public static Shop Instance { get; private set; }
    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        }else{ Instance = this;} 
    }

    private Items[] itemsList;


    class EquipmentUpgrade : Item {

    }
    class OfficeUprade : Item {

    }
    class Booster : Item {

    }
    class Contract : Item {
        private float pricePerView;
    }

}