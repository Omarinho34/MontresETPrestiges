using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MontresETPrestiges
{ 
    /// <summary>
    /// Permet d'accéder aux infos de la DB via le WEB SERVICE
    /// </summary>
    public class Contexte
    {
        public static string urlServiceWeb = "http://localhost/WebServicesMontres"; // LIEN DU WEB SERVICE

        public static HttpClient httpClient = new HttpClient();
        private static JsonSerializerOptions optionJson = new JsonSerializerOptions();

        //public static async Task<Utilisateur?> GetUtilisateur(string email , string pwd)
        //{
        //    Contexte.optionJson.PropertyNameCaseInsensitive = true;
        //    Utilisateur? leUser = null;

        //    string urlAPI = Contexte.urlServiceWeb + "/connexion/"; // A RAJOUTER DANS LE WEB SERVICE
        //    MultipartFormDataContent form = new MultipartFormDataContent();
        //    form.Add(new StringContent(email), name: "user");
        //    form.Add(new StringContent(pwd), name: "mdp");

        //    HttpResponseMessage reponse = await Contexte.httpClient.PostAsync(new Uri(urlAPI), form);
        //    if (reponse.IsSuccessStatusCode)
        //    {
        //        string resultat = await reponse.Content.ReadAsStringAsync();
        //        if (resultat.Contains("false") == false) //Si le résultat ne contient pas la chaine False : il existe un utilisateur
        //        {
        //            JsonSerializerOptions optionJson = new JsonSerializerOptions();
        //            optionJson.PropertyNameCaseInsensitive = true;
        //            leUser = JsonSerializer.Deserialize<Utilisateur>(resultat, optionJson);
        //        }
        //        //Sinon le login et le mot de passe n'existe pas, alors leUser reste null
        //    }
        //    else
        //    {
        //        throw new Exception(); //Lève une exception si la connexion n'a pas aboutie
        //    }
        //    return leUser;
        //}


        public static async Task<List<Montre>?> GetLesMontres(int genre = 0)
        {
            string urlAPI = genre == 0 ? $"{urlServiceWeb}/parGenre/" : $"{urlServiceWeb}/parGenre/{genre}"; 

            HttpResponseMessage resultReq = await Contexte.httpClient.GetAsync(new Uri(urlAPI));
            if(resultReq.IsSuccessStatusCode)
            {
                string content = await resultReq.Content.ReadAsStringAsync();

                JsonSerializerOptions optionsJson = new JsonSerializerOptions();
                optionsJson.PropertyNameCaseInsensitive = true;
                List<Montre>? lesMontres = JsonSerializer.Deserialize<List<Montre>>(content, optionsJson);

                return lesMontres;
            }
            else
            {
                throw new Exception("Erreur lors du chargement des montres" + resultReq.StatusCode.ToString());
            }
        }

        public static async Task<bool> UpdateSeuilMontre(int id, int seuil)
        {
            string urlAPI = $"{urlServiceWeb}/updateSeuil/{id}/{seuil}";

            HttpResponseMessage resultReq = await Contexte.httpClient.GetAsync(new Uri(urlAPI));
            if (resultReq.IsSuccessStatusCode)
            {
                string content = await resultReq.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<Dictionary<string, bool>>(content);

                if (response != null && response.TryGetValue("success", out bool isSuccess))
                {
                    return isSuccess;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static async Task<List<Montre>> GetProduitsReapprovisionnement()
        {
            string urlAPI = $"{urlServiceWeb}/getReaprovisionnement";

            HttpResponseMessage resultReq = await Contexte.httpClient.GetAsync(new Uri(urlAPI));
            if (resultReq.IsSuccessStatusCode)
            {
                string content = await resultReq.Content.ReadAsStringAsync();

                JsonSerializerOptions optionsJson = new JsonSerializerOptions();
                optionsJson.PropertyNameCaseInsensitive = true;
                List<Montre>? lesMontres = JsonSerializer.Deserialize<List<Montre>>(content, optionsJson);

                return lesMontres;
            }
            else
            {
                throw new Exception("Erreur lors du chargement des montres" + resultReq.StatusCode.ToString());
            }
        }

        public static async Task<List<Status>> GetLesStatus(int IdCommande)
        {
            string urlAPI = $"{urlServiceWeb}/getStatus/{IdCommande}";

            HttpResponseMessage resultReq = await Contexte.httpClient.GetAsync(new Uri(urlAPI));
            if (resultReq.IsSuccessStatusCode)
            {
                string content = await resultReq.Content.ReadAsStringAsync();

                JsonSerializerOptions optionsJson = new JsonSerializerOptions();
                optionsJson.PropertyNameCaseInsensitive = true;
                List<Status>? lesStatus = JsonSerializer.Deserialize<List<Status>>(content, optionsJson);

                return lesStatus;
            }
            else
            {
                throw new Exception("Erreur lors du chargement des status" + resultReq.StatusCode.ToString());
            }
        }
    }
}
