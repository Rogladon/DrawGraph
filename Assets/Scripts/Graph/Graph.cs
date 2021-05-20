using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
namespace DrawGraph.Graph {
    public class Colors: IEnumerable<KeyValuePair<int,Color>> {
        private static Colors instance;
        public static Colors Instance {
			get {
                if(instance == null) {
                    instance = new Colors();
				}
                return instance;
			}
		}
        Dictionary<int, Color> colors = new Dictionary<int, Color> {
            {0,new Color(1,0,0) },
            {1,new Color(0,1,0) },
            {2, new Color(0,0,1) },
            {3, new Color(1,1,0) },
            {4, new Color(1,0,1) },
            {5, new Color(0,1,1) },
            {6, new Color(0,0,0) },
            {7,new Color(1,0.5f,0) },
            {8,new Color(0.5f,1,0) },
            {9, new Color(0.5f,0,1) },
            {10,new Color(1,0,0.5f) },
            {11,new Color(0,1,0.5f) },
            {12, new Color(0,0.5f,1) },
            {13, new Color(1,0.5f,0.5f) },
            {14, new Color(0.5f,1,0.5f) },
            {15, new Color(0.5f,0.5f,1) }
        };

        public Color this[int index] {
			get {
                return colors[index];
			}
		}

		public IEnumerator<KeyValuePair<int, Color>> GetEnumerator() {
			return ((IEnumerable<KeyValuePair<int, Color>>)colors).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IEnumerable)colors).GetEnumerator();
		}
	}

    [System.Serializable]
    public struct SaveGraph {
        public List<SaveNode> nodes;
	}
    public class Graph :IEnumerable<Node> {
        public List<Node> nodes { get; private set; }
        public Node this[int index] {
            get {
                return nodes[index];
            }
            set {
                nodes[index] = value;
            }
        }
        public int Count => nodes.Count;

        public Graph() {
            nodes = new List<Node>();
		}
        public Graph(SaveGraph graph) {
            nodes = graph.nodes.Select(p => new Node(p)).ToList();
		}

        public IEnumerator<Node> GetEnumerator() {
            return ((IEnumerable<Node>)nodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)nodes).GetEnumerator();
        }

        public Node AddNode(Vector2 pos) {
            var node = new Node(pos);
            nodes.Add(node);
            return node;
		}
        public void AddLine(Node node1, Node node2) {
            if (node1.neighbouringNodes.Contains(nodes.IndexOf(node2))) return;
            node1.AddNeibhord(nodes.IndexOf(node2));
            node2.AddNeibhord(nodes.IndexOf(node1));
		}
        public Node GetNode(Vector2 pos, float radius) {
            return nodes.Find(p => Vector2.Distance(p.position, pos) < radius);
		}
        public SaveGraph GetSaveGraph() {
            SaveGraph saveGraph = new SaveGraph();
            nodes.ForEach(p => saveGraph.nodes.Add(p.GetSaveNode()));
            return saveGraph;
		}
		
	}
}