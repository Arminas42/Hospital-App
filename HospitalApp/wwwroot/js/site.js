$(document).ready(function () {
    $('#Drug').select2({
        placeholder: "Select a drug",
        allowClear: true,
        ajax: {
            url: "/Prescription/SearchDrug",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                console.log(result);
                return {
                    
                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.name
                        };
                    }),
                };
            },
            minimumInputLength: 4,
            width: 'resolve'
        }
    });
    $('#PatientInput').select2({
        placeholder: "Select a patient",
        allowClear: true,
        ajax: {
            url: "/Prescription/SearchPatient",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                console.log(result);
                return {

                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.tab_number+ ' ' +item.name
                        };
                    }),
                };
            }
        }
    });
});