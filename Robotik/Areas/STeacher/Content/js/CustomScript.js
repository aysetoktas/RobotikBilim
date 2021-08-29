$('#educationSelect').change(function myfunction() {
    debugger
    var eduId = $(this).val();
    $.get('/Admin/Lesson/GetLevelsByEducationId/' + eduId, function (data) {
        $("#levelsSelect").find('option').remove();
        for (let prop of data) {
            $("#levelsSelect").append('<option value="' + prop['ID'] + '">' + prop['Name'] + '</option>');
        }
    });
});