using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200001E RID: 30
public class UIManagerTech : MonoBehaviour
{
	// Token: 0x0600007A RID: 122 RVA: 0x00003E2E File Offset: 0x0000202E
	public void MoveToFront(GameObject currentObj)
	{
		this.tempParent = currentObj.transform;
		this.tempParent.SetAsLastSibling();
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00003E48 File Offset: 0x00002048
	private void Start()
	{
		this.homeScreen.SetActive(true);
		if (this.newAccountScreen != null)
		{
			this.newAccountScreen.SetActive(false);
		}
		if (this.deleteAccountScreen != null)
		{
			this.deleteAccountScreen.SetActive(false);
		}
		if (this.loginScreen != null)
		{
			this.loginScreen.SetActive(false);
		}
		if (this.databaseScreen != null)
		{
			this.databaseScreen.SetActive(false);
		}
		if (this.creditsScreen != null)
		{
			this.creditsScreen.SetActive(false);
		}
		if (this.systemScreen != null)
		{
			this.systemScreen.SetActive(false);
		}
		if (this.loadingScreen != null)
		{
			this.loadingScreen.SetActive(false);
		}
		if (this.loadGameScreen != null)
		{
			this.loadGameScreen.SetActive(false);
		}
		if (this.newGameScreen != null)
		{
			this.newGameScreen.SetActive(false);
		}
		if (this.advancedMenu)
		{
			this.m_Path = Application.dataPath;
			this.UpdateAccountValues();
		}
		if (this.menuBar != null && !this.showMenuBar)
		{
			this.menuBar.gameObject.SetActive(false);
			this.menuBarButton.gameObject.SetActive(false);
		}
		for (int i = 0; i < this.panelGraphics.Length; i++)
		{
			this.panelGraphics[i].color = this.tint;
		}
		for (int j = 0; j < this.blurs.Length; j++)
		{
			this.blurs[j].material.SetColor("_Color", this.tint);
		}
		this.qualityNames = QualitySettings.names;
		this.resolutions = Screen.resolutions;
		if (this.ResolutionDropDown != null)
		{
			for (int k = 0; k < this.resolutions.Length; k++)
			{
				this.ResolutionDropDown.options.Add(new TMP_Dropdown.OptionData(this.ResToString(this.resolutions[k])));
				this.ResolutionDropDown.value = k;
				this.ResolutionDropDown.onValueChanged.AddListener(delegate(int <p0>)
				{
					Screen.SetResolution(this.resolutions[this.ResolutionDropDown.value].width, this.resolutions[this.ResolutionDropDown.value].height, true);
				});
			}
		}
		if (PlayerPrefs.GetInt("firsttime") == 0)
		{
			PlayerPrefs.SetInt("firsttime", 1);
			PlayerPrefs.SetFloat("volume", 1f);
		}
		if (this.audioSlider != null)
		{
			this.audioSlider.value = PlayerPrefs.GetFloat("volume");
		}
		this.speakersIndex = this.speakersDefault;
		this.subtitleLanguageIndex = this.subtitleLanguageDefault;
		this.textSpeakers.text = this.speakers[this.speakersDefault];
		this.textSubtitleLanguage.text = this.subtitleLanguage[this.subtitleLanguageDefault];
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00004114 File Offset: 0x00002314
	public void IncreaseIndex(int i)
	{
		if (i == 0)
		{
			if (this.speakersIndex != this.speakers.Count - 1)
			{
				this.speakersIndex++;
			}
			else
			{
				this.speakersIndex = 0;
			}
			this.textSpeakers.text = this.speakers[this.speakersIndex];
			return;
		}
		if (i != 1)
		{
			return;
		}
		if (this.subtitleLanguageIndex != this.subtitleLanguage.Count - 1)
		{
			this.subtitleLanguageIndex++;
		}
		else
		{
			this.subtitleLanguageIndex = 0;
		}
		this.textSubtitleLanguage.text = this.subtitleLanguage[this.subtitleLanguageIndex];
	}

	// Token: 0x0600007D RID: 125 RVA: 0x000041BC File Offset: 0x000023BC
	public void DecreaseIndex(int i)
	{
		if (i == 0)
		{
			if (this.speakersIndex == 0)
			{
				this.speakersIndex = this.speakers.Count;
			}
			this.speakersIndex--;
			this.textSpeakers.text = this.speakers[this.speakersIndex];
			return;
		}
		if (i != 1)
		{
			return;
		}
		if (this.subtitleLanguageIndex == 0)
		{
			this.subtitleLanguageIndex = this.subtitleLanguage.Count;
		}
		this.subtitleLanguageIndex--;
		this.textSubtitleLanguage.text = this.subtitleLanguage[this.subtitleLanguageIndex];
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00004258 File Offset: 0x00002458
	public void SetTint()
	{
		for (int i = 0; i < this.panelGraphics.Length; i++)
		{
			this.panelGraphics[i].color = this.tint;
		}
		for (int j = 0; j < this.blurs.Length; j++)
		{
			this.blurs[j].material.SetColor("_Color", this.tint);
		}
	}

	// Token: 0x0600007F RID: 127 RVA: 0x000042BC File Offset: 0x000024BC
	private void Update()
	{
		if (this.reloadSceneButton && Input.GetKeyDown(KeyCode.Delete))
		{
			SceneManager.LoadScene("Tech Demo Scene");
		}
		this.SetTint();
		if (this.showMenuBar)
		{
			DateTime now = DateTime.Now;
			if (this.showTime)
			{
				this.timeDisplay.text = string.Concat(new string[]
				{
					now.Hour.ToString(),
					":",
					now.Minute.ToString(),
					":",
					now.Second.ToString()
				});
			}
			else if (!this.showTime)
			{
				this.timeDisplay.text = "";
			}
			if (this.showDate)
			{
				this.dateDisplay.text = DateTime.Now.ToString("yyyy/MM/dd");
				return;
			}
			if (!this.showDate)
			{
				this.dateDisplay.text = "";
			}
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x000043B7 File Offset: 0x000025B7
	public void MessageDisplayDatabase(string message, Color col)
	{
		base.StartCoroutine(this.MessageDisplay(message, col));
	}

	// Token: 0x06000081 RID: 129 RVA: 0x000043C8 File Offset: 0x000025C8
	private IEnumerator MessageDisplay(string message, Color col)
	{
		this.messageDisplayDatabase.color = col;
		this.messageDisplayDatabase.text = message;
		yield return new WaitForSeconds(this.messageDisplayLength);
		this.messageDisplayDatabase.text = "";
		yield break;
	}

	// Token: 0x06000082 RID: 130 RVA: 0x000043E8 File Offset: 0x000025E8
	public void UIScaler()
	{
		this.xScale = 1920f * this.uiScaleSlider.value;
		this.yScale = 1080f * this.uiScaleSlider.value;
		this.mainCanvas.referenceResolution = new Vector2(this.xScale, this.yScale);
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00004440 File Offset: 0x00002640
	public void CheckSettings()
	{
		this.tempQualityLevel = QualitySettings.GetQualityLevel();
		if (this.tempQualityLevel == 0)
		{
			this.qualityText.text = this.qualityNames[0];
			this.qualityDisplay.SetTrigger("Low");
			return;
		}
		if (this.tempQualityLevel == 1)
		{
			this.qualityText.text = this.qualityNames[1];
			this.qualityDisplay.SetTrigger("Medium");
			return;
		}
		if (this.tempQualityLevel == 2)
		{
			this.qualityText.text = this.qualityNames[2];
			this.qualityDisplay.SetTrigger("High");
			return;
		}
		if (this.tempQualityLevel == 3)
		{
			this.qualityText.text = this.qualityNames[3];
			this.qualityDisplay.SetTrigger("Ultra");
		}
	}

	// Token: 0x06000084 RID: 132 RVA: 0x0000450C File Offset: 0x0000270C
	private string ResToString(Resolution res)
	{
		return res.width.ToString() + " x " + res.height.ToString();
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00004541 File Offset: 0x00002741
	public void AudioSlider()
	{
		AudioListener.volume = this.audioSlider.value;
		PlayerPrefs.SetFloat("volume", this.audioSlider.value);
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00004568 File Offset: 0x00002768
	public void Quit()
	{
		Application.Quit();
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00004570 File Offset: 0x00002770
	public void QualityChange(int x)
	{
		if (x == 0)
		{
			QualitySettings.SetQualityLevel(x, true);
			this.qualityText.text = this.qualityNames[0];
		}
		else if (x == 1)
		{
			QualitySettings.SetQualityLevel(x, true);
			this.qualityText.text = this.qualityNames[1];
		}
		else if (x == 2)
		{
			QualitySettings.SetQualityLevel(x, true);
			this.qualityText.text = this.qualityNames[2];
		}
		if (x == 3)
		{
			QualitySettings.SetQualityLevel(x, true);
			this.qualityText.text = this.qualityNames[3];
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x000045F8 File Offset: 0x000027F8
	public void LoadNewLevel()
	{
		if (this.newSceneName != "")
		{
			base.StartCoroutine(this.LoadAsynchronously(this.newSceneName));
		}
	}

	// Token: 0x06000089 RID: 137 RVA: 0x0000461F File Offset: 0x0000281F
	public void LoadSavedLevel()
	{
		if (this.loadSceneName != "")
		{
			base.StartCoroutine(this.LoadAsynchronously(this.newSceneName));
		}
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00004646 File Offset: 0x00002846
	private IEnumerator LoadAsynchronously(string sceneName)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
		while (!operation.isDone)
		{
			float value = Mathf.Clamp01(operation.progress / 0.9f);
			this.loadingBar.value = value;
			yield return null;
		}
		yield break;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x0000465C File Offset: 0x0000285C
	public void UpdateAccountValues()
	{
		this.Username = this.username.text;
		this.Password = this.password.text;
		this.ConfPassword = this.confPassword.text;
		this.logUsernameString = this.logUsername.text;
		this.logPasswordString = this.logPassword.text;
		this.delUsernameString = this.delUsername.text;
		this.delPasswordString = this.delPassword.text;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x000046E0 File Offset: 0x000028E0
	public void ConfirmNewAccount()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (this.Username != "")
		{
			if (!File.Exists(this.m_Path + "_" + this.Username + ".txt"))
			{
				flag = true;
			}
			else
			{
				this.error_NewAccount.color = this.errorColor;
				this.error_NewAccount.text = "USERNAME ALREADY TAKEN";
			}
		}
		else
		{
			this.error_NewAccount.color = this.errorColor;
			this.error_NewAccount.text = "INVALID USERNAME";
		}
		if (this.Password != "")
		{
			if (this.Password.Length > 5)
			{
				flag2 = true;
			}
			else
			{
				this.error_NewAccount.color = this.errorColor;
				this.error_NewAccount.text = "PASSWORD IS TOO SHORT";
			}
		}
		else
		{
			this.error_NewAccount.color = this.errorColor;
			this.error_NewAccount.text = "INVALID PASSWORD";
		}
		if (this.ConfPassword != "")
		{
			if (this.ConfPassword == this.Password)
			{
				flag3 = true;
			}
			else
			{
				this.error_NewAccount.color = this.errorColor;
				this.error_NewAccount.text = "PASSWORDS MUST MATCH";
			}
		}
		else
		{
			this.error_NewAccount.color = this.errorColor;
			this.error_NewAccount.text = "INVALID PASSWORD";
		}
		if (flag && flag2 && flag3)
		{
			bool flag4 = true;
			int num = 1;
			foreach (int num2 in this.Password)
			{
				if (flag4)
				{
					this.Password = "";
					flag4 = false;
				}
				num++;
				char c = (char)(num2 * num);
				this.Password += c.ToString();
			}
			this.form = this.Username + Environment.NewLine + Environment.NewLine + this.Password;
			File.WriteAllText(this.m_Path + "_" + this.Username + ".txt", this.form);
			this.Username = "";
			this.Password = "";
			this.username.text = "";
			this.password.text = "";
			this.confPassword.text = "";
			this.error_NewAccount.text = "";
			this.DecryptedPass = "";
			this.MessageDisplayDatabase(this.newAccountMessageDisplay, this.successColor);
			MonoBehaviour.print("Registration Complete");
			this.databaseScreen.SetActive(true);
			this.newAccountScreen.SetActive(false);
		}
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00004994 File Offset: 0x00002B94
	public void LoginButton()
	{
		bool flag = false;
		bool flag2 = false;
		if (this.logUsernameString != "")
		{
			if (File.Exists(this.m_Path + "_" + this.logUsernameString + ".txt"))
			{
				flag = true;
				this.Lines = File.ReadAllLines(this.m_Path + "_" + this.logUsernameString + ".txt");
			}
			else
			{
				this.error_LogIn.color = this.errorColor;
				this.error_LogIn.text = "INVALID USERNAME";
			}
		}
		else
		{
			this.error_LogIn.color = this.errorColor;
			this.error_LogIn.text = "PLEASE ENTER USERNAME";
		}
		if (this.logPasswordString != "")
		{
			if (File.Exists(this.m_Path + "_" + this.logUsernameString + ".txt"))
			{
				int num = 1;
				foreach (int num2 in this.Lines[2])
				{
					num++;
					char c = (char)(num2 / num);
					this.DecryptedPass += c.ToString();
				}
				if (this.logPasswordString == this.DecryptedPass)
				{
					flag2 = true;
				}
				else
				{
					this.error_LogIn.color = this.errorColor;
					this.error_LogIn.text = "PASSWORD INCORRECT";
				}
			}
			else
			{
				this.error_LogIn.color = this.errorColor;
				this.error_LogIn.text = "PASSWORD INCORRECT";
			}
		}
		else
		{
			this.error_LogIn.color = this.errorColor;
			this.error_LogIn.text = "PLEASE ENTER PASSWORD";
		}
		if (flag && flag2)
		{
			this.profileDisplay.text = this.logUsernameString;
			this.logUsernameString = "";
			this.logPasswordString = "";
			this.logUsername.text = "";
			this.logPassword.text = "";
			this.error_LogIn.text = "";
			this.DecryptedPass = "";
			this.MessageDisplayDatabase(this.loginMessageDisplay, this.successColor);
			MonoBehaviour.print("Login Successful");
			this.databaseScreen.SetActive(true);
			this.loginScreen.SetActive(false);
		}
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00004BEC File Offset: 0x00002DEC
	public void ConfirmDeleteAccount()
	{
		bool flag = false;
		bool flag2 = false;
		if (this.delUsernameString != "" && this.profileDisplay.text != this.delUsernameString)
		{
			if (File.Exists(this.m_Path + "_" + this.delUsernameString + ".txt"))
			{
				flag = true;
				this.Lines = File.ReadAllLines(this.m_Path + "_" + this.delUsernameString + ".txt");
			}
			else
			{
				this.error_Delete.color = this.errorColor;
				this.error_Delete.text = "INVALID USERNAME";
			}
		}
		else
		{
			this.error_Delete.color = this.errorColor;
			this.error_Delete.text = "ENTER VALID USERNAME";
		}
		if (this.delPasswordString != "")
		{
			if (File.Exists(this.m_Path + "_" + this.delUsernameString + ".txt"))
			{
				int num = 1;
				foreach (int num2 in this.Lines[2])
				{
					num++;
					char c = (char)(num2 / num);
					this.DecryptedPass += c.ToString();
				}
				if (this.delPasswordString == this.DecryptedPass)
				{
					flag2 = true;
				}
				else
				{
					this.error_Delete.color = this.errorColor;
					this.error_Delete.text = "PASSWORD INCORRECT";
				}
			}
			else
			{
				this.error_Delete.color = this.errorColor;
				this.error_Delete.text = "PASSWORD INCORRECT";
			}
		}
		else
		{
			this.error_Delete.color = this.errorColor;
			this.error_Delete.text = "PLEASE ENTER PASSWORD";
		}
		if (flag && flag2)
		{
			File.Delete(this.m_Path + "_" + this.delUsernameString + ".txt");
			this.delUsernameString = "";
			this.delPasswordString = "";
			this.delUsername.text = "";
			this.delPassword.text = "";
			this.error_Delete.text = "";
			this.DecryptedPass = "";
			this.MessageDisplayDatabase(this.deletedMessageDisplay, this.successColor);
			MonoBehaviour.print("Deletion Successful");
			this.deleteAccountScreen.SetActive(false);
			this.databaseScreen.SetActive(true);
		}
	}

	// Token: 0x04000082 RID: 130
	[Header("What Menu Is Active?")]
	public bool simpleMenu;

	// Token: 0x04000083 RID: 131
	public bool advancedMenu = true;

	// Token: 0x04000084 RID: 132
	[Header("Simple Panels")]
	[Tooltip("The UI Panel holding the Home Screen elements")]
	public GameObject homeScreen;

	// Token: 0x04000085 RID: 133
	[Tooltip("The UI Panel holding the credits")]
	public GameObject creditsScreen;

	// Token: 0x04000086 RID: 134
	[Tooltip("The UI Panel holding the settings")]
	public GameObject systemScreen;

	// Token: 0x04000087 RID: 135
	[Tooltip("The UI Panel holding the CANCEL or ACCEPT Options for New Game")]
	public GameObject newGameScreen;

	// Token: 0x04000088 RID: 136
	[Tooltip("The UI Panel holding the YES or NO Options for Load Game")]
	public GameObject loadGameScreen;

	// Token: 0x04000089 RID: 137
	[Tooltip("The Loading Screen holding loading bar")]
	public GameObject loadingScreen;

	// Token: 0x0400008A RID: 138
	[Header("COLORS - Tint")]
	public Image[] panelGraphics;

	// Token: 0x0400008B RID: 139
	public Image[] blurs;

	// Token: 0x0400008C RID: 140
	public Color tint;

	// Token: 0x0400008D RID: 141
	[Header("ADVANDED - Panels")]
	[Tooltip("The UI Panel holding the New Account Screen elements")]
	public GameObject newAccountScreen;

	// Token: 0x0400008E RID: 142
	[Tooltip("The UI Panel holding the Delete Account Screen elements")]
	public GameObject deleteAccountScreen;

	// Token: 0x0400008F RID: 143
	[Tooltip("The UI Panel holding Log-In Buttons")]
	public GameObject loginScreen;

	// Token: 0x04000090 RID: 144
	[Tooltip("The UI Panel holding account and load menu")]
	public GameObject databaseScreen;

	// Token: 0x04000091 RID: 145
	[Tooltip("The UI Menu Bar at the edge of the screen")]
	public GameObject menuBar;

	// Token: 0x04000092 RID: 146
	[Header("ADVANDED - UI Elements & User Data")]
	[Tooltip("The Main Canvas Gameobject")]
	public CanvasScaler mainCanvas;

	// Token: 0x04000093 RID: 147
	[Tooltip("The dropdown menu containing all the resolutions that your game can adapt to")]
	public TMP_Dropdown ResolutionDropDown;

	// Token: 0x04000094 RID: 148
	private Resolution[] resolutions;

	// Token: 0x04000095 RID: 149
	[Tooltip("The text object in the Settings Panel displaying the current quality setting enabled")]
	public TMP_Text qualityText;

	// Token: 0x04000096 RID: 150
	[Tooltip("The icon showing the current quality selected in the Settings Panels")]
	public Animator qualityDisplay;

	// Token: 0x04000097 RID: 151
	private string[] qualityNames;

	// Token: 0x04000098 RID: 152
	private int tempQualityLevel;

	// Token: 0x04000099 RID: 153
	[Tooltip("The volume slider UI element in the Settings Screen")]
	public Slider audioSlider;

	// Token: 0x0400009A RID: 154
	[Tooltip("If a message is displaying indiciating FAILURE, this is the color of that error text")]
	public Color errorColor;

	// Token: 0x0400009B RID: 155
	[Tooltip("If a message is displaying indiciating SUCCESS, this is the color of that success text")]
	public Color successColor;

	// Token: 0x0400009C RID: 156
	public float messageDisplayLength = 2f;

	// Token: 0x0400009D RID: 157
	public Slider uiScaleSlider;

	// Token: 0x0400009E RID: 158
	private float xScale;

	// Token: 0x0400009F RID: 159
	private float yScale;

	// Token: 0x040000A0 RID: 160
	[Header("Menu Bar")]
	public bool showMenuBar = true;

	// Token: 0x040000A1 RID: 161
	[Tooltip("The Arrow at the corner of the screen activating and de-activating the menu bar")]
	public GameObject menuBarButton;

	// Token: 0x040000A2 RID: 162
	[Tooltip("The date and time display text at the bottom of the screen")]
	public TMP_Text dateDisplay;

	// Token: 0x040000A3 RID: 163
	public TMP_Text timeDisplay;

	// Token: 0x040000A4 RID: 164
	public bool showDate = true;

	// Token: 0x040000A5 RID: 165
	public bool showTime = true;

	// Token: 0x040000A6 RID: 166
	[Header("Loading Screen Elements")]
	[Tooltip("The name of the scene loaded when a 'NEW GAME' is started")]
	public string newSceneName;

	// Token: 0x040000A7 RID: 167
	[Tooltip("The loading bar Slider UI element in the Loading Screen")]
	public Slider loadingBar;

	// Token: 0x040000A8 RID: 168
	private string loadSceneName;

	// Token: 0x040000A9 RID: 169
	[Header("Register Account")]
	public TMP_InputField username;

	// Token: 0x040000AA RID: 170
	public TMP_InputField password;

	// Token: 0x040000AB RID: 171
	public TMP_InputField confPassword;

	// Token: 0x040000AC RID: 172
	public TMP_Text error_NewAccount;

	// Token: 0x040000AD RID: 173
	public TMP_Text messageDisplayDatabase;

	// Token: 0x040000AE RID: 174
	public string newAccountMessageDisplay = "ACCOUNT CREATED";

	// Token: 0x040000AF RID: 175
	private string Username;

	// Token: 0x040000B0 RID: 176
	private string Password;

	// Token: 0x040000B1 RID: 177
	private string ConfPassword;

	// Token: 0x040000B2 RID: 178
	private string form;

	// Token: 0x040000B3 RID: 179
	private string m_Path;

	// Token: 0x040000B4 RID: 180
	private string[] Characters = new string[]
	{
		"a",
		"b",
		"c",
		"d",
		"e",
		"f",
		"g",
		"h",
		"i",
		"j",
		"k",
		"l",
		"m",
		"n",
		"o",
		"p",
		"q",
		"r",
		"s",
		"t",
		"u",
		"v",
		"w",
		"x",
		"y",
		"z",
		"A",
		"B",
		"C",
		"D",
		"E",
		"F",
		"G",
		"H",
		"I",
		"J",
		"K",
		"L",
		"M",
		"N",
		"O",
		"P",
		"Q",
		"R",
		"S",
		"T",
		"U",
		"V",
		"W",
		"X",
		"Y",
		"Z",
		"1",
		"2",
		"3",
		"4",
		"5",
		"6",
		"7",
		"8",
		"9",
		"0",
		"_",
		"-"
	};

	// Token: 0x040000B5 RID: 181
	[Header("Login Account")]
	public TMP_InputField logUsername;

	// Token: 0x040000B6 RID: 182
	public TMP_InputField logPassword;

	// Token: 0x040000B7 RID: 183
	private string logUsernameString;

	// Token: 0x040000B8 RID: 184
	private string logPasswordString;

	// Token: 0x040000B9 RID: 185
	private string[] Lines;

	// Token: 0x040000BA RID: 186
	private string DecryptedPass;

	// Token: 0x040000BB RID: 187
	public TMP_Text error_LogIn;

	// Token: 0x040000BC RID: 188
	public TMP_Text profileDisplay;

	// Token: 0x040000BD RID: 189
	public string loginMessageDisplay = "LOGGED IN";

	// Token: 0x040000BE RID: 190
	[Header("Delete Account")]
	public TMP_InputField delUsername;

	// Token: 0x040000BF RID: 191
	public TMP_InputField delPassword;

	// Token: 0x040000C0 RID: 192
	private string delUsernameString;

	// Token: 0x040000C1 RID: 193
	private string delPasswordString;

	// Token: 0x040000C2 RID: 194
	private string[] delLines;

	// Token: 0x040000C3 RID: 195
	private string delDecryptedPass;

	// Token: 0x040000C4 RID: 196
	public TMP_Text error_Delete;

	// Token: 0x040000C5 RID: 197
	public string deletedMessageDisplay = "ACCOUNT DELETED";

	// Token: 0x040000C6 RID: 198
	[Header("Settings Screen")]
	public TMP_Text textSpeakers;

	// Token: 0x040000C7 RID: 199
	public TMP_Text textSubtitleLanguage;

	// Token: 0x040000C8 RID: 200
	public List<string> speakers = new List<string>();

	// Token: 0x040000C9 RID: 201
	public List<string> subtitleLanguage = new List<string>();

	// Token: 0x040000CA RID: 202
	[Header("Starting Options Values")]
	public int speakersDefault;

	// Token: 0x040000CB RID: 203
	public int subtitleLanguageDefault;

	// Token: 0x040000CC RID: 204
	[Header("List Indexing")]
	private int speakersIndex;

	// Token: 0x040000CD RID: 205
	private int subtitleLanguageIndex;

	// Token: 0x040000CE RID: 206
	[Header("Debug")]
	[Tooltip("If this is true, pressing 'R' will reload the scene.")]
	public bool reloadSceneButton = true;

	// Token: 0x040000CF RID: 207
	private Transform tempParent;
}
