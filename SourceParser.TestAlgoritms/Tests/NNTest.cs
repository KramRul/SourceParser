using Catalyst;
using Catalyst.Models;
using Mosaik.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Version = Mosaik.Core.Version;
using P = Catalyst.PatternUnitPrototype;
using System.Linq;
using Numpy;
using Keras.Models;
using Keras.Layers;
using System.IO;
using Keras;
using Keras.Callbacks;
using MatplotlibCS;
using MatplotlibCS.PlotItems;
using Keras.Utils;
using Deedle;
using Keras.PreProcessing.Text;
using Keras.PreProcessing.sequence;
using Accord.MachineLearning;
using OxyPlot;
using OxyPlot.Axes;

namespace SourceParser.TestAlgoritms.Tests
{
    public static class FrequencyDictionary
    {
        public static Dictionary<string, int> Learn(string[][] tokens)
        {
            var allTokens = tokens.SelectMany(item => item);

            var groupedTokens = allTokens.GroupBy(token => token);

            var dictionary = groupedTokens.Select(groupItem => new KeyValuePair<string, int>(groupItem.Key, groupItem.Count())).OrderByDescending(pair => pair.Value).ToList();

            var dictionaryLikeIMDB = new Dictionary<string, int>();
            for (int index = 0; index < dictionary.Count; index++)
            {
                dictionaryLikeIMDB.Add(dictionary[index].Key, index + 1);
            }

            return dictionaryLikeIMDB;
        }

        public static int[][] Transform(string[][] tokens, Dictionary<string, int> dictionaryLikeIMDB)
        {
            var bow = tokens.Select(tokenString => tokenString.Select(token =>
            {
                var exist = dictionaryLikeIMDB.TryGetValue(token, out int value);
                if (exist)
                {
                    return value;
                }
                else
                {
                    return dictionaryLikeIMDB.Count;
                }
            }).ToArray()).ToArray();
            return bow;
        }
    }

    public class NNTest
    {
        public async void Test()
        {
            // Максимальное количество слов 
            var num_words = 10000;
            // Максимальная длина новости
            var max_news_len = 100;//100
            // Количество классов новостей
            var nb_classes = 12;//3

            var trainCsvPath = "D:\\УНИВЕР\\6 КУРС\\МАГ РАБОТА\\Базы со ссылками\\train.csv";

            var testCsvPath = "D:\\УНИВЕР\\6 КУРС\\МАГ РАБОТА\\Базы со ссылками\\test.csv";

            var (history_gru, model, dictionary) = this.LearnNeuralNetwork(trainCsvPath, num_words, max_news_len, nb_classes);

            this.BuildPlot(history_gru);

            this.TestNeuralNetwork(testCsvPath, nb_classes, dictionary, max_news_len);

            var testCSV = Frame.ReadCsv(testCsvPath, false, separators: ";");
            var testXString = testCSV.Rows.Select(kvp => { return kvp.Value.GetAs<string>("Column2"); }).ValuesAll.ToList();
            var testXStringArray = testXString.ToArray();

            /*foreach (var text in testXStringArray)
            {
                this.Predict(text, codebook, max_news_len);
            }*/
            Console.ReadLine();
        }

