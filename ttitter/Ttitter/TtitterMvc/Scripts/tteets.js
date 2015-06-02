var page = 1;
var _inCallback = false;

function loadTteets() {
    if (page > 0 && !_inCallback) {
        _inCallback = true;
        page++;

        $('#tteets-loading').html('<img src="/Content/Images/ajax-loader.gif" alt="loading..." />');

        $.get("/Home/Index/" + page, function (successData) {
            if (successData != '') {
                $('.tteets-container').append(successData);
            }
            else {
                page = 0;
            }

            _inCallback = false;
            $('#tteets-loading').empty();
        })
            .done(
            function success() { }
        )
        .fail(function (errorData) { console.log(errorData); });
    }
}

$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        loadTteets();
    }
});