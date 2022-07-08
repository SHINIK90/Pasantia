using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Items : MonoBehaviour
{
    private void Awake()
    {
        Enlist();
    }

    [SerializeField] protected string itemName;
    [SerializeField] public float price;
    [SerializeField] protected Image icon;
    [SerializeField] protected string description;

    protected abstract void Enlist();

}
