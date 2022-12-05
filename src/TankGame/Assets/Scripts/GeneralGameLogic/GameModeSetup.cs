using System;
using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using Assets.Scripts.Objective;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GeneralGameLogic
{
    public class GameModeSetup : MonoBehaviour
    {
        public GameModeType GameMode { get; private set; }
        public GameModeObjectives GameModeObjectives { get; private set; }
        public DefenseKillCount DefenseKillCount { get; private set; }

        void Start()
        {
            GameMode = GetGameModeBySceneName();
            GameModeObjectives = new GameModeObjectives(GameMode);

            if (GameMode == GameModeType.Defensive)
            {
                DefenseKillCount = new DefenseKillCount();
            }

            int seed = (int)(new System.Random().NextDouble() * 1000000000);
            UnityEngine.Random.InitState(seed);

            GameObject.Find(HUDNames.Seed).GetComponent<TextMeshProUGUI>().text = $"Seed: {seed}";
        }

        private GameModeType GetGameModeBySceneName()
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case SceneNames.Defense:
                    return GameModeType.Defensive;
                case SceneNames.Offense:
                    return GameModeType.Offensive;
                default:
                    throw new NotImplementedException($"This scene, {SceneManager.GetActiveScene().name}, does not have a game mode type defined.");
            }
        }
    }
}
