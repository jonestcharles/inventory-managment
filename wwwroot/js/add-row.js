$("#addAnother").click(function () {
    $.get('/User/MovieEntryRow', function (template) {
        $("#movieEditor").append(template);
    });
});