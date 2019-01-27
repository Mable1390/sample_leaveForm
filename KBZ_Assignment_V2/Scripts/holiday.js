var ViewModel = function () {
    var self = this;
    self.holidays = ko.observableArray();
    self.error = ko.observable();

    var holidayUri = "/api/holidays/";

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

    function getAllHolidays() {
        ajaxHelper(holidayUri, "GET").done(function (data) {
            self.holidays(data);
        })
    }
    getAllHolidays();

    self.newHoliday = {
        Title: ko.observable(),
        Date: ko.observable()
    }

    self.addHoliday = function (formElement) {
        var holiday = {
            Title: self.newHoliday.Title(),
            Date: self.newHoliday.Date()
        };

        ajaxHelper(holidayUri, "POST", holiday).done(function (item) {
            self.holidays.push(item);
        });
    }

}
ko.applyBindings(new ViewModel());