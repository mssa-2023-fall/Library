using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlizzyServices
{
    public class GlizzyFactsRepository : IGlizzyFacts
    {
        private Dictionary<int, GlizzyFact> glizzyFacts = new Dictionary<int, GlizzyFact>();
        private int _keyIndex = 1;

        public GlizzyFactsRepository()
        {
            glizzyFacts = new Dictionary<int, GlizzyFact>
            {
                {1, fact1 },
                {2, fact2 },
                {3, fact3 }

            };
        }

        GlizzyFact fact1 = new GlizzyFact(1, "Internet", "Origins of the Hotdog are a mystery");
        GlizzyFact fact2 = new GlizzyFact(1, "Wienerschnitzel.com", "Believe it or not, Kids dress up as there are Evil Weiners in the world!");
        GlizzyFact fact3 = new GlizzyFact(1, "TheHotDog.Org", "Americans consume an estimated 20 billion hot dogs each year and 70 million on July 4th alone.");


        public GlizzyFact GetGlizzyFact()
        {
            // Implement logic to retrieve a GlizzyFact from your data source.
            // For example, you can return a random fact from your list of Glizzy facts.
            Random random = new Random();
            int randomIndex = random.Next(glizzyFacts.Count);
            return glizzyFacts[randomIndex];
        }

        public bool AddGlizzyFacts(GlizzyFact fact)
        {
            // Implement logic to add a GlizzyFact to your data source.
            // For example, add the fact to the list.
            glizzyFacts.Add(fact.FactId, fact);

            return true; // You might want to implement error handling and return appropriate results.
        }
    }
}

    /*
    IGlizzyFacts glizzyFactsRepository = new GlizzyFactsRepository();

    // Add a GlizzyFact
    GlizzyFact newFact = new GlizzyFact
    {
        FactId = 4,
        Source = "Example Source",
        Fact = "This is an example Glizzy fact."
    };
    glizzyFactsRepository.AddGlizzyFacts(newFact);

    // Retrieve a GlizzyFact
    GlizzyFact randomFact = glizzyFactsRepository.GetGlizzyFact();
    Console.WriteLine($"Fact ID: {randomFact.FactId}");
    Console.WriteLine($"Source: {randomFact.Source}");
    Console.WriteLine($"Fact: {randomFact.Fact}");
    */
