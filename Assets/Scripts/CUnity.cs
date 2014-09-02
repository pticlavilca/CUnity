using UnityEngine;
using System.Collections;

public class CUnity : MonoBehaviour {


	private string username="";
	private string password="";
	void OnGUI(){

		username = GUI.TextField (new Rect (0, 0, 200, 35),username );
		password = GUI.TextField (new Rect (0, 40, 200, 35),password);

		if (GUI.Button (new Rect (0, 80, 100, 35), "send")) {
			handlerSend(username,password);
					
		}

	}

	string url = "http://localhost:8080/CJava/CJava?";
	HTTP.Request httpRequest;
	void handlerSend (string _username, string _password)
	{
		httpRequest = new HTTP.Request ("get", url + "username=" + _username + "&password=" + _password);
		httpRequest.Send ();

		while (!httpRequest.isDone) {
			Debug.Log("working ...");
		}	

		string path = httpRequest.response.Text;

		string[] user = path.Split(':');

		Debug.Log ("username :" + user [0]);
		Debug.Log ("password :" + user [1]);
	}
}
