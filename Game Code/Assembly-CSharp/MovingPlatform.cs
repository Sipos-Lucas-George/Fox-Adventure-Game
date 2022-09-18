using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000015 RID: 21
public class MovingPlatform : MonoBehaviour
{
	// Token: 0x0600005C RID: 92 RVA: 0x000038DE File Offset: 0x00001ADE
	private void Update()
	{
		this.MoveToTheNextPoint();
	}

	// Token: 0x0600005D RID: 93 RVA: 0x000038E8 File Offset: 0x00001AE8
	private void MoveToTheNextPoint()
	{
		this.platform.position = Vector2.MoveTowards(this.platform.position, this.points[this.goalPoint].position, Time.deltaTime * this.moveSpeed);
		if (Vector2.Distance(this.platform.position, this.points[this.goalPoint].position) < 0.1f)
		{
			if (this.goalPoint == this.points.Count - 1)
			{
				this.goalPoint = 0;
				return;
			}
			this.goalPoint++;
		}
	}

	// Token: 0x0400006A RID: 106
	public List<Transform> points;

	// Token: 0x0400006B RID: 107
	public Transform platform;

	// Token: 0x0400006C RID: 108
	private int goalPoint;

	// Token: 0x0400006D RID: 109
	public float moveSpeed = 2f;
}
