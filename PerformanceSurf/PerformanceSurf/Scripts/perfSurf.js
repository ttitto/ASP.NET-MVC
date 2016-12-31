(function () {
    var perfHub = $.connection.perfHub;
    $.connection.hub.logging = true;
    $.connection.hub.start();

    perfHub.client.newMessage = function newMessage(message) {
        model.addMessage(message);
    };

    perfHub.client.newCounters = function newCounters(counters) {
        model.addCounters(counters);
    };

    var ChartEntry = function ChartEntry(name) {
        var self = this;
        self.name = name;
        self.chart = new SmoothieChart({ millisPerPixel: 50, labels: { fontSize: 15 } });
        self.timeSeries = new TimeSeries();
        self.chart.addTimeSeries(self.timeSeries, { lineWidth: 3, strokeStype: '#00ff00' });
    };

    ChartEntry.prototype = {
        addValue: function addValue(value) {
            var self = this;
            self.timeSeries.append(new Date().getTime(), value);
        },
        start: function start() {
            var self = this;
            self.canvas = document.getElementById(self.name);
            self.chart.streamTo(self.canvas);
        }
    };

    var Model = function Model() {
        var self = this;
        self.message = ko.observable(''),
        self.messages = ko.observableArray();
        self.counters = ko.observableArray();
    };

    Model.prototype = {
        sendMessage: function sendMessage() {
            var self = this;
            perfHub.server.send(self.message());
            self.message('');
        },
        addMessage: function addMessage(message) {
            var self = this;
            self.messages.push(message);
        },
        addCounters: function addCounters(updatedCounters) {
            var self = this;
            $.each(updatedCounters, function processUpdatedCounter(index, updateCounter) {
                var existingEntry = ko.utils.arrayFirst(self.counters(),
                    function (counter) {
                        return counter.name === updateCounter.name;
                    }
                );
                if (!existingEntry) {
                    existingEntry = new ChartEntry(updateCounter.name);
                    self.counters.push(existingEntry);
                    existingEntry.start();
                }

                existingEntry.addValue(updateCounter.value);
            });
        }
    };

    var model = new Model();
    $(function onReady() {
        ko.applyBindings(model);
    });

})();