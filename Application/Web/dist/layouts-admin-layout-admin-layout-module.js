(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["layouts-admin-layout-admin-layout-module"],{

/***/ "/2DJ":
/*!************************************************************************************!*\
  !*** ./src/app/pages/category/category-dashboard/category-dashboard.component.css ***!
  \************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2NhdGVnb3J5L2NhdGVnb3J5LWRhc2hib2FyZC9jYXRlZ29yeS1kYXNoYm9hcmQuY29tcG9uZW50LmNzcyJ9 */");

/***/ }),

/***/ "/v23":
/*!**************************************************************************!*\
  !*** ./src/app/pages/house/house-dashboard/house-dashboard.component.ts ***!
  \**************************************************************************/
/*! exports provided: HouseDashboardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HouseDashboardComponent", function() { return HouseDashboardComponent; });
/* harmony import */ var _raw_loader_house_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./house-dashboard.component.html */ "BEIF");
/* harmony import */ var _house_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./house-dashboard.component.css */ "yQUv");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HouseDashboardComponent = /** @class */ (function () {
    function HouseDashboardComponent() {
    }
    HouseDashboardComponent.prototype.ngOnInit = function () {
    };
    HouseDashboardComponent.ctorParameters = function () { return []; };
    HouseDashboardComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-house-dashboard',
            template: _raw_loader_house_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_house_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [])
    ], HouseDashboardComponent);
    return HouseDashboardComponent;
}());



/***/ }),

/***/ "049Q":
/*!***************************************************************************!*\
  !*** ./src/app/pages/category/category-table/category-table.component.ts ***!
  \***************************************************************************/
/*! exports provided: CategoryTableComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CategoryTableComponent", function() { return CategoryTableComponent; });
/* harmony import */ var _raw_loader_category_table_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./category-table.component.html */ "VfQe");
/* harmony import */ var _category_table_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./category-table.component.css */ "xMCQ");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/categories/category.service */ "TT9N");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var CategoryTableComponent = /** @class */ (function () {
    function CategoryTableComponent(categoryService) {
        this.categoryService = categoryService;
        this.categories = [];
        this.id = 0;
        this.errorBackend = '';
    }
    CategoryTableComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.categoryService.getAll()
            .subscribe(function (response) {
            _this.getAll(response);
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    CategoryTableComponent.prototype.getAll = function (response) {
        this.categories = response;
    };
    CategoryTableComponent.prototype.delete = function (event) {
        var _this = this;
        this.id = event.id;
        this.categoryService.delete(this.id)
            .subscribe(function (response) {
            _this.delete(response);
            _this.categories = _this.categories.filter(function (item) { return item.id != _this.id; });
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    CategoryTableComponent.ctorParameters = function () { return [
        { type: src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_3__["CategoryService"] }
    ]; };
    CategoryTableComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-category-table',
            template: _raw_loader_category_table_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_category_table_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_3__["CategoryService"]])
    ], CategoryTableComponent);
    return CategoryTableComponent;
}());



/***/ }),

/***/ "1bUw":
/*!********************************************************************************************!*\
  !*** ./src/app/pages/tourist-point/tourist-points-table/tourist-points-table.component.ts ***!
  \********************************************************************************************/
/*! exports provided: TouristPointsTableComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TouristPointsTableComponent", function() { return TouristPointsTableComponent; });
/* harmony import */ var _raw_loader_tourist_points_table_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./tourist-points-table.component.html */ "4EA9");
/* harmony import */ var _tourist_points_table_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./tourist-points-table.component.css */ "zrvB");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/touristpoints/touristpoint.service */ "Tscr");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var TouristPointsTableComponent = /** @class */ (function () {
    function TouristPointsTableComponent(touristPointService) {
        this.touristPointService = touristPointService;
        this.touristpoints = [];
        this.id = 0;
        this.errorMessageBackend = '';
    }
    TouristPointsTableComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.touristPointService.getAll()
            .subscribe(function (touristPointResponse) {
            _this.getAll(touristPointResponse);
        }, function (catchError) {
            _this.errorMessageBackend = catchError + ', fix it and try again';
        });
    };
    TouristPointsTableComponent.prototype.getAll = function (touristPointResponse) {
        this.touristpoints = touristPointResponse;
    };
    TouristPointsTableComponent.prototype.delete = function (event) {
        var _this = this;
        this.id = event.id;
        this.touristPointService.delete(this.id)
            .subscribe(function (touristPointResponse) {
            _this.delete(touristPointResponse);
            _this.touristpoints = _this.touristpoints.filter(function (item) { return item.id != _this.id; });
        }, function (catchError) {
            _this.errorMessageBackend = catchError + ', fix it and try again';
        });
    };
    TouristPointsTableComponent.ctorParameters = function () { return [
        { type: src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_3__["TouristPointsService"] }
    ]; };
    TouristPointsTableComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-tourist-points-table',
            template: _raw_loader_tourist_points_table_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_tourist_points_table_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_3__["TouristPointsService"]])
    ], TouristPointsTableComponent);
    return TouristPointsTableComponent;
}());



/***/ }),

/***/ "4EA9":
/*!*******************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/tourist-point/tourist-points-table/tourist-points-table.component.html ***!
  \*******************************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<!-- Table -->\n<div class=\"card shadow\">\n  <div class=\"card-header border-0\">\n    <h3 class=\"mb-0\">Tourist Points</h3>\n  </div>\n  <div class=\"table-responsive\">\n    <table class=\"table align-items-center table-flush\">\n      <thead class=\"thead-light\">\n        <tr>\n          <th scope=\"col\">Name</th>\n          <th scope=\"col\">regionId</th>\n          <th></th>\n          <th></th>\n        </tr>\n      </thead>\n      <tbody>\n        <tr *ngFor=\"let touristpoint of touristpoints; let i = index\">\n          <th scope=\"row\"> {{touristpoint.name}} </th>\n          <td>{{touristpoint.regionId}}</td>\n          <td>\n            <button [routerLink]=\"['/tourist-points/tourist-point-editor',touristpoint.id]\" type=\"button\"\n              placement=\"top-center\" triggers=\"hover focus click\" class=\"btn btn-rounded\" ngxClipboard\n              (cbOnSuccess)=\"copy = 'air-baloon'\">\n              Edit\n            </button>\n          </td>\n          <td>\n            <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n              class=\"btn btn-rounded btn-outline-danger\" ngxClipboard\n              (cbOnSuccess)=\"copy = 'air-baloon'\" (click)=\"delete(touristpoint)\">\n              Delete\n            </button>\n          </td>\n        </tr>\n      </tbody>\n    </table>\n  </div>\n</div>\n");

/***/ }),

/***/ "6ijC":
/*!**************************************************************************!*\
  !*** ./src/app/pages/booking/booking-editor/booking-editor.component.ts ***!
  \**************************************************************************/
/*! exports provided: BookingEditorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BookingEditorComponent", function() { return BookingEditorComponent; });
/* harmony import */ var _raw_loader_booking_editor_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./booking-editor.component.html */ "94c9");
/* harmony import */ var _booking_editor_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./booking-editor.component.css */ "onE1");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var src_app_services_bookings_booking_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/bookings/booking.service */ "w8/2");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "tyNb");
/* harmony import */ var src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/houses/house.service */ "ccfc");
/* harmony import */ var src_app_services_states_states_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/services/states/states.service */ "vaMk");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var BookingEditorComponent = /** @class */ (function () {
    function BookingEditorComponent(route, bookingService, houseService, stateService) {
        this.route = route;
        this.bookingService = bookingService;
        this.houseService = houseService;
        this.stateService = stateService;
        this.booking = {};
        this.houses = [];
        this.states = [];
        this.bookingId = 0;
        this.dateIn = '';
        this.dateOut = '';
        this.errorMessageEndpoint = '';
        this.stateName = '';
        this.updateMessage = '';
    }
    BookingEditorComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id = this.route.snapshot.paramMap.get('id');
        this.bookingId = Number(id);
        this.bookingService.getBy(this.bookingId)
            .subscribe(function (bookingResponse) {
            _this.getBy(bookingResponse);
            _this.dateIn = _this.formatDate(_this.booking.checkIn);
            _this.dateOut = _this.formatDate(_this.booking.checkOut);
            _this.stateName = bookingResponse.state.name;
        }, function (catchError) {
            _this.errorMessageEndpoint = catchError + ', fix it and try again';
        });
        this.houseService.getAll()
            .subscribe(function (houseResponse) {
            _this.getAllHouses(houseResponse);
        }, function (catchError) {
            _this.errorMessageEndpoint = catchError + ', fix it and try again';
        });
        this.stateService.getAll()
            .subscribe(function (stateResponse) {
            _this.getAllStates(stateResponse);
        }, function (catchError) {
            _this.errorMessageEndpoint = catchError + ', fix it and try again';
        });
    };
    BookingEditorComponent.prototype.getBy = function (bookingResponse) {
        this.booking = bookingResponse;
    };
    BookingEditorComponent.prototype.getAllHouses = function (houseResponse) {
        this.houses = houseResponse;
    };
    BookingEditorComponent.prototype.getAllStates = function (stateResponse) {
        this.states = stateResponse;
    };
    BookingEditorComponent.prototype.formatDate = function (date) {
        var dateString = date.toString();
        var dateArray = dateString.split('-');
        if (dateArray.length == 3) {
            var year = dateArray[0];
            var month = dateArray[1];
            var day = dateArray[2].substr(0, 2);
            return year + '-' + month + '-' + day;
        }
        return '';
    };
    BookingEditorComponent.prototype.onChangeStateName = function (stateName) {
        var newStateId = this.states.filter(function (s) { return s.name === stateName; });
        this.booking.stateId = newStateId[0].id;
    };
    BookingEditorComponent.prototype.updateState = function () {
        var _this = this;
        this.bookingService.update(this.bookingId, this.booking)
            .subscribe(function (bookingResponse) {
            _this.booking = bookingResponse;
            _this.updateMessage = 'Update done!';
        }, function (catchError) {
            _this.errorMessageEndpoint = catchError + ', fix it and try again';
        });
    };
    BookingEditorComponent.ctorParameters = function () { return [
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__["ActivatedRoute"] },
        { type: src_app_services_bookings_booking_service__WEBPACK_IMPORTED_MODULE_3__["BookingService"] },
        { type: src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_5__["HouseService"] },
        { type: src_app_services_states_states_service__WEBPACK_IMPORTED_MODULE_6__["StatesService"] }
    ]; };
    BookingEditorComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-booking-editor',
            template: _raw_loader_booking_editor_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_booking_editor_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_4__["ActivatedRoute"],
            src_app_services_bookings_booking_service__WEBPACK_IMPORTED_MODULE_3__["BookingService"],
            src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_5__["HouseService"],
            src_app_services_states_states_service__WEBPACK_IMPORTED_MODULE_6__["StatesService"]])
    ], BookingEditorComponent);
    return BookingEditorComponent;
}());



/***/ }),

/***/ "94c9":
/*!*************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/booking/booking-editor/booking-editor.component.html ***!
  \*************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header pb-8 pt-5 pt-lg-8 d-flex align-items-center\" style=\"\n    min-height: 600px;\n    background-image: url(assets/img/theme/profile-cover.jpg);\n    background-size: cover;\n    background-position: center top;\n  \">\n  <!-- Mask -->\n  <span class=\"mask bg-gradient-danger opacity-8\"></span>\n</div>\n<div class=\"container-fluid mt--7\">\n  <div class=\"row\">\n    <div class=\"col-xl-8 order-xl-1\">\n      <div class=\"card bg-secondary shadow\">\n        <div class=\"card-header bg-white border-0\">\n          <div class=\"row align-items-center\">\n            <div class=\"col-4\">\n              <h3 class=\"mb-0\">Booking</h3>\n              <span class=\"heading-small text-muted mb-4\">Id {{ bookingId }}</span>\n            </div>\n            <div class=\"col-4 text-right\">\n              <p class=\"errorMessage\" id=\"error-message\">{{errorMessageEndpoint}}</p>\n              <p class=\"successMessage\" id=\"succes-messages\">{{updateMessage}}</p>\n            </div>\n            <div class=\"col-4 text-right\">\n              <a (click)=\"updateState()\" class=\"btn btn-sm btn-primary\">Update</a>\n            </div>\n          </div>\n        </div>\n        <div class=\"card-body\">\n          <form>\n            <div class=\"pl-lg-4\">\n              <div class=\"row\">\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-username\">Name</label>\n                    <input type=\"text\" id=\"input-username\" class=\"form-control form-control-alternative\"\n                      value=\"{{ booking.name }}\" disabled />\n                  </div>\n                </div>\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-email\">Email</label>\n                    <input type=\"email\" id=\"input-email\" class=\"form-control form-control-alternative\"\n                      value=\"{{ booking.email }}\" disabled />\n                  </div>\n                </div>\n                <div class=\"col-9\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"select-house\">House</label>\n                    <input type=\"text\" id=\"input-house\" class=\"form-control form-control-alternative\"\n                      value=\"{{ booking.house.name }}\" disabled />\n                  </div>\n                </div>\n                <div class=\"col-9\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\">State</label>\n                    <select class=\"custom-select form-control form-control-alternative\"\n                      [(ngModel)]=\"stateName\"\n                      name=\"stateName\" (change)=\"onChangeStateName(stateName)\">\n                      <option disabled>Choose State</option>\n                      <option *ngFor=\"let state of states\">\n                        {{ state.name }}\n                      </option>\n                    </select>\n                  </div>\n                </div>\n                <div class=\"col-3\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-state-id\">State Id</label>\n                    <input type=\"number\" id=\"input-state-id\" class=\"form-control form-control-alternative\"\n                      value=\"{{ booking.stateId }}\" disabled/>\n                  </div>\n                </div>\n                <div class=\"col-8\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-code\">Code</label>\n                    <input tyinpute=\"text\" id=\"input-code\" class=\"form-control form-control-alternative\" disabled\n                      value=\"{{ booking.code }}\" />\n                  </div>\n                </div>\n                <div class=\"col-4\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-price\">Price</label>\n                    <input type=\"number\" id=\"input-price\" class=\"form-control form-control-alternative\"\n                      value=\"{{ booking.price }}\" disabled />\n                  </div>\n                </div>\n\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-date\">Check In</label>\n                    <input type=\"date\" id=\"input-date-in\" class=\"form-control form-control-alternative\"\n                      value=\"{{dateIn}}\" disabled />\n                  </div>\n                </div>\n\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-date\">Check Out</label>\n                    <input type=\"date\" id=\"input-date-out\" class=\"form-control form-control-alternative\"\n                      value=\"{{dateOut}}\" disabled />\n                  </div>\n                </div>\n              </div>\n            </div>\n            <hr class=\"my-4\" />\n          </form>\n\n          <button routerLink=\"/bookings\" type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n            class=\"btn btn-rounded btn-outline-warning\" ngxClipboard\n            (cbOnSuccess)=\"copy = 'air-baloon'\">\n            Go back\n          </button>\n        </div>\n      </div>\n    </div>\n  </div>\n</div>\n");

/***/ }),

