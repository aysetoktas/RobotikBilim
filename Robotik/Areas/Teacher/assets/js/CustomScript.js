function GetLessonByModuleId(mdlId) {
    $('#kt_subheader').remove();
    $('.content').remove();
    $('#homeLogo').remove();
    //document.getElementById("EduImageDiv").style.display = "none";
    var subHeader = '';
    var page = '';
    var beginPage = '<div class="row content" style="justify-content: center;">';
    var lessonList = '';
    var beginPortletBody = '';
    var widgetHead = '';
    var widgetBody = '';
    var widgetFooter = '';
    var endPortletBody = '';
    var endPage = '</div>';
    var counter = 0;
    var educationName = '';
    var eduLogo = '';
    $.get('/Teacher/Home/GetLessonByModuleId/?levelId=' + mdlId, function (data) {
        for (let prop of data) {
            if (counter < 2) {
                beginPortletBody = '<div class="col-sm-2"><div class="kt-portlet kt-portlet--height-fluid"><div class="kt-portlet__head kt-portlet__head--noborder"> <span class="kt-badge kt-badge--brand kt-badge--md kt-badge--rounded">' + prop["RowNumber"] + '</span> </div><div class="kt-portlet__body"><div class="kt-widget kt-widget--user-profile-2" style="align-items:center;">';
                widgetHead = '<div class="kt-widget__head"><div class="kt-widget__media"><img class="" src="' + prop['Logo'] + '" style="width:100%; padding-bottom:10px" alt="image"></div></div>';
                widgetBody = '<div class="kt-widget__body" style="text-align: center;"><div class="kt-widget__contact" style=""><h5 style="color:#616682;">' + prop['Name'] + '</h5></div><h6>' + prop['Code'] + '</h6></div>';
                widgetFooter = '<div class="embed-responsive kt-widget__footer"><a onclick="GetLesson(' + prop['ID'] + ')" type="button" id="' + prop['ID'] + '" class="btn btn-label-danger btn-lg btn-upper" style="">Derse Git</a></div>';
                endPortletBody = '</div></div></div></div>';
                lessonList += beginPortletBody + widgetHead + widgetBody + widgetFooter + endPortletBody;
            }
            else {
                beginPortletBody = '<div class="col-sm-2"><div class="kt-portlet kt-portlet--height-fluid ' + prop['Class'] + '"><div class="kt-portlet__head kt-portlet__head--noborder"><span class="kt-badge kt-badge--brand kt-badge--md kt-badge--rounded">' + prop["RowNumber"] + '</span></div><div class="kt-portlet__body"><div class="kt-widget kt-widget--user-profile-2" style="align-items:center;">';
                widgetHead = '<div class="kt-widget__head"><div class="kt-widget__media"><img class="" src="' + prop['Logo'] + '" style="width:100%; padding-bottom:10px" alt="image"></div></div>';
                widgetBody = '<div class="kt-widget__body" style="text-align: center;"><div class="kt-widget__contact" style=""><h5 style="color:#616682;">' + prop['Name'] + '</h5></div><h6>' + prop['Code'] + '</h6></div>';
                widgetFooter = '<div class="embed-responsive kt-widget__footer"><a onclick="GetLesson(' + prop['ID'] + ')" type="button" id="' + prop['ID'] + '" class="btn btn-label-danger btn-lg btn-upper ' + prop['Class'] + '" style="">Derse Git</a></div>';
                endPortletBody = '</div></div></div></div>';
                lessonList += beginPortletBody + widgetHead + widgetBody + widgetFooter + endPortletBody;
            }
            counter++;
            subHeader = '<div class="kt-subheader kt-grid__item" id="kt_subheader"><div class="kt-subheader__main"><h3 class="kt-subheader__title">' + prop["Education"] + '</h3><span class="kt-subheader__separator kt-subheader__separator--v"></span><span class="kt-subheader__desc">' + prop["Level"] + ' ' + prop["Hour"] + ' Saat </span></div></div>';
            eduName = prop["Education"];
            moduleLogo = prop["Logo"];
            modulLevel = prop["Level"];
            modulHour = prop["Hour"];
        }
        page = subHeader + beginPage + lessonList + endPage;
        $('#pageContentTr').append(page);
        $('#moduleImage').attr("src", moduleLogo);
        $('#educationName').append(eduName);
        $('#level').append(modulLevel);
        $('#hour').append(modulHour + " Saat");
    });
}

function GetLesson(id) {
    var page = '';
    $('.content').remove();
    $.get('/Lesson/GetLessonById/' + id, function (data) {
        debugger
        for (let prop of data) {
            var beginPortletHead = '<div class="kt-portlet content"><div class="kt-portlet__head">';
            var portletHeadLabel = '<div class="kt-portlet__head-label"><h3 class="kt-portlet__head-title">' + prop['Name'] + '<small>' + prop['EducationName'] + '</small></h3></div></div>';
            var beginPortletBody = '<div class="kt-portlet__body"><div class="kt-section kt-section--first"><div class="kt-section__body">';
            var iframe = '<iframe src="' + prop['Path'] + '" type="application/pdf" frameborder="0" width="751" height="451" allowfullscreen="true" mozallowfullscreen="true" webkitallowfullscreen="true"></iframe>';
            var endPortlet = '</div></div></div></div>';
        }
        page = beginPortletHead + portletHeadLabel + beginPortletBody + iframe + endPortlet;
        $('#pageContentEn').append(page);
        $('#pageContentTr').append(page);
    });
}

//function sessionTimeForever() {
//    $.get('/Home/GetSessionTime/', function (data) {
//        console.log(data);
//    });
//}
//window.setInterval(sessionTimeForever, 1000);

//$(document).ready(function () {
//    var fullpath = window.location.pathname;
//    var currentLink = $('a[href="' + fullpath + '"]');
//    currentLink.parent().addClass('kt-menu__item--active');
//})

function showImage(id) {
    $('#homeLogo').remove();
    $('.content').remove();
    document.getElementById("EduImageDiv").style.display = "block";
    $("#eduImage").attr("src", id);
}
