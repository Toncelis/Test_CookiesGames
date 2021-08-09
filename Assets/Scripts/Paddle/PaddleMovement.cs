using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects
{
    /// <summary>
    /// Двигает объект вдоль оси х в  соответствии с положением курсора мышки
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PaddleMovement : MonoBehaviour
    {
        Rigidbody myRigidbody;

        [Tooltip("Координатное ограничение на положение биты (от -value до value)")]
        [SerializeField] private float maxXPosition;

        void Start()
        {
            maxXPosition = Mathf.Abs(maxXPosition);
            myRigidbody = GetComponent<Rigidbody>();
        }

        Vector3 _cursorPosition;
        float _xCursor;
        void Update()
        {
            _cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z-Camera.main.transform.position.z);
            _xCursor = Camera.main.ScreenToWorldPoint(_cursorPosition, Camera.MonoOrStereoscopicEye.Mono).x;
            myRigidbody.MovePosition(new Vector3(Mathf.Clamp(_xCursor, -maxXPosition, maxXPosition), transform.position.y, transform.position.z));
        }
    }
}