using Advent2017.Extension;
using System.Linq;
using System;
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

        public Dictionary<int, bool> GetVisitedNodes(Dictionary<int, List<int>> Nodes, int beginningNode)
        {
            var nodeVisited = new Dictionary<int, bool>() { [beginningNode] = true };
            return GetNodesInSameGroupThanParent(nodeVisited, Nodes[beginningNode], Nodes);
        }

        public int GetNumberGroup(Dictionary<int, List<int>> programGroups, int beginningNode)
        {
            var numberGroup = 0;
            while (programGroups.Any())
            {
                numberGroup++;
                var nodesVisited = new Dictionary<int, bool>() { [beginningNode] = true };
                nodesVisited = GetNodesInSameGroupThanParent(nodesVisited, programGroups[nodesVisited.First().Key], programGroups);
                nodesVisited.ToList().ForEach(nv => programGroups.Remove(nv.Key));

                if (programGroups.Any())
                    beginningNode = programGroups.First().Key;

            }

            return numberGroup;
        }

        private Dictionary<int, bool> GetNodesInSameGroupThanParent(Dictionary<int, bool> nodeVisited, List<int> nodes, Dictionary<int, List<int>> programs)
        {
            foreach (var node in nodes)
            {
                if (!nodeVisited.Keys.Contains(node))
                {
                    var IsNeighbourFromSamePath = programs[node].Any(p => nodeVisited.Where(n => n.Value == true).Select(n => n.Key).Contains(p));
                    nodeVisited.Add(node, IsNeighbourFromSamePath);
                    GetNodesInSameGroupThanParent(nodeVisited, programs[node], programs);
                }
            }

            return nodeVisited;
        }
    }
}

