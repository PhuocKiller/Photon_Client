using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientInputForCube : NetworkBehaviour, INetworkRunnerCallbacks
{
    public struct CubeInput: INetworkInput
    {
        public const byte A = 0x01;
        public uint AKey;
        public uint BKey;
        public const uint B = 1;
    }
    Vector2 inputDiretion;
    CubeInput cubeInput = new CubeInput();
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
       if (inputDiretion==Vector2.left)
        {
            cubeInput.AKey |= CubeInput.A;
        }
       if (inputDiretion==Vector2.right)
        {
            cubeInput.BKey =  CubeInput.B <<1;
        }
        input.Set(cubeInput);
        cubeInput.AKey = 0x00;
        cubeInput.BKey = 0x01;
    }
    #region
    public void OnConnectedToServer(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        throw new NotImplementedException();
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        throw new NotImplementedException();
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        throw new NotImplementedException();
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        throw new NotImplementedException();
    }

    

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        throw new NotImplementedException();
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        throw new NotImplementedException();
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        throw new NotImplementedException();
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        throw new NotImplementedException();
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        throw new NotImplementedException();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDiretion = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    public override void Spawned()
    {
        base.Spawned();
        if (Object.IsValid)
        {
            Runner.AddCallbacks(this);
        }

    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        if (Object.IsValid)
        {
            Runner.RemoveCallbacks(this);
        }
        base.Despawned(runner, hasState);
    }
}
