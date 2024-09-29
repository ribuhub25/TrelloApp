using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TrelloApp.Resources
{
    
    public static class ToastrExtensions
    {
        public static void AddToastMessage(this ITempDataDictionary tempData, string message, ToastrOptions options = null)
        {
            tempData["toastr"] = new ToastrMessage { Message = message, Options = options ?? new ToastrOptions() };
        }
    }

    public class ToastrMessage
    {
        public string? Message { get; set; }
        public ToastrOptions? Options { get; set; }
    }

    public class ToastrOptions
    {
        // Aquí puedes definir las opciones de Toastr, como tipo, posición, tiempo de espera, etc.
        // Por ejemplo:
        public string? Title { get; set; }
        public string? PositionClass { get; set; }
        public string? TimeOut { get; set; }
        // ... otras opciones ...
    }
}
