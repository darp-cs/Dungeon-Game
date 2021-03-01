using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager health;
    public Slider healthBar;

    public Text hp;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.currHealth;
        hp.text = "HP: " + health.currHealth + "/" + health.maxHealth;
    }
}
