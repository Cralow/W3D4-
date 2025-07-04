using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
   public int maxHealth;
   public int health;

    public Slider slider;
    public Gradient Gradient;
    public Image fill;

    void Start()
    {
        health = maxHealth;
        slider.maxValue =maxHealth;
        slider.value = health;
        fill.color = Gradient.Evaluate(2f);

    }

    public int TakeDamage(int dmg)
    {
        health = health - dmg;
        slider.value = health;
        fill.color = Gradient.Evaluate(slider.normalizedValue);
        return health;
    }

    void Update()
    {

    }
}
