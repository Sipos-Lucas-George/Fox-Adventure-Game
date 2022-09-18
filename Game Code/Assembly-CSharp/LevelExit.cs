using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class LevelExit : MonoBehaviour
{
	// Token: 0x06000042 RID: 66 RVA: 0x000035BE File Offset: 0x000017BE
	private void Start()
	{
	}

	// Token: 0x06000043 RID: 67 RVA: 0x000035C0 File Offset: 0x000017C0
	private void Update()
	{
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000035C2 File Offset: 0x000017C2
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Object.FindObjectOfType<LevelManager>().EndLevel();
		}
	}
}
