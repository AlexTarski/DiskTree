using System;
using System.Collections.Generic;
using System.Linq;


namespace DiskTree;
public static class DiskTreeTask
{
    public static List<string> Solve (List<string> input)
    {
        Node directoriesTree = BuildDirectoriesTree(input);
        List<string> result = new ();
        CreateFormattedDirectoriesList(directoriesTree, result);
        return result;
    }

    class Node
    {
        public string DirName { get; }
        public List<Node> Subdirs { get; }

        public Node(string name)
        {
            DirName = name;
            Subdirs = new List<Node>();
        }
    }

    static Node BuildDirectoriesTree(List<string> directoriesPaths)
    {
        var root = new Node("");
        foreach (var directoryPath in directoriesPaths)
        {
            var splitedPath = directoryPath.Split('\\');
            var currentNode = root;
            foreach (var directory in splitedPath)
            {
                var existingSubdirs = currentNode.Subdirs.Find(c => c.DirName == directory);
                if (existingSubdirs == null)
                {
                    var newSubdir = new Node(directory);
                    currentNode.Subdirs.Add(newSubdir);
                    currentNode = newSubdir;
                }
                else
                {
                    currentNode = existingSubdirs;
                }
            }
        }

        return root;
    }

    static void CreateFormattedDirectoriesList(Node node, List<string> directories, int depth = 0)
    {
        foreach (var subdir in node.Subdirs.OrderBy(c => c.DirName, StringComparer.Ordinal))
        {
            directories.Add(new string(' ', depth) + subdir.DirName);
            CreateFormattedDirectoriesList(subdir, directories, depth + 1);
        }
    }
}