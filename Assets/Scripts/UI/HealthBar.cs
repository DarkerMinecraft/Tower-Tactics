using System.Collections;
using System.Collections.Generic;
using Tactics.Attributes;
using UnityEngine;

namespace Tactics.UI
{
    public class HealthBar : MonoBehaviour
    {

        [SerializeField]
        private Health health;

        private RectTransform rect;

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
        }

        void Start()
        {

        }

        void Update()
        {
            float healthPercentage = health.GetPercentage();

            if (healthPercentage >= 1)
                transform.parent.GetComponent<Canvas>().enabled = false;
            else transform.parent.GetComponent<Canvas>().enabled = true;

            rect.localScale = new Vector3(healthPercentage, 1, 1);
        }
    }
}
