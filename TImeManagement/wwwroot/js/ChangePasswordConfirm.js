function changePasswordConfirm() {

    debugger;
    const data = $('#changePasswordForm').serialize();

    $.ajax({
        type: 'POST',
        url: '/Account/ChangePasswordConfirm',
        data: data
    })

};