(function ($) {
    console.log('in js');
    var _subjectService = abp.services.app.uniSubject;
    var _$modal = $('#AddSubjectInstance');
    var _$form = $('form[name=subjectInstanceCreateForm]');
    _$modal.modal('show'); 

    function meLog(logData) {
        console.log('Me Log: ' + logData);
    }
    function save(instanceType) {

        if (!_$form.valid()) {
            return;
        }

        var subject = _$form.serializeFormToObject();
        subject.Type = instanceType;

        ////subject.SubjectId = $('#instance-subj-id').value;
        ////subject.ProfId = $('#instance-prof-id').value;
        ////subject.Description = $('#instance-description').value;
        ////subject.Name = $('#instance-name').value;

        console.log(subject);

        abp.ui.setBusy(_$form);
        //_subjectService.update(subject).done(function () {
        //    _$modal.modal('hide');
        //    location.reload(true); //reload page to see edited user!
        //}).always(function () {
        //    abp.ui.clearBusy(_$modal);
        //    });

        console.log(subject);

        $.ajax({
            url: abp.appPath + 'Instances/AddInstance?profId=' + subject.ProfId + '&subjectId=' + subject.SubjectId + '&description=' + subject.Description + '&name=' + subject.Name + '&type=' + subject.Type,
            //body: subject,
            //data: JSON.stringify(subject),
            type: 'POST',
            //contentType: 'application/json',
            error: function (e) { },
            success: function(sData) {
                _$modal.modal('hide');
                meLog(sData);

                meLog(sData.AttendenceCode);
                location.reload();
            }
            }).done(function (ss) {
                _$modal.modal('hide');
        }).always(function () {
                abp.ui.clearBusy(_$modal);
                console.log('In always');
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        console.log('In save');

        var instType = $(this).attr("data-subject-type");
        save(instType);
    });
    ////btn-asSeminar
    //$("#btn-asSeminar").click(function (e) {
    //    e.preventDefault();
    //    console.log('In save seminar');
    //    save();
    //});
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