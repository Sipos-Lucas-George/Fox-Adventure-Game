using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000019 RID: 25
public class ShootingAction : MonoBehaviour
{
	// Token: 0x0600006D RID: 109 RVA: 0x00003B61 File Offset: 0x00001D61
	public void Action()
	{
		UnityEvent unityEvent = this.action;
		if (unityEvent == null)
		{
			return;
		}
		unityEvent.Invoke();
	}

	// Token: 0x04000078 RID: 120
	public UnityEvent action;
}
