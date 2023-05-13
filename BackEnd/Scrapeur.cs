using System.Diagnostics;

namespace BackEnd
{
    public class Scrapeur
    {
        public string nameAccount;

        public Scrapeur(string name)
        {
            nameAccount = name;
        }

        //écrie dans le fichier tweets.json les tweets récupérer
        public void getTweets(int numberOfTweets)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python"; // Chemin vers l'interpréteur Python
            start.Arguments = ".\\GetTweets.py \""+ nameAccount +"\" \""+ numberOfTweets +"\""; // Chemin vers le script Python
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
