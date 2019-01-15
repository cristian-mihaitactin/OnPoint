(function ($) {
    console.log('in js');
    var _subjectService = abp.services.app.uniSubject;
    var _$modal = $('#EditSubjectModal');
    var _$form = $('form[name=SubjectEditForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var subject = _$form.serializeFormToObject();
        console.log(subject);

        abp.ui.setBusy(_$form);
        _subjectService.update(subject).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited user!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
        //$.ajax({
        //    url: abp.appPath + 'Subjects/Update',
        //    body: subject,
        //    type: 'POST',
        //    contentType: 'application/json',
        //    error: function (e) { }
        //}).done(function (ss) {
        //    _$modal.modal('hide');
        //    console.log('In done');

        //        location.reload(true); //reload page to see edited user!
        //    }).always(function () {
        //        abp.ui.clearBusy(_$modal);
        //        console.log('In always');

        //    });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        console.log('In save');

        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);