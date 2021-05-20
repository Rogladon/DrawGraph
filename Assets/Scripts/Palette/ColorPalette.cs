using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DrawGraph.Graph;

namespace DrawGraph {
	public class ColorPalette : MonoBehaviour{
		[SerializeField] Image img;

		int colorId;
		UnityAction<int> action;
		public void Init(Color color, int colorId, UnityAction<int> action) {
			img.color = color;
			this.colorId = colorId;
			this.action = action;
		}
		public void Click() {
			action(colorId);
		}
	}
}