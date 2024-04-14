namespace Trie
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class TrieExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trie"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<string> Autocomplete(this TrieStructure trie, string input)
        {
            var res = new List<string>();
            TrieNode node = trie.Root;

            foreach(char c in input)
            {
                if(node.Children.ContainsKey(c))
                {
                    node = node.Children[c];
                }else
                {
                    return res;
                }
            }
            
            node.GetEndNodes(res);
            return res;
        }

        /// <summary>
        /// Get endpoints of a trie structure from a node.
        /// </summary>
        /// <param name="node">Node to start from</param>
        /// <param name="result">all endpoints</param>
        /// <returns></returns>
        public static List<string> GetEndNodes(this TrieNode node, List<string> result)
        {
            if(node.End)
            {

                result.Add(node.Key);
            }
            else
            {
                foreach(KeyValuePair<char, TrieNode> child in node.Children)
                {
                    child.Value.GetEndNodes(result);
                }
            }
            
            return result;
        }
    }
}