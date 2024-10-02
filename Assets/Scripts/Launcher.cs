using Fusion;
using Fusion.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    string roomName = "four";
    NetworkRunner runner;
    NetworkSceneManagerDefault sceneManager;
    private void Start()
    {
        runner??= GetComponent<NetworkRunner>();
        sceneManager??= GetComponent<NetworkSceneManagerDefault>();
        runner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Client,
            SessionName = roomName,
            SceneManager = sceneManager,
            Address = NetAddress.Any()
        });
    }
}
