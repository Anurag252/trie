public class Trie {

    Dictionary<char , Trie> hs;
    public bool endshere = false;
    /** Initialize your data structure here. */
    public Trie() {
       hs = new Dictionary<char , Trie>();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        
        
        
        if(word != "" && hs.ContainsKey(word[0]))            
        {
            if(word.Length == 1)
            {
                 hs[word[0]].endshere = true;
                 hs[word[0]].Insert(word.Substring(1));
            }
            else
            {
                 hs[word[0]].Insert(word.Substring(1));
            }
           
        }
        else
        {
            if(word!= "")
            {
                if(word.Length != 1)
                {
                    var t = new Trie();
                    hs.Add(word[0],t);
                    t.Insert(word.Substring(1));
                }
                else
                {
                    var t = new Trie();
                    t.endshere = true;
                    hs.Add(word[0],t);
                    t.Insert(word.Substring(1));
                }
                
                
            }
        }
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        
        if(word.Length == 1)
        {
            return hs.ContainsKey(word[0]) && hs[word[0]].endshere;
        }
        
        if(word != "" && hs.ContainsKey(word[0]))            
        {
           return hs[word[0]].Search(word.Substring(1));
        }
        else
        {
            return false;
        }
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string word) {
         if(word.Length == 1)
        {
            return hs.ContainsKey(word[0]);
        }
        
        if(word != "" && hs.ContainsKey(word[0]))            
        {
           return hs[word[0]].StartsWith(word.Substring(1));
        }
        else
        {
            return false;
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
