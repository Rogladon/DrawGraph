using System.Collections;
using UnityEngine;

namespace DrawGraph.Graph {
	public class NodeObject : MonoBehaviour {
		[SerializeField]
		SpriteRenderer spriteRenderer;
		private Node node;

		public NodeObject Create(Node node) {
			NodeObject nodeObj = Instantiate(this);
			nodeObj.node = node;
			nodeObj.transform.position = node.position.Vector3();
			return nodeObj;
		}

		public void UpdateColor() {
			spriteRenderer.color = Colors.Instance[node.color];
		}
	}
}