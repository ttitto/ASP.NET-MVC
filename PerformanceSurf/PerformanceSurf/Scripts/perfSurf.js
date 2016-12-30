(function () {
    var perfHub = $.connection.perfHub;
    $.connection.hub.logging = true;
    $.connection.hub.start();

    perfHub.client.newMessage = function newMessage(message) {
        model.addMessage(message);
    };

    var Model = function Model() {
        var self = this;
        self.message = ko.observable(''),
        self.messages = ko.observableArray();
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
        }
    };

    var model = new Model();
    $(function onReady() {
        ko.applyBindings(model);
    });

})();