using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawGraph {
    public class Algoritm {
        public static void SimpleDraw(ref Graph.Graph graph) {
            foreach(var i in graph) {
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
		}
    }
}
