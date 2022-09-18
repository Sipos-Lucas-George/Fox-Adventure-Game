using System;
using UnityEngine;

// Token: 0x02000018 RID: 24
public class Shooting : MonoBehaviour
{
	// Token: 0x0600006A RID: 106 RVA: 0x00003AA0 File Offset: 0x00001CA0
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return) && Time.time > this.delay)
		{
			this.delay = Time.time + this.fireRate;
			base.gameObject.GetComponent<Animator>().SetBool("Shoot", true);
			AudioManager.instance.PlaySFX("shoot");
			this.Shoot();
			return;
		}
		if (Input.GetKeyUp(KeyCode.Return))
		{
			base.gameObject.GetComponent<Animator>().SetBool("Shoot", false);
		}
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00003B20 File Offset: 0x00001D20
	private void Shoot()
	{
		if (!this.canShoot)
		{
			return;
		}
		Object.Instantiate<GameObject>(this.shootingItem, this.shootingPoint).transform.parent = null;
	}

	// Token: 0x04000073 RID: 115
	public GameObject shootingItem;

	// Token: 0x04000074 RID: 116
	public Transform shootingPoint;

	// Token: 0x04000075 RID: 117
	public bool canShoot = true;

	// Token: 0x04000076 RID: 118
	public float fireRate = 0.5f;

	// Token: 0x04000077 RID: 119
	private float delay;
}
