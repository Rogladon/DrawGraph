using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DrawGraph {
    public class Algoritm {
        public static Graph.Graph SimpleDraw(Graph.Graph graph) {
            foreach (var i in graph) {
                i.SetColor(-1);
			}
            int color = 0;
            int count = graph.Count;
            int id = 0;
            while(count > 0 || id > 100) {
                foreach(var i in graph) {
                    if (i.color != -1) continue;
                    bool draw = true;
                    foreach(var j in i.neighbouringNodes) {
                        if (color == graph[j].color) {
                            draw = false;
                            break;
                        }
					}
                    if (draw) {
                        i.SetColor(color);
                        count--;
                    }
                }
                id++;
                color++;
			}
            return graph;
		}
        public static Graph.Graph DeepSearchDraw(Graph.Graph graph) {
            foreach (var i in graph) {
                i.SetColor(-1);
            }
            Graph.Node node = graph.nodes[0];
            Stack<Graph.Node> nodes = new Stack<Graph.Node>();
            Stack<Graph.Node> neighbouringNodes = new Stack<Graph.Node>();
            node.SetColor(0);
            nodes.Push(node);
            node.neighbouringNodes.ForEach(p => neighbouringNodes.Push(graph[p]));
            var colors = Graph.Colors.Instance.keys;

            while(neighbouringNodes.Count != 0) {
                node = neighbouringNodes.Pop();
                if (nodes.Contains(node)) continue;
                nodes.Push(node);
                node.SetColor(colors.First(p => !node.neighbouringNodes.Select(c => graph[c].color).Contains(p)));
                neighbouringNodes.Clear();
                node.neighbouringNodes.ForEach(p => neighbouringNodes.Push(graph[p]));
            }
            return graph;
		}
    }
}
