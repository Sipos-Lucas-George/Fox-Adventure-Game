using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000013 RID: 19
public class LifeCount : MonoBehaviour
{
	// Token: 0x06000053 RID: 83 RVA: 0x0000372C File Offset: 0x0000192C
	private void Start()
	{
		this.UpdateGemCount();
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00003734 File Offset: 0x00001934
	private void Update()
	{
		if (this.invincibleCounter > 0f)
		{
			this.invincibleCounter -= Time.deltaTime;
			if (this.invincibleCounter <= 0f)
			{
				this.SR.color = new Color(this.SR.color.r, this.SR.color.g, this.SR.color.b, 1f);
			}
		}
	}

	// Token: 0x06000055 RID: 85 RVA: 0x000037B4 File Offset: 0x000019B4
	public void LoseLife()
	{
		if (this.livesRemaning == 0)
		{
			return;
		}
		if (this.invincibleCounter <= 0f)
		{
			this.livesRemaning--;
			this.lives[this.livesRemaning].enabled = false;
			if (this.livesRemaning == 0)
			{
				Object.FindObjectOfType<Fox>().Die();
				return;
			}
			this.invincibleCounter = this.invincibleLength;
			this.SR.color = new Color(this.SR.color.r, this.SR.color.g, this.SR.color.b, 0.5f);
		}
	}

	// Token: 0x06000056 RID: 86 RVA: 0x0000385F File Offset: 0x00001A5F
	public void AddLife()
	{
		if (this.livesRemaning == 3)
		{
			return;
		}
		this.lives[this.livesRemaning].enabled = true;
		this.livesRemaning++;
	}

	// Token: 0x06000057 RID: 87 RVA: 0x0000388C File Offset: 0x00001A8C
	public void UpdateGemCount()
	{
		this.gemText.text = (Object.FindObjectOfType<LevelManager>().gemsCollected * 10).ToString();
	}

	// Token: 0x04000063 RID: 99
	public Image[] lives;

	// Token: 0x04000064 RID: 100
	public int livesRemaning;

	// Token: 0x04000065 RID: 101
	public float invincibleLength;

	// Token: 0x04000066 RID: 102
	public float invincibleCounter;

	// Token: 0x04000067 RID: 103
	public TextMeshProUGUI gemText;

	// Token: 0x04000068 RID: 104
	public SpriteRenderer SR;
}