        private (History, Sequential, Dictionary<string, int>) LearnNeuralNetwork(string trainCsvPath, int num_words, int max_news_len, int nb_classes)
        {
            NDarray x_train = null;
            NDarray y_train = null;

            var trainCSV = Frame.ReadCsv(trainCsvPath, false, separators: ";");
            var trainYFloat = trainCSV.Rows.Select(kvp => { return kvp.Value.GetAs<float>("Column1"); }).ValuesAll.ToList();
            var trainXString = trainCSV.Rows.Select(kvp => { return kvp.Value.GetAs<string>("Column2"); }).ValuesAll.ToList();
            var trainXStringArray = trainXString.ToArray();

            //x_train = np.array(new float[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } });
            y_train = np.array(trainYFloat.ToArray());

            y_train = Util.ToCategorical(y_train, nb_classes);

            string[][] tokens = trainXStringArray.Tokenize();

            var dictionaryLikeIMDB = FrequencyDictionary.Learn(tokens);

            var bow = FrequencyDictionary.Transform(tokens, dictionaryLikeIMDB);

            // Create a new TF-IDF with options:
            /*var codebook = new Accord.MachineLearning.TFIDF()
            {
                Tf = TermFrequency.Log,
                Idf = InverseDocumentFrequency.Default
            };

            codebook.Learn(tokens);

            double[][] bow = codebook.Transform(tokens);*/

            var list = new List<NDarray>();
            foreach (var item in bow)
            {
                //var newItem = item.Take(max_news_len).ToArray();
                //var ndarray = np.array(newItem);
                var ndarray = np.array(item);
                list.Add(ndarray);
            }

            var sequences = np.array(list);

            //x_train = SequenceUtil.PadSequences(sequences, maxlen: max_news_len, dtype: "double");
            x_train = SequenceUtil.PadSequences(sequences, maxlen: max_news_len);

            var model = new Sequential();
            model.Add(new Embedding(num_words, 32, null, null, null, null, false, max_news_len));
            model.Add(new GRU(138));//16
            model.Add(new Dense(12, activation: "softmax"));

            model.Compile(optimizer: "adam", loss: "categorical_crossentropy", metrics: new string[] { "accuracy" });

            model.Summary();

            var model_gru_save_path = "best_model_gru.h5";
            var checkpoint_callback_gru = new ModelCheckpoint(
                model_gru_save_path,
                "val_accuracy",
                1,
                true
                );

            var callbacks = new List<Callback>() { checkpoint_callback_gru };

            float validation_split = (float)0.1;

            var history_gru = model.Fit(x_train,
                              y_train,
                              batch_size: 128,
                              epochs: 10,
                              validation_split: validation_split,
                              callbacks: callbacks.ToArray());

            //Save model and weights
            string json = model.ToJson();
            File.WriteAllText("model.json", json);

            return (history_gru, model, dictionaryLikeIMDB);
        }

        private void BuildPlot(History history_gru)
        {
            //Доля верных ответов на обучающем наборе
            var accuracy_y = history_gru.HistoryLogs["accuracy"];
            var accuracy_x = accuracy_y.Select((val, index) => { return index; });

            //Доля верных ответов на проверочном наборе
            var val_accuracy_y = history_gru.HistoryLogs["val_accuracy"];
            var val_accuracy_x = val_accuracy_y.Select((val, index) => { return index; });

            int pointCount = 10;
            double[] xs1 = accuracy_x.Select<int, double>(i => i).ToArray();
            double[] ys1 = accuracy_y;
            double[] xs2 = val_accuracy_x.Select<int, double>(i => i).ToArray();
            double[] ys2 = val_accuracy_y;

            // create lines and fill them with data points
            var line1 = new OxyPlot.Series.LineSeries()
            {
                Title = $"Доля верных ответов на обучающем наборе",
                Color = OxyPlot.OxyColors.Blue,
                StrokeThickness = 1,
                MarkerSize = 2,
                MarkerType = OxyPlot.MarkerType.Circle
            };

            var line2 = new OxyPlot.Series.LineSeries()
            {
                Title = $"Доля верных ответов на проверочном наборе",
                Color = OxyPlot.OxyColors.Red,
                StrokeThickness = 1,
                MarkerSize = 2,
                MarkerType = OxyPlot.MarkerType.Circle
            };

            for (int i = 0; i < pointCount; i++)
            {
                line1.Points.Add(new OxyPlot.DataPoint(xs1[i], ys1[i]));
                line2.Points.Add(new OxyPlot.DataPoint(xs2[i], ys2[i]));
            }

            // create the model and add the lines to it
            var plotModel = new OxyPlot.PlotModel
            {
                Title = $"Scatter Plot ({pointCount:N0} points each)"
            };

            plotModel.LegendPosition = LegendPosition.LeftBottom;

            plotModel.Series.Add(line1);
            plotModel.Series.Add(line2);

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Эпоха обучения" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Доля верных ответов" });

