using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class LevelLoader : MonoBehaviour
{
	// Token: 0x06000046 RID: 70 RVA: 0x000035E8 File Offset: 0x000017E8
	private void Start()
	{
		this.playerInZone = false;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x000035F1 File Offset: 0x000017F1
	[Obsolete]
	private void Update()
	{
		if (this.playerInZone)
		{
			Application.LoadLevel(this.levelToLoad);
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00003606 File Offset: 0x00001806
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			this.playerInZone = true;
		}
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00003621 File Offset: 0x00001821
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			this.playerInZone = false;
		}
	}

	// Token: 0x04000058 RID: 88
	private bool playerInZone;

	// Token: 0x04000059 RID: 89
	public string levelToLoad;
}
