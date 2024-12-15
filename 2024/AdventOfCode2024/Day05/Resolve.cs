namespace AdventOfCode2024.Day05
{
    static public partial class RegexHelper
    {
    }
    public class Resolve
    {
        public int GetMiddlePageSummed(List<string> list)
        {
            int count = 0;

            var orderPagesConfiguration = GetOrderPagesConfiguration(list.Where(l => l.Contains('|')));
            List<List<int>> validPageOrder = GetValidOrderPage(orderPagesConfiguration, list.Where(l => l.Contains(',')));
            count = validPageOrder.Sum(v => v[(v.Count - 1) / 2]);

            return count;
        }
        public int GetUnorderedMiddlePageSummed(List<string> list)
        {
            int count = 0;

            var orderPagesConfiguration = GetOrderPagesConfiguration(list.Where(l => l.Contains('|')));
            List<List<int>> PageUnorder = GetUnOrderPage(orderPagesConfiguration, list.Where(l => l.Contains(',')));
            List<List<int>> validPageOrdered = GetOrderedPage(orderPagesConfiguration, PageUnorder);
            count = validPageOrdered.Sum(v => v[(v.Count - 1) / 2]);

            return count;
        }


        private Dictionary<int, Dictionary<int, Order>> GetOrderPagesConfiguration(IEnumerable<string> list)
        {
            Dictionary<int, Dictionary<int, Order>> orderPage = [];

            foreach (var page in list)
            {
                var numbers = page.Split('|').Select(int.Parse).ToList();
                SetValue(numbers[0], numbers[1], Order.After);
                SetValue(numbers[1], numbers[0], Order.Before);
            }


            return orderPage;

            void SetValue(int page, int pageDependencies, Order order)
            {
                var orderPageValue = orderPage.TryGetValue(page, out var page1) ? page1 : new();
                orderPageValue.Add(pageDependencies, order);
                orderPage[page] = orderPageValue;
            }
        }

        private List<List<int>> GetUnOrderPage(Dictionary<int, Dictionary<int, Order>> orderPagesConfiguration, IEnumerable<string> list)
        {
            List<List<int>> unOrderPage = [];
            foreach (var line in list)
            {
                bool isUnOrdered = false;
                var numbers = line.Split(',').Select(int.Parse).ToList();
                for (int i = 0; i < numbers.Count; i++)
                {
                    var nextNumbers = numbers[(i + 1)..];
                    foreach (var number in nextNumbers)
                        if (orderPagesConfiguration[numbers[i]][number] is not Order.After)
                            isUnOrdered = true;
                    if (isUnOrdered == true) break;
                }
                if (isUnOrdered)
                    unOrderPage.Add(numbers);
            }

            return unOrderPage;
        }
        private List<List<int>> GetValidOrderPage(Dictionary<int, Dictionary<int, Order>> orderPagesConfiguration, IEnumerable<string> list)
        {
            List<List<int>> validOrderPage = [];
            foreach (var line in list)
            {
                bool isOrdered = true;
                var numbers = line.Split(',').Select(int.Parse).ToList();
                for (int i = 0; i < numbers.Count; i++)
                {
                    var nextNumbers = numbers[(i + 1)..];
                    foreach (var number in nextNumbers)
                        if (orderPagesConfiguration[numbers[i]][number] is not Order.After)
                            isOrdered = false;
                    if (isOrdered == false) break;
                }
                if (isOrdered)
                    validOrderPage.Add(numbers);
            }

            return validOrderPage;
        }
        private List<List<int>> GetOrderedPage(Dictionary<int, Dictionary<int, Order>> orderPagesConfiguration, List<List<int>> pageUnorder)
        {
            List<List<int>> orderedPages = [];
            foreach (var line in pageUnorder)
            {
                List<int> nextNumbers = line[..];
                List<int> orderedPage = [];
                int index = 1;

                while (ControlList(orderPagesConfiguration, nextNumbers) && index != line.Count)
                {
                    int indexNumber = nextNumbers[index - 1];
                    bool isOrdered = true;
                    orderedPage = [..nextNumbers[..index]];
                    foreach (var number in nextNumbers[index..])
                    {
                        if (orderPagesConfiguration[indexNumber][number] is Order.After)
                            orderedPage.Add(number);
                        else
                        {
                            orderedPage.Insert(0, number);
                            isOrdered = false;
                            index = 1;
                        }

                    }
                    nextNumbers = orderedPage;
                    if (isOrdered)
                        index++;
                }
                orderedPages.Add(nextNumbers);
            }

            return orderedPages;
        }

        private bool ControlList(Dictionary<int, Dictionary<int, Order>> orderPagesConfiguration, List<int>? nextNumbers)
        {
            bool isValid = false;
            for (int i = 0; i < nextNumbers!.Count; i++)
            {
                isValid = IsAllNextNumberIsOrdered(nextNumbers[i], nextNumbers[(i + 1)..], orderPagesConfiguration);
            }

            return isValid;
        }

        bool IsAllNextNumberIsOrdered(int number, List<int> nextNumbers, Dictionary<int, Dictionary<int, Order>> orderPagesConfiguration)
            => !nextNumbers.Any(n => orderPagesConfiguration[number][n] is Order.Before);
    }

    public enum Order
    {
        Before,
        After
    }
}
