using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class CameraFollow : MonoBehaviour
{
	// Token: 0x06000007 RID: 7 RVA: 0x00002203 File Offset: 0x00000403
	private void FixedUpdate()
	{
		this.Follow();
	}

	// Token: 0x06000008 RID: 8 RVA: 0x0000220C File Offset: 0x0000040C
	private void Follow()
	{
		Vector3 vector = this.target.position + this.offset;
		Vector3 b = new Vector3(Mathf.Clamp(vector.x, this.minValues.x, this.maxValue.x), Mathf.Clamp(vector.y, this.minValues.y, this.maxValue.y), Mathf.Clamp(vector.z, this.minValues.z, this.maxValue.z));
		Vector3 position = Vector3.Lerp(base.transform.position, b, this.smoothFactor * Time.fixedDeltaTime);
		base.transform.position = position;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000022C4 File Offset: 0x000004C4
	public void ResetValues()
	{
		this.setupComplete = false;
		this.minValues = Vector3.zero;
		this.maxValue = Vector3.zero;
	}

	// Token: 0x04000009 RID: 9
	public Transform target;

	// Token: 0x0400000A RID: 10
	public Vector3 offset;

	// Token: 0x0400000B RID: 11
	[Range(1f, 10f)]
	public float smoothFactor;

	// Token: 0x0400000C RID: 12
	[HideInInspector]
	public Vector3 minValues;

	// Token: 0x0400000D RID: 13
	[HideInInspector]
	public Vector3 maxValue;

	// Token: 0x0400000E RID: 14
	[HideInInspector]
	public bool setupComplete;

	// Token: 0x0400000F RID: 15
	[HideInInspector]
	public CameraFollow.SetupState ss;

	// Token: 0x0200001F RID: 31
	public enum SetupState
	{
		// Token: 0x040000D1 RID: 209
		None,
		// Token: 0x040000D2 RID: 210
		Step1,
		// Token: 0x040000D3 RID: 211
		Step2
	}
}
