(function() {
    $(function() {

        var _subjectService = abp.services.app.uniSubject;
        var _$modal = $('#SubjectCreateModal');
        var _$form = _$modal.find('form');

        $('#RefreshButton').click(function () {
            //refreshUserList();
            refreshSubjectList();
        });

        $('.delete-subject').click(function () {
            var subjectId = $(this).attr("data-subject-id");
            var subjectName = $(this).attr('data-subject-name');

            deleteSubject(subjectId, subjectName);
        });

        $('.edit-subject').click(function (e) {
            var subjectId = $(this).attr("data-subject-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Subjects/EditSubjectModal?subjectId=' + subjectId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#EditSubjectModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var subject = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            //user.roleNames = [];
            //var _$roleCheckboxes = $("input[name='role']:checked");
            //if (_$roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
            //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
            //        user.roleNames.push(_$roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy(_$modal);
            var newSubject = {Title: subject.NewTitle, Credits: subject.NewCredits, Description: subject.NewDescription};
            _subjectService.create(newSubject).done(function () {
                console.log(subject);
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshSubjectList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteSubject(subjectId, subjectName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'eMMA'), subjectName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        console.log(subjectId);
                        _subjectService.delete(/*{
                            id: JSON.stringify(subjectId)
                        }*/subjectId).done(function () {
                            refreshSubjectList();
                        });
                    }
                }
            );
        }
    });
})();