using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text LifeDisplay;
    public int count;
    public UnitDetails Health;
    public UnitDetails UnitDetails;
    public GameObject Unit;

    void Start()
    {
        Health = Unit.GetComponent<UnitDetails>();
    }

    // Update is called once per frame
    void Update()
    {
        count = Health.hp;
        LifeDisplay.text = count.ToString();
    }
}
