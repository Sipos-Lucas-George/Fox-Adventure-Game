using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000017 RID: 23
public class SceneFader : MonoBehaviour
{
	// Token: 0x06000065 RID: 101 RVA: 0x00003A54 File Offset: 0x00001C54
	private void Start()
	{
		base.StartCoroutine(this.FadeIn());
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00003A63 File Offset: 0x00001C63
	public void FadeTo(int scene)
	{
		base.StartCoroutine(this.FadeOut(scene));
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00003A73 File Offset: 0x00001C73
	private IEnumerator FadeIn()
	{
		float t = 1f;
		while (t > 0f)
		{
			t -= Time.deltaTime;
			float a = this.curve.Evaluate(t);
			this.img.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
		yield break;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00003A82 File Offset: 0x00001C82
	private IEnumerator FadeOut(int scene)
	{
		float t = 0f;
		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = this.curve.Evaluate(t);
			this.img.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
		SceneManager.LoadScene(scene);
		yield break;
	}

	// Token: 0x04000071 RID: 113
	public Image img;

	// Token: 0x04000072 RID: 114
	public AnimationCurve curve;
}
