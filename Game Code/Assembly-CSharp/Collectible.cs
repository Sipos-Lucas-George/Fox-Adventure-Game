using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class Collectible : MonoBehaviour
{
	// Token: 0x0600000B RID: 11 RVA: 0x000022EC File Offset: 0x000004EC
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player" && !this.isCollected)
		{
			AudioManager.instance.PlaySFX("collect");
			Object.FindObjectOfType<LevelManager>().gemsCollected++;
			this.isCollected = true;
			Object.Destroy(base.gameObject);
			Object.FindObjectOfType<LifeCount>().UpdateGemCount();
		}
	}

	// Token: 0x04000010 RID: 16
	private bool isCollected;
}
