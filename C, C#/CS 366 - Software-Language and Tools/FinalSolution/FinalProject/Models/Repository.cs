using System.Collections.Generic;

namespace FinalProject.Models {
    public static class Repository {
        private static List<Responses> responses = new List<Responses> ();

        public static IEnumerable<Responses> Responses => responses;

        public static void AddResponse(Responses response) {
            responses.Add(response);
        }
    }
}