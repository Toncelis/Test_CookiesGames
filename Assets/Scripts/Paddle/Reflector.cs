using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects
{
    /// <summary>
    /// �������� ���, ���������� � �������. ���� ��������� ������� �� �������������� ��������� ����.
    /// </summary>
    public class Reflector : MonoBehaviour
    {
        [Header("��������� ���������")]
        [Tooltip("����������� ���� ������� ������� ������������ � ����� �� ���� ���������")]
        [Range(0, 2)]    // ��� ��� ���� ����� ��������� �������� ����������� ��������������� ������ ����, ��� ����� � ������. 
            [SerializeField] private float hitPositionEffect;

        [Header("������ � ���������� ������")]
        [SerializeField] private UI.TextCounter reflectionCounter;
        
        [Tooltip("������ �������� ����")]
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
        /// ������� vector ������ ������� ��� ������ ��� Z  �� angle ������.
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
            angle = Mathf.Clamp(angle, -Mathf.PI * 0.49f, Mathf.PI * 0.49f);    // ����������� ���� ������ ����, � �����, ������� ������� ������� ������ ���
            return Rotate(Vector3.up * ballVelocity.magnitude, angle);
        }
    }
}