/***/ "BEIF":
/*!*************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/house/house-dashboard/house-dashboard.component.html ***!
  \*************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header bg-gradient-danger pb-8 pt-5 pt-md-8\">\n    <div class=\"container-fluid\">\n        <div class=\"header-body\">\n            <!-- Card stats -->\n            <div class=\"row\">\n                <div class=\"col-xl-3 col-lg-6\">\n\n                    <div class=\"row\">\n                        <div class=\"col\">\n                            <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\" class=\"bg-warning btn btn-rounded bg-warning text-white shadow\" ngxClipboard (cbOnSuccess)=\"copy = 'air-baloon'\" routerLink=\"/houses/house-editor/new\">\n                  Add House\n                </button>\n                        </div>\n                    </div>\n\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n<!-- Page content -->\n<div class=\"container-fluid mt--7\">\n    <app-house-table></app-house-table>\n</div>");

/***/ }),

/***/ "Ddk7":
/*!*************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/user-profile/user-profile.component.html ***!
  \*************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header pb-8 pt-5 pt-lg-8 d-flex align-items-center\" style=\"min-height: 600px; background-image: url(assets/img/theme/profile-cover.jpg); background-size: cover; background-position: center top;\">\n  <!-- Mask -->\n  <span class=\"mask bg-gradient-danger opacity-8\"></span>\n  <!-- Header container -->\n  <div class=\"container-fluid d-flex align-items-center\">\n    <div class=\"row\">\n      <div class=\"col-lg-7 col-md-10\">\n        <h1 class=\"display-2 text-white\">Hello {{user.name}}</h1>\n        <p class=\"text-white mt-0 mb-5\">This is your profile page. You can see the progress you've made with your work and manage your projects or assigned tasks</p>\n      </div>\n    </div>\n  </div>\n</div>\n<div class=\"container-fluid mt--7\">\n  <div class=\"row\">\n    <div class=\"col-xl-8 order-xl-1\">\n      <div class=\"card bg-secondary shadow\">\n        <div class=\"card-header bg-white border-0\">\n          <div class=\"row align-items-center\">\n            <div class=\"col-8\">\n              <h3 class=\"mb-0\">My account</h3>\n            </div>\n            <div class=\"col-4 text-right\">\n              <a (click)=\"updateData()\" class=\"btn btn-sm btn-primary\">Update</a>\n            </div>\n          </div>\n        </div>\n        <div class=\"card-body\">\n          <form>\n            <h6 class=\"heading-small text-muted mb-4\">User information</h6>\n            <div class=\"pl-lg-4\">\n              <div class=\"row\">\n                <div class=\"col-lg-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-username\">Username</label>\n                    <input type=\"text\" id=\"input-username\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"user.name\" name=\"name\"\n                      placeholder=\"Username\" value={{user.name}}>\n                  </div>\n                </div>\n                <div class=\"col-lg-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-email\">Email address</label>\n                    <input type=\"email\" id=\"input-email\" class=\"form-control form-control-alternative\"\n                      value={{user.email}} [(ngModel)]=\"user.email\" name=\"email\"\n                      placeholder=\"jesse@example.com\">\n                  </div>\n                </div>\n                <div class=\"col-lg-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-password\">Password</label>\n                    <input type=\"password\" id=\"input-password\"\n                      value={{user.password}}\n                      [(ngModel)]=\"user.password\" name=\"password\"\n                      class=\"form-control form-control-alternative\">\n                  </div>\n                </div>\n                <div class=\"col-12\">\n                  <p class=\"errorMessage\" id=\"error-message\">{{errorMessage}}</p>\n                  <p class=\"successMessage\" id=\"succes-messages\">{{updateMessage}}</p>\n                </div>\n              </div>\n            </div>\n            <hr class=\"my-4\" />\n          </form>\n        </div>\n      </div>\n    </div>\n  </div>\n</div>\n");

/***/ }),

/***/ "Dvla":
/*!***************************************************************************!*\
  !*** ./node_modules/ngx-clipboard/__ivy_ngcc__/fesm2015/ngx-clipboard.js ***!
  \***************************************************************************/
/*! exports provided: ClipboardDirective, ClipboardIfSupportedDirective, ClipboardModule, ClipboardService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ClipboardDirective", function() { return ClipboardDirective; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ClipboardIfSupportedDirective", function() { return ClipboardIfSupportedDirective; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ClipboardModule", function() { return ClipboardModule; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ClipboardService", function() { return ClipboardService; });
/* harmony import */ var _Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_classCallCheck__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@angular-devkit/build-angular/node_modules/@babel/runtime/helpers/esm/classCallCheck */ "MGFw");
/* harmony import */ var _Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_createClass__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./node_modules/@angular-devkit/build-angular/node_modules/@babel/runtime/helpers/esm/createClass */ "WtWf");
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! tslib */ "WQAP");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ "ofXK");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var ngx_window_token__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ngx-window-token */ "mzkM");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ "qCKp");







/**
 * The following code is heavily copied from https://github.com/zenorocha/clipboard.js
 */



var ClipboardService = /*#__PURE__*/function () {
  function ClipboardService(document, window) {
    Object(_Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_classCallCheck__WEBPACK_IMPORTED_MODULE_0__["default"])(this, ClipboardService);

    this.document = document;
    this.window = window;
    this.copySubject = new rxjs__WEBPACK_IMPORTED_MODULE_6__["Subject"]();
    this.copyResponse$ = this.copySubject.asObservable();
    this.config = {};
  }

  Object(_Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_createClass__WEBPACK_IMPORTED_MODULE_1__["default"])(ClipboardService, [{
    key: "configure",
    value: function configure(config) {
      this.config = config;
    }
  }, {
    key: "copy",
    value: function copy(content) {
      if (!this.isSupported || !content) {
        return this.pushCopyResponse({
          isSuccess: false,
          content: content
        });
      }

      var copyResult = this.copyFromContent(content);

      if (copyResult) {
        return this.pushCopyResponse({
          content: content,
          isSuccess: copyResult
        });
      }

      return this.pushCopyResponse({
        isSuccess: false,
        content: content
      });
    }
  }, {
    key: "isTargetValid",
    value: function isTargetValid(element) {
      if (element instanceof HTMLInputElement || element instanceof HTMLTextAreaElement) {
        if (element.hasAttribute('disabled')) {
          throw new Error('Invalid "target" attribute. Please use "readonly" instead of "disabled" attribute');
        }

        return true;
      }

      throw new Error('Target should be input or textarea');
    }
    /**
     * Attempts to copy from an input `targetElm`
     */

  }, {
    key: "copyFromInputElement",
    value: function copyFromInputElement(targetElm) {
      var isFocus = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : true;

      try {
        this.selectTarget(targetElm);
        var re = this.copyText();
        this.clearSelection(isFocus ? targetElm : undefined, this.window);
        return re && this.isCopySuccessInIE11();
      } catch (error) {
        return false;
      }
    }
    /**
     * This is a hack for IE11 to return `true` even if copy fails.
     */

  }, {
    key: "isCopySuccessInIE11",
    value: function isCopySuccessInIE11() {
      var clipboardData = this.window['clipboardData'];

      if (clipboardData && clipboardData.getData) {
        if (!clipboardData.getData('Text')) {
          return false;
        }
      }

      return true;
    }
    /**
     * Creates a fake textarea element, sets its value from `text` property,
     * and makes a selection on it.
     */

  }, {
    key: "copyFromContent",
    value: function copyFromContent(content) {
      var container = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : this.document.body;

      // check if the temp textarea still belongs to the current container.
      // In case we have multiple places using ngx-clipboard, one is in a modal using container but the other one is not.
      if (this.tempTextArea && !container.contains(this.tempTextArea)) {
        this.destroy(this.tempTextArea.parentElement || undefined);
      }

      if (!this.tempTextArea) {
        this.tempTextArea = this.createTempTextArea(this.document, this.window);

        try {
          container.appendChild(this.tempTextArea);
        } catch (error) {
          throw new Error('Container should be a Dom element');
        }
      }

      this.tempTextArea.value = content;
      var toReturn = this.copyFromInputElement(this.tempTextArea, false);

      if (this.config.cleanUpAfterCopy) {
        this.destroy(this.tempTextArea.parentElement || undefined);
      }

      return toReturn;
    }
    /**
     * Remove temporary textarea if any exists.
     */

  }, {
    key: "destroy",
    value: function destroy() {
      var container = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : this.document.body;

      if (this.tempTextArea) {
        container.removeChild(this.tempTextArea); // removeChild doesn't remove the reference from memory

        this.tempTextArea = undefined;
      }
    }
    /**
     * Select the target html input element.
     */

  }, {
    key: "selectTarget",
    value: function selectTarget(inputElement) {
      inputElement.select();
      inputElement.setSelectionRange(0, inputElement.value.length);
      return inputElement.value.length;
    }
  }, {
    key: "copyText",
    value: function copyText() {
      return this.document.execCommand('copy');
    }
    /**
     * Moves focus away from `target` and back to the trigger, removes current selection.
     */

  }, {
    key: "clearSelection",
    value: function clearSelection(inputElement, window) {
      var _a;

      inputElement && inputElement.focus();
      (_a = window.getSelection()) === null || _a === void 0 ? void 0 : _a.removeAllRanges();
    }
    /**
     * Creates a fake textarea for copy command.
     */

  }, {
    key: "createTempTextArea",
    value: function createTempTextArea(doc, window) {
      var isRTL = doc.documentElement.getAttribute('dir') === 'rtl';
      var ta;
      ta = doc.createElement('textarea'); // Prevent zooming on iOS

      ta.style.fontSize = '12pt'; // Reset box model

      ta.style.border = '0';
      ta.style.padding = '0';
      ta.style.margin = '0'; // Move element out of screen horizontally

      ta.style.position = 'absolute';
      ta.style[isRTL ? 'right' : 'left'] = '-9999px'; // Move element to the same position vertically

      var yPosition = window.pageYOffset || doc.documentElement.scrollTop;
      ta.style.top = yPosition + 'px';
      ta.setAttribute('readonly', '');
      return ta;
    }
    /**
     * Pushes copy operation response to copySubject, to provide global access
     * to the response.
     */

  }, {
    key: "pushCopyResponse",
    value: function pushCopyResponse(response) {
      this.copySubject.next(response);
    }
    /**
     * @deprecated use pushCopyResponse instead.
     */

  }, {
    key: "pushCopyReponse",
    value: function pushCopyReponse(response) {
      this.pushCopyResponse(response);
    }
  }, {
    key: "isSupported",
    get: function get() {
      return !!this.document.queryCommandSupported && !!this.document.queryCommandSupported('copy') && !!this.window;
    }
  }]);

  return ClipboardService;
}();

ClipboardService.ɵfac = function ClipboardService_Factory(t) {
  return new (t || ClipboardService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_common__WEBPACK_IMPORTED_MODULE_3__["DOCUMENT"]), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](ngx_window_token__WEBPACK_IMPORTED_MODULE_5__["WINDOW"], 8));
};

ClipboardService.ctorParameters = function () {
  return [{
    type: undefined,
    decorators: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Inject"],
      args: [_angular_common__WEBPACK_IMPORTED_MODULE_3__["DOCUMENT"]]
    }]
  }, {
    type: undefined,
    decorators: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Optional"]
    }, {
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Inject"],
      args: [ngx_window_token__WEBPACK_IMPORTED_MODULE_5__["WINDOW"]]
    }]
  }];
};

ClipboardService.ɵprov = Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"])({
  factory: function ClipboardService_Factory() {
    return new ClipboardService(Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"])(_angular_common__WEBPACK_IMPORTED_MODULE_3__["DOCUMENT"]), Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"])(ngx_window_token__WEBPACK_IMPORTED_MODULE_5__["WINDOW"], 8));
  },
  token: ClipboardService,
  providedIn: "root"
});
ClipboardService = Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__decorate"])([Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__param"])(0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Inject"])(_angular_common__WEBPACK_IMPORTED_MODULE_3__["DOCUMENT"])), Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__param"])(1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Optional"])()), Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__param"])(1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Inject"])(ngx_window_token__WEBPACK_IMPORTED_MODULE_5__["WINDOW"]))], ClipboardService);

var ClipboardDirective = /*#__PURE__*/function () {
  function ClipboardDirective(clipboardSrv) {
    Object(_Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_classCallCheck__WEBPACK_IMPORTED_MODULE_0__["default"])(this, ClipboardDirective);

    this.clipboardSrv = clipboardSrv;
    this.cbOnSuccess = new _angular_core__WEBPACK_IMPORTED_MODULE_4__["EventEmitter"]();
    this.cbOnError = new _angular_core__WEBPACK_IMPORTED_MODULE_4__["EventEmitter"]();
  } // tslint:disable-next-line:no-empty


  Object(_Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_createClass__WEBPACK_IMPORTED_MODULE_1__["default"])(ClipboardDirective, [{
    key: "ngOnInit",
    value: function ngOnInit() {}
  }, {
    key: "ngOnDestroy",
    value: function ngOnDestroy() {
      this.clipboardSrv.destroy(this.container);
    }
  }, {
    key: "onClick",
    value: function onClick(event) {
      if (!this.clipboardSrv.isSupported) {
        this.handleResult(false, undefined, event);
      } else if (this.targetElm && this.clipboardSrv.isTargetValid(this.targetElm)) {
        this.handleResult(this.clipboardSrv.copyFromInputElement(this.targetElm), this.targetElm.value, event);
      } else if (this.cbContent) {
        this.handleResult(this.clipboardSrv.copyFromContent(this.cbContent, this.container), this.cbContent, event);
      }
    }
    /**
     * Fires an event based on the copy operation result.
     * @param succeeded
     */

  }, {
    key: "handleResult",
    value: function handleResult(succeeded, copiedContent, event) {
      var response = {
        isSuccess: succeeded,
        event: event
      };

      if (succeeded) {
        response = Object.assign(response, {
          content: copiedContent,
          successMessage: this.cbSuccessMsg
        });
        this.cbOnSuccess.emit(response);
      } else {
        this.cbOnError.emit(response);
      }

      this.clipboardSrv.pushCopyResponse(response);
    }
  }]);

  return ClipboardDirective;
}();

ClipboardDirective.ɵfac = function ClipboardDirective_Factory(t) {
  return new (t || ClipboardDirective)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](ClipboardService));
};

