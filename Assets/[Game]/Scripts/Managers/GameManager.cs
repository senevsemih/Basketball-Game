using _Game_.Scripts.Court.Rim;
using UnityEngine;

namespace _Game_.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public RimController RimController { get; private set; }
        public void SetRimController(RimController rimController) => RimController = rimController;
    }
}