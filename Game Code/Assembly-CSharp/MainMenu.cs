using System;
using UnityEngine;

// Token: 0x02000014 RID: 20
public class MainMenu : MonoBehaviour
{
	// Token: 0x06000059 RID: 89 RVA: 0x000038C1 File Offset: 0x00001AC1
	public void PlayGame()
	{
		this.scene.FadeTo(1);
	}

	// Token: 0x0600005A RID: 90 RVA: 0x000038CF File Offset: 0x00001ACF
	public void QuitGame()
	{
		Application.Quit();
	}

	// Token: 0x04000069 RID: 105
	public SceneFader scene;
}
