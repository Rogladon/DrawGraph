using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DrawGraph.Graph {
    [System.Serializable]
    public struct SaveNode {
        public Vector2 position;
        public List<int> neighbouringNodes;
        public int color;
    }
    public class Node {
        public Vector2 position { get; private set; }
        public List<int> neighbouringNodes { get; private set; }
        public int color { get; private set; }
		public Node(Vector2 pos) {
            position = pos;
            color = -1;
            neighbouringNodes = new List<int>();
		}
        public Node(SaveNode node) {
            position = node.position;
            color = node.color;
            neighbouringNodes = node.neighbouringNodes;
		}
        public SaveNode GetSaveNode() {
            return new SaveNode {
                color = color,
                position = position,
                neighbouringNodes = neighbouringNodes
            };
		}
        public void AddNeibhord(int indexNode) {
            neighbouringNodes.Add(indexNode);
		}
        public void SetColor(int color) {
            this.color = color;
		}
    }
}
