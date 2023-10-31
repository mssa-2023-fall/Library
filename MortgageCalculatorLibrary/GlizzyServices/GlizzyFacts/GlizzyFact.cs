using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlizzyServices.GlizzyFacts
{
    public class GlizzyFactsRepository : IGlizzyFacts
    {
        private Dictionary<int, GlizzyFact> glizzyFacts = new Dictionary<int, GlizzyFact>();
        

        public GlizzyFactsRepository()
        {
            glizzyFacts = new Dictionary<int, GlizzyFact>
            {
                {0, fact1 },
                {1, fact2 },
                {2, fact3 }

            };
        }

        GlizzyFact fact1 = new GlizzyFact(1, "Internet", "Origins of the Hotdog are a mystery");
        GlizzyFact fact2 = new GlizzyFact(2, "Wienerschnitzel.com", "Believe it or not, Kids dress up as an Evil Weiner on Halloween!");
        GlizzyFact fact3 = new GlizzyFact(3, "TheHotDog.Org", "Americans consume an estimated 20 billion hot dogs each year and 70 million on July 4th alone.");


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

