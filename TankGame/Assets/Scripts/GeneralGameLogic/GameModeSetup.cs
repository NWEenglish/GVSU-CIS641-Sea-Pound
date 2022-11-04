using Assets.Scripts.Helpers;
using Assets.Scripts.Names;
using UnityEngine;

namespace Assets.Scripts.GeneralGameLogic
{
    public class GameModeSetup : MonoBehaviour
    {
        public GameModeType Type;

        void Start()
        {
            GameModeHelper.GameMode = Type;
        }

        void Update()
        {
            if (GameModeHelper.GameMode != Type)
            {
                GameModeHelper.GameMode = Type;
            }
        }
    }
}
