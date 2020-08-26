// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function UpdateModelList(ModelListUrl, setEnableDropdowns) {
    var selectedManufacturer = $("#Manufacturer").val();
    var modelsSelect = $('#Model');

    modelsSelect.empty();
    modelsSelect.append($('<option></option>')
        .attr('value', '')
        .text('Select Model'));

    if (selectedManufacturer != null && selectedManufacturer != '') {
        $.getJSON(ModelListUrl, { manufacturerId: selectedManufacturer }, function (data) {
            $.each(data, function (key, entry) {
                modelsSelect.append($('<option></option>')
                    .attr('value', entry.id)
                    .text(entry.name));
            });
        });
    }

    if (setEnableDropdowns) {
        EnableDropdowns();
    }
}

function EnableDropdowns() {
    var selectedManufacturer = $("#Manufacturer").val();
    var modelsSelect = $('#Model');

    modelsSelect.prop('disabled', (selectedManufacturer == null || selectedManufacturer == ''));
}

function ConfigureDropdowns(manufacturerId, colourId) {
    var manufacturerSelect = $("#Manufacturer");
    var colourSelect = $('#Colour');

    manufacturerSelect.val(manufacturerId);
    colourSelect.val(colourId);
}

function ConfigureModelDropdown(vehicleModelId) {
    var modelsSelect = $('#Model');

    modelsSelect.val(vehicleModelId);
}