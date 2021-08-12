using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DrawGraph.HUD {
	public class HUD : MonoBehaviour {
		[SerializeField] Text chrom;
		public void Save(string path) {
			Main.Instance.Save(path);
		}
		public void New() {
			Main.Instance.New();
		}
		public void Open(string path) {
			Main.Instance.Open(path);
		}
		public void FileButton(Button btn) {
			GameObject content = btn.transform.Find("Content").gameObject;
			if (content.activeSelf) {
				content.SetActive(false);
				btn.Select();
			} else {
				content.SetActive(true);
			}
		}
		public void DrawGraph() {
			Main.Instance.AlgDraw();
			SetChrom();
		}
		public void DeepSerachDraw() {
			Main.Instance.DeepSearchDraw();
			SetChrom();
		}
		public void SetChrom() {
			chrom.text = Main.Instance.GetChrom().ToString();
		}
	}
}