ClipboardDirective.ɵdir = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineDirective"]({
  type: ClipboardDirective,
  selectors: [["", "ngxClipboard", ""]],
  hostBindings: function ClipboardDirective_HostBindings(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵlistener"]("click", function ClipboardDirective_click_HostBindingHandler($event) {
        return ctx.onClick($event.target);
      });
    }
  },
  inputs: {
    targetElm: ["ngxClipboard", "targetElm"],
    container: "container",
    cbContent: "cbContent",
    cbSuccessMsg: "cbSuccessMsg"
  },
  outputs: {
    cbOnSuccess: "cbOnSuccess",
    cbOnError: "cbOnError"
  }
});

ClipboardDirective.ctorParameters = function () {
  return [{
    type: ClipboardService
  }];
};

Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__decorate"])([Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Input"])('ngxClipboard')], ClipboardDirective.prototype, "targetElm", void 0);

Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__decorate"])([Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Input"])()], ClipboardDirective.prototype, "container", void 0);

Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__decorate"])([Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Input"])()], ClipboardDirective.prototype, "cbContent", void 0);

Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__decorate"])([Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Input"])()], ClipboardDirective.prototype, "cbSuccessMsg", void 0);

Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__decorate"])([Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Output"])()], ClipboardDirective.prototype, "cbOnSuccess", void 0);

Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__decorate"])([Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["Output"])()], ClipboardDirective.prototype, "cbOnError", void 0);

Object(tslib__WEBPACK_IMPORTED_MODULE_2__["__decorate"])([Object(_angular_core__WEBPACK_IMPORTED_MODULE_4__["HostListener"])('click', ['$event.target'])], ClipboardDirective.prototype, "onClick", null);

var ClipboardIfSupportedDirective = /*#__PURE__*/function () {
  function ClipboardIfSupportedDirective(_clipboardService, _viewContainerRef, _templateRef) {
    Object(_Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_classCallCheck__WEBPACK_IMPORTED_MODULE_0__["default"])(this, ClipboardIfSupportedDirective);

    this._clipboardService = _clipboardService;
    this._viewContainerRef = _viewContainerRef;
    this._templateRef = _templateRef;
  }

  Object(_Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_createClass__WEBPACK_IMPORTED_MODULE_1__["default"])(ClipboardIfSupportedDirective, [{
    key: "ngOnInit",
    value: function ngOnInit() {
      if (this._clipboardService.isSupported) {
        this._viewContainerRef.createEmbeddedView(this._templateRef);
      }
    }
  }]);

  return ClipboardIfSupportedDirective;
}();

ClipboardIfSupportedDirective.ɵfac = function ClipboardIfSupportedDirective_Factory(t) {
  return new (t || ClipboardIfSupportedDirective)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](ClipboardService), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_angular_core__WEBPACK_IMPORTED_MODULE_4__["ViewContainerRef"]), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_angular_core__WEBPACK_IMPORTED_MODULE_4__["TemplateRef"]));
};

ClipboardIfSupportedDirective.ɵdir = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineDirective"]({
  type: ClipboardIfSupportedDirective,
  selectors: [["", "ngxClipboardIfSupported", ""]]
});

ClipboardIfSupportedDirective.ctorParameters = function () {
  return [{
    type: ClipboardService
  }, {
    type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["ViewContainerRef"]
  }, {
    type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["TemplateRef"]
  }];
};

var ClipboardModule = function ClipboardModule() {
  Object(_Users_valedamasco_Documents_DA2_Obligatorio_Damasco_Gomez_Front_UruguayNatrualWeb_node_modules_angular_devkit_build_angular_node_modules_babel_runtime_helpers_esm_classCallCheck__WEBPACK_IMPORTED_MODULE_0__["default"])(this, ClipboardModule);
};

ClipboardModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({
  type: ClipboardModule
});
ClipboardModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({
  factory: function ClipboardModule_Factory(t) {
    return new (t || ClipboardModule)();
  },
  imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_3__["CommonModule"]]]
});
/*@__PURE__*/

(function () {
  _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵsetClassMetadata"](ClipboardService, [{
    type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Injectable"],
    args: [{
      providedIn: 'root'
    }]
  }], function () {
    return [{
      type: undefined,
      decorators: [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Inject"],
        args: [_angular_common__WEBPACK_IMPORTED_MODULE_3__["DOCUMENT"]]
      }]
    }, {
      type: undefined,
      decorators: [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Optional"]
      }, {
        type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Inject"],
        args: [ngx_window_token__WEBPACK_IMPORTED_MODULE_5__["WINDOW"]]
      }]
    }];
  }, null);
})();
/*@__PURE__*/


(function () {
  _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵsetClassMetadata"](ClipboardDirective, [{
    type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Directive"],
    args: [{
      selector: '[ngxClipboard]'
    }]
  }], function () {
    return [{
      type: ClipboardService
    }];
  }, {
    cbOnSuccess: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Output"]
    }],
    cbOnError: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Output"]
    }],
    onClick: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["HostListener"],
      args: ['click', ['$event.target']]
    }],
    targetElm: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Input"],
      args: ['ngxClipboard']
    }],
    container: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Input"]
    }],
    cbContent: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Input"]
    }],
    cbSuccessMsg: [{
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Input"]
    }]
  });
})();
/*@__PURE__*/


(function () {
  _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵsetClassMetadata"](ClipboardIfSupportedDirective, [{
    type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["Directive"],
    args: [{
      selector: '[ngxClipboardIfSupported]'
    }]
  }], function () {
    return [{
      type: ClipboardService
    }, {
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["ViewContainerRef"]
    }, {
      type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["TemplateRef"]
    }];
  }, null);
})();

(function () {
  (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](ClipboardModule, {
    declarations: function declarations() {
      return [ClipboardDirective, ClipboardIfSupportedDirective];
    },
    imports: function imports() {
      return [_angular_common__WEBPACK_IMPORTED_MODULE_3__["CommonModule"]];
    },
    exports: function exports() {
      return [ClipboardDirective, ClipboardIfSupportedDirective];
    }
  });
})();
/*@__PURE__*/


(function () {
  _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵsetClassMetadata"](ClipboardModule, [{
    type: _angular_core__WEBPACK_IMPORTED_MODULE_4__["NgModule"],
    args: [{
      imports: [_angular_common__WEBPACK_IMPORTED_MODULE_3__["CommonModule"]],
      declarations: [ClipboardDirective, ClipboardIfSupportedDirective],
      exports: [ClipboardDirective, ClipboardIfSupportedDirective]
    }]
  }], null, null);
})();
/*
 * Public API Surface of ngx-clipboard
 */

/**
 * Generated bundle index. Do not edit.
 */




/***/ }),

/***/ "EMQA":
/*!******************************************************************************!*\
  !*** ./src/app/pages/category/category-editor/category-editor.component.css ***!
  \******************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = (".container-fluid.mt--7{\n  margin-top: -26rem!important;\n}\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvY2F0ZWdvcnkvY2F0ZWdvcnktZWRpdG9yL2NhdGVnb3J5LWVkaXRvci5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsNEJBQTRCO0FBQzlCIiwiZmlsZSI6InNyYy9hcHAvcGFnZXMvY2F0ZWdvcnkvY2F0ZWdvcnktZWRpdG9yL2NhdGVnb3J5LWVkaXRvci5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmNvbnRhaW5lci1mbHVpZC5tdC0tN3tcbiAgbWFyZ2luLXRvcDogLTI2cmVtIWltcG9ydGFudDtcbn1cbiJdfQ== */");

/***/ }),

/***/ "ENuD":
/*!*************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component.html ***!
  \*************************************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header bg-gradient-danger pb-8 pt-5 pt-md-8\">\n    <div class=\"container-fluid\">\n        <div class=\"header-body\">\n            <!-- Card stats -->\n            <div class=\"row\">\n\n                <div class=\"card card-stats mb-4 mb-xl-0\">\n                    <div class=\"row\">\n                        <div class=\"col\">\n                            <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\" class=\"bg-warning btn btn-rounded bg-warning text-white shadow\" ngxClipboard (cbOnSuccess)=\"copy = 'air-baloon'\" routerLink=\"/tourist-points/tourist-point-editor/new\">\n                  Add Tourist Point\n                </button>\n                        </div>\n                    </div>\n                </div>\n\n            </div>\n        </div>\n    </div>\n</div>\n<!-- Page content -->\n<div class=\"container-fluid mt--7\">\n    <app-tourist-points-table></app-tourist-points-table>\n</div>");

/***/ }),

/***/ "G9Dd":
/*!****************************************************************!*\
  !*** ./src/app/pages/user-profile/user-profile.component.scss ***!
  \****************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = (".errorMessage {\n  font-weight: bold;\n  color: red;\n}\n\n.successMessage {\n  font-weight: bold;\n  color: green;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvdXNlci1wcm9maWxlL3VzZXItcHJvZmlsZS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNFLGlCQUFBO0VBQ0EsVUFBQTtBQUNGOztBQUNBO0VBQ0UsaUJBQUE7RUFDQSxZQUFBO0FBRUYiLCJmaWxlIjoic3JjL2FwcC9wYWdlcy91c2VyLXByb2ZpbGUvdXNlci1wcm9maWxlLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmVycm9yTWVzc2FnZXtcbiAgZm9udC13ZWlnaHQ6IGJvbGQ7XG4gIGNvbG9yOiByZWQ7XG59XG4uc3VjY2Vzc01lc3NhZ2V7XG4gIGZvbnQtd2VpZ2h0OiBib2xkO1xuICBjb2xvcjogZ3JlZW47XG59XG4iXX0= */");

/***/ }),

/***/ "G9k0":
/*!**************************************************************!*\
  !*** ./src/app/pages/user-profile/user-profile.component.ts ***!
  \**************************************************************/
/*! exports provided: UserProfileComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserProfileComponent", function() { return UserProfileComponent; });
/* harmony import */ var _raw_loader_user_profile_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./user-profile.component.html */ "Ddk7");
/* harmony import */ var _user_profile_component_scss__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./user-profile.component.scss */ "G9Dd");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var src_app_services_persons_person_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/persons/person.service */ "f7Y7");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var UserProfileComponent = /** @class */ (function () {
    function UserProfileComponent(userService) {
        this.userService = userService;
        this.user = {};
        this.persons = [];
        this.id = 0;
        this.errorMessageBackend = '';
        this.email = '';
        this.updateMessage = '';
        this.errorMessageEndpoint = '';
    }
    UserProfileComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.email = localStorage.getItem('email');
        this.userService.getAll()
            .subscribe(function (personResponse) {
            _this.persons = personResponse;
            _this.getPersonWithMail();
            localStorage.setItem('name', _this.user.name);
        }, function (catchError) {
            _this.errorMessageEndpoint = catchError.error + ', fix it and try again';
        });
    };
    UserProfileComponent.prototype.updateData = function () {
        var _this = this;
        var basicInfo = this.createModel(this.user);
        this.userService.update(this.user.id, basicInfo)
            .subscribe(function (personResponse) {
            _this.user = personResponse;
            localStorage.setItem('name', _this.user.name);
            _this.updateMessage = 'Update sucessfully!';
        }, function (catchError) {
            _this.errorMessageEndpoint = catchError.error + ', fix it and try again';
        });
    };
    UserProfileComponent.prototype.createModel = function (user) {
        var modelBase = {};
        modelBase.name = user.name;
        modelBase.email = user.email;
        modelBase.password = user.password;
        return modelBase;
    };
    UserProfileComponent.prototype.getPersonWithMail = function () {
        var _this = this;
        this.user = this.persons.find(function (x) { return x.email == _this.email; });
    };
    UserProfileComponent.ctorParameters = function () { return [
        { type: src_app_services_persons_person_service__WEBPACK_IMPORTED_MODULE_3__["PersonService"] }
    ]; };
    UserProfileComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-user-profile',
            template: _raw_loader_user_profile_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_user_profile_component_scss__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [src_app_services_persons_person_service__WEBPACK_IMPORTED_MODULE_3__["PersonService"]])
    ], UserProfileComponent);
    return UserProfileComponent;
}());



/***/ }),

/***/ "GC7X":
/*!*********************************************************************!*\
  !*** ./src/app/pages/house/house-editor/house-editor.component.css ***!
  \*********************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = (".container-fluid.mt--7{\n  margin-top: -28rem!important;\n}\n.errorMessage{\n  font-weight: bold;\n  color: red;\n}\n.successMessage{\n  font-weight: bold;\n  color: green;\n}\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvaG91c2UvaG91c2UtZWRpdG9yL2hvdXNlLWVkaXRvci5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsNEJBQTRCO0FBQzlCO0FBQ0E7RUFDRSxpQkFBaUI7RUFDakIsVUFBVTtBQUNaO0FBQ0E7RUFDRSxpQkFBaUI7RUFDakIsWUFBWTtBQUNkIiwiZmlsZSI6InNyYy9hcHAvcGFnZXMvaG91c2UvaG91c2UtZWRpdG9yL2hvdXNlLWVkaXRvci5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmNvbnRhaW5lci1mbHVpZC5tdC0tN3tcbiAgbWFyZ2luLXRvcDogLTI4cmVtIWltcG9ydGFudDtcbn1cbi5lcnJvck1lc3NhZ2V7XG4gIGZvbnQtd2VpZ2h0OiBib2xkO1xuICBjb2xvcjogcmVkO1xufVxuLnN1Y2Nlc3NNZXNzYWdle1xuICBmb250LXdlaWdodDogYm9sZDtcbiAgY29sb3I6IGdyZWVuO1xufVxuIl19 */");

/***/ }),

