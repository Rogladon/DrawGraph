using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DrawGraph.Graph;
using System.IO;

namespace DrawGraph {
	public class Main : MonoBehaviour {
		public static Main Instance { get; private set; }
		[SerializeField]
		Draw draw;

		Graph.Graph graph => draw.graph;
		private void Awake() {
			Instance = this;
		}
		public void AlgDraw() {
			Algoritm.SimpleDraw(ref draw.graph);
			draw.UpdateColors();
		}
		public void New() {
			draw.Clear();
		}
		public void Save(string path) {
			StreamWriter stream = new StreamWriter(path);
			string json = JsonUtility.ToJson(graph.GetSaveGraph());
			stream.Write(json);
		}
		public void Open(string path) {
			StreamReader stream = new StreamReader(path);
			string json = stream.ReadToEnd();
			Graph.Graph graph = new Graph.Graph(JsonUtility.FromJson<SaveGraph>(json)); 
			draw.Clear();
			draw.NewDraw(graph);
		}
	}
}
