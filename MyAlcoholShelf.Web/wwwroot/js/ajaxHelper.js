api = {
    get: function (url, options, success, error) {
        var finalUrl = url;

        if (finalUrl.last != '?') {
            finalUrl += '?';
        }

        for (var urlParam in options) {
            if (options.hasOwnProperty(urlParam)) {
                finalUrl += urlParam + '=' + options[urlParam];
            }
        }

        $.ajax({
            method: 'GET',
            url: finalUrl,
            success: success,
            error: error
        });
    },

    getView: function(url, options, anchorId, error) {
        var anchor = anchorId[0] === '#' ? anchorId : '#' + anchorId;
        this.get(url,
            options,
            function(response) {
                $(anchor).html(response);
            },
            error);
    }
}