using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DrawGraph.Graph;

namespace DrawGraph {
    public class Draw : MonoBehaviour {
        [SerializeField]
        Transform graphDomain;
        [SerializeField]
        NodeObject point;
        [SerializeField]
        GameObject line;
        [SerializeField]
        float radius;

        public Graph.Graph graph;

        LineRenderer lineRenderer;
        Node currentNode;
        List<NodeObject> nodes = new List<NodeObject>();

        private delegate void MethodUpdate();
        MethodUpdate update; 
		private void Awake() {
            graph = new Graph.Graph();
            update = DefaultUpdate;
		}

		private void Update() {
            update();
		}

        private void DefaultUpdate() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.tag != "Draw") return;
                if (Input.GetMouseButtonDown(0)) {
                    Node node;
                    if ((node = graph.GetNode(hit.point.Vector2(), radius)) == null) {
                        var n = point.Create(graph.AddNode(hit.point.Vector2()));
                        n.transform.SetParent(graphDomain);
                        nodes.Add(n);
                    } else {
                        currentNode = node;
                        lineRenderer = Instantiate(line, graphDomain)
                            .GetComponent<LineRenderer>();
                        lineRenderer.positionCount = 2;
                        lineRenderer.SetPosition(0, node.position.Vector3());
                        update = CreateLine;
                    }
                }
            }
        }

        private void CreateLine() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Node node;
                if ((node = graph.GetNode(hit.point.Vector2(), radius)) == null) {
                    lineRenderer.SetPosition(1, hit.point.Vector2().Vector3());
                } else {
                    lineRenderer.SetPosition(1, node.position.Vector3());
                }
				if (Input.GetMouseButtonUp(0)) {
					if (node == null) {
                        Destroy(lineRenderer.gameObject);
					} else {
                        graph.AddLine(currentNode, node);
					}
                    update = DefaultUpdate;
                }
            }
        }

        public void UpdateColors() {
            foreach(var i in nodes) {
                i.UpdateColor();
			}
		}

        public void Clear() {
            graph = null;
            foreach(Transform t in graphDomain) {
                Destroy(t.gameObject);
			}
            nodes.Clear();
		}
        public void NewDraw(Graph.Graph graph) {
            this.graph = graph;
            foreach(var i in graph) {
                var n = point.Create(i);
                n.transform.SetParent(graphDomain);
                nodes.Add(n);
			}
            foreach(var i in graph) {
                foreach(var j in i.neighbouringNodes) {
                    lineRenderer = Instantiate(line, graphDomain)
                            .GetComponent<LineRenderer>();
                    lineRenderer.positionCount = 2;
                    lineRenderer.SetPosition(0, i.position);
                    lineRenderer.SetPosition(1, graph[j].position);
                }
			}
		}
	}
}
