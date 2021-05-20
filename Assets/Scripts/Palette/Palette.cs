using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DrawGraph.Graph;

namespace DrawGraph {
	public class Palette : MonoBehaviour {
		[SerializeField] GameObject palette;
		[SerializeField] Transform colorDomain;
		[SerializeField] ColorPalette colorPalette;
		[SerializeField] RectTransform paletteRect;
		RectTransform canvas;

		UnityAction<int> action;
		Vector2 mousePosition => new Vector2(
			Input.mousePosition.x * (canvas.sizeDelta.x / Screen.width),
			Input.mousePosition.y * (canvas.sizeDelta.y / Screen.height));

		private void Start() {
			foreach (var i in Colors.Instance) {
				Instantiate(colorPalette, colorDomain).Init(i.Value, i.Key, SetColor);
			}
			canvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
			paletteRect = palette.GetComponent<RectTransform>();
		}
		public void ShowPalette(UnityAction<int> action) {
			this.action = action;
			palette.SetActive(true);
			paletteRect.anchoredPosition = mousePosition;
		}
		public void SetColor(int colorId) {
			action(colorId);
			HidePalette();
		}
		public void HidePalette() {
			palette.SetActive(false);
		}
	}
}