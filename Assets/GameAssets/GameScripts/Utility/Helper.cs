using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameScripts.Utility
{
    public static class Helper 
    {
        private static readonly Dictionary<float, WaitForSeconds> WfsDictionary = new();
        
        public static WaitForSeconds GetWaitForSeconds(float time)
        {
            if (WfsDictionary.TryGetValue(time, out var wait)) return wait;

            WfsDictionary[time] = new WaitForSeconds(time);
            return WfsDictionary[time];
        }

        #region List
        public static T GetRandomElementFromList<T>(List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
        
        public static List<T> GetRandomListWithUniqueElements<T>(List<T> list, int numberOfElements)
        {
            List<T> result = new();
            List<T> tempList = new(list);
            numberOfElements = Mathf.Min(numberOfElements, tempList.Count);
            while (result.Count < numberOfElements)
            {
                int randomIndex = Random.Range(0, tempList.Count);
                T randomElement = tempList[randomIndex];
                result.Add(randomElement);
                tempList.RemoveAt(randomIndex);
            }
            return result;
        }
        
        public static void AddElements<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
        }
        #endregion
        
        #region String
        public static string[] SplitString(string input, string splitter)
        {
            return input.Split(new string[] { splitter }, System.StringSplitOptions.None);
        }

        public static string CapitalizeFirstCharacter(string input)
        {
            string capitalizedText = char.ToUpper(input[0]) + input[1..].ToLower();
            return capitalizedText;
        }

        public static string ProperNameStandardization(string name)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(name.ToLower());
        }

        public static string ConvertPascalCaseEnumToString<T>(T enumValue) where T : Enum
        {
            string enumString = enumValue.ToString();
            string displayString = Regex.Replace(enumString, "([a-z])([A-Z])", "$1 $2");
            return displayString;
        }
        #endregion
    }
}

