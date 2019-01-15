(function () {
    $(function () {

        var _subjectService = abp.services.app.uniSubject;

        $('#RefreshButton').click(function () {
            //refreshUserList();
            refreshSubjectList();
        });

        $('.add-subject-instance').click(function (e) {
            var subjectId = $(this).attr("data-subject-id");

            e.preventDefault();
            $.ajax({
                url: window.location.origin + '/Subjects/AddInstancePop?subjectId=' + subjectId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#AddSubjectInstance div.modal-content').html(content);
                    $('#AddSubjectInstance').modal('show');
                },
                error: function (e) { }
            });
        });

        function refreshSubjectList() {
            location.reload(true); //reload page to see new user!
        }
    });
})();