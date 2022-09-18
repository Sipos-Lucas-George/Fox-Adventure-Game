using System;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class PausedMenu : MonoBehaviour
{
	// Token: 0x0600005F RID: 95 RVA: 0x000039B6 File Offset: 0x00001BB6
	private void Start()
	{
	}

	// Token: 0x06000060 RID: 96 RVA: 0x000039B8 File Offset: 0x00001BB8
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			this.PauseUnpause();
		}
	}

	// Token: 0x06000061 RID: 97 RVA: 0x000039CC File Offset: 0x00001BCC
	public void PauseUnpause()
	{
		if (this.isPaused)
		{
			this.isPaused = false;
			this.pauseScreen.SetActive(false);
			Time.timeScale = 1f;
			return;
		}
		this.isPaused = true;
		this.pauseScreen.SetActive(true);
		Time.timeScale = 0f;
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00003A1C File Offset: 0x00001C1C
	public void LevelSelect()
	{
		this.scene.FadeTo(1);
		Time.timeScale = 1f;
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00003A34 File Offset: 0x00001C34
	public void MainMenu()
	{
		this.scene.FadeTo(0);
		Time.timeScale = 1f;
	}

	// Token: 0x0400006E RID: 110
	public SceneFader scene;

	// Token: 0x0400006F RID: 111
	public GameObject pauseScreen;

	// Token: 0x04000070 RID: 112
	public bool isPaused;
}
