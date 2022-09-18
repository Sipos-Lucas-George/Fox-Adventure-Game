using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class DestroyObjectOverTime : MonoBehaviour
{
	// Token: 0x0600000F RID: 15 RVA: 0x0000237E File Offset: 0x0000057E
	private void Update()
	{
		this.lifetime -= Time.deltaTime;
		if (this.lifetime < 0f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000011 RID: 17
	public float lifetime;
}
