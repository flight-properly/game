using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System;
using UnityEngine;

public class SocketManager : MonoBehaviour
{

	private static SocketManager instance;

	TcpClient client;

	string host = "127.0.0.1";
	int port = 12325;
	StreamReader reader;
	bool ready = false;
	NetworkStream stream;

	bool status;
	float pitch;
	float roll;
	float yaw;
	int throttle;

	public static SocketManager getInstance()
	{
		return instance ?? FindObjectOfType<SocketManager>();
	}

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Start()
	{
		connect();
	}

	void Update()
	{
		if (!ready) return;

		if (stream.DataAvailable)
		{
			byte[] recvBuffer = new byte[client.ReceiveBufferSize];
			int bytesRead = stream.Read(recvBuffer, 0, client.ReceiveBufferSize);
			string raw = Encoding.UTF8.GetString(recvBuffer, 0, bytesRead);
			SocketData data = JsonUtility.FromJson<SocketData>(raw);
			status = data.status;
			pitch = data.pitch;
			roll = data.roll;
			yaw = data.yaw;
			throttle = data.throttle;
		}
	}

	void connect()
	{
		if (ready) return;

		try
		{
			client = new TcpClient(host, port);

			if (client.Connected)
			{
				stream = client.GetStream();
				Debug.Log("Connected to the server.");
				ready = true;
			}
		}
		catch (Exception e)
		{
			Debug.LogError("Failed to connect to the server: " + e);
		}
	}

	void OnApplicationQuit()
	{
		close();
	}

	void close()
	{
		if (!ready) return;
		reader.Close();
		client.Close();
		ready = false;
	}

	public bool isReady()
	{
		return ready;
	}

	public bool getStatus()
	{
		return status;
	}

	public float getPitchValue()
	{
		return pitch;
	}

	public float getRollValue()
	{
		return roll;
	}

	public float getYawValue()
	{
		return yaw;
	}

	public int getThrottleValue()
	{
		return throttle;
	}

	[System.Serializable]
	public class SocketData
	{
		public bool status;
		public float pitch;
		public float roll;
		public float yaw;
		public int throttle;
	}
}
