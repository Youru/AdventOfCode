using System.Linq;
using System.Collections.Generic;

namespace Advent2017.Day12
{
    public class Advent
    {
        public Dictionary<int, List<int>> GetNodes(List<string> lines)
        {
            var programGroups = new Dictionary<int, List<int>>();

            foreach (var line in lines)
            {
                var programs = line.Split("<->");
                programGroups[int.Parse(programs[0].Trim())] = programs[1].Split(',').Select(p => int.Parse(p)).ToList();
            }

            return programGroups;
        }

        public List<int> GetNodesInSameGroup(Dictionary<int, List<int>> nodes, int beginningNode)
        {
            var visitedNodes = new List<int>() { beginningNode };
            return GetNeighbourNodes(visitedNodes, nodes[beginningNode], nodes);
        }

        public int GetNumberGroup(Dictionary<int, List<int>> nodes, int beginningNode)
        {
            var numberGroup = 0;
            while (nodes.Any())
            {
                beginningNode = nodes.ContainsKey(beginningNode) ? beginningNode : nodes.First().Key;
                var visitedNodes = new List<int>() { beginningNode };
                numberGroup++;

                visitedNodes = GetNeighbourNodes(visitedNodes, nodes[beginningNode], nodes);
                visitedNodes.ToList().ForEach(nv => nodes.Remove(nv));
            }

            return numberGroup;
        }

        private List<int> GetNeighbourNodes(List<int> visitedNodes, List<int> nodes, Dictionary<int, List<int>> programs)
        {
            foreach (var node in nodes)
            {
                if (IsNodeNotVisited(visitedNodes, node))
                {
                    visitedNodes.Add(node);
                    GetNeighbourNodes(visitedNodes, programs[node], programs);
                }
            }

            return visitedNodes;
        }

        private bool IsNodeNotVisited(List<int> visitedNodes, int node) => !visitedNodes.Contains(node);
    }
}

