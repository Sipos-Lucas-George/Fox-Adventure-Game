using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class DeadPoint : MonoBehaviour
{
	// Token: 0x0600000D RID: 13 RVA: 0x00002358 File Offset: 0x00000558
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Object.FindObjectOfType<LevelManager>().Restart();
		}
	}
}
