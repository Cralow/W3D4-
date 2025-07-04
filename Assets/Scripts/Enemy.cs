using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

        public int maxHealth;
        public int health;

        public Slider slider;


        void Start()
        {
            health = maxHealth;
            slider.maxValue = maxHealth;
            slider.value = health;


        }

        public int EnemyTakeDamage(int dmg)
        {
            health = health - dmg;
            slider.value = health;

            return health;
        }


}