/***/ "IqXj":
/*!*************************************************************!*\
  !*** ./src/app/layouts/admin-layout/admin-layout.module.ts ***!
  \*************************************************************/
/*! exports provided: AdminLayoutModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdminLayoutModule", function() { return AdminLayoutModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "tk/3");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "tyNb");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ "ofXK");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ "3Pt+");
/* harmony import */ var ngx_clipboard__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ngx-clipboard */ "Dvla");
/* harmony import */ var _admin_layout_routing__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./admin-layout.routing */ "qZ7x");
/* harmony import */ var _pages_user_profile_user_profile_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../pages/user-profile/user-profile.component */ "G9k0");
/* harmony import */ var _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @ng-bootstrap/ng-bootstrap */ "1kSV");
/* harmony import */ var src_app_pages_booking_bookings_table_bookings_table_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! src/app/pages/booking/bookings-table/bookings-table.component */ "UZZc");
/* harmony import */ var src_app_pages_booking_booking_dashboard_booking_dashboard_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! src/app/pages/booking/booking-dashboard/booking-dashboard.component */ "c2NT");
/* harmony import */ var src_app_pages_tourist_point_tourist_point_dashboard_tourist_point_dashboard_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component */ "paqg");
/* harmony import */ var src_app_pages_tourist_point_tourist_points_table_tourist_points_table_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! src/app/pages/tourist-point/tourist-points-table/tourist-points-table.component */ "1bUw");
/* harmony import */ var src_app_pages_booking_booking_editor_booking_editor_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! src/app/pages/booking/booking-editor/booking-editor.component */ "6ijC");
/* harmony import */ var src_app_pages_tourist_point_tourist_point_editor_tourist_point_editor_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component */ "LPe0");
/* harmony import */ var src_app_pages_category_category_editor_category_editor_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! src/app/pages/category/category-editor/category-editor.component */ "dKqQ");
/* harmony import */ var src_app_pages_category_category_dashboard_category_dashboard_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! src/app/pages/category/category-dashboard/category-dashboard.component */ "U96i");
/* harmony import */ var src_app_pages_category_category_table_category_table_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! src/app/pages/category/category-table/category-table.component */ "049Q");
/* harmony import */ var src_app_pages_house_house_dashboard_house_dashboard_component__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! src/app/pages/house/house-dashboard/house-dashboard.component */ "/v23");
/* harmony import */ var src_app_pages_house_house_table_house_table_component__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! src/app/pages/house/house-table/house-table.component */ "O3fv");
/* harmony import */ var src_app_pages_house_house_editor_house_editor_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! src/app/pages/house/house-editor/house-editor.component */ "X3Jt");
/* harmony import */ var src_app_pages_report_report_dashboard_report_dashboard_component__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! src/app/pages/report/report-dashboard/report-dashboard.component */ "ktt0");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






















var AdminLayoutModule = /** @class */ (function () {
    function AdminLayoutModule() {
    }
    AdminLayoutModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_3__["CommonModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forChild(_admin_layout_routing__WEBPACK_IMPORTED_MODULE_6__["AdminLayoutRoutes"]),
                _angular_forms__WEBPACK_IMPORTED_MODULE_4__["FormsModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClientModule"],
                _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_8__["NgbModule"],
                ngx_clipboard__WEBPACK_IMPORTED_MODULE_5__["ClipboardModule"]
            ],
            declarations: [
                _pages_user_profile_user_profile_component__WEBPACK_IMPORTED_MODULE_7__["UserProfileComponent"],
                src_app_pages_booking_bookings_table_bookings_table_component__WEBPACK_IMPORTED_MODULE_9__["BookingsTableComponent"],
                src_app_pages_booking_booking_dashboard_booking_dashboard_component__WEBPACK_IMPORTED_MODULE_10__["BookingDashboardComponent"],
                src_app_pages_booking_booking_editor_booking_editor_component__WEBPACK_IMPORTED_MODULE_13__["BookingEditorComponent"],
                src_app_pages_tourist_point_tourist_point_dashboard_tourist_point_dashboard_component__WEBPACK_IMPORTED_MODULE_11__["TouristPointDashboardComponent"],
                src_app_pages_tourist_point_tourist_points_table_tourist_points_table_component__WEBPACK_IMPORTED_MODULE_12__["TouristPointsTableComponent"],
                src_app_pages_tourist_point_tourist_point_editor_tourist_point_editor_component__WEBPACK_IMPORTED_MODULE_14__["TouristPointEditorComponent"],
                src_app_pages_category_category_editor_category_editor_component__WEBPACK_IMPORTED_MODULE_15__["CategoryEditorComponent"],
                src_app_pages_category_category_dashboard_category_dashboard_component__WEBPACK_IMPORTED_MODULE_16__["CategoryDashboardComponent"],
                src_app_pages_category_category_table_category_table_component__WEBPACK_IMPORTED_MODULE_17__["CategoryTableComponent"],
                src_app_pages_house_house_dashboard_house_dashboard_component__WEBPACK_IMPORTED_MODULE_18__["HouseDashboardComponent"],
                src_app_pages_house_house_table_house_table_component__WEBPACK_IMPORTED_MODULE_19__["HouseTableComponent"],
                src_app_pages_house_house_editor_house_editor_component__WEBPACK_IMPORTED_MODULE_20__["HouseEditorComponent"],
                src_app_pages_report_report_dashboard_report_dashboard_component__WEBPACK_IMPORTED_MODULE_21__["ReportDashboardComponent"]
            ]
        })
    ], AdminLayoutModule);
    return AdminLayoutModule;
}());



/***/ }),

/***/ "J4i+":
/*!*******************************************************************!*\
  !*** ./src/app/pages/house/house-table/house-table.component.css ***!
  \*******************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2hvdXNlL2hvdXNlLXRhYmxlL2hvdXNlLXRhYmxlLmNvbXBvbmVudC5jc3MifQ== */");

/***/ }),

/***/ "LPe0":
/*!********************************************************************************************!*\
  !*** ./src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component.ts ***!
  \********************************************************************************************/
/*! exports provided: TouristPointEditorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TouristPointEditorComponent", function() { return TouristPointEditorComponent; });
/* harmony import */ var _raw_loader_tourist_point_editor_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./tourist-point-editor.component.html */ "OlKK");
/* harmony import */ var _tourist_point_editor_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./tourist-point-editor.component.css */ "OESc");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "tyNb");
/* harmony import */ var src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/categories/category.service */ "TT9N");
/* harmony import */ var src_app_services_regions_region_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/regions/region.service */ "wx6Z");
/* harmony import */ var src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/services/touristpoints/touristpoint.service */ "Tscr");
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! src/environments/environment */ "AytR");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var TouristPointEditorComponent = /** @class */ (function () {
    function TouristPointEditorComponent(route, router, touristPointService, regionService, categoryService) {
        this.route = route;
        this.router = router;
        this.touristPointService = touristPointService;
        this.regionService = regionService;
        this.categoryService = categoryService;
        this.touristPoint = {};
        this.touristPointIn = {};
        this.regions = [];
        this.categories = [];
        this.touristPointId = 0;
        this.regionName = '';
        this.image = {};
        this.categoriesName = [];
        this.sourceImage = '';
        this.existTP = false;
        this.selectedFile = null;
        this.categoryNew = {};
        this.errorMessageBackend = '';
        this.updateMessage = '';
    }
    TouristPointEditorComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id = this.route.snapshot.paramMap.get('id');
        this.touristPointId = Number(id);
        this.touristPoint.categories = [];
        this.existTP = this.isExistentTouristPoint();
        if (this.existTP) {
            this.touristPointService.getBy(this.touristPointId)
                .subscribe(function (touristPointResponse) {
                _this.getBy(touristPointResponse);
            }, function (catchError) {
                _this.errorMessageBackend = catchError + ', fix it and try again';
            });
        }
        this.regionService.getAll()
            .subscribe(function (regionResponse) {
            _this.getAllRegions(regionResponse);
        }, function (catchError) {
            _this.errorMessageBackend = catchError + ', fix it and try again';
        });
        this.categoryService.getAll()
            .subscribe(function (categoryResponse) {
            _this.getAllCategories(categoryResponse);
        }, function (catchError) {
            _this.errorMessageBackend = catchError + ', fix it and try again';
        });
    };
    TouristPointEditorComponent.prototype.isExistentTouristPoint = function () {
        return !isNaN(this.touristPointId);
    };
    TouristPointEditorComponent.prototype.getBy = function (touristPointResponse) {
        this.touristPoint = touristPointResponse;
        this.image = this.touristPoint.image;
        this.sourceImage = src_environments_environment__WEBPACK_IMPORTED_MODULE_7__["environment"].imageURL + this.touristPoint.image.name;
        this.categoriesName = this.touristPoint.categories ? this.touristPoint.categories.map(function (category) { return category.name; })
            : [];
    };
    TouristPointEditorComponent.prototype.onSelectFile = function (event) {
        this.selectedFile = event.target.files[0];
        this.imageName = this.selectedFile.name;
        this.sourceImage = src_environments_environment__WEBPACK_IMPORTED_MODULE_7__["environment"].imageURL + this.imageName;
    };
    TouristPointEditorComponent.prototype.getAllRegions = function (regionResponse) {
        var _this = this;
        this.regions = regionResponse;
        var regionWithId = this.regions.find(function (x) { return x.id === _this.touristPoint.regionId; });
        this.regionName = regionWithId ? regionWithId.name : '';
    };
    TouristPointEditorComponent.prototype.getAllCategories = function (categoryResponse) {
        this.categories = categoryResponse;
    };
    TouristPointEditorComponent.prototype.addTouristPoint = function () {
        var _this = this;
        var touristPoint = this.touristPoint;
        var basicInfo = this.createModel(touristPoint);
        this.touristPointService.add(basicInfo)
            .subscribe(function (responseResponse) {
            _this.touristPointId = responseResponse.id;
            _this.sourceImage = src_environments_environment__WEBPACK_IMPORTED_MODULE_7__["environment"].imageURL + responseResponse.image.name;
            _this.router.navigateByUrl("/tourist-points/tourist-point-editor/" + _this.touristPointId);
            _this.existTP = true;
            _this.errorMessageBackend = '';
            _this.updateMessage = 'Added!';
        }, function (catchError) {
            _this.errorMessageBackend = catchError + ', fix it and try again';
        });
    };
    TouristPointEditorComponent.prototype.updateData = function () {
        var _this = this;
        var touristPoint = this.touristPoint;
        var basicInfo = this.createModel(touristPoint);
        this.touristPointService.update(this.touristPointId, basicInfo)
            .subscribe(function (responseResponse) {
            _this.sourceImage = src_environments_environment__WEBPACK_IMPORTED_MODULE_7__["environment"].imageURL + responseResponse.image.name;
            _this.updateMessage = 'Update is done!';
            _this.errorMessageBackend = '';
            _this.touristPoint = responseResponse;
        }, function (catchError) {
            _this.errorMessageBackend = catchError + ', fix it and try again';
        });
    };
    TouristPointEditorComponent.prototype.onChangeRegionName = function (event) {
        var _this = this;
        this.touristPoint.region = this.regions.find(function (x) { return _this.regionName == x.name; });
        this.touristPoint.regionId = this.touristPoint.region.id;
    };
    TouristPointEditorComponent.prototype.onChangeCategoryName = function (categoryName, index) {
        var categoryId = this.categories.find(function (x) { return x.name == categoryName; });
        this.touristPoint.categories[index] = categoryId;
    };
    TouristPointEditorComponent.prototype.addCategory = function () {
        this.touristPoint.categories = this.touristPoint.categories.concat(this.categoryNew);
    };
    TouristPointEditorComponent.prototype.deleteCategory = function () {
        this.touristPoint.categories.splice(-1, 1);
        this.categoriesName.splice(-1, 1);
    };
    TouristPointEditorComponent.prototype.createModel = function (touristPoint) {
        var modelBase = {};
        modelBase.categories = touristPoint.categories.map(function (x) { return x.id; });
        modelBase.description = touristPoint.description;
        modelBase.image = this.imageName;
        modelBase.name = touristPoint.name;
        modelBase.regionId = touristPoint.regionId;
        return modelBase;
    };
    TouristPointEditorComponent.ctorParameters = function () { return [
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"] },
        { type: src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_6__["TouristPointsService"] },
        { type: src_app_services_regions_region_service__WEBPACK_IMPORTED_MODULE_5__["RegionService"] },
        { type: src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_4__["CategoryService"] }
    ]; };
    TouristPointEditorComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-tourist-point-editor',
            template: _raw_loader_tourist_point_editor_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_tourist_point_editor_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"],
            _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
            src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_6__["TouristPointsService"],
            src_app_services_regions_region_service__WEBPACK_IMPORTED_MODULE_5__["RegionService"],
            src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_4__["CategoryService"]])
    ], TouristPointEditorComponent);
    return TouristPointEditorComponent;
}());



/***/ }),

/***/ "M/UZ":
/*!*****************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/house/house-table/house-table.component.html ***!
  \*****************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<!-- Table -->\n<div class=\"card shadow\">\n  <div class=\"card-header border-0\">\n    <h3 class=\"mb-0\">Houses</h3>\n  </div>\n  <div class=\"table-responsive\">\n    <table class=\"table align-items-center table-flush\">\n      <thead class=\"thead-light\">\n        <tr>\n          <th scope=\"col\">Name</th>\n        </tr>\n      </thead>\n      <tbody>\n        <tr *ngFor=\"let house of houses; let i = index\">\n          <th scope=\"row\">{{ house.name }}</th>\n          <td>\n            <button [routerLink]=\"['/houses/house-editor', house.id]\" type=\"button\" placement=\"top-center\"\n              triggers=\"hover focus click\" class=\"btn btn-rounded\" ngxClipboard\n              (cbOnSuccess)=\"copy = 'air-baloon'\">\n              Edit\n            </button>\n          </td>\n          <td>\n            <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n              class=\"btn btn-rounded btn-outline-danger\" ngxClipboard\n              (cbOnSuccess)=\"copy = 'air-baloon'\" (click)=\"delete(house)\">\n              Delete\n            </button>\n          </td>\n        </tr>\n      </tbody>\n    </table>\n  </div>\n</div>\n");

/***/ }),

