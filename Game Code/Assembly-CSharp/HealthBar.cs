using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000A RID: 10
public class HealthBar : MonoBehaviour
{
	// Token: 0x0600002B RID: 43 RVA: 0x00003174 File Offset: 0x00001374
	public void LoseHealth(int value)
	{
		if (this.health <= 0f)
		{
			return;
		}
		this.health -= (float)value;
		this.fillBar.fillAmount = this.health / 100f;
		if (this.health <= 0f)
		{
			Object.FindObjectOfType<Fox>().Die();
		}
	}

	// Token: 0x0400003F RID: 63
	public Image fillBar;

	// Token: 0x04000040 RID: 64
	public float health;
}
