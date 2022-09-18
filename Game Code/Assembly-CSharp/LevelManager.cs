using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000011 RID: 17
public class LevelManager : MonoBehaviour
{
	// Token: 0x0600004B RID: 75 RVA: 0x00003644 File Offset: 0x00001844
	private void Start()
	{
		this.playerInitPosition = Object.FindObjectOfType<Fox>().transform.position;
		this.currentLevel = SceneManager.GetActiveScene().buildIndex;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00003680 File Offset: 0x00001880
	public void Restart()
	{
		this.scene.FadeTo(SceneManager.GetActiveScene().buildIndex);
	}

	// Token: 0x0600004D RID: 77 RVA: 0x000036A5 File Offset: 0x000018A5
	public void EndLevel()
	{
		base.StartCoroutine(this.EndLevelCO());
	}

	// Token: 0x0600004E RID: 78 RVA: 0x000036B4 File Offset: 0x000018B4
	public IEnumerator EndLevelCO()
	{
		this.endLVL = true;
		this.completeLVL.SetActive(true);
		yield return new WaitForSeconds(1f);
		PlayerPrefs.SetInt("levelReached", this.currentLevel);
		this.scene.FadeTo(this.currentLevel + 1);
		yield break;
	}

	// Token: 0x0400005A RID: 90
	private Vector2 playerInitPosition;

	// Token: 0x0400005B RID: 91
	public int gemsCollected;

	// Token: 0x0400005C RID: 92
	public bool endLVL;

	// Token: 0x0400005D RID: 93
	public SceneFader scene;

	// Token: 0x0400005E RID: 94
	public GameObject completeLVL;

	// Token: 0x0400005F RID: 95
	private int currentLevel;
}
