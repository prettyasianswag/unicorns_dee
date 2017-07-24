using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
	public GUISkin loginSkin;

	public string username = "Username";
	public string password = "Password";
	public bool showAccountCreation;

	public string createUsername = "Username";
	public string createPassword = "Password";
	public string createConfirmPassword = "Confirm Password";
	public string createEmail = "Email";

	void OnGUI()
	{
		float scrW = Screen.width / 16;
		float scrH = Screen.height / 9;

		GUI.skin = loginSkin;

		if (!showAccountCreation) 
		{
			GUI.Box (new Rect (4.5f * scrW, 4.5f * scrH, 2f * scrW, 0.5f * scrH), "Username");
			GUI.Box (new Rect (4.5f * scrW, 5f * scrH, 2f * scrW, 0.5f * scrH), "Password");
			username = GUI.TextField (new Rect (6.5f * scrW, 4.5f * scrH, 5f * scrW, 0.5f * scrH), username, 15);
			password = GUI.PasswordField (new Rect (6.5f * scrW, 5f * scrH, 5f * scrW, 0.5f * scrH), password, "?" [0], 15);

			if (GUI.Button (new Rect (0.5f * scrW, 8f * scrH, 2f * scrW, 0.75f * scrH), "Create Account")) 
			{
				StartCoroutine (CreateUser(createUsername, createPassword, createEmail));
				showAccountCreation = true;
			}

			if (GUI.Button (new Rect (13.5f * scrW, 8f * scrH, 2f * scrW, 0.75f * scrH), "Exit Game")) 
			{
				Application.Quit ();
			}
		}
		else
		{
			GUI.Box (new Rect (4.5f * scrW, 3.5f * scrH, 2f * scrW, 0.5f * scrH), "Username");
			GUI.Box (new Rect (4.5f * scrW, 4f * scrH, 2f * scrW, 0.5f * scrH), "Password");
			GUI.Box (new Rect (4.5f * scrW, 4.5f * scrH, 2f * scrW, 0.5f * scrH), "Confirm Password");
			GUI.Box (new Rect (4.5f * scrW, 5f * scrH, 2f * scrW, 0.5f * scrH), "Email");
			createUsername = GUI.TextField (new Rect (6.5f * scrW, 3.5f * scrH, 5f * scrW, 0.5f * scrH), createUsername, 15);
			createPassword = GUI.PasswordField (new Rect (6.5f * scrW, 4f * scrH, 5f * scrW, 0.5f * scrH), createPassword, "?" [0], 15);
			createConfirmPassword = GUI.PasswordField (new Rect (6.5f * scrW, 4.5f * scrH, 5f * scrW, 0.5f * scrH), createConfirmPassword, "?" [0], 15);
			createEmail = GUI.TextField (new Rect (6.5f * scrW, 5f * scrH, 5f * scrW, 0.5f * scrH), createEmail, 30);

			if (GUI.Button (new Rect (0.5f * scrW, 8f * scrH, 2f * scrW, 0.75f * scrH), "Back")) 
			{
				showAccountCreation = false;
			}

			if (GUI.Button (new Rect (7f * scrW, 8f * scrH, 2f * scrW, 0.75f * scrH), "Submit")) 
			{
				showAccountCreation = false;
			}

			GUI.skin = loginSkin;
		}			
	}

	IEnumerator CreateUser (string userName, string passWord, string eMail)
	{
		string createUserURL = "localhost/unicorns_dee/InsertUser.php";

		WWWForm userInfo = new WWWForm ();
		userInfo.AddField ("usernamePost", userName);
		userInfo.AddField ("passwordPost", passWord);
		userInfo.AddField ("emailPost", eMail);
		WWW www = new WWW (createUserURL, userInfo);

		yield return www;

		Debug.Log (www.text);
	}
}
