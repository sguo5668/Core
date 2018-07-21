function DeactivateService(ServiceID) {
    var result = confirm("Are you sure you want to Deactivate this Service?");
    var url = "/ApplicationKeys/DeactivateService";
    if (result) {
        $.post(url, { ServiceID: ServiceID },
            function (data)
            {
                if (data != '')
                {
                    $.notify({
                        icon: 'ti-gift',
                        message: "Service Deactivate Successfully!"
                    }, {
                            type: 'success',
                            timer: 3000
                        });

                    setTimeout(function () {
                        window.location.reload(1);
                    }, 4000);
                }
            });
    }
}

function ReActivateService(ServiceID) {
    var result = confirm("Are you sure you want to Reactivate this Service?");
    var url = "/ApplicationKeys/ReActivateService";
    if (result) {
        $.post(url, { ServiceID: ServiceID },
            function (data) {
                if (data != '')
                {
                    $.notify({
                        icon: 'ti-gift',
                        message: "Service Reactivate Successfully!"
                    }, {
                            type: 'success',
                            timer: 3000
                        });

                    setTimeout(function ()
                    {
                        window.location.reload(1);
                    }, 4000);
                }
            });
    }
}