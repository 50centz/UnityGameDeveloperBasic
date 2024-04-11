using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// ReSharper disable ParameterTypeCanBeEnumerable.Global
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator

namespace Sample
{
    public static class LessonCollections
    {
        // Основное количество баллов = 10
        // Дополнительное количество баллов = 10

        ///Пример: Изменить знак для всех положительных элементов массива
        public static void InvertPositives(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];
                if (element > 0)
                {
                    array[i] = -element;
                }
            }
        }

        ///Пример: Выделить в список отрицательные элементы из заданного массива
        public static List<int> NegativeList(int[] array)
        {
            List<int> result = new List<int>();
            foreach (int element in array)
            {
                if (element < 0)
                {
                    result.Add(element);
                }
            }

            return result;
        }

        /**
         * Пример
         *
         * Для заданного списка покупок `shoppingList` посчитать его общую стоимость
         * на основе цен из `costs`. В случае неизвестной цены считать, что товар
         * игнорируется.
         */
        public static float ShoppingListCost(List<string> shoppingList, Dictionary<string, int> costs)
        {
            int totalCost = 0;

            foreach (string item in shoppingList)
            {
                if (costs.TryGetValue(item, out int itemCost))
                {
                    totalCost += itemCost;
                }
            }

            return totalCost;
        }

        /**
         * Пример
         *
         * Для набора "имя"-"номер телефона" `phoneBook` оставить только такие пары,
         * для которых телефон начинается с заданного кода страны `countryCode`
         */
        public static void FilterByCountryCode(Dictionary<string, string> phoneBook, string countryCode)
        {
            List<string> namesToRemove = new();

            foreach (var kv in phoneBook)
            {
                string name = kv.Key;
                string phone = kv.Value;

                if (!phone.StartsWith(countryCode))
                {
                    namesToRemove.Add(name);
                }
            }

            foreach (string name in namesToRemove)
            {
                phoneBook.Remove(name);
            }
        }

        /**
         * Простая (1 балл)
         *
         * Рассчитать среднее арифметическое элементов массива. Вернуть 0, если массив пуст.
         */
        public static float Mean(float[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            float total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                total += array[i];
            }
            return total / array.Length;
        }

        /**
         * Простая (1 балл)
         *
         * Центрировать массив, уменьшив каждый элемент на среднее арифметическое всех элементов.
         * Если массив пуст, не делать ничего. Вернуть изменённый массив.
         */
        public static float[] Center(float[] array)
        {
            float average = 0;
            if (array.Length == 0)
            {
                return Array.Empty<float>();
            }

            average = getAverage(array, average);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] -= average;
            }

            return array;
        }

        public static float getAverage(float[] array, float average)
        {
            for (int i = 0; i < array.Length; i++)
            {
                average += array[i];
            }
            return average / array.Length;
        }


        /**
         * Простая (1 балл)
         *
         * Для двух списков людей найти людей, встречающихся в обоих списках.
         * В выходном списке не должно быть повторяющихся элементов,
         * т. е. WhoAreInBoth(new List {"Иван", "Семён, "Марат"}, new List{"Петр", "Марат"}) == new List {"Марат"}
         */
        public static List<string> WhoAreInBoth(List<string> list1, List<string> list2)
        {
            List<string> result = new();

            for (int i = 0; i < list1.Count; i++)
            {
                for (int j = 0; j < list2.Count; j++)
                {
                    if (list1[i].Equals(list2[j]))
                    {
                        result.Add(list1[i]);
                    }
                }

            }

            return result;
        }

        /**
         * Средняя (2 балл)
         *
         * По заданному ассоциативному массиву "студент"-"оценка за экзамен" построить
         * обратно сортированный словарь "оценка за экзамен"-"список студентов с этой оценкой".
         * (т.е вначале должна идти группа студентов с большим балом)
         * 
         * Например:
         *   BuildGrades(new Dictionary { {"Семён", 5}, {"Марат", 3}, {"Михаил", 5}})
         *     => new SortedDictionary { {5, new List {"Семён", "Михаил"}}, {3, new List{"Марат"}}} 
         */
        public static SortedDictionary<int, List<string>> BuildGrades(Dictionary<string, int> grades)
        {
            SortedDictionary<int, List<string>> result = new SortedDictionary<int, List<string>>(
                Comparer<int>.Create(
                    delegate (int x, int y)
                    {
                        return y.CompareTo(x);
                    }));


            foreach (KeyValuePair<string, int> keyValuePair in grades)
            {
                if (result.ContainsKey(keyValuePair.Value))
                {
                    List<string> names = result[keyValuePair.Value];
                    names.Add(keyValuePair.Key);
                }
                else
                {
                    List<string> names = new();
                    names.Add(keyValuePair.Key);
                    result.Add(keyValuePair.Value, names);
                }
            }





            return result;
        }

        private static SortedDictionary<int, List<string>> ReverseDictionary(SortedDictionary<int, List<string>> sortedDictionary)
        {
            SortedDictionary<int, List<string>> tmp = new SortedDictionary<int, List<string>>();
            //sortedDictionary.OrderByDescending(sortedDictionary.Keys);
            return sortedDictionary;
        }

        /**
         * Средняя (2 балла)
         *
         * Объединить два ассоциативных массива `mapA` и `mapB` с парами
         * "имя"-"номер телефона" в итоговый ассоциативный массив, склеивая
         * значения для повторяющихся ключей через запятую.
         * В случае повторяющихся *ключей* значение из mapA должно быть
         * перед значением из mapB.
         *
         * Повторяющиеся *значения* следует добавлять только один раз.
         *
         * Например:
         *   MergePhoneBooks(
         *     new Dictionary {{"Emergency", "112"}, {"Police", "02"}},
         *     new Dictionary {{"Emergency", "911"}, {"Police", "02"}}
         *   ) => new Dictionary {{"Emergency", "112, 911"}, {"Police", "02"}}
         */
        public static Dictionary<string, string> MergePhoneBooks(
            Dictionary<string, string> mapA,
            Dictionary<string, string> mapB
        )
        {
            Dictionary<string, string> result = new();

            result = MergePhoneBookA(mapA, mapB, result);
            result = MergePhoneBookB(mapA, mapB, result);

            return result;
        }


        public static Dictionary<string, string> MergePhoneBookA(
            Dictionary<string, string> mapA,
            Dictionary<string, string> mapB,
            Dictionary<string, string> result
        )
        {

            foreach (KeyValuePair<string, string> keyValue in mapA)
            {
                if (mapB.ContainsKey(keyValue.Key))
                {
                    string tmpA = mapA[keyValue.Key];
                    string tmpB = mapB[keyValue.Key];
                    if (tmpA.Equals(tmpB))
                    {
                        result.Add(keyValue.Key, tmpA);
                    }
                    else
                    {
                        result.Add(keyValue.Key, tmpA + ", " + tmpB);
                    }
                }
                else
                {
                    result.Add(keyValue.Key, keyValue.Value);
                }
            }
            return result;
        }


        public static Dictionary<string, string> MergePhoneBookB(
            Dictionary<string, string> mapA,
            Dictionary<string, string> mapB,
            Dictionary<string, string> result
        )
        {
            foreach (KeyValuePair<string, string> keyValue in mapB)
            {
                if (!mapA.ContainsKey(keyValue.Key))
                {
                    result.Add(keyValue.Key, keyValue.Value);
                }
            }

            return result;
        }



        /**
         * Средняя (2 балла)
         *
         * Найти в заданном списке повторяющиеся элементы и вернуть
         * ассоциативный массив с информацией о числе повторений
         * для каждого повторяющегося элемента.
         * Если элемент встречается только один раз, включать его в результат
         * не следует.
         *
         * Например:
         *   ExtractRepeats(new List {"a", "b", "a"}) => new Dictionary{ {"a", 2}}
         */
        public static Dictionary<string, int> ExtractRepeats(List<string> list)
        {
            int count = 0;

            Dictionary<string, int> result = new();

            if (list.Count == count)
            {
                return result;
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0 + i; j < list.Count; j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        count++;
                    }

                }

                if (!result.ContainsKey(list[i]) && count > 1)
                {
                    result.Add(list[i], count);
                }
                count = 0;
            }

            return result;
        }

        /**
         * Сложная (4 балла)
         *
         * Перевести натуральное число 5000 > n > 0 в римскую систему.
         * Римские цифры: 1 = I, 4 = IV, 5 = V, 9 = IX, 10 = X, 40 = XL, 50 = L,
         * 90 = XC, 100 = C, 400 = CD, 500 = D, 900 = CM, 1000 = M.
         * Например: 23 = XXIII, 44 = XLIV, 100 = C
         */
        public static string Roman(int n)
        {
            string result = "";

            string[] romanNumbers = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] numbers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            int i = 0;

            while (n > 0)
            {
                if (n - numbers[i] >= 0)
                {
                    result += romanNumbers[i];
                    n -= numbers[i];
                }
                else
                {
                    i++;
                }
            }

            return result;
        }

        /**
         * Очень сложная (максимум  6 балла):
         * - рещение методом перебора (2 балла):
         * - рещение методами "Динамического программирования" (6 балла):
         *
         * Входными данными является ассоциативный массив
         * "название сокровища"-"пара (вес сокровища, цена сокровища)"
         * и вместимость вашего рюкзака.
         * Необходимо вернуть множество сокровищ с максимальной суммарной стоимостью,
         * которые вы можете унести в рюкзаке.
         * Примечание.
         * В этом примере Рюкзак 0-1 (англ. 0-1 Knapsack Problem) не более одного экземпляра каждого предмета.
         * Вес сокровища >0; Цена сокровища > 0
         * 
         * Перед решением этой задачи лучше прочитать статью Википедии "Динамическое программирование".
         * 
         * Например:
         *   BagPacking(
         *     new Dictionary { {"Кубок", (500, 2000)}, {"Слиток", (1000, 5000)} },
         *     850
         *   ) => new HashSet{"Кубок"}
         *   BagPacking(
         *     new Dictionary { {"Кубок" to (500, 2000)}, {"Слиток", (1000, 5000)} },
         *     450
         *   ) => new HashSet()
         */
        public static HashSet<string> BagPacking(Dictionary<string, (int weight, int price)> treasures, int capacity)
        {
            HashSet<string> result = new();

            int[] weights = GetWeight(treasures);
            int[] price = GetPrice(treasures);
            string[] names = GetName(treasures);

            int count = weights.Length;


            int[,] table = new int[count + 1, capacity + 1];

            for (int i = 0; i <= count; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        table[i, j] = 0;
                    }
                    else
                    {
                        if (j >= weights[i - 1])
                        {
                            table[i, j] = (int)MathF.Max(table[i - 1, j], table[i - 1, j - weights[i - 1]] + price[i - 1]);
                        }
                        else
                        {
                            table[i, j] = table[i - 1, j];
                        }
                    }
                }
            }

            List<int> list = new List<int>();
            TraceResult(table, weights, count, capacity, list);

            foreach (var item in list)
            {
                result.Add(names[item - 1]);
            }


            return result;
        }


        public static int[] GetWeight(Dictionary<string, (int weight, int price)> treasures)
        {
            int[] weight = new int[treasures.Count];

            int count = 0;

            foreach (KeyValuePair<string, (int, int)> keyValue in treasures)
            {
                weight[count] = keyValue.Value.Item1;
                count++;
            }

            return weight;
        }

        private static int[] GetPrice(Dictionary<string, (int weight, int price)> treasures)
        {
            int[] price = new int[treasures.Count];

            int count = 0;

            foreach (KeyValuePair<string, (int, int)> keyValue in treasures)
            {
                price[count] = keyValue.Value.Item2;
                count++;
            }

            return price;
        }

        private static string[] GetName(Dictionary<string, (int weight, int price)> treasures)
        {
            string[] names = new string[treasures.Count];

            int count = 0;

            foreach (KeyValuePair<string, (int, int)> keyValue in treasures)
            {
                names[count] = keyValue.Key;
                count++;
            }

            return names;
        }

        private static void TraceResult(int[,] table, int[] weight, int count, int capacity, List<int> result)
        {
            if (table[count, capacity] == 0)
            {
                return;
            }

            if (table[count - 1, capacity] == table[count, capacity])
            {
                TraceResult(table, weight, count - 1, capacity, result);
            }
            else
            {
                TraceResult(table, weight, count - 1, capacity - weight[count - 1], result);
                result.Add(count);
            }
        }

    }
}