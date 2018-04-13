using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;

public class NetworkController : NetworkManager {

	private Transform spawnPosition; 
	private int playerPrefabIndex = -1;

	public class NetworkMessage : MessageBase {
		public int PlayerPrefab;
	}
		
	public override void OnClientSceneChanged (NetworkConnection conn) {
		NetworkMessage test = new NetworkMessage();
		test.PlayerPrefab = playerPrefabIndex;
		ClientScene.AddPlayer (conn, 0, test);
	}

	public override void OnClientConnect(NetworkConnection conn) {
					
	}
		
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader) {
		NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
		int mes = message.PlayerPrefab;
		if (mes == 0) {
			GameObject player = Instantiate (spawnPrefabs [mes], new Vector3(0f, 2.11f, -8.62f), Quaternion.identity) as GameObject;
			NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
		} else {
			GameObject player = Instantiate (spawnPrefabs [mes], NetworkManager.singleton.GetStartPosition ().position, NetworkManager.singleton.GetStartPosition ().rotation) as GameObject;
			NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
		}
	}

	public void selectPrefab (int ID) {
		playerPrefabIndex = ID;
	}
}