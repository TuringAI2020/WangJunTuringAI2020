using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public static class WordAnalysor
    { 

        public static List<KeyValuePair<string, int>> Analyse(string input) {
            var hanziDict = HANZI.GetAllHanZiDict();
            if (!string.IsNullOrWhiteSpace(input)) {


                foreach (var _char in input)
                {
                    if (hanziDict.ContainsKey(_char.ToString()))
                    {
                        hanziDict[_char.ToString()] += 1;
                    }
                }

                for (int k = 1; k < input.Length; k++)
                {
                    var _next_char = input[k];
                    var word = input[k - 1].ToString() + input[k].ToString();
                    if (!hanziDict.ContainsKey(word))
                    {
                        hanziDict.Add(word, 0);
                    }
                    hanziDict[word] += 1;
                }

                for (int k = 2; k < input.Length; k++)
                {
                    var _next_char = input[k];
                    var word = input[k - 2].ToString() + input[k-1].ToString() + input[k].ToString();
                    if (!hanziDict.ContainsKey(word))
                    {
                        hanziDict.Add(word, 0);
                    }
                    hanziDict[word] += 1;
                }

                for (int k = 3; k < input.Length; k++)
                {
                    var _next_char = input[k];
                    var word = input[k - 3].ToString() + input[k - 2].ToString() + input[k - 1].ToString() + input[k].ToString();
                    if (!hanziDict.ContainsKey(word))
                    {
                        hanziDict.Add(word, 0);
                    }
                    hanziDict[word] += 1;
                }

                for (int k = 4; k < input.Length; k++)
                {
                    var _next_char = input[k];
                    var word = input[k - 4].ToString() + input[k - 3].ToString() + input[k - 2].ToString() + input[k - 1].ToString() + input[k].ToString();
                    if (!hanziDict.ContainsKey(word))
                    {
                        hanziDict.Add(word, 0);
                    }
                    hanziDict[word] += 1;
                }

                var word3List = hanziDict.Keys.Where(p => p.Length == 3).ToList();
                word3List.ForEach(p => {
                    var word2pre = p.Substring(0, 2);
                    var word2next = p.Substring(1, 2);
                    if (hanziDict.ContainsKey(p[0].ToString()) && hanziDict.ContainsKey(p[1].ToString()) && hanziDict.ContainsKey(p[2].ToString()) && hanziDict.ContainsKey(word2pre) && hanziDict.ContainsKey(word2next) && hanziDict[word2pre] == hanziDict[word2next] && hanziDict[word2next] == hanziDict[p])
                    {
                        hanziDict.Remove(word2pre);
                        hanziDict.Remove(word2next);
                    }
                });

                var word4List = hanziDict.Keys.Where(p => p.Length == 4).ToList();
                word4List.ForEach(p=> {
                    var word3pre = p.Substring(0, 3);
                    var word3next = p.Substring(1, 3);
                    if (hanziDict.ContainsKey(p[0].ToString()) && hanziDict.ContainsKey(p[1].ToString()) && hanziDict.ContainsKey(p[2].ToString()) && hanziDict.ContainsKey(p[3].ToString()) && hanziDict.ContainsKey(word3pre) && hanziDict.ContainsKey(word3next) && hanziDict[word3pre] == hanziDict[word3next] && hanziDict[word3next] == hanziDict[p])
                    {
                        hanziDict.Remove(word3pre);
                        hanziDict.Remove(word3next);
                    }
                });

            }
            return hanziDict.Where(p => p.Value >1&&2<=p.Key.Length).OrderByDescending(p=>p.Value).ToList();
        }
    }
}
