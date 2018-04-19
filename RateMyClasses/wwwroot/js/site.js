// Write your JavaScript code.
$('#searchDataTable').dataTable({searching: false, ordering: true, info: true});
$("#makeReviewCourseBox").prop("readonly", true);
$('#makeReviewCourseBox').val(location.href.match(/([^\/]*)\/*$/)[1]);
