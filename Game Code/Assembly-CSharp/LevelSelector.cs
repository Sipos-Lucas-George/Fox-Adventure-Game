using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000012 RID: 18
public class LevelSelector : MonoBehaviour
{
	// Token: 0x06000050 RID: 80 RVA: 0x000036CC File Offset: 0x000018CC
	private void Start()
	{
		this.levelReached = PlayerPrefs.GetInt("levelReached", 1);
		for (int i = 0; i < this.levelButtons.Length; i++)
		{
			if (i + 1 > this.levelReached)
			{
				this.levelButtons[i].interactable = false;
			}
		}
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00003716 File Offset: 0x00001916
	public void Select(int lvlIndex)
	{
		this.fader.FadeTo(lvlIndex);
	}

	// Token: 0x04000060 RID: 96
	public SceneFader fader;

	// Token: 0x04000061 RID: 97
	public int levelReached;

	// Token: 0x04000062 RID: 98
	public Button[] levelButtons;
}