/***/ "O3fv":
/*!******************************************************************!*\
  !*** ./src/app/pages/house/house-table/house-table.component.ts ***!
  \******************************************************************/
/*! exports provided: HouseTableComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HouseTableComponent", function() { return HouseTableComponent; });
/* harmony import */ var _raw_loader_house_table_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./house-table.component.html */ "M/UZ");
/* harmony import */ var _house_table_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./house-table.component.css */ "J4i+");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/houses/house.service */ "ccfc");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var HouseTableComponent = /** @class */ (function () {
    function HouseTableComponent(houseService) {
        this.houseService = houseService;
        this.houses = [];
        this.id = 0;
        this.errorBackend = '';
    }
    HouseTableComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.houseService.getAll()
            .subscribe(function (response) {
            _this.getAll(response);
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    HouseTableComponent.prototype.getAll = function (response) {
        this.houses = response;
    };
    HouseTableComponent.prototype.delete = function (event) {
        var _this = this;
        this.id = event.id;
        this.houseService.delete(this.id)
            .subscribe(function (response) {
            _this.delete(response);
            _this.houses = _this.houses.filter(function (item) { return item.id != _this.id; });
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    HouseTableComponent.ctorParameters = function () { return [
        { type: src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_3__["HouseService"] }
    ]; };
    HouseTableComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-house-table',
            template: _raw_loader_house_table_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_house_table_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_3__["HouseService"]])
    ], HouseTableComponent);
    return HouseTableComponent;
}());



/***/ }),

/***/ "OESc":
/*!*********************************************************************************************!*\
  !*** ./src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component.css ***!
  \*********************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("#categoriesTouristPoints select {\n  margin-bottom: 1rem;\n}\n.container-fluid.mt--7{\n  margin-top: -26rem!important;\n}\n.errorMessage{\n  font-weight: bold;\n  color: red;\n}\n.successMessage{\n  font-weight: bold;\n  color: green;\n}\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvdG91cmlzdC1wb2ludC90b3VyaXN0LXBvaW50LWVkaXRvci90b3VyaXN0LXBvaW50LWVkaXRvci5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsbUJBQW1CO0FBQ3JCO0FBQ0E7RUFDRSw0QkFBNEI7QUFDOUI7QUFDQTtFQUNFLGlCQUFpQjtFQUNqQixVQUFVO0FBQ1o7QUFDQTtFQUNFLGlCQUFpQjtFQUNqQixZQUFZO0FBQ2QiLCJmaWxlIjoic3JjL2FwcC9wYWdlcy90b3VyaXN0LXBvaW50L3RvdXJpc3QtcG9pbnQtZWRpdG9yL3RvdXJpc3QtcG9pbnQtZWRpdG9yLmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyIjY2F0ZWdvcmllc1RvdXJpc3RQb2ludHMgc2VsZWN0IHtcbiAgbWFyZ2luLWJvdHRvbTogMXJlbTtcbn1cbi5jb250YWluZXItZmx1aWQubXQtLTd7XG4gIG1hcmdpbi10b3A6IC0yNnJlbSFpbXBvcnRhbnQ7XG59XG4uZXJyb3JNZXNzYWdle1xuICBmb250LXdlaWdodDogYm9sZDtcbiAgY29sb3I6IHJlZDtcbn1cbi5zdWNjZXNzTWVzc2FnZXtcbiAgZm9udC13ZWlnaHQ6IGJvbGQ7XG4gIGNvbG9yOiBncmVlbjtcbn1cbiJdfQ== */");

/***/ }),

/***/ "OlKK":
/*!*******************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component.html ***!
  \*******************************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header pb-8 pt-5 pt-lg-8 d-flex align-items-center\" style=\"\n    min-height: 600px;\n    background-image: url(assets/img/theme/profile-cover.jpg);\n    background-size: cover;\n    background-position: center top;\n  \">\n  <!-- Mask -->\n  <span class=\"mask bg-gradient-danger opacity-8\"></span>\n</div>\n<div class=\"container-fluid mt--7\">\n  <div class=\"row\">\n    <div class=\"col-xl-8 order-xl-1\">\n      <div class=\"card bg-secondary shadow\">\n        <div class=\"card-header bg-white border-0\">\n          <div class=\"row align-items-center\">\n            <div class=\"col-4\">\n              <h3 class=\"mb-0\">Tourist Point</h3>\n              <span class=\"heading-small text-muted mb-4\">Id {{ touristPointId }}</span>\n            </div>\n            <div class=\"col-4 text-right\">\n              <p class=\"errorMessage\" id=\"error-message\">{{errorMessageBackend}}</p>\n              <p class=\"successMessage\" id=\"succes-messages\">{{updateMessage}}</p>\n            </div>\n            <div class=\"col-4 text-right\">\n              <a *ngIf=\"existTP\" (click)=\"updateData()\" class=\"btn btn-primary\">Update</a>\n              <a *ngIf=\"!existTP\" (click)=\"addTouristPoint()\" class=\"btn btn-primary\">Add</a>\n            </div>\n\n          </div>\n        </div>\n        <div class=\"card-body\">\n          <form>\n            <div class=\"pl-lg-4\">\n              <div class=\"row\">\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-username\">Name</label>\n                    <input type=\"text\" id=\"input-username\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"touristPoint.name\" name=\"nameT\" />\n                  </div>\n                </div>\n\n                <div class=\"col-12\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-description\">Description</label>\n                    <input type=\"text\" id=\"input-description\" size=\"50\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"touristPoint.description\" name=\"description\" />\n                  </div>\n                </div>\n\n                <div class=\"col-12\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-image\">Image</label>\n                    <input type=\"file\" id=\"input-image\" size=\"50\" class=\"form-control form-control-alternative\"\n                      (change)=\"onSelectFile($event)\" value=\"image.name\" />\n                    <img *ngIf=\"sourceImage\" src=\"{{sourceImage}}\" class=\"img-thumbnail img-circle\">\n                  </div>\n                </div>\n\n                <div class=\"col-9\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\">Region</label>\n                    <select class=\"custom-select form-control form-control-alternative\"\n                      [(ngModel)]=\"regionName\"\n                      name=\"regionName\" (change)=\"onChangeRegionName(regionName)\">\n                      <option disabled>Choose Region</option>\n                      <option *ngFor=\"let region of regions\">\n                        {{ region.name }}\n                      </option>\n                    </select>\n                  </div>\n                </div>\n\n                <div class=\"col-3\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"label-region-id\">Region Id</label>\n                    <input type=\"number\" id=\"input-region-id\" class=\"form-control form-control-alternative\"\n                      value=\"{{ touristPoint.regionId }}\" [(ngModel)]=\"touristPoint.regionId\" name=\"regionId\"\n                      disabled />\n                  </div>\n                </div>\n\n                <div class=\"col-12\">\n                  <div class=\"form-group\" id=\"categoriesTouristPoints\">\n                    <label class=\"form-control-label\" for=\"input-categories\">Categories</label>\n                    <select *ngFor=\"let categoryTouristPoint of touristPoint.categories;\n                        let i = index\" [(ngModel)]=\"categoriesName[i]\" name=\"{{ i }}\"\n                      (change)=\"onChangeCategoryName(categoriesName[i], i)\"\n                      class=\"custom-select form-control form-control-alternative\">\n                      <option>{{ categoryTouristPoint.name }}</option>\n                      <option disabled>Choose Category</option>\n                      <option *ngFor=\"let category of categories\" [ngValue]=\"category.name\">\n                        {{ category.name }}\n                      </option>\n                    </select>\n                  </div>\n                  <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                    class=\"btn btn-rounded btn-md btn-outline-warning\" ngxClipboard (click)=\"addCategory()\"\n                    (cbOnSuccess)=\"copy = 'air-baloon'\">\n                    Add Category\n                  </button>\n                  <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                    class=\"btn btn-rounded btn-outline-danger\" ngxClipboard (click)=\"deleteCategory()\"\n                    (cbOnSuccess)=\"copy = 'air-baloon'\">\n                    Delete Category\n                  </button>\n                </div>\n              </div>\n            </div>\n            <hr class=\"my-4\" />\n          </form>\n\n          <button routerLink=\"/tourist-points\" type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n            class=\"btn btn-rounded btn-outline-warning\" ngxClipboard (cbOnSuccess)=\"copy = 'air-baloon'\">\n            Go back\n          </button>\n        </div>\n      </div>\n    </div>\n  </div>\n</div>\n");

/***/ }),

/***/ "S24i":
/*!****************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/category/category-editor/category-editor.component.html ***!
  \****************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header pb-8 pt-5 pt-lg-8 d-flex align-items-center\" style=\"\n    min-height: 600px;\n    background-image: url(assets/img/theme/profile-cover.jpg);\n    background-size: cover;\n    background-position: center top;\n  \">\n  <!-- Mask -->\n  <span class=\"mask bg-gradient-danger opacity-8\"></span>\n</div>\n<div class=\"container-fluid mt--7\">\n  <div class=\"row\">\n    <div class=\"col-xl-8 order-xl-1\">\n      <div class=\"card bg-secondary shadow\">\n        <div class=\"card-header bg-white border-0\">\n          <div class=\"row align-items-center\">\n            <div class=\"col-4\">\n              <h3 class=\"mb-0\">Category</h3>\n              <span class=\"heading-small text-muted mb-4\">Id {{ categoryId }}</span>\n            </div>\n            <div class=\"col-4 text-right\">\n              <p class=\"errorMessage\" id=\"error-message\">{{errorMessage}}</p>\n              <p class=\"successMessage\" id=\"succes-messages\">{{updateMessage}}</p>\n            </div>\n            <div class=\"col-4 text-right\">\n              <button *ngIf=\"existentCategory\" type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                class=\"btn btn-rounded btn-outline-warning\" ngxClipboard\n                (cbOnSuccess)=\"copy = 'air-baloon'\" (click)=\"updateData(category)\">\n                Update\n              </button>\n              <button *ngIf=\"!existentCategory\" type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                class=\"btn btn-rounded btn-outline-warning\" ngxClipboard\n                (cbOnSuccess)=\"copy = 'air-baloon'\" (click)=\"addCategory(category)\">\n                Add Category\n              </button>\n            </div>\n          </div>\n        </div>\n        <div class=\"card-body\">\n          <form>\n            <div class=\"pl-lg-4\">\n              <div class=\"row\">\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-username\">Name</label>\n                    <input type=\"text\" id=\"input-username\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"category.name\" name=\"nameCategory\" />\n                  </div>\n                </div>\n\n                <div class=\"col-12\">\n                  <div class=\"form-group\" id=\"categoriesTouristPoints\">\n                    <label class=\"form-control-label\" for=\"input-categories\">Tourist Points</label>\n                    <select *ngFor=\"let touristPointCategory of category.touristPoints;\n                        let i = index\" [(ngModel)]=\"touristPointName[i]\" name=\"{{ i }}\" (change)=\"\n                        onChangeTouristPointName(touristPointName[i], i)\"\n                        class=\"mb-2 custom-select form-control form-control-alternative\">\n                      <option>{{ touristPoints.name }}</option>\n                      <option disabled>Choose Tourist point</option>\n                      <option *ngFor=\"let touristPoint of touristPoints\" [ngValue]=\"touristPoint.name\">\n                        {{ touristPoint.name }}\n                      </option>\n                    </select>\n                  </div>\n\n                  <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                    class=\"btn btn-rounded btn-outline-warning\" ngxClipboard\n                    (click)=\"addTouristPoint()\" (cbOnSuccess)=\"copy = 'air-baloon'\">\n                    Add Tourist Point\n                  </button>\n                  <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                    class=\"btn btn-rounded btn-outline-danger\" ngxClipboard\n                    (click)=\"deleteTouristPoint()\" (cbOnSuccess)=\"copy = 'air-baloon'\">\n                    Delete Tourist Point\n                  </button>\n                </div>\n              </div>\n            </div>\n            <hr class=\"my-4\" />\n          </form>\n\n          <button routerLink=\"/categories\" type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n            class=\"btn btn-rounded btn-outline-warning\" ngxClipboard\n            (cbOnSuccess)=\"copy = 'air-baloon'\">\n            Go back\n          </button>\n\n        </div>\n      </div>\n    </div>\n  </div>\n</div>\n");

/***/ }),

/***/ "U96i":
/*!***********************************************************************************!*\
  !*** ./src/app/pages/category/category-dashboard/category-dashboard.component.ts ***!
  \***********************************************************************************/
/*! exports provided: CategoryDashboardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CategoryDashboardComponent", function() { return CategoryDashboardComponent; });
/* harmony import */ var _raw_loader_category_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./category-dashboard.component.html */ "c3Pk");
/* harmony import */ var _category_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./category-dashboard.component.css */ "/2DJ");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var CategoryDashboardComponent = /** @class */ (function () {
    function CategoryDashboardComponent() {
    }
    CategoryDashboardComponent.prototype.ngOnInit = function () {
    };
    CategoryDashboardComponent.ctorParameters = function () { return []; };
    CategoryDashboardComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-category-dashboard',
            template: _raw_loader_category_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_category_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [])
    ], CategoryDashboardComponent);
    return CategoryDashboardComponent;
}());



/***/ }),

/***/ "UZZc":
/*!**************************************************************************!*\
  !*** ./src/app/pages/booking/bookings-table/bookings-table.component.ts ***!
  \**************************************************************************/
/*! exports provided: BookingsTableComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BookingsTableComponent", function() { return BookingsTableComponent; });
/* harmony import */ var _raw_loader_bookings_table_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./bookings-table.component.html */ "pnvp");
/* harmony import */ var _bookings_table_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./bookings-table.component.css */ "rM81");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var src_app_services_bookings_booking_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/bookings/booking.service */ "w8/2");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var BookingsTableComponent = /** @class */ (function () {
    function BookingsTableComponent(bookingService) {
        this.bookingService = bookingService;
        this.bookings = [];
        this.id = 0;
        this.errorBackend = '';
    }
    BookingsTableComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.bookingService.getAll()
            .subscribe(function (bookingResponse) {
            _this.getAll(bookingResponse);
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    BookingsTableComponent.prototype.getAll = function (bookingResponse) {
        this.bookings = bookingResponse;
    };
    BookingsTableComponent.prototype.delete = function (event) {
        var _this = this;
        this.id = event.id;
        this.bookingService.delete(this.id)
            .subscribe(function (bookingResponse) {
            _this.delete(bookingResponse);
            _this.bookings = _this.bookings.filter(function (item) { return item.id != _this.id; });
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    BookingsTableComponent.ctorParameters = function () { return [
        { type: src_app_services_bookings_booking_service__WEBPACK_IMPORTED_MODULE_3__["BookingService"] }
    ]; };
    BookingsTableComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-bookings-table',
            template: _raw_loader_bookings_table_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_bookings_table_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [src_app_services_bookings_booking_service__WEBPACK_IMPORTED_MODULE_3__["BookingService"]])
    ], BookingsTableComponent);
    return BookingsTableComponent;
}());



/***/ }),

