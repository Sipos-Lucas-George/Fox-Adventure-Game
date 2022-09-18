using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class KillSound : MonoBehaviour
{
	// Token: 0x0600003F RID: 63 RVA: 0x0000358E File Offset: 0x0000178E
	private void Start()
	{
		this.source = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000040 RID: 64 RVA: 0x0000359C File Offset: 0x0000179C
	private void Update()
	{
		if (!this.source.isPlaying)
		{
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000057 RID: 87
	private AudioSource source;
}
