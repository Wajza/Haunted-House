using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace StealthGame
{
    public class MainMenu : MonoBehaviour
    {
        private UIDocument m_UIDocument;

        private Button m_StartButton;
        private Button m_ExitButton;
    
        private void Awake()
        {
            m_UIDocument = GetComponent<UIDocument>();
        }

        private void OnEnable()
        {
            m_StartButton = m_UIDocument.rootVisualElement.Q<Button>("StartButton");
            m_ExitButton = m_UIDocument.rootVisualElement.Q<Button>("ExitButton");

            m_StartButton.clicked += () =>
            {
                SceneManager.LoadScene(1);
            };

            m_ExitButton.clicked += () =>
            {
                Time.timeScale = 0;

                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #elif UNITY_WEBGL
                Debug.Log("Game Quit triggered in WebGL browser window.");
                #else
                Application.Quit();
                #endif
            };
        }
    }
}