/***/ "VfQe":
/*!**************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/category/category-table/category-table.component.html ***!
  \**************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<!-- Table -->\n<div class=\"card shadow\">\n  <div class=\"card-header border-0\">\n    <h3 class=\"mb-0\">Categories</h3>\n  </div>\n  <div class=\"table-responsive\">\n    <table class=\"table align-items-center table-flush\">\n      <thead class=\"thead-light\">\n        <tr>\n          <th scope=\"col\">Name</th>\n        </tr>\n      </thead>\n      <tbody>\n        <tr *ngFor=\"let category of categories; let i = index\">\n          <th scope=\"row\"> {{category.name}} </th>\n          <td>\n            <button [routerLink]=\"['/categories/category-editor',category.id]\" type=\"button\" placement=\"top-center\"\n              triggers=\"hover focus click\" class=\"btn btn-rounded\" ngxClipboard\n              (cbOnSuccess)=\"copy = 'air-baloon'\">\n              Edit\n            </button>\n          </td>\n          <td>\n            <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n              class=\"btn btn-rounded btn-outline-danger\" ngxClipboard\n              (cbOnSuccess)=\"copy = 'air-baloon'\" (click)=\"delete(category)\">\n              Delete\n            </button>\n          </td>\n        </tr>\n      </tbody>\n    </table>\n  </div>\n</div>\n");

/***/ }),

/***/ "X3Jt":
/*!********************************************************************!*\
  !*** ./src/app/pages/house/house-editor/house-editor.component.ts ***!
  \********************************************************************/
/*! exports provided: HouseEditorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HouseEditorComponent", function() { return HouseEditorComponent; });
/* harmony import */ var _raw_loader_house_editor_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./house-editor.component.html */ "kki9");
/* harmony import */ var _house_editor_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./house-editor.component.css */ "GC7X");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "tyNb");
/* harmony import */ var src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/houses/house.service */ "ccfc");
/* harmony import */ var src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/touristpoints/touristpoint.service */ "Tscr");
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/environments/environment */ "AytR");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var HouseEditorComponent = /** @class */ (function () {
    function HouseEditorComponent(route, router, houseService, touristPointService) {
        this.route = route;
        this.router = router;
        this.houseService = houseService;
        this.touristPointService = touristPointService;
        this.house = {};
        this.houseIn = {};
        this.touristPoints = [];
        this.houseId = 0;
        this.categoriesName = [];
        this.startsList = [];
        this.categories = [];
        this.imagesHouse = [];
        this.imagesNames = [];
        this.sourcesImages = [];
        this.updateMessage = '';
        this.errorBackend = '';
        this.addNewImage = false;
        this.areImages = false;
    }
    HouseEditorComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id = this.route.snapshot.paramMap.get('id');
        this.houseId = Number(id);
        this.startsList = [1, 2, 3, 4, 5];
        this.existentHouse = this.isExistentHouse();
        if (this.existentHouse) {
            this.houseService.getBy(this.houseId)
                .subscribe(function (houseResponse) {
                _this.getBy(houseResponse);
                _this.errorBackend = '';
            }, function (catchError) {
                _this.errorBackend = catchError + ', fix it and try again';
            });
        }
        this.touristPointService.getAll()
            .subscribe(function (touristPointResponse) {
            _this.getAllTouristPoints(touristPointResponse);
            _this.errorBackend = '';
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    HouseEditorComponent.prototype.isExistentHouse = function () {
        return !isNaN(this.houseId);
    };
    HouseEditorComponent.prototype.updateAvailable = function () {
        var _this = this;
        var basicInfo = this.createModel();
        this.houseService.updateAvailable(this.houseId, basicInfo)
            .subscribe(function (responseUpdate) {
            _this.updateMessage = 'Update done!';
            _this.house = responseUpdate;
            _this.addNewImage = false;
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    HouseEditorComponent.prototype.addHouse = function () {
        var _this = this;
        var basicInfo = this.createModel();
        console.log(basicInfo);
        this.houseService.add(basicInfo)
            .subscribe(function (responseAdd) {
            _this.updateMessage = 'Added!';
            _this.houseId = responseAdd.id;
            _this.router.navigateByUrl("/houses/house-editor/" + _this.houseId);
            _this.existentHouse = true;
            _this.errorBackend = '';
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    HouseEditorComponent.prototype.createModel = function () {
        var house = this.house;
        var modelBase = {};
        modelBase.name = house.name;
        modelBase.starts = house.starts;
        modelBase.pricePerNight = house.pricePerNight;
        modelBase.avaible = house.avaible;
        modelBase.address = house.address;
        modelBase.description = house.description;
        modelBase.phone = house.phone;
        modelBase.contact = house.contact;
        modelBase.touristPointId = house.touristPointId;
        modelBase.images = this.imagesNames;
        return modelBase;
    };
    HouseEditorComponent.prototype.getBy = function (houseResponse) {
        this.house = houseResponse;
        this.imagesNames = houseResponse.images ? houseResponse.images.map(function (x) { return x.name; }) : [];
        this.areImages = this.imagesNames.length > 0;
        this.sourcesImages = this.imagesNames ? this.imagesNames.map(function (x) { return src_environments_environment__WEBPACK_IMPORTED_MODULE_6__["environment"].imageURL + x; }) : [];
        this.touristPointName = houseResponse.touristPoint ? houseResponse.touristPoint.name : '';
    };
    HouseEditorComponent.prototype.getAllTouristPoints = function (touristPointResponse) {
        this.touristPoints = touristPointResponse;
    };
    HouseEditorComponent.prototype.onChangeTouristPointName = function (touristPointName) {
        var touristPoint = this.touristPoints.find(function (x) { return x.name == touristPointName; });
        this.house.touristPointId = touristPoint.id;
    };
    HouseEditorComponent.prototype.onSelectFile = function (event) {
        this.selectedFiles = event.target.files;
        for (var i = 0; i < this.selectedFiles.length; i++) {
            this.imagesNames.push(this.selectedFiles[i].name);
            this.sourcesImages.push(src_environments_environment__WEBPACK_IMPORTED_MODULE_6__["environment"].imageURL + this.selectedFiles[i].name);
        }
    };
    HouseEditorComponent.prototype.addImage = function () {
        this.addNewImage = true;
    };
    HouseEditorComponent.prototype.deleteImage = function () {
        this.house.images.splice(-1, 1);
        this.imagesNames.splice(-1, 1);
    };
    HouseEditorComponent.ctorParameters = function () { return [
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"] },
        { type: src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_4__["HouseService"] },
        { type: src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_5__["TouristPointsService"] }
    ]; };
    HouseEditorComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-house-editor',
            template: _raw_loader_house_editor_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_house_editor_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"],
            _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
            src_app_services_houses_house_service__WEBPACK_IMPORTED_MODULE_4__["HouseService"],
            src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_5__["TouristPointsService"]])
    ], HouseEditorComponent);
    return HouseEditorComponent;
}());



/***/ }),

/***/ "c2NT":
/*!********************************************************************************!*\
  !*** ./src/app/pages/booking/booking-dashboard/booking-dashboard.component.ts ***!
  \********************************************************************************/
/*! exports provided: BookingDashboardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BookingDashboardComponent", function() { return BookingDashboardComponent; });
/* harmony import */ var _raw_loader_booking_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./booking-dashboard.component.html */ "lIo6");
/* harmony import */ var _booking_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./booking-dashboard.component.css */ "nqEt");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var BookingDashboardComponent = /** @class */ (function () {
    function BookingDashboardComponent() {
    }
    BookingDashboardComponent.prototype.ngOnInit = function () {
    };
    BookingDashboardComponent.ctorParameters = function () { return []; };
    BookingDashboardComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-booking-dashboard',
            template: _raw_loader_booking_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_booking_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [])
    ], BookingDashboardComponent);
    return BookingDashboardComponent;
}());



/***/ }),

/***/ "c3Pk":
/*!**********************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/category/category-dashboard/category-dashboard.component.html ***!
  \**********************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header bg-gradient-danger pb-8 pt-5 pt-md-8\">\n  <div class=\"container-fluid\">\n    <div class=\"header-body\">\n      <!-- Card stats -->\n      <div class=\"row\">\n        <div class=\"col-xl-3 col-lg-6\">\n          <div class=\"card card-stats mb-4 mb-xl-0\">\n            <div class=\"card-body\">\n              <div class=\"row\">\n                <div class=\"col\">\n                  <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                    class=\"bg-warning btn btn-rounded bg-warning text-white shadow\"\n                    ngxClipboard  (cbOnSuccess)=\"copy = 'air-baloon'\"\n                    routerLink=\"/categories/category-editor/new\" >\n                    Add Category</button>\n                </div>\n              </div>\n            </div>\n          </div>\n        </div>\n      </div>\n    </div>\n  </div>\n</div>\n<!-- Page content -->\n<div class=\"container-fluid mt--7\">\n  <app-category-table></app-category-table>\n</div>\n");

/***/ }),

/***/ "c9im":
/*!***************************************************************************************************!*\
  !*** ./src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component.css ***!
  \***************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL3RvdXJpc3QtcG9pbnQvdG91cmlzdC1wb2ludC1kYXNoYm9hcmQvdG91cmlzdC1wb2ludC1kYXNoYm9hcmQuY29tcG9uZW50LmNzcyJ9 */");

/***/ }),

/***/ "dKqQ":
/*!*****************************************************************************!*\
  !*** ./src/app/pages/category/category-editor/category-editor.component.ts ***!
  \*****************************************************************************/
