import { type } from "os";
import { url } from "inspector";

var table = null;
var arrDepart = [];

$(document).ready(function () {
    //debugger;
    table = $("#department").DataTable({
        "processing": true,
        "ajax": {
            url: "/Division/LoadDivision",
            type: "GET",
            dataType: "json",
            dataSrc: "",
        },
        "columns": [
            { "data": "name" },
            { "data": "departmentID" },
            { "data": "departmentName" },
            {
                "render": function (data, type, row) {
                    //console.log(row);
                    return '<button class="btn btn-warning" data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + row.id + ')" >Edit</button>'
                        + '&nbsp;'
                        + '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id + ')" >Delete</button>'
                }
            }
        ]
    });
});

function ClearScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Update').hide();
    $('#Save').show();
}

function LoadDepartment(element) {
    //debugger;
    if (arrDepart.length === 0) {
        $.ajax({
            type: "Get",
            url: "/Department/LoadDivision",
            success: function (data) {
                arrDepart = datal;
                renderDepartment(element);
            }
        });   
    }
    else {
        renderDepartment(element);
    }
}

function renderDepartment(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Department').hide());
    $.each(Departments, function (i, val) {
        $option.append($('<option/>').val(val.id).text('Select Department'))
    });
}

LoadDepartment($('#DepartmentOption'))


function GetById(id) {
    $.ajax({
        url: "/Departments/GetById/",
        data: { id: id }
    }).then((result) => {
        debugger;
        $('#Id').val(result.id);
        $('#Name').val(result.name);
        $('#Save').hide();
        $('#Update').show();
        $('#mymodal').modal('show');
    })
}

function Save() {
    debugger;
    var Department = new Object();
    Department.name = $('#Name').val();
    $.ajax({
        type: 'POST',
        url: "/Departments/Insert/",
        data: Department
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                type: 'success',
                title: 'Department inserted Successfully'
            })
        } else {
            Swal.fire('Error', 'Failed to Input', 'error');
            ClearScreen();
        }
    })
}

function Update() {
    var Department = new Object();
    Department.id = $('#Id').val();
    Department.name = $('#Name').val();
    $.ajax({
        type: 'POST',
        url: "/Departments/Update/",
        data: Department
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                type: 'success',
                title: 'Department Updated Successfully'
            })
        } else {
            Swal.fire('Error', 'Failed to Input', 'error');
            ClearScreen();
        }
    })
}