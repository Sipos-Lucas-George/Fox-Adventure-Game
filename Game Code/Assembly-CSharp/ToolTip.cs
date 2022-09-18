using System;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class ToolTip : MonoBehaviour
{
	// Token: 0x06000074 RID: 116 RVA: 0x00003CBD File Offset: 0x00001EBD
	private void Update()
	{
		this.toolTip.anchoredPosition = Input.mousePosition;
	}

	// Token: 0x0400007B RID: 123
	public RectTransform toolTip;
}
