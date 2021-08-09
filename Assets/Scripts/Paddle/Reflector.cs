using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects
{
    /// <summary>
    /// Отражает шар, попадающий в триггер. Угол отражения зависит от относительного положения шара.
    /// </summary>
    public class Reflector : MonoBehaviour
    {
        [Header("Настройки отражения")]
        [Tooltip("Коэффициент силы влияния позиции столкновения с битой на угол отражения")]
        [Range(0, 2)]    // уже при двух часто возникает ситуация практически горизонтального отлета шара, что долго и скучно. 
            [SerializeField] private float hitPositionEffect;

        [Header("Ссылки и внутренние данные")]
        [SerializeField] private UI.TextCounter reflectionCounter;
        
        [Tooltip("Ширина триггера биты")]
            [SerializeField] private float paddleWidth;

        private void Start()
        {
            paddleWidth = Mathf.Abs(paddleWidth);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Paddle trigger activated");
            if (other.CompareTag("Player"))
            {
                other.attachedRigidbody.velocity = Reflect(transform.position.x - other.transform.position.x, other.attachedRigidbody.velocity);
                reflectionCounter.Raise();
                
            }
        }

        /// <summary>
        /// Поворот vector против часовой оси вокруг оси Z  на angle радиан.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private Vector3 Rotate (Vector3 vector, float angle)
        {
            return new Vector3(
                vector.x * Mathf.Cos(angle) + vector.y * Mathf.Sin(angle),
                -vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle),
                vector.z);
        }

        private Vector3 Reflect (float collisionX, Vector3 ballVelocity)
        {
            float angle = -Mathf.Atan(ballVelocity.x / ballVelocity.y);
            angle -= hitPositionEffect * collisionX * 2 / paddleWidth;
            angle = Mathf.Clamp(angle, -Mathf.PI * 0.49f, Mathf.PI * 0.49f);    // ограничение угла отлета шара, в целом, разумно сделать границы сильно уже
            return Rotate(Vector3.up * ballVelocity.magnitude, angle);
        }
    }
}
