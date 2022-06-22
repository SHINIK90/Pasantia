using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaFinanzas : MonoBehaviour {

    public static SistemaFinanzas Instance { get; private set; }
    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        }else{ Instance = this;} 
    }
    
    public GameObject s;
    public float money;
    private Earnings earningsManager = new Earnings();
    private Expenses expenseManager = new Expenses();

    public class Earnings{

        private Contract[] currentContracts;
        private float moneyCollector;
        public void EpEarnings(float audience, float ppv, float rating){
            moneyCollector += audience*ppv*rating;
        }
        public void updateMoney(){
            money += moneyCollector;
        }
    }
    public class Expenses{
        Shop shop = Shop.Instance;
        Staff staff = Staff.Instance;
        private float spenceCollector;

        public void updateMoney(){
            money -= spenceCollector;
        }
    }

}