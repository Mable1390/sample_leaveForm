var ViewModel = function () {
    var self = this;
    self.leaves = ko.observableArray();
    self.error = ko.observable();

    var leavesUri = "/api/leaves/";

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

    function getAllLeaves() {
        ajaxHelper(leavesUri, "GET").done(function (data) {
            self.leaves(data);
        })
    }

    getAllLeaves();

    self.detail = ko.observable();

    self.getLeaveDetail = function (item) {
        ajaxHelper(leavesUri + item.Id, "GET").done(function (data) {            
            self.detail(data);
        })
    }

    self.employees = ko.observableArray();

    self.newLeave = {
        Title: ko.observable(),
        Date: ko.observable(),
        Reason: ko.observable(),
        Employee: ko.observable()
    }

    var employeesUri = "/api/Employees/";

    function getEmployees() {
        ajaxHelper(employeesUri, "GET").done(function (data) {
            self.employees(data);
        });
    }

    self.addLeave = function (formElement) {
        var leave = {
            EmployeeId: self.newLeave.Employee().Id,            
            Title: self.newLeave.Title(),
            Date: self.newLeave.Date(),
            Reason: self.newLeave.Reason()
        };

        ajaxHelper(leavesUri, "POST", leave).done(function (item) {
            self.leaves.push(item);
        });
    }
    getEmployees();
}

ko.applyBindings(new ViewModel());