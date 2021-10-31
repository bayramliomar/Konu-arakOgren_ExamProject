//#region Change Content 
$('#title').on('change', function () {
    var id = $(this).find(':selected').data('id');
    $.ajax({
        type: "POST",
        data: ({ id: id }),
        url: "/Home/FillContent",
        dataType: "json",
        success: function (data) {
            $('#content').html(data);
            $('#content').html().replace('\n', '');
            $('#content').html().replace('\t', '');
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });
});
//#endregion

//#region Finish Exam
$('.finishExam').on('click', function () {
    var eId = $('.eId').val();
    var selectedVariant = new Array();
    var selectVariant1 = $('input[type=radio][name=1]:checked').attr('id');
    var selectVariant2 = $('input[type=radio][name=2]:checked').attr('id');
    var selectVariant3 = $('input[type=radio][name=3]:checked').attr('id');
    var selectVariant4 = $('input[type=radio][name=4]:checked').attr('id');
    selectedVariant.push(selectVariant1);
    selectedVariant.push(selectVariant2);
    selectedVariant.push(selectVariant3);
    selectedVariant.push(selectVariant4);
    for (var i = 1; i < 5; i++) {
        if ($('input[type=radio][name=' + i + ']:checked').attr('id') == undefined) {
            Swal.fire({
                icon: 'warning',
                title: 'Dikkat',
                text: 'Sınavı bitirebilmek için bütün soruları cevaplamalısınız!'
            })
        }
    }
    $.ajax({
        type: "POST",
        data: ({ id: eId, selectedVariant: selectedVariant }),
        url: "/Home/FinishTheExam",
        dataType: "json",
        success: function (data) {
            for (var i = 1; i < 5; i++) {
                var sv = $('input[type=radio][name=' + i + ']:checked').attr('id');
                if (data[i-1] == "true") {
                    $('#' + sv).parent('div').css('background-color', 'green');
                }
                else {
                    $('#' + sv).parent('div').css('background-color', 'red');
                }
            }
            $('input:radio').remove();
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });
});
//#endregion