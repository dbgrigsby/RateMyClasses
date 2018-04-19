// Write your JavaScript code.
$('#searchDataTable').dataTable({searching: false, ordering: true, info: true});
$('#popularProfessors').dataTable({searching: false, paging: false, ordering: true});
$('#reviewList').dataTable({searching: false, paging: false, ordering: true});
$("#makeReviewCourseBox").prop("readonly", true);
$('#makeReviewCourseBox').val(location.href.match(/([^\/]*)\/*$/)[1]);