            using (var stream = File.Create("C:\\Users\\KramRul\\Documents\\GitHub\\SourceParser\\SourceParser.TestAlgoritms\\plot.svg"))
            {
                var exporter = new SvgExporter { Width = 600, Height = 400 };
                exporter.Export(plotModel, stream);
            }
        }

        private void TestNeuralNetwork(string testCsvPath, int nb_classes, Dictionary<string, int> dictionaryLikeIMDB, int max_news_len)
        {
            NDarray x_test = null;
            NDarray y_test = null;

            var testCSV = Frame.ReadCsv(testCsvPath, false, separators: ";");
            var testYFloat = testCSV.Rows.Select(kvp => { return kvp.Value.GetAs<float>("Column1"); }).ValuesAll.ToList();
            var testXString = testCSV.Rows.Select(kvp => { return kvp.Value.GetAs<string>("Column2"); }).ValuesAll.ToList();
            var testXStringArray = testXString.ToArray();

            y_test = np.array(testYFloat.ToArray());

            y_test = Util.ToCategorical(y_test, nb_classes);

            string[][] tokens_test = testXStringArray.Tokenize();

            int[][] bow_test = FrequencyDictionary.Transform(tokens_test, dictionaryLikeIMDB);
            //double[][] bow_test = codebook.Transform(tokens_test);

            var list_test = new List<NDarray>();
            foreach (var item in bow_test)
            {
                //var newItem = item.Take(100).ToArray();
                //var ndarray = np.array(newItem);
                var ndarray = np.array(item);
                list_test.Add(ndarray);
            }

            var sequences_test = np.array(list_test);

            x_test = SequenceUtil.PadSequences(sequences_test, maxlen: max_news_len);

            //Load model and weight
            var loaded_model = Sequential.ModelFromJson(File.ReadAllText("model.json"));
            loaded_model.LoadWeight("best_model_gru.h5");

            loaded_model.Compile(optimizer: "adam", loss: "categorical_crossentropy", metrics: new string[] { "accuracy" });
            loaded_model.Summary();

            var scores = loaded_model.Evaluate(x_test, y_test, verbose: 0);
            Console.WriteLine("Test loss:" + scores[0] * 100);
            Console.WriteLine("Test accuracy:" + scores[1] * 100);
        }

        public void Predict(string text, Accord.MachineLearning.TFIDF codebook, int max_news_len)
        {
            var model = Sequential.LoadModel("best_model_gru.h5");
            string result = "";

            string[] words = TextUtil.TextToWordSequence(text);
            double[] tokens = codebook.Transform(words);
            var newItem = tokens.Where(value => value != 0).ToArray();
            NDarray x = np.array(newItem);
            x = x.reshape(1, x.shape[0]);
            x = SequenceUtil.PadSequences(x, maxlen: max_news_len, dtype: "double");

            var y = model.Predict(x);
            Console.WriteLine(y.str);
        }

        private void Old()
        {
            //NDarray x = np.array(new float[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } });
            //NDarray y = np.array(new float[] { 0, 1, 1, 0 });

            ////Build sequential model
            //var model = new Sequential();
            //model.Add(new Dense(32, activation: "relu", input_shape: new Shape(2)));
            //model.Add(new Dense(64, activation: "relu"));
            //model.Add(new Dense(1, activation: "sigmoid"));

            ////Compile and train
            //model.Compile(optimizer: "sgd", loss: "binary_crossentropy", metrics: new string[] { "accuracy" });
            //model.Fit(x, y, batch_size: 2, epochs: 1000, verbose: 1);

            ////Save model and weights
            //string json = model.ToJson();
            //File.WriteAllText("model.json", json);
            //model.SaveWeight("model.h5");

            ////Load model and weight
            //var loaded_model = Sequential.ModelFromJson(File.ReadAllText("model.json"));
            //loaded_model.LoadWeight("model.h5");



            /*var doc = new Document(Data.Link, Language.Russian);

            Storage.Current = new OnlineRepositoryStorage(new DiskStorage("catalyst-models"));
            var nlp = Pipeline.For(Language.Russian);
            nlp.ProcessSingle(doc);
            Console.WriteLine(doc.ToJson());
            PrintDocumentEntities(doc);*/
            /*var nlp1 = Pipeline.For(Language.English);
            var ft = new FastText(Language.English, 0, "wiki-word2vec");
            ft.Data.Type = FastText.ModelType.CBow;
            ft.Data.Loss = FastText.LossType.NegativeSampling;
            var docs = new List<Document>()
            {
                doc
            };
            ft.Train(nlp1.Process(docs));
            await ft.StoreAsync();*/
            /*await DemonstrateAveragePerceptronEntityRecognizerAndPatternSpotter();
            DemonstrateSpotter();*/
        }

        private static async Task DemonstrateAveragePerceptronEntityRecognizerAndPatternSpotter()
        {
            // For training an AveragePerceptronModel, check the source-code here: https://github.com/curiosity-ai/catalyst/blob/master/Catalyst.Training/src/TrainWikiNER.cs
            // This example uses the pre-trained WikiNER model, trained on the data provided by the paper "Learning multilingual named entity recognition from Wikipedia", Artificial Intelligence 194 (DOI: 10.1016/j.artint.2012.03.006)
            // The training data was sourced from the following repository: https://github.com/dice-group/FOX/tree/master/input/Wikiner

            //Configures the model storage to use the online repository backed by the local folder ./catalyst-models/
            Storage.Current = new OnlineRepositoryStorage(new DiskStorage("catalyst-models"));

            //Create a new pipeline for the english language, and add the WikiNER model to it
            Console.WriteLine("Loading models... This might take a bit longer the first time you run this sample, as the models have to be downloaded from the online repository");
            var nlp = Pipeline.For(Language.Russian);
            // nlp.Add(await AveragePerceptronEntityRecognizer.FromStoreAsync(language: Language.English, version: Mosaik.Core.Version.Latest, tag: "WikiNER"));

            //Another available model for NER is the PatternSpotter, which is the conceptual equivalent of a RegEx on raw text, but operating on the tokenized form off the text.
            //Adds a custom pattern spotter for the pattern: single("is" / VERB) + multiple(NOUN/AUX/PROPN/AUX/DET/ADJ)
            /*var isApattern = new PatternSpotter(Language.English, 0, tag: "is-a-pattern", captureTag: "IsA");
            isApattern.NewPattern(
                "Is+Noun",
                mp => mp.Add(
                    new PatternUnit(P.Single().WithToken("is").WithPOS(PartOfSpeech.VERB)),
                    new PatternUnit(P.Multiple().WithPOS(PartOfSpeech.NOUN, PartOfSpeech.PROPN, PartOfSpeech.AUX, PartOfSpeech.DET, PartOfSpeech.ADJ))
            ));
            nlp.Add(isApattern);*/

            //For processing a single document, you can call nlp.ProcessSingle
            var doc = new Document(Data.Link, Language.Russian);
            nlp.ProcessSingle(doc);

            //For processing a multiple documents in parallel (i.e. multithreading), you can call nlp.Process on an IEnumerable<IDocument> enumerable
            //var docs = nlp.Process(MultipleDocuments());

            //This will print all recognized entities. You can also see how the WikiNER model makes a mistake on recognizing Amazon as a location on Data.Sample_1
            PrintDocumentEntities(doc);
            //foreach (var d in docs) { PrintDocumentEntities(d); }

            //For correcting Entity Recognition mistakes, you can use the Neuralyzer class. 
            //This class uses the Pattern Matching entity recognition class to perform "forget-entity" and "add-entity" 
            //passes on the document, after it has been processed by all other proceses in the NLP pipeline
            var neuralizer = new Neuralyzer(Language.English, 0, "WikiNER-sample-fixes");

            //Teach the Neuralyzer class to forget the match for a single token "Amazon" with entity type "Location"
            neuralizer.TeachForgetPattern("Location", "Amazon", mp => mp.Add(new PatternUnit(P.Single().WithToken("Amazon").WithEntityType("Location"))));

            //Teach the Neuralyzer class to add the entity type Organization for a match for the single token "Amazon"
            neuralizer.TeachAddPattern("Organization", "Amazon", mp => mp.Add(new PatternUnit(P.Single().WithToken("Amazon"))));

            //Add the Neuralyzer to the pipeline
            nlp.UseNeuralyzer(neuralizer);

            //Now you can see that "Amazon" is correctly recognized as the entity type "Organization"
            var doc2 = new Document(Data.Sample_1, Language.English);
            nlp.ProcessSingle(doc2);
            PrintDocumentEntities(doc2);
        }

        private static void DemonstrateSpotter()
        {
            //Another way to perform entity recognition is to use a gazeteer-like model. For example, here is one for capturing a set of programing languages
            var spotter = new Spotter(Language.Any, 0, "programming", "ProgrammingLanguage");
            spotter.Data.IgnoreCase = true; //In some cases, it might be better to set it to false, and only add upper/lower-case exceptions as required

            spotter.AddEntry("C#");
            spotter.AddEntry("Python");
            spotter.AddEntry("Python 3"); //entries can have more than one word, and will be automatically tokenized on whitespace
            spotter.AddEntry("C++");
            spotter.AddEntry("Rust");
            spotter.AddEntry("Java");

            var nlp = Pipeline.TokenizerFor(Language.English);
            nlp.Add(spotter); //When adding a spotter model, the model propagates any exceptions on tokenization to the pipeline's tokenizer

            var docAboutProgramming = new Document(Data.SampleProgramming, Language.English);

            nlp.ProcessSingle(docAboutProgramming);

            PrintDocumentEntities(docAboutProgramming);
        }

        private static void PrintDocumentEntities(IDocument doc)
        {
            Console.WriteLine($"Input text:\n\t'{doc.Value}'\n\nTokenized Value:\n\t'{doc.TokenizedValue(mergeEntities: true)}'\n\nEntities: \n{string.Join("\n", doc.SelectMany(span => span.GetEntities()).Select(e => $"\t{e.Value} [{e.EntityType.Type}]"))}");
        }

        static IEnumerable<IDocument> MultipleDocuments()
        {
            yield return new Document(Data.Sample_2, Language.English);
            yield return new Document(Data.Sample_3, Language.English);
            yield return new Document(Data.Sample_4, Language.English);
        }
    }

    public static class Data
    {
        public const string Link = "Белов, А. В. Финансы и кредит [Текст] : учеб. / А. В. Белов, В. Н. Николаев ; КНУ им. Т. Г. Шевченко. – К. : Университет, 2004. – 215 с. – Библиогр. : с. 213–215. – ISBN 5-7042-1441-Х.";
        public const string Sample_1 = "Google LLC is an American multinational technology company that specializes in internet-related services and products, which include online advertising technologies, search engine, cloud computing, software, and hardware. It is considered one of the Big Four technology companies, alongside Amazon, Apple, and Facebook.Google was founded in September 1998 by Larry Page and Sergey Brin while they were Ph.D. students at Stanford University in California.";
        public const string Sample_2 = "Berlin is the capital and largest city of Germany by both area and population. Its 3,748,148 (2018) inhabitants make it the second most populous city proper of the European Union after London.";
        public const string Sample_3 = "Microsoft is an American multinational technology company with headquarters in Redmond, Washington.";
        public const string Sample_4 = "Munich is the capital and most populous city of Bavaria, the second most populous German federal state.";
        public const string SampleProgramming = "Being the descendant of C and with its code compiled, C++ excels such languages as Python, C#, or any interpreted language. In terms of Rust vs. C++, Rust is frequently proclaimed to be faster than C++ due to its unique components.";
    }
}
