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

namespace SourceParser.TestAlgoritms.Tests
{
    public class NNTest
    {
        public async void Test()
        {
            var doc = new Document(Data.Link, Language.Russian);

            Storage.Current = new OnlineRepositoryStorage(new DiskStorage("catalyst-models"));
            var nlp = Pipeline.For(Language.Russian);
            nlp.ProcessSingle(doc);
            Console.WriteLine(doc.ToJson());
            PrintDocumentEntities(doc);
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
            await DemonstrateAveragePerceptronEntityRecognizerAndPatternSpotter();
            DemonstrateSpotter();
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
