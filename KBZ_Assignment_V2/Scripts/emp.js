var ViewModel = function () {
    var self = this;
    self.employees = ko.observableArray();
    self.error = ko.observable();

    var employeeUri = "/api/employees/";

    function ajaxHelper(uri, method, data) {
        self.error("");
        return $.ajax({
            type: method,
            url: uri,
            dataType: "json",
            contentType: "application/json",
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllEmployee() {
        ajaxHelper(employeeUri, "GET").done(function (data) {
            self.employees(data);
        })
    }

    getAllEmployee();

    self.detail = ko.observable();

    self.getEmployeeDetail = function (item) {
        ajaxHelper(employeeUri + item.Id, "GET").done(function (data) {
            self.detail(data);
        })
    }

    self.newEmployee = {
        Name: ko.observable(),
        Position: ko.observable(),
        Status: ko.observable()
    }

    self.addEmployee = function (formElement) {
        var employee = {
            Name: self.newEmployee.Name(),
            Position: self.newEmployee.Position(),
            Status: true
        };

        ajaxHelper(employeeUri, "POST", employee).done(function (item) {
            self.employees.push(item);
        });
    }

}

ko.applyBindings(new ViewModel());