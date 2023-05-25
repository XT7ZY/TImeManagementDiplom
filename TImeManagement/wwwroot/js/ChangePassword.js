function changePassword(){
    const modal = $('#modal');

    $.ajax({
        type: 'GET',
        url: '/Account/ChangePassword',

        success: function (model) {
            modal.find(".modal-body").html(model);
            modal.modal('show')
        },

        failure: function () {
            modal.modal('hide')
        },

        error: function () {
            modal.modal('hide')
        }
    });
};

function register() {
    const modal = $('#modal');

    $.ajax({
        type: 'GET',
        url: '/Account/Register',

        success: function (model) {
            modal.find(".modal-body").html(model);
            modal.modal('show')
        },

        failure: function () {
            modal.modal('hide')
        },

        error: function () {
            modal.modal('hide')
        }
    });
};

