using System.Collections.Generic;

namespace FinalProject.Models {
    public static class MenuRepository {
        private static List<MenuResponses> responses = new List<MenuResponses> ();

        public static IEnumerable<MenuResponses> Responses => responses;

        public static void AddResponse(MenuResponses response) {
            responses.Add(response);
        }
    }
}