/*! exports provided: CategoryEditorComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CategoryEditorComponent", function() { return CategoryEditorComponent; });
/* harmony import */ var _raw_loader_category_editor_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./category-editor.component.html */ "S24i");
/* harmony import */ var _category_editor_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./category-editor.component.css */ "EMQA");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "tyNb");
/* harmony import */ var src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/categories/category.service */ "TT9N");
/* harmony import */ var src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/touristpoints/touristpoint.service */ "Tscr");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var newLocal = false;
var CategoryEditorComponent = /** @class */ (function () {
    function CategoryEditorComponent(route, router, categoryService, touristPointService) {
        this.route = route;
        this.router = router;
        this.categoryService = categoryService;
        this.touristPointService = touristPointService;
        this.category = {};
        this.touristPoints = [];
        this.categoryId = 0;
        this.touristPointName = [];
        this.newTouristPoint = {};
        this.existentCategory = false;
        this.updateMessage = '';
        this.errorBackend = '';
    }
    CategoryEditorComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id = this.route.snapshot.paramMap.get('id');
        this.categoryId = Number(id);
        this.existentCategory = this.isExistentCategory();
        if (this.existentCategory) {
            this.categoryService.getBy(this.categoryId)
                .subscribe(function (categoryResponse) {
                _this.getBy(categoryResponse);
            }, function (catchError) {
                _this.errorBackend = catchError + ', fix it and try again';
            });
        }
        this.touristPointService.getAll()
            .subscribe(function (touristPointResponse) {
            _this.getAllTouristPoints(touristPointResponse);
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
        this.category.touristPoints = [];
    };
    CategoryEditorComponent.prototype.isExistentCategory = function () {
        return !isNaN(this.categoryId);
    };
    CategoryEditorComponent.prototype.getBy = function (categoryResponse) {
        this.category = categoryResponse;
        this.touristPointName = this.category.touristPoints ? this.category.touristPoints.map(function (touristPonit) { return touristPonit.name; })
            : [];
    };
    CategoryEditorComponent.prototype.getAllTouristPoints = function (touristPointResponse) {
        this.touristPoints = touristPointResponse;
    };
    CategoryEditorComponent.prototype.updateData = function (category) {
        var _this = this;
        var basicInfo = this.createModel(category);
        this.categoryService.update(this.categoryId, basicInfo)
            .subscribe(function (responseAdd) {
            _this.updateMessage = 'Update sucessfully!';
            _this.category = responseAdd;
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    CategoryEditorComponent.prototype.addCategory = function (category) {
        var _this = this;
        var basicInfo = this.createModel(category);
        this.categoryService.add(basicInfo)
            .subscribe(function (responseAdd) {
            _this.categoryId = responseAdd.id;
            _this.router.navigateByUrl("/category/category-editor/" + _this.categoryId);
            _this.existentCategory = true;
            _this.updateMessage = 'Added sucessfully!';
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    CategoryEditorComponent.prototype.createModel = function (category) {
        var modelBase = {};
        modelBase.name = category.name;
        modelBase.touristPoints = category.touristPoints.map(function (x) { return x.id; });
        return modelBase;
    };
    CategoryEditorComponent.prototype.onChangeTouristPointName = function (touristPointName, index) {
        var touristPointId = this.touristPoints.find(function (x) { return x.name == touristPointName; });
        this.category.touristPoints[index] = touristPointId;
    };
    CategoryEditorComponent.prototype.addTouristPoint = function () {
        this.category.touristPoints = this.category.touristPoints.concat(this.newTouristPoint);
    };
    CategoryEditorComponent.prototype.deleteTouristPoint = function () {
        this.category.touristPoints.splice(-1, 1);
        this.touristPointName.splice(-1, 1);
    };
    CategoryEditorComponent.ctorParameters = function () { return [
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"] },
        { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"] },
        { type: src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_4__["CategoryService"] },
        { type: src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_5__["TouristPointsService"] }
    ]; };
    CategoryEditorComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-category-editor',
            template: _raw_loader_category_editor_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_category_editor_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"],
            _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
            src_app_services_categories_category_service__WEBPACK_IMPORTED_MODULE_4__["CategoryService"],
            src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_5__["TouristPointsService"]])
    ], CategoryEditorComponent);
    return CategoryEditorComponent;
}());



/***/ }),

/***/ "kki9":
/*!*******************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/house/house-editor/house-editor.component.html ***!
  \*******************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header pb-8 pt-5 pt-lg-8 d-flex align-items-center\" style=\"\n    min-height: 600px;\n    background-image: url(assets/img/theme/profile-cover.jpg);\n    background-size: cover;\n    background-position: center top;\n  \">\n  <!-- Mask -->\n  <span class=\"mask bg-gradient-danger opacity-8\"></span>\n</div>\n<div class=\"container-fluid mt--7\">\n  <div class=\"row\">\n    <div class=\"col-xl-8 order-xl-1\">\n      <div class=\"card bg-secondary shadow\">\n        <div class=\"card-header bg-white border-0\">\n          <div class=\"row align-items-center\">\n            <div class=\"col-4\">\n              <h3 class=\"mb-0\">House</h3>\n              <span class=\"heading-small text-muted mb-4\">Id {{ houseId }}</span>\n            </div>\n            <div class=\"col-4 text-right\">\n              <p class=\"errorMessage\" id=\"error-message\">{{errorBackend}}</p>\n              <p class=\"successMessage\" id=\"succes-messages\">{{updateMessage}}</p>\n            </div>\n            <div *ngIf=\"existentHouse\" class=\"col-4 text-right\">\n              <a (click)=\"updateAvailable()\" class=\"btn btn-primary\">Update</a>\n            </div>\n            <div *ngIf=\"!existentHouse\" class=\"col-4 text-right\">\n              <a (click)=\"addHouse()\" class=\"btn btn-primary\">Add</a>\n            </div>\n          </div>\n        </div>\n        <div class=\"card-body\">\n          <form>\n            <div class=\"pl-lg-4\">\n              <div class=\"row\">\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-username\">Name</label>\n                    <input type=\"text\" id=\"input-username\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"house.name\" name=\"nameHouse\" />\n                  </div>\n                </div>\n\n\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-pricePerNight\">Starts</label>\n                    <input type=\"number\" id=\"input-starts\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"house.starts\" name=\"starts\" />\n                  </div>\n                </div>\n\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-pricePerNight\">PricePerNight</label>\n                    <input type=\"number\" id=\"input-pricepernight\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"house.pricePerNight\" name=\"pricePerNigth\" />\n                  </div>\n                </div>\n\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\">Avaiable</label>\n                    <select class=\"custom-select form-control form-control-alternative\" [(ngModel)]=\"house.avaible\"\n                      name=\"house.avaible\">\n                      <option disabled>Choose Avaible</option>\n                      <option [ngValue]=\"true\">True</option>\n                      <option [ngValue]=\"false\">False</option>\n                    </select>\n                  </div>\n                </div>\n\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-adress\">Adress</label>\n                    <input type=\"text\" id=\"input-adress\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"house.address\" name=\"adress\" />\n                  </div>\n                </div>\n\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-description\">Description</label>\n                    <input type=\"text\" id=\"input-description\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"house.description\" name=\"description\" />\n                  </div>\n                </div>\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-phone\">Phone</label>\n                    <input type=\"number\" id=\"input-phone\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"house.phone\" name=\"phone\" />\n                  </div>\n                </div>\n\n                <div class=\"col-6\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\" for=\"input-contact\">Contact</label>\n                    <input type=\"text\" id=\"input-contact\" class=\"form-control form-control-alternative\"\n                      [(ngModel)]=\"house.contact\" name=\"contact\" />\n                  </div>\n                </div>\n\n                <div class=\"col-12\">\n                  <div class=\"form-group\">\n                    <label class=\"form-control-label\">Tourist Point</label>\n                    <select class=\"custom-select form-control form-control-alternative\"\n                      [(ngModel)]=\"touristPointName\"\n                      name=\"touristPointName\" (change)=\"onChangeTouristPointName(touristPointName)\">\n                      <option disabled>Choose Tourist Point</option>\n                      <option *ngFor=\"let touristPoint of touristPoints\">\n                        {{ touristPoint.name }}\n                      </option>\n                    </select>\n                  </div>\n                </div>\n\n\n\n                <div class=\"col-12\">\n                  <div class=\"form-group\" id=\"imagesTouristPoints\">\n                    <label class=\"form-control-label\" for=\"input-images\">Images</label>\n                    <div *ngFor=\"let image of imagesNames;\n                          let i = index\" [(ngModel)]=\"imagesNames[i]\" name=\"{{i}}\">\n                      <img src=\"{{sourcesImages[i]}}\" class=\"img-thumbnail img-circle\">\n                    </div>\n                    <input *ngIf=\"addNewImage\" type=\"file\" size=\"50\"\n                      class=\"form-control form-control-alternative\"\n                      (change)=\"onSelectFile($event)\" multiple/>\n                  </div>\n                  <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                    class=\"btn btn-rounded btn-md btn-outline-warning\" ngxClipboard (click)=\"addImage()\"\n                    (cbOnSuccess)=\"copy = 'air-baloon'\">\n                    Add Images\n                  </button>\n                  <button\n                    type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                    class=\"btn btn-rounded btn-outline-danger\" ngxClipboard (click)=\"deleteImage()\"\n                    (cbOnSuccess)=\"copy = 'air-baloon'\">\n                    Delete Image\n                  </button>\n                </div>\n\n              </div>\n            </div>\n            <hr class=\"my-4\" />\n          </form>\n          <button routerLink=\"/houses\" type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n            class=\"btn btn-rounded btn-outline-warning\" ngxClipboard\n            (cbOnSuccess)=\"copy = 'air-baloon'\">\n            Go back\n          </button>\n        </div>\n      </div>\n    </div>\n  </div>\n</div>\n");

/***/ }),

/***/ "ktt0":
/*!*****************************************************************************!*\
  !*** ./src/app/pages/report/report-dashboard/report-dashboard.component.ts ***!
  \*****************************************************************************/
/*! exports provided: ReportDashboardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ReportDashboardComponent", function() { return ReportDashboardComponent; });
/* harmony import */ var _raw_loader_report_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./report-dashboard.component.html */ "yev0");
/* harmony import */ var _report_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./report-dashboard.component.css */ "yMUY");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var src_app_services_reports_report_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/reports/report.service */ "fJYE");
/* harmony import */ var src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/touristpoints/touristpoint.service */ "Tscr");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var ReportDashboardComponent = /** @class */ (function () {
    function ReportDashboardComponent(touristPointService, reportService) {
        this.touristPointService = touristPointService;
        this.reportService = reportService;
        this.touristPoints = [];
        this.errorMessageDates = '';
        this.reports = [];
        this.errorBackend = '';
        this.noReportsMessage = '';
    }
    ReportDashboardComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.touristPointService.getAll()
            .subscribe(function (touristPointResponse) {
            _this.getAllTouristPoints(touristPointResponse);
        }, function (catchError) {
            _this.errorBackend = catchError + ', fix it and try again';
        });
    };
    ReportDashboardComponent.prototype.onChangeTouristPointName = function (touristPointName) {
        var touristPoint = this.touristPoints.find(function (x) { return x.name == touristPointName; });
        this.touristPointName = touristPoint.name;
        this.touristPointId = touristPoint.id;
    };
    ReportDashboardComponent.prototype.onChangeCheckIn = function (checkIn) {
        this.checkIParse = this.parseDate(checkIn);
    };
    ReportDashboardComponent.prototype.onChangeCheckOut = function (checkOut) {
        this.checkOutParse = this.parseDate(checkOut);
    };
    ReportDashboardComponent.prototype.parseDate = function (date) {
        var dates = date.split('-');
        var returnValue = '';
        if (dates.length == 3) {
            var year = dates.length == 3 ? dates[0] : '0';
            var month = dates.length == 3 ? dates[1] : '0';
            var day = dates.length == 3 ? dates[2] : '0';
            returnValue = day + '/' + month + '/' + year;
        }
        return returnValue;
    };
    ReportDashboardComponent.prototype.getAllTouristPoints = function (touristPointResponse) {
        this.touristPoints = touristPointResponse;
    };
    ReportDashboardComponent.prototype.getAllReports = function (reportResponse) {
        this.reports = reportResponse;
        this.showReports = reportResponse.length > 0;
        this.noReportsMessage = reportResponse.length > 0 ? '' : 'No reports for that data';
    };
    ReportDashboardComponent.prototype.getReportByTp = function () {
        var _this = this;
        var checkInDate = new Date(this.dateFrom);
        var checkOutDate = new Date(this.dateOut);
        if (checkInDate < checkOutDate) {
            this.reportService.GetHousesReportBy(this.touristPointId.toString(), this.checkIParse, this.checkOutParse)
                .subscribe(function (responseUpdate) {
                _this.getAllReports(responseUpdate);
            }, function (catchError) {
                _this.errorBackend = catchError + ', fix it and try again';
            });
        }
        else {
            this.errorMessageDates = 'Error in the dates, check them please';
        }
    };
    ReportDashboardComponent.ctorParameters = function () { return [
        { type: src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_4__["TouristPointsService"] },
        { type: src_app_services_reports_report_service__WEBPACK_IMPORTED_MODULE_3__["ReportService"] }
    ]; };
    ReportDashboardComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-report-dashboard',
            template: _raw_loader_report_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_report_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [src_app_services_touristpoints_touristpoint_service__WEBPACK_IMPORTED_MODULE_4__["TouristPointsService"], src_app_services_reports_report_service__WEBPACK_IMPORTED_MODULE_3__["ReportService"]])
    ], ReportDashboardComponent);
    return ReportDashboardComponent;
}());



/***/ }),

/***/ "lIo6":
/*!*******************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/booking/booking-dashboard/booking-dashboard.component.html ***!
  \*******************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header bg-gradient-danger pb-8 pt-5 pt-md-8\">\n  <div class=\"container-fluid\">\n    <div class=\"header-body\">\n      <!-- Card stats -->\n      <div class=\"row\">\n        <div class=\"col-xl-3 col-lg-6\">\n        </div>\n      </div>\n    </div>\n  </div>\n</div>\n<!-- Page content -->\n<div class=\"container-fluid mt--7\">\n  <app-bookings-table></app-bookings-table>\n</div>\n");

/***/ }),

/***/ "mzkM":
/*!************************************************************************************************************!*\
  !*** ./node_modules/ngx-clipboard/node_modules/ngx-window-token/__ivy_ngcc__/fesm2015/ngx-window-token.js ***!
  \************************************************************************************************************/
/*! exports provided: WINDOW */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WINDOW", function() { return WINDOW; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "fXoL");

var WINDOW = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["InjectionToken"]('WindowToken', typeof window !== 'undefined' && window.document ? {
  providedIn: 'root',
  factory: function factory() {
    return window;
  }
} : undefined);
/*
 * Public API Surface of ngx-window-token
 */

/**
 * Generated bundle index. Do not edit.
 */



/***/ }),

/***/ "nqEt":
/*!*********************************************************************************!*\
  !*** ./src/app/pages/booking/booking-dashboard/booking-dashboard.component.css ***!
  \*********************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2Jvb2tpbmcvYm9va2luZy1kYXNoYm9hcmQvYm9va2luZy1kYXNoYm9hcmQuY29tcG9uZW50LmNzcyJ9 */");

/***/ }),

/***/ "onE1":
/*!***************************************************************************!*\
  !*** ./src/app/pages/booking/booking-editor/booking-editor.component.css ***!
  \***************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = (".mt--7{\n  margin-top: -30rem !important;\n}\n.errorMessage{\n  font-weight: bold;\n  color: red;\n}\n.successMessage{\n  font-weight: bold;\n  color: green;\n}\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvYm9va2luZy9ib29raW5nLWVkaXRvci9ib29raW5nLWVkaXRvci5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsNkJBQTZCO0FBQy9CO0FBQ0E7RUFDRSxpQkFBaUI7RUFDakIsVUFBVTtBQUNaO0FBQ0E7RUFDRSxpQkFBaUI7RUFDakIsWUFBWTtBQUNkIiwiZmlsZSI6InNyYy9hcHAvcGFnZXMvYm9va2luZy9ib29raW5nLWVkaXRvci9ib29raW5nLWVkaXRvci5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLm10LS03e1xuICBtYXJnaW4tdG9wOiAtMzByZW0gIWltcG9ydGFudDtcbn1cbi5lcnJvck1lc3NhZ2V7XG4gIGZvbnQtd2VpZ2h0OiBib2xkO1xuICBjb2xvcjogcmVkO1xufVxuLnN1Y2Nlc3NNZXNzYWdle1xuICBmb250LXdlaWdodDogYm9sZDtcbiAgY29sb3I6IGdyZWVuO1xufVxuIl19 */");

/***/ }),

/***/ "paqg":
/*!**************************************************************************************************!*\
  !*** ./src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component.ts ***!
  \**************************************************************************************************/
/*! exports provided: TouristPointDashboardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TouristPointDashboardComponent", function() { return TouristPointDashboardComponent; });
/* harmony import */ var _raw_loader_tourist_point_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! raw-loader!./tourist-point-dashboard.component.html */ "ENuD");
/* harmony import */ var _tourist_point_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./tourist-point-dashboard.component.css */ "c9im");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var TouristPointDashboardComponent = /** @class */ (function () {
    function TouristPointDashboardComponent() {
    }
    TouristPointDashboardComponent.prototype.ngOnInit = function () {
    };
    TouristPointDashboardComponent.ctorParameters = function () { return []; };
    TouristPointDashboardComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
            selector: 'app-tourist-point-dashboard',
            template: _raw_loader_tourist_point_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
            styles: [_tourist_point_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
        }),
        __metadata("design:paramtypes", [])
    ], TouristPointDashboardComponent);
    return TouristPointDashboardComponent;
}());



/***/ }),

/***/ "pnvp":
/*!*************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/booking/bookings-table/bookings-table.component.html ***!
  \*************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<!-- Table -->\n<div class=\"card shadow\">\n  <div class=\"card-header border-0\">\n    <h3 class=\"mb-0\">Bookings</h3>\n  </div>\n  <div class=\"table-responsive\">\n    <table class=\"table align-items-center table-flush\">\n      <thead class=\"thead-light\">\n        <tr>\n          <th scope=\"col\">Name</th>\n          <th scope=\"col\">Email</th>\n          <th scope=\"col\">Code</th>\n          <th scope=\"col\">HouseId</th>\n          <th></th>\n          <th></th>\n        </tr>\n      </thead>\n      <tbody>\n        <tr *ngFor=\"let booking of bookings; let i = index\">\n          <th scope=\"row\"> {{booking.name}} </th>\n          <td>{{booking.email}}</td>\n          <td>{{booking.code}} </td>\n          <td>{{booking.houseId}}</td>\n          <td>\n              <button\n                [routerLink]=\"['/bookings/booking-editor',booking.id]\"\n                type=\"button\"\n                placement=\"top-center\"\n                triggers=\"hover focus click\"\n                class=\"btn btn-rounded\"\n                ngxClipboard\n                (cbOnSuccess) = \"copy = 'air-baloon'\">\n                Edit\n              </button>\n              </td>\n                <td>\n              <button\n                type=\"button\"\n                placement=\"top-center\"\n                triggers=\"hover focus click\"\n                class=\"btn btn-rounded btn-outline-danger\"\n                ngxClipboard\n                (cbOnSuccess) = \"copy = 'air-baloon'\"\n                (click)=\"delete(booking)\">\n                Delete\n              </button>\n          </td>\n        </tr>\n      </tbody>\n    </table>\n  </div>\n</div>\n");

/***/ }),

/***/ "qZ7x":
/*!**************************************************************!*\
  !*** ./src/app/layouts/admin-layout/admin-layout.routing.ts ***!
  \**************************************************************/
/*! exports provided: AdminLayoutRoutes */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdminLayoutRoutes", function() { return AdminLayoutRoutes; });
/* harmony import */ var _pages_user_profile_user_profile_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../pages/user-profile/user-profile.component */ "G9k0");
/* harmony import */ var src_app_pages_booking_booking_dashboard_booking_dashboard_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/pages/booking/booking-dashboard/booking-dashboard.component */ "c2NT");
/* harmony import */ var src_app_pages_booking_booking_editor_booking_editor_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/pages/booking/booking-editor/booking-editor.component */ "6ijC");
/* harmony import */ var src_app_pages_tourist_point_tourist_point_dashboard_tourist_point_dashboard_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/pages/tourist-point/tourist-point-dashboard/tourist-point-dashboard.component */ "paqg");
/* harmony import */ var src_app_pages_tourist_point_tourist_point_editor_tourist_point_editor_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/pages/tourist-point/tourist-point-editor/tourist-point-editor.component */ "LPe0");
/* harmony import */ var src_app_pages_category_category_dashboard_category_dashboard_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/pages/category/category-dashboard/category-dashboard.component */ "U96i");
/* harmony import */ var src_app_pages_category_category_editor_category_editor_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/pages/category/category-editor/category-editor.component */ "dKqQ");
/* harmony import */ var src_app_pages_house_house_editor_house_editor_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! src/app/pages/house/house-editor/house-editor.component */ "X3Jt");
/* harmony import */ var src_app_pages_house_house_dashboard_house_dashboard_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! src/app/pages/house/house-dashboard/house-dashboard.component */ "/v23");
/* harmony import */ var src_app_pages_report_report_dashboard_report_dashboard_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! src/app/pages/report/report-dashboard/report-dashboard.component */ "ktt0");
/* harmony import */ var src_app_pages_import_import_dashboard_import_dashboard_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! src/app/pages/import/import-dashboard/import-dashboard.component */ "0enL");
/* harmony import */ var src_app_pages_admin_admin_dashboard_admin_dashboard_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! src/app/pages/admin/admin-dashboard/admin-dashboard.component */ "M/Gj");
/* harmony import */ var src_app_pages_admin_admin_editor_admin_editor_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! src/app/pages/admin/admin-editor/admin-editor.component */ "VZEW");













var AdminLayoutRoutes = [
    { path: 'user-profile', component: _pages_user_profile_user_profile_component__WEBPACK_IMPORTED_MODULE_0__["UserProfileComponent"] },
    {
        path: 'bookings',
        children: [
            { path: '', component: src_app_pages_booking_booking_dashboard_booking_dashboard_component__WEBPACK_IMPORTED_MODULE_1__["BookingDashboardComponent"] },
            { path: 'booking-editor/:id', component: src_app_pages_booking_booking_editor_booking_editor_component__WEBPACK_IMPORTED_MODULE_2__["BookingEditorComponent"] }
        ]
    },
    {
        path: 'tourist-points',
        children: [
            { path: '', component: src_app_pages_tourist_point_tourist_point_dashboard_tourist_point_dashboard_component__WEBPACK_IMPORTED_MODULE_3__["TouristPointDashboardComponent"] },
            { path: 'tourist-point-editor/:id', component: src_app_pages_tourist_point_tourist_point_editor_tourist_point_editor_component__WEBPACK_IMPORTED_MODULE_4__["TouristPointEditorComponent"] },
        ]
    },
    {
        path: 'categories',
        children: [
            { path: '', component: src_app_pages_category_category_dashboard_category_dashboard_component__WEBPACK_IMPORTED_MODULE_5__["CategoryDashboardComponent"] },
            { path: 'category-editor/:id', component: src_app_pages_category_category_editor_category_editor_component__WEBPACK_IMPORTED_MODULE_6__["CategoryEditorComponent"] },
        ]
    },
    {
        path: 'houses', children: [
            { path: '', component: src_app_pages_house_house_dashboard_house_dashboard_component__WEBPACK_IMPORTED_MODULE_8__["HouseDashboardComponent"] },
            { path: 'house-editor/:id', component: src_app_pages_house_house_editor_house_editor_component__WEBPACK_IMPORTED_MODULE_7__["HouseEditorComponent"] },
        ]
    },
    { path: 'reports', component: src_app_pages_report_report_dashboard_report_dashboard_component__WEBPACK_IMPORTED_MODULE_9__["ReportDashboardComponent"] },
    { path: 'import', component: src_app_pages_import_import_dashboard_import_dashboard_component__WEBPACK_IMPORTED_MODULE_10__["ImportDashboardComponent"] },
    {
        path: 'admin',
        children: [
            { path: '', component: src_app_pages_admin_admin_dashboard_admin_dashboard_component__WEBPACK_IMPORTED_MODULE_11__["AdminDashboardComponent"] },
            { path: 'admin-editor/:id', component: src_app_pages_admin_admin_editor_admin_editor_component__WEBPACK_IMPORTED_MODULE_12__["AdminEditorComponent"] },
        ]
    },
];


/***/ }),

/***/ "rM81":
/*!***************************************************************************!*\
  !*** ./src/app/pages/booking/bookings-table/bookings-table.component.css ***!
  \***************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2Jvb2tpbmcvYm9va2luZ3MtdGFibGUvYm9va2luZ3MtdGFibGUuY29tcG9uZW50LmNzcyJ9 */");

/***/ }),

/***/ "vaMk":
/*!***************************************************!*\
  !*** ./src/app/services/states/states.service.ts ***!
  \***************************************************/
/*! exports provided: StatesService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StatesService", function() { return StatesService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "tk/3");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "qCKp");
/* harmony import */ var rxjs_internal_operators_catchError__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/internal/operators/catchError */ "rNzc");
/* harmony import */ var rxjs_internal_operators_catchError__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(rxjs_internal_operators_catchError__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/environments/environment */ "AytR");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var StatesService = /** @class */ (function () {
    function StatesService(http) {
        this.http = http;
        this.uri = src_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].baseURL + 'states';
    }
    StatesService.prototype.getAll = function () {
        return this.http.get(this.uri)
            .pipe(Object(rxjs_internal_operators_catchError__WEBPACK_IMPORTED_MODULE_3__["catchError"])(this.handleError));
    };
    StatesService.prototype.handleError = function (error) {
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(error.error);
    };
    StatesService.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"] }
    ]; };
    StatesService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])
    ], StatesService);
    return StatesService;
}());



/***/ }),

/***/ "xMCQ":
/*!****************************************************************************!*\
  !*** ./src/app/pages/category/category-table/category-table.component.css ***!
  \****************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2NhdGVnb3J5L2NhdGVnb3J5LXRhYmxlL2NhdGVnb3J5LXRhYmxlLmNvbXBvbmVudC5jc3MifQ== */");

/***/ }),

/***/ "yMUY":
/*!******************************************************************************!*\
  !*** ./src/app/pages/report/report-dashboard/report-dashboard.component.css ***!
  \******************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = (".errorMessage{\n  font-weight: bold;\n  color: red;\n}\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvcmVwb3J0L3JlcG9ydC1kYXNoYm9hcmQvcmVwb3J0LWRhc2hib2FyZC5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsaUJBQWlCO0VBQ2pCLFVBQVU7QUFDWiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL3JlcG9ydC9yZXBvcnQtZGFzaGJvYXJkL3JlcG9ydC1kYXNoYm9hcmQuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5lcnJvck1lc3NhZ2V7XG4gIGZvbnQtd2VpZ2h0OiBib2xkO1xuICBjb2xvcjogcmVkO1xufVxuIl19 */");

/***/ }),

/***/ "yQUv":
/*!***************************************************************************!*\
  !*** ./src/app/pages/house/house-dashboard/house-dashboard.component.css ***!
  \***************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2hvdXNlL2hvdXNlLWRhc2hib2FyZC9ob3VzZS1kYXNoYm9hcmQuY29tcG9uZW50LmNzcyJ9 */");

/***/ }),

/***/ "yev0":
/*!****************************************************************************************************************************************************************!*\
  !*** ./node_modules/@angular-devkit/build-angular/node_modules/raw-loader/dist/cjs.js!./src/app/pages/report/report-dashboard/report-dashboard.component.html ***!
  \****************************************************************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"header pb-8 pt-5 pt-lg-8 d-flex align-items-center\" style=\"\n    min-height: 600px;\n    background-image: url(assets/img/theme/profile-cover.jpg);\n    background-size: cover;\n    background-position: center top;\n  \">\n  <!-- Mask -->\n  <span class=\"mask bg-gradient-danger opacity-8\"></span>\n  <!-- Header container -->\n  <div class=\"container-fluid d-flex align-items-center\">\n    <div class=\"row\">\n      <div class=\"col-12\">\n        <h1 class=\"display-2 text-white\">Reports</h1>\n        <div>\n          <form class=\"form\">\n            <div class=\"container-fluid\">\n              <div class=\"row\">\n                <div class=\"col-12 mt-4\">\n                  <div class=\"card bg-secondary shadow\">\n                    <div class=\"card-header bg-white border-0\">\n                      <div class=\"row align-items-center\">\n\n\n                        <div class=\"col-6\">\n                          <div class=\"input-group align-items-center\">\n                            <label class=\"form-control-label m-0 mr-3\" for=\"input-date-in\">Check In:</label>\n                            <input type=\"date\" id=\"input-date-in\" [(ngModel)]=\"dateFrom\" name=\"checkIn\"\n                              class=\"form-control form-control-alternative\" (change)=\"onChangeCheckIn(dateFrom)\" />\n                          </div>\n                        </div>\n\n                        <div class=\"col-6\">\n                          <div class=\"input-group align-items-center\">\n                            <label class=\"form-control-label m-0 mr-3\" for=\"input-date-out\">Check Out:</label>\n                            <input type=\"date\" id=\"input-date-in\" [(ngModel)]=\"dateOut\" name=\"checkOut\"\n                              class=\"form-control form-control-alternative\" (change)=\"onChangeCheckOut(dateOut)\" />\n                          </div>\n                        </div>\n\n                        <div class=\"col-12\">\n                          <p class=\"errorMessage\">{{ errorMessageDates }}</p>\n                        </div>\n\n\n                        <div class=\"col-12\">\n                          <div class=\"form-group\" id=\"TouristPoints\">\n                            <label class=\"form-control-label\" for=\"input-tourist-point\">Tourist Point</label>\n                            <select [(ngModel)]=\"touristPointName\" name=\"touristPointName\" (change)=\"\n                                onChangeTouristPointName(touristPointName)\"\n                              class=\"custom-select form-control form-control-alternative\">\n                              <option disabled>Choose Tourist point</option>\n                              <option *ngFor=\"let touristPoint of touristPoints\" [ngValue]=\"touristPoint.name\">\n                                {{ touristPoint.name }}\n                              </option>\n                            </select>\n                          </div>\n                        </div>\n\n                        <div class=\"col-6\">\n                          <button type=\"button\" placement=\"top-center\" triggers=\"hover focus click\"\n                            class=\"bg-warning btn btn-rounded bg-warning text-white shadow\" ngxClipboard\n                            (cbOnSuccess)=\"copy = 'air-baloon'\" (click)=\"getReportByTp()\">\n                            Search Bookings\n                          </button>\n                        </div>\n                        <div class=\"col-6\">\n                          <p class=\"errorMessage\">{{ noReportsMessage }}</p>\n                        </div>\n                      </div>\n                    </div>\n                  </div>\n                </div>\n\n              </div>\n            </div>\n\n          </form>\n        </div>\n      </div>\n    </div>\n  </div>\n</div>\n\n<!-- Page content -->\n<div *ngIf=\"showReports\" class=\"container-fluid mt--7\">\n  <!-- Table -->\n  <div class=\"card shadow\">\n    <div class=\"card-header border-0\">\n      <h3 class=\"mb-0\">Bookings</h3>\n    </div>\n    <div class=\"table-responsive\">\n      <table class=\"table align-items-center table-flush\">\n        <thead class=\"thead-light\">\n          <tr>\n            <th scope=\"col\">House</th>\n            <th scope=\"col\">Cant Bookings</th>\n          </tr>\n        </thead>\n        <tbody>\n          <tr *ngFor=\"let report of reports; let i = index\">\n            <th scope=\"row\">{{ report.nameHouse }}</th>\n            <td>{{ report.cantBookings }}</td>\n          </tr>\n        </tbody>\n      </table>\n    </div>\n  </div>\n</div>\n");

/***/ }),

/***/ "zrvB":
/*!*********************************************************************************************!*\
  !*** ./src/app/pages/tourist-point/tourist-points-table/tourist-points-table.component.css ***!
  \*********************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL3RvdXJpc3QtcG9pbnQvdG91cmlzdC1wb2ludHMtdGFibGUvdG91cmlzdC1wb2ludHMtdGFibGUuY29tcG9uZW50LmNzcyJ9 */");

/***/ })

}]);
//# sourceMappingURL=layouts-admin-layout-admin-layout-module.js.map