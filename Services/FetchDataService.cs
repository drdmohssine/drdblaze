using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace drdblaze.Services;

public class FetchDataService
{

    public async IAsyncEnumerable<string> GetItemsAsync()
    {
        var items = new List<string> { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
        
        foreach (var item in items)
        {
            // Simulate a delay in fetching each item
            await Task.Delay(1000);
            yield return item;
        }
    }

}
