using DeepMorphy;
using DeepMorphy.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практики;

namespace Programs
{
    internal class Practice8 : SubProgram
    {
        //Текст более 700 строк. В каждом предложении посчитать части речи. Вывести статистику по предложениям и посчитать самые встречающиеся слова по корню.
        public Practice8(History history) : base("p8", history, new Listeners()
        {
            ["order"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count < 1)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\norder <string>");
                }
                if (command.Arguments.Count > 1)
                {
                    throw new CommandExeption("Слишком много аргументов");
                }
                var words = command.Arguments[0].Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                var ordered = words.OrderBy(x => x).ToList();
                Console.WriteLine($"Отсортированная строка:\n{string.Join(" ", ordered)}");
            },
            ["stat"] = delegate (Command command, History hist)
            {
                var path = Path.GetFullPath("./../../") + "Utils\\MediumText.txt";
                using (var stream = new StreamReader(path))
                {
                    var morph = new MorphAnalyzer(withLemmatization: true, maxBatchSize: 100000);

                    var allText = stream.ReadToEnd();
                    var allWords = allText.Split(new char[] { '.', '!', '?', ':', ';', ' ', ',', '\"', '\'', '\n', '\r', '\t', '—' }, StringSplitOptions.RemoveEmptyEntries);
                    var sentenses = allText.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    //var results = morph.Parse(allWords).ToArray();
                    //var morphInfo = results[0];
                    //Console.WriteLine(String.Join("\n", morphInfo["чр"].Grams));
                    List<uint> columnWidths = new List<uint>() { 4 };
                    List<string> postNames = new List<string>() {
                        "част",
                        "нареч",
                        "прил",
                        "сущ",
                        "комп",
                        "кр_прил",
                        "гл",
                        "инф_гл",
                        "деепр",
                        "кр_прич",
                        "прич ",
                    };
                    foreach (var postName in postNames)
                    {
                        columnWidths.Add((uint)postName.Length);
                    }
                    List<List<string>> postValues = new List<List<string>>();
                    for (int i = 0; i < sentenses.Length; i++)
                    {
                        var words = sentenses[i].Split(new char[] { '.', '!', '?', ':', ';', ' ', ',', '\"', '\'', '\n', '\r', '\t', '—' }, StringSplitOptions.RemoveEmptyEntries);
                        var results = morph.Parse(words).ToArray();
                        if (results.Length == 0)
                        {
                            continue;
                        }
                        var morphInfo = results[0];
                        var morphGrams = morphInfo["чр"].Grams.ToDictionary<Gram, string, double>(gram => gram.Key, gram => gram.Power);
                        var row = new List<string>() { (i + 1).ToString() };
                        foreach (var postName in postNames)
                        {
                            double power;
                            if (!morphGrams.TryGetValue(postName, out power))
                            {
                                power = 0;
                            }
                            row.Add(((int)(power * words.Length)).ToString());
                        }
                        postValues.Add(row);
                    }
                    postNames.Insert(0, "№ пр");
                    ConsoleTable.makeTable(columnWidths, postNames, postValues);

                    
                }
            }
        })
        { }
    }
}
