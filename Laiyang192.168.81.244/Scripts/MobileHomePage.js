function updateBadge(num) {

    $('#requestNum').attr('data-badge', num);
}
function RemoveBadge() {
    $('#requestNum').attr('style', 'display:none');
}
function updateFaultBadge(num) {

    $('#pendingfaultcount').attr('data-badge', num);
}
function RemoveFaultBadge() {
    $('#pendingfaultcount').attr('style', 'display:none');
}