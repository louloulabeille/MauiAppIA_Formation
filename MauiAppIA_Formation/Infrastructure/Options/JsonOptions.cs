using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MauiAppIA_Formation.Infrastructure.Options
{
    public static class JsonOptions
    {
        /// <summary>
        /// méthode qui retourne les options lors de la déserialization d'un json, notamment pour ignorer la casse des propriétés
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerOptions GetJsonOptions()
        {
            JsonSerializerOptions option = new()
            {
                PropertyNameCaseInsensitive = true,
            };

            return option;
        }

    }
}
