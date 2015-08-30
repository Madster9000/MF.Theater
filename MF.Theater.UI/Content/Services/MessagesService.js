var Channel = function()
{
    var self = this;

    self.Listeners = [];

    self.Subscribe = function(listener)
    {
        self.Listeners.push(listener);
    };

    self.Publish = function(sender, message)
    {
        for (var i = 0; i < self.Listeners.length; i++)
        {
            self.Listeners[i](sender, message);
        }
    }
}

var MessagesService = (function()
{
    var instance;

    function createInstance()
    {
        var service =
            {
                PerfomanceCreatedChannel: new Channel()
            };
        return service;
    }

    return {
        GetInstance: function()
        {
            if (!instance)
            {
                instance = createInstance();
            }
            return instance;
        }
    };
})();