using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    /// <summary>
    /// Методы взаимодействия с текстовым полем, служащим для демонстрации  целочисленных значений. Позволяет менять значение и восстанавливать базовое.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class TextCounter : MonoBehaviour
    {
        [SerializeField] private int baseValue;

        private Text text;

        private void Start()
        {
            text = GetComponent<Text>();
            text.text = $"{baseValue}";
        }

        public void Raise(int raisingValue = 1)
        {
            int value;
            if (int.TryParse(text.text, out value))
            {
                text.text = $"{value + raisingValue}";
                return;
            }

            Debug.LogError($"Nonparsable value in {text.name}\n \t{text.text}");
        }

        public void ResetText()
        {
            text.text = $"{baseValue}";
        }
    }
}
