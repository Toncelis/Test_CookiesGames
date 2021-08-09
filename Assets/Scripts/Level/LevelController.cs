using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Ball;

namespace Game.Controllers
{
    /// <summary>
    /// —инглтон, отвечающий за м€гкий перезапуск уровн€ при "смерти" игрока. 
    /// </summary>
    public class LevelController : MonoBehaviour
    {
        #region Singleton
        private static LevelController _instance;
        public static LevelController GetInstance()
        {
            return _instance;
        }
        private void SingletonInit ()
        {
            if (_instance != null)
            {
                Destroy(this);
            }
            else
            {
                Debug.Log("_instance initialisd");
                _instance = this;
            }
        }
        private void Awake()
        {
            SingletonInit();
        }
        #endregion

        [SerializeField] private Ball.Launcher ball;
        [SerializeField] private UI.TextCounter loseCounter;
        [SerializeField] private UI.TextCounter reflectionCounter; 
        public void Lose ()
        {
            loseCounter.Raise();
            reflectionCounter.ResetText();
            ball.PrepareToLaunch();
        }
    }
}
