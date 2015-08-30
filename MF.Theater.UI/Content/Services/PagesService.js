var PagesService = function()
{
    var service =
        {
            ComputePages: function(itemsCount, itemsOnPage)
            {
                var pagesCount = Math.floor(itemsCount / itemsOnPage);
                var hasAdditionalPage = (itemsCount % itemsOnPage) > 0;
                if (hasAdditionalPage)
                {
                    pagesCount++;
                }

                var result = [];

                for (var i = 1; i <= pagesCount; i++)
                {
                    var itemToInsert =
                        {
                            itemIndex: i
                        }
                    result.push(itemToInsert);
                }

                return result;
            }
        }

    return service;
}