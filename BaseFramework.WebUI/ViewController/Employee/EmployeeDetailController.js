OOPSApp.controller('personDetailCtrl', function (OOPSService) {
    var vm = this;
    vm.accessTypeList = [];
    vm.bloodGroupList = [];


    //public int Id { get; set; }

    //   public string AccessTypeName { get; set; }
    vm.pageLoad = function () {
        vm.staticTypeList = OOPSService.OOPSGet("http://localhost:61842/api/StaticTypes/StaticTypeList");

        vm.accessTypeList = vm.staticTypeList.accessTypeList;
        vm.bloodGroupList = vm.staticTypeList.bloodGroupList;

        vm.employeeDetail = OOPSService.OOPSGet("http://localhost:61842/api/Employee/EmployeeDetail");
    };

    vm.pageLoad();
});
