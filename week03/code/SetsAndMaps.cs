using System.Diagnostics;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // create list of pairs
        var pairs = new List<string>();

        // create a set to add unique words
        var wordsSet = new HashSet<string>();

        // loop through words (similar to DisplaySums) to see if we already have the transposed word in our set
        foreach (string w in words)
        {
            // transpose w to see if already in set
            var transposedWord = $"{w[1]}{w[0]}";

            // if we do, then add the pairs to the pairs list
            if (wordsSet.Contains(transposedWord))
            {
                pairs.Add($"{w} & {transposedWord}");
            }

            // add word to set
            wordsSet.Add(w);
        }
        
        // convert pairs list to array and return
        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            // get degree
            var degree = fields[3];

            // check if degree is already in degrees
            // if it is, add to total
            if (degrees.ContainsKey(degree))
            {
                degrees[degree] += 1;
            }
            // otherwise, add to degrees with total starting at 1
            else
            {
                degrees.Add(degree, 1);
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // take out spaces from words and make all lowercase for comparison
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // compare length of words, if they are not the same, they cannot be an anagram
        if (word1.Length != word2.Length)
        {
            return false;
        }

        // turn each word into a char array and sort
        char[] word1Array = word1.ToCharArray();
        Array.Sort(word1Array);

        char[] word2Array = word2.ToCharArray();
        Array.Sort(word2Array);

        // create and add word1Array into dictionary1 and word2Array into dictionary2
        Dictionary<int, char> dictionary1 = new Dictionary<int, char>();
        Dictionary<int, char> dictionary2 = new Dictionary<int, char>();
        for (int c = 0; c < word1Array.Length; c++)
        {
            dictionary1.Add(c, word1Array[c]);
            dictionary2.Add(c, word2Array[c]);
        }

        foreach (KeyValuePair<int, char> entry in dictionary1)
        {
            if (entry.Value != dictionary2[entry.Key])
            {
                return false;
            }
        }

        return true;
    }

    public class CharUsed
    {
        public char _character;
        public bool _charUsed;

        public CharUsed(char character, bool charUsed)
        {
            _character = character;
            _charUsed = charUsed;
        }
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}