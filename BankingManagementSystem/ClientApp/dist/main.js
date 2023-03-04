"use strict";
(self["webpackChunkBankingManagmentSystem_Angular"] = self["webpackChunkBankingManagmentSystem_Angular"] || []).push([["main"],{

/***/ 13914:
/*!*******************************!*\
  !*** ./src/app/app-events.ts ***!
  \*******************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppEvents": () => (/* binding */ AppEvents)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ 22560);


class AppEvents {
    constructor() {
        this.LoginEmitter = new _angular_core__WEBPACK_IMPORTED_MODULE_0__.EventEmitter();
        this.LogoutEmitter = new _angular_core__WEBPACK_IMPORTED_MODULE_0__.EventEmitter();
    }
}
AppEvents.ɵfac = function AppEvents_Factory(t) { return new (t || AppEvents)(); };
AppEvents.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: AppEvents, factory: AppEvents.ɵfac });


/***/ }),

/***/ 23054:
/*!*******************************!*\
  !*** ./src/app/app-routes.ts ***!
  \*******************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppRoutes": () => (/* binding */ AppRoutes)
/* harmony export */ });
var AppRoutes;
(function (AppRoutes) {
    AppRoutes["Root"] = "";
    AppRoutes["Transactions"] = "transactions";
    AppRoutes["UserAccount"] = "user-account";
    AppRoutes["Products"] = "products";
    AppRoutes["CustomerRelationships"] = "customer-relationships";
})(AppRoutes || (AppRoutes = {}));


/***/ }),

/***/ 90158:
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppRoutingModule": () => (/* binding */ AppRoutingModule)
/* harmony export */ });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ 60124);
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./login/login.component */ 98458);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 22560);




const routes = [
    { path: "", component: _login_login_component__WEBPACK_IMPORTED_MODULE_0__.LoginComponent },
    { path: "user-managment",
        loadChildren: () => Promise.resolve(/*! import() */).then(__webpack_require__.bind(__webpack_require__, /*! ./user-managment/user-managment.module */ 55209)).then((m) => m.UserManagmentModule) }
];
class AppRoutingModule {
}
AppRoutingModule.ɵfac = function AppRoutingModule_Factory(t) { return new (t || AppRoutingModule)(); };
AppRoutingModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineNgModule"]({ type: AppRoutingModule });
AppRoutingModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineInjector"]({ imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__.RouterModule.forRoot(routes), _angular_router__WEBPACK_IMPORTED_MODULE_2__.RouterModule] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵsetNgModuleScope"](AppRoutingModule, { imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__.RouterModule], exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__.RouterModule] }); })();


/***/ }),

/***/ 55041:
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppComponent": () => (/* binding */ AppComponent)
/* harmony export */ });
/* harmony import */ var _Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 71670);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ 90833);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ 78611);
/* harmony import */ var _app_routes__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./app-routes */ 23054);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _login_identity_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./login/identity.service */ 34077);
/* harmony import */ var _app_events__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app-events */ 13914);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 60124);
/* harmony import */ var ngx_cookie_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ngx-cookie-service */ 25502);
/* harmony import */ var _auth0_angular_jwt__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @auth0/angular-jwt */ 4467);
/* harmony import */ var devextreme_angular__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! devextreme-angular */ 17712);
/* harmony import */ var devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! devextreme-angular/ui/nested */ 18237);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/common */ 94666);
/* harmony import */ var _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! @ng-bootstrap/ng-bootstrap */ 34534);














function AppComponent_button_14_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](0, "button", 16);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵlistener"]("click", function AppComponent_button_14_Template_button_click_0_listener() {
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵrestoreView"](_r3);
      const ctx_r2 = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵnextContext"]();
      return _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵresetView"](ctx_r2.onLogOut());
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtext"](1, "Log out");
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]();
  }
}

function AppComponent_dx_menu_17_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](0, "dx-menu", 17)(1, "dxi-item", 18)(2, "dxi-item")(3, "a", 19);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtext"](4, "Users");
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](5, "dxi-item")(6, "a", 20);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtext"](7, "Roles");
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](8, "dxi-item")(9, "a", 21);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtext"](10, "Claims");
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()()()();
  }
}

class AppComponent {
  constructor(service, events, router, cookie, jwtHelper) {
    this.service = service;
    this.events = events;
    this.router = router;
    this.cookie = cookie;
    this.jwtHelper = jwtHelper;
    this.cancellationObservable = new rxjs__WEBPACK_IMPORTED_MODULE_5__.Observable();
    this.isUserLogin = false;
  }

  ngOnInit() {
    this.events.LoginEmitter.subscribe(x => this.isUserLogin = true);
    this.events.LogoutEmitter.subscribe(x => {
      this.cookie.delete('Token');
      this.isUserLogin = false;
    });

    if (this.cookie.get('Token') && !this.jwtHelper.isTokenExpired(this.cookie.get('Token'))) {
      this.isUserLogin = true;
    }
  }

  onLogOut() {
    var _this = this;

    return (0,_Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      yield (0,rxjs__WEBPACK_IMPORTED_MODULE_6__.lastValueFrom)(_this.service.logout());
      _this.isUserLogin = false;

      _this.router.navigate([_app_routes__WEBPACK_IMPORTED_MODULE_1__.AppRoutes.Root]);
    })();
  }

}

AppComponent.ɵfac = function AppComponent_Factory(t) {
  return new (t || AppComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_login_identity_service__WEBPACK_IMPORTED_MODULE_2__.IdentityService), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_app_events__WEBPACK_IMPORTED_MODULE_3__.AppEvents), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_7__.Router), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](ngx_cookie_service__WEBPACK_IMPORTED_MODULE_8__.CookieService), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_auth0_angular_jwt__WEBPACK_IMPORTED_MODULE_9__.JwtHelperService));
};

AppComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineComponent"]({
  type: AppComponent,
  selectors: [["app-root"]],
  decls: 22,
  vars: 2,
  consts: [[1, "d-flex", "flex-row", "h-100"], ["id", "outer0", 1, "d-flex", "flex-column", "flex-grow-1"], ["id", "one", 1, "d-flex", "flex-row", "justify-content-md-between", "bg-light"], [1, "navbar", "navbar-expand-lg"], [1, "container-fluid"], ["id", "navbarNav", 1, "collapse", "navbar-collapse"], [1, "navbar-nav"], [1, "nav-item"], ["src", "../assets/logo.png", 2, "width", "45px"], [1, "nav-link", "active"], [1, ""], ["type", "button", "class", "btn btn-link mb-3", 3, "click", 4, "ngIf"], ["id", "two", 1, "d-flex", "flex-row", "h-100"], ["orientation", "vertical", "class", "d-flex", 4, "ngIf"], [1, "d-flex", "flex-column", "flex-grow-1", "bg-info"], ["id", "three", 1, ""], ["type", "button", 1, "btn", "btn-link", "mb-3", 3, "click"], ["orientation", "vertical", 1, "d-flex"], ["text", "User Managment"], ["href", "user-managment/user-list"], ["href", "user-managment/roles"], ["href", "user-managment/claims"]],
  template: function AppComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](0, "div", 0)(1, "div", 1)(2, "div", 2)(3, "nav", 3)(4, "div", 4)(5, "div", 5)(6, "ul", 6)(7, "li", 7)(8, "a");
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](9, "img", 8);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](10, "li", 7)(11, "a", 9);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtext"](12, "Management system");
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()()()()()();
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](13, "div", 10);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtemplate"](14, AppComponent_button_14_Template, 2, 0, "button", 11);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](15, "div", 12)(16, "div");
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtemplate"](17, AppComponent_dx_menu_17_Template, 11, 0, "dx-menu", 13);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](18, "div", 14);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](19, "router-outlet");
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](20, "div", 15);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtext"](21, " Banking Managment System 2022 \u00A9 ");
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](14);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("ngIf", ctx.isUserLogin);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](3);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("ngIf", ctx.isUserLogin);
    }
  },
  dependencies: [devextreme_angular__WEBPACK_IMPORTED_MODULE_10__.DxMenuComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_11__.DxiItemComponent, _angular_common__WEBPACK_IMPORTED_MODULE_12__.NgIf, _angular_router__WEBPACK_IMPORTED_MODULE_7__.RouterOutlet, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_13__.NgbNavbar],
  styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhcHAuY29tcG9uZW50LnNjc3MifQ== */"]
});

/***/ }),

/***/ 36747:
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppModule": () => (/* binding */ AppModule)
/* harmony export */ });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/platform-browser */ 34497);
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app-routing.module */ 90158);
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./app.component */ 55041);
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./login/login.component */ 98458);
/* harmony import */ var _login_identity_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./login/identity.service */ 34077);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @angular/forms */ 2508);
/* harmony import */ var _common_services_http_api_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./common-services/http-api.service */ 21026);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/common/http */ 58987);
/* harmony import */ var _user_managment_user_managment_module__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./user-managment/user-managment.module */ 55209);
/* harmony import */ var _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @ng-bootstrap/ng-bootstrap */ 34534);
/* harmony import */ var _common_services_http_error_interceptor__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./common-services/http-error-interceptor */ 96008);
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! @angular/platform-browser/animations */ 37146);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ngx-toastr */ 94817);
/* harmony import */ var _app_events__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./app-events */ 13914);
/* harmony import */ var ngx_cookie_service__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ngx-cookie-service */ 25502);
/* harmony import */ var devextreme_angular__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! devextreme-angular */ 17712);
/* harmony import */ var devextreme_data_data_source__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! devextreme/data/data_source */ 56260);
/* harmony import */ var _auth0_angular_jwt__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @auth0/angular-jwt */ 4467);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/core */ 22560);




















class AppModule {
}
AppModule.ɵfac = function AppModule_Factory(t) { return new (t || AppModule)(); };
AppModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_9__["ɵɵdefineNgModule"]({ type: AppModule, bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_1__.AppComponent] });
AppModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_9__["ɵɵdefineInjector"]({ providers: [
        { provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_10__.HTTP_INTERCEPTORS,
            useClass: _common_services_http_error_interceptor__WEBPACK_IMPORTED_MODULE_6__.HttpErrorInterceptor,
            multi: true },
        { provide: _auth0_angular_jwt__WEBPACK_IMPORTED_MODULE_11__.JWT_OPTIONS, useValue: _auth0_angular_jwt__WEBPACK_IMPORTED_MODULE_11__.JWT_OPTIONS },
        _login_identity_service__WEBPACK_IMPORTED_MODULE_3__.IdentityService,
        _common_services_http_api_service__WEBPACK_IMPORTED_MODULE_4__.HttpApiService,
        _angular_common_http__WEBPACK_IMPORTED_MODULE_10__.HttpClient,
        _app_events__WEBPACK_IMPORTED_MODULE_7__.AppEvents,
        ngx_cookie_service__WEBPACK_IMPORTED_MODULE_12__.CookieService,
        _auth0_angular_jwt__WEBPACK_IMPORTED_MODULE_11__.JwtHelperService,
        devextreme_data_data_source__WEBPACK_IMPORTED_MODULE_8__["default"]
    ], imports: [devextreme_angular__WEBPACK_IMPORTED_MODULE_13__.DxMenuModule,
        _angular_platform_browser__WEBPACK_IMPORTED_MODULE_14__.BrowserModule,
        _angular_common_http__WEBPACK_IMPORTED_MODULE_10__.HttpClientModule,
        _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
        _angular_forms__WEBPACK_IMPORTED_MODULE_15__.FormsModule,
        _user_managment_user_managment_module__WEBPACK_IMPORTED_MODULE_5__.UserManagmentModule,
        _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_16__.NgbModule,
        _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_17__.BrowserAnimationsModule,
        ngx_toastr__WEBPACK_IMPORTED_MODULE_18__.ToastrModule.forRoot()] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_9__["ɵɵsetNgModuleScope"](AppModule, { declarations: [_app_component__WEBPACK_IMPORTED_MODULE_1__.AppComponent,
        _login_login_component__WEBPACK_IMPORTED_MODULE_2__.LoginComponent], imports: [devextreme_angular__WEBPACK_IMPORTED_MODULE_13__.DxMenuModule,
        _angular_platform_browser__WEBPACK_IMPORTED_MODULE_14__.BrowserModule,
        _angular_common_http__WEBPACK_IMPORTED_MODULE_10__.HttpClientModule,
        _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
        _angular_forms__WEBPACK_IMPORTED_MODULE_15__.FormsModule,
        _user_managment_user_managment_module__WEBPACK_IMPORTED_MODULE_5__.UserManagmentModule,
        _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_16__.NgbModule,
        _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_17__.BrowserAnimationsModule, ngx_toastr__WEBPACK_IMPORTED_MODULE_18__.ToastrModule] }); })();


/***/ }),

/***/ 21026:
/*!*****************************************************!*\
  !*** ./src/app/common-services/http-api.service.ts ***!
  \*****************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HttpApiService": () => (/* binding */ HttpApiService)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/operators */ 68951);
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/environments/environment */ 92340);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ 58987);




class HttpApiService {
    constructor(http) {
        this.http = http;
    }
    get(url, data, cancellationSubject) {
        let request = this.http.get(this.combineCompleteUrl(url, data));
        if (cancellationSubject) {
            //request = this.applyCancellationSubject(
            //    request,
            //    cancellationSubject
            //);
        }
        return request;
    }
    post(url, data, cancellationSubject) {
        let request = this.http.post(this.combineCompleteUrl(url), data);
        if (cancellationSubject) {
            //request = this.applyCancellationSubject(
            //    request,
            //    cancellationSubject
            //);
        }
        return request;
    }
    put(url, data, cancellationSubject) {
        let request = this.http.put(this.combineCompleteUrl(url), data);
        if (cancellationSubject) {
            request = this.applyCancellationSubject(request, cancellationSubject);
        }
        return request;
    }
    delete(url, data, cancellationSubject) {
        let request = this.http.delete(this.combineCompleteUrl(url, data));
        if (cancellationSubject) {
            request = this.applyCancellationSubject(request, cancellationSubject);
        }
        return request;
    }
    combineCompleteUrl(url, data = null) {
        let requestData = "";
        if (data) {
            if (typeof data === "object") {
                requestData = `?request=${encodeURIComponent(JSON.stringify(data))}`;
            }
            else {
                requestData = `/${data}`;
            }
        }
        return `${src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.apiUrl}/${url}${requestData}`;
    }
    applyCancellationSubject(request, cancellationSubject) {
        return request.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_1__.takeUntil)(cancellationSubject));
    }
}
HttpApiService.ɵfac = function HttpApiService_Factory(t) { return new (t || HttpApiService)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_3__.HttpClient)); };
HttpApiService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineInjectable"]({ token: HttpApiService, factory: HttpApiService.ɵfac });


/***/ }),

/***/ 96008:
/*!***********************************************************!*\
  !*** ./src/app/common-services/http-error-interceptor.ts ***!
  \***********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HttpErrorInterceptor": () => (/* binding */ HttpErrorInterceptor)
/* harmony export */ });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ 58987);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ 50635);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs */ 53158);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ 90833);
/* harmony import */ var _app_routes__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../app-routes */ 23054);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ngx-toastr */ 94817);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/router */ 60124);
/* harmony import */ var _app_events__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../app-events */ 13914);







class HttpErrorInterceptor {
    constructor(toastService, router, events) {
        this.toastService = toastService;
        this.router = router;
        this.events = events;
    }
    intercept(request, next) {
        return next.handle(request).pipe((0,rxjs__WEBPACK_IMPORTED_MODULE_2__.map)((event) => {
            if (event instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_3__.HttpResponse) {
                let applicationError = event.body?.applicationError;
                if (applicationError) {
                    this.toastService.warning(applicationError);
                    event = event.clone({ body: null });
                }
            }
            return event;
        }), (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.catchError)((err) => {
            if (err instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_3__.HttpErrorResponse) {
                if (err.status == 401 /* HttpStatusCode.Unauthorized */) {
                    this.events.LogoutEmitter.emit();
                    this.router.navigate([_app_routes__WEBPACK_IMPORTED_MODULE_0__.AppRoutes.Root]);
                }
                else {
                    this.toastService.error(err.error.applicationError);
                }
            }
            return new rxjs__WEBPACK_IMPORTED_MODULE_5__.Observable();
        }));
    }
}
HttpErrorInterceptor.ɵfac = function HttpErrorInterceptor_Factory(t) { return new (t || HttpErrorInterceptor)(_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵinject"](ngx_toastr__WEBPACK_IMPORTED_MODULE_7__.ToastrService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵinject"](_angular_router__WEBPACK_IMPORTED_MODULE_8__.Router), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵinject"](_app_events__WEBPACK_IMPORTED_MODULE_1__.AppEvents)); };
HttpErrorInterceptor.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineInjectable"]({ token: HttpErrorInterceptor, factory: HttpErrorInterceptor.ɵfac });


/***/ }),

/***/ 13514:
/*!**********************************************!*\
  !*** ./src/app/login/identity-api-routes.ts ***!
  \**********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "IdentityApiRoutes": () => (/* binding */ IdentityApiRoutes)
/* harmony export */ });
var IdentityApiRoutes;
(function (IdentityApiRoutes) {
    IdentityApiRoutes["Root"] = "identity";
    IdentityApiRoutes["Login"] = "login";
    IdentityApiRoutes["Logout"] = "logout";
})(IdentityApiRoutes || (IdentityApiRoutes = {}));


/***/ }),

/***/ 34077:
/*!*******************************************!*\
  !*** ./src/app/login/identity.service.ts ***!
  \*******************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "IdentityService": () => (/* binding */ IdentityService)
/* harmony export */ });
/* harmony import */ var _identity_api_routes__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./identity-api-routes */ 13514);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _common_services_http_api_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../common-services/http-api.service */ 21026);



class IdentityService {
    constructor(httpService) {
        this.httpService = httpService;
    }
    login(request, cancellationSubject) {
        return this.httpService.post(`${_identity_api_routes__WEBPACK_IMPORTED_MODULE_0__.IdentityApiRoutes.Root}/${_identity_api_routes__WEBPACK_IMPORTED_MODULE_0__.IdentityApiRoutes.Login}`, request, cancellationSubject);
    }
    logout() {
        return this.httpService.get(`${_identity_api_routes__WEBPACK_IMPORTED_MODULE_0__.IdentityApiRoutes.Root}/${_identity_api_routes__WEBPACK_IMPORTED_MODULE_0__.IdentityApiRoutes.Logout}`);
    }
}
IdentityService.ɵfac = function IdentityService_Factory(t) { return new (t || IdentityService)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵinject"](_common_services_http_api_service__WEBPACK_IMPORTED_MODULE_1__.HttpApiService)); };
IdentityService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineInjectable"]({ token: IdentityService, factory: IdentityService.ɵfac });


/***/ }),

/***/ 98458:
/*!******************************************!*\
  !*** ./src/app/login/login.component.ts ***!
  \******************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "LoginComponent": () => (/* binding */ LoginComponent)
/* harmony export */ });
/* harmony import */ var _Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 71670);
/* harmony import */ var _loginDto__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./loginDto */ 99);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ 90833);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ 78611);
/* harmony import */ var _user_managment_user_managment_routes__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../user-managment/user-managment-routes */ 63099);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _identity_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./identity.service */ 34077);
/* harmony import */ var _app_events__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../app-events */ 13914);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/router */ 60124);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/forms */ 2508);









class LoginComponent {
  constructor(service, events, router) {
    this.service = service;
    this.events = events;
    this.router = router;
    this.cancellationObservable = new rxjs__WEBPACK_IMPORTED_MODULE_5__.Observable();
    this.model = new _loginDto__WEBPACK_IMPORTED_MODULE_1__.LoginDto();
  }

  ngOnInit() {}

  onLogin() {
    var _this = this;

    return (0,_Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      var result = yield (0,rxjs__WEBPACK_IMPORTED_MODULE_6__.lastValueFrom)(_this.service.login(_this.model, _this.cancellationObservable));

      if (result) {
        _this.router.navigate([_user_managment_user_managment_routes__WEBPACK_IMPORTED_MODULE_2__.UserManagmentRoutes.Root, _user_managment_user_managment_routes__WEBPACK_IMPORTED_MODULE_2__.UserManagmentRoutes.UserList]);

        _this.events.LoginEmitter.emit();
      }
    })();
  }

}

LoginComponent.ɵfac = function LoginComponent_Factory(t) {
  return new (t || LoginComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdirectiveInject"](_identity_service__WEBPACK_IMPORTED_MODULE_3__.IdentityService), _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdirectiveInject"](_app_events__WEBPACK_IMPORTED_MODULE_4__.AppEvents), _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_8__.Router));
};

LoginComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineComponent"]({
  type: LoginComponent,
  selectors: [["app-login"]],
  decls: 23,
  vars: 2,
  consts: [[1, "container", "text-center", 2, "margin-top", "25px"], [1, "row", "justify-content-md-center"], [1, "col-md-auto"], [1, "card"], [1, "row", "justify-content-md-center", 2, "margin", "5px"], ["src", "../../assets/logo.png", 2, "width", "75px"], ["for", "userName", 1, "col-auto", "col-form-label"], [1, "col-auto"], ["type", "text", "name", "userName", "id", "userName", "placeholder", "User name", "required", "", 1, "form-control", 3, "ngModel", "ngModelChange"], ["for", "password", 1, "col-auto", "col-form-label"], ["type", "password", "id", "password", "name", "password", "placeholder", "Password", "required", "", 1, "form-control", 3, "ngModel", "ngModelChange"], [1, "col-auto", 2, "margin", "5px"], ["type", "submit", "name", "Login", 1, "btn", "btn-primary", "mb-3", 3, "click"], ["routerLink", "/user-managment/new-user"]],
  template: function LoginComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementStart"](0, "div", 0)(1, "div", 1)(2, "div", 2)(3, "div", 3)(4, "div", 4)(5, "a");
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelement"](6, "img", 5);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementStart"](7, "div", 4)(8, "label", 6);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵtext"](9, "Username");
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementStart"](10, "div", 7)(11, "input", 8);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵlistener"]("ngModelChange", function LoginComponent_Template_input_ngModelChange_11_listener($event) {
        return ctx.model.Username = $event;
      });
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementEnd"]()()();
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementStart"](12, "div", 4)(13, "label", 9);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵtext"](14, "Password");
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementStart"](15, "div", 7)(16, "input", 10);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵlistener"]("ngModelChange", function LoginComponent_Template_input_ngModelChange_16_listener($event) {
        return ctx.model.Password = $event;
      });
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementEnd"]()()();
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementStart"](17, "div", 11)(18, "button", 12);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵlistener"]("click", function LoginComponent_Template_button_click_18_listener() {
        return ctx.onLogin();
      });
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵtext"](19, "Login");
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementStart"](20, "div", 7)(21, "a", 13);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵtext"](22, "Create a new user");
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵelementEnd"]()()()()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵadvance"](11);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵproperty"]("ngModel", ctx.model.Username);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵadvance"](5);
      _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵproperty"]("ngModel", ctx.model.Password);
    }
  },
  dependencies: [_angular_router__WEBPACK_IMPORTED_MODULE_8__.RouterLinkWithHref, _angular_forms__WEBPACK_IMPORTED_MODULE_9__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_9__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_9__.RequiredValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_9__.NgModel],
  styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJsb2dpbi5jb21wb25lbnQuc2NzcyJ9 */"]
});

/***/ }),

/***/ 99:
/*!***********************************!*\
  !*** ./src/app/login/loginDto.ts ***!
  \***********************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "LoginDto": () => (/* binding */ LoginDto)
/* harmony export */ });
class LoginDto {
    constructor() {
        this.Username = "admin@irocbank.com";
        this.Password = "admin";
    }
}


/***/ }),

/***/ 17414:
/*!***************************************************************!*\
  !*** ./src/app/user-managment/new-user/new-user.component.ts ***!
  \***************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "NewUserComponent": () => (/* binding */ NewUserComponent)
/* harmony export */ });
/* harmony import */ var _Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 71670);
/* harmony import */ var _newUserDto__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./newUserDto */ 76265);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs */ 90833);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ 78611);
/* harmony import */ var src_app_app_routes__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/app-routes */ 23054);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _user_managment_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../user-managment.service */ 62083);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 60124);
/* harmony import */ var devextreme_angular__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! devextreme-angular */ 49889);
/* harmony import */ var devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! devextreme-angular/ui/nested */ 18237);









class NewUserComponent {
  constructor(service, router) {
    this.service = service;
    this.router = router;
    this.newUser = new _newUserDto__WEBPACK_IMPORTED_MODULE_1__.NewUserDto();
    this.cancellationObservable = new rxjs__WEBPACK_IMPORTED_MODULE_4__.Observable();
    this.registerButtonOptions = {
      text: 'Register',
      type: 'primary',
      useSubmitBehavior: true //onclick: this.createNewUser()

    };

    this.passwordComparison = () => this.newUser.password;
  }

  ngOnInit() {}

  createNewUser() {
    var _this = this;

    return (0,_Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      var result = (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.lastValueFrom)(_this.service.createNewUser(_this.newUser, _this.cancellationObservable));
      var b = yield result;

      if (b) {
        _this.router.navigate([src_app_app_routes__WEBPACK_IMPORTED_MODULE_2__.AppRoutes.Root]);
      }
    })();
  }

}

NewUserComponent.ɵfac = function NewUserComponent_Factory(t) {
  return new (t || NewUserComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](_user_managment_service__WEBPACK_IMPORTED_MODULE_3__.UserManagmentService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_7__.Router));
};

NewUserComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineComponent"]({
  type: NewUserComponent,
  selectors: [["app-new-user"]],
  decls: 17,
  vars: 3,
  consts: [[1, "long-title"], ["id", "new-user-form", 1, "row", "d-flex", "justify-content-center"], [1, "col-md-3"], [1, "form-container"], ["id", "form", 3, "colCount", "formData"], ["dataField", "userName"], ["type", "required", "message", "Username is required."], ["type", "email", "message", "Email pattern doesn't match."], ["dataField", "password"], ["type", "required", "message", "Password is required"], ["dataField", "confirmPassword"], ["type", "required", "message", "Confirm Password is required"], ["type", "compare", "message", "Don't compare", 3, "comparisonTarget"], ["type", "button", 1, "btn", "btn-primary", 3, "click"]],
  template: function NewUserComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](0, "div", 0)(1, "h3");
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtext"](2, "Create a new User");
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](3, "div", 1)(4, "div", 2)(5, "div", 3)(6, "dx-form", 4)(7, "dxi-item", 5);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](8, "dxi-validation-rule", 6)(9, "dxi-validation-rule", 7);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](10, "dxi-item", 8);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](11, "dxi-validation-rule", 9);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](12, "dxi-item", 10);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](13, "dxi-validation-rule", 11)(14, "dxi-validation-rule", 12);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](15, "button", 13);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵlistener"]("click", function NewUserComponent_Template_button_click_15_listener() {
        return ctx.createNewUser();
      });
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtext"](16, "Create user");
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]()()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](6);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("colCount", 1)("formData", ctx.newUser);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](8);
      _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("comparisonTarget", ctx.passwordComparison);
    }
  },
  dependencies: [devextreme_angular__WEBPACK_IMPORTED_MODULE_8__.DxFormComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_9__.DxiItemComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_9__.DxiValidationRuleComponent],
  styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJuZXctdXNlci5jb21wb25lbnQuc2NzcyJ9 */"]
});

/***/ }),

/***/ 76265:
/*!*******************************************************!*\
  !*** ./src/app/user-managment/new-user/newUserDto.ts ***!
  \*******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "NewUserDto": () => (/* binding */ NewUserDto)
/* harmony export */ });
class NewUserDto {
    constructor() {
        this.userName = "admin@admin.com";
        this.password = "1234";
        this.confirmPassword = "1234";
    }
}


/***/ }),

/***/ 85475:
/*!*********************************************************!*\
  !*** ./src/app/user-managment/roles/roles.component.ts ***!
  \*********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "RolesComponent": () => (/* binding */ RolesComponent)
/* harmony export */ });
/* harmony import */ var _Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 71670);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ 90833);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ 78611);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _user_managment_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../user-managment.service */ 62083);
/* harmony import */ var devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! devextreme-angular/ui/nested */ 18237);
/* harmony import */ var devextreme_angular__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! devextreme-angular */ 65821);






class RolesComponent {
  constructor(service) {
    this.service = service;
    this.cancellationObservable = new rxjs__WEBPACK_IMPORTED_MODULE_2__.Observable();
    this.roles = [];
  }

  ngOnInit() {
    var _this = this;

    return (0,_Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      _this.roles = yield (0,rxjs__WEBPACK_IMPORTED_MODULE_3__.lastValueFrom)(_this.service.getRolesList(_this.cancellationObservable));
    })();
  }

  saveRole(e, object) {
    return (0,_Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      console.log(e);
      console.log(object);
    })();
  }

}

RolesComponent.ɵfac = function RolesComponent_Factory(t) {
  return new (t || RolesComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_user_managment_service__WEBPACK_IMPORTED_MODULE_1__.UserManagmentService));
};

RolesComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineComponent"]({
  type: RolesComponent,
  selectors: [["app-roles"]],
  decls: 10,
  vars: 5,
  consts: [["height", "790px", "keyExpr", "id", "id", "usersList", 3, "dataSource", "showBorders"], [3, "enabled"], ["mode", "virtual"], [3, "allowAdding"], [3, "visible"], ["name", "addRowButton", "location", "center"], ["name", "searchPanel", "locateInMenu", "auto", "location", "center"], ["dataField", "name", "dataType", "string"]],
  template: function RolesComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](0, "div")(1, "dx-data-grid", 0);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](2, "dxo-load-panel", 1)(3, "dxo-scrolling", 2)(4, "dxo-editing", 3)(5, "dxo-search-panel", 4);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](6, "dxo-toolbar");
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](7, "dxi-item", 5)(8, "dxi-item", 6);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](9, "dxi-column", 7);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("dataSource", ctx.roles)("showBorders", true);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("enabled", true);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("allowAdding", true);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("visible", true);
    }
  },
  dependencies: [devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxiItemComponent, devextreme_angular__WEBPACK_IMPORTED_MODULE_6__.DxDataGridComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxiColumnComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoEditingComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoLoadPanelComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoScrollingComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoSearchPanelComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoToolbarComponent],
  styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJyb2xlcy5jb21wb25lbnQuc2NzcyJ9 */"]
});

/***/ }),

/***/ 56392:
/*!*****************************************************************!*\
  !*** ./src/app/user-managment/user-list/user-list.component.ts ***!
  \*****************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UserListComponent": () => (/* binding */ UserListComponent)
/* harmony export */ });
/* harmony import */ var _Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 71670);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ 90833);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ 78611);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _user_managment_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../user-managment.service */ 62083);
/* harmony import */ var devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! devextreme-angular/ui/nested */ 18237);
/* harmony import */ var devextreme_angular__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! devextreme-angular */ 65821);






class UserListComponent {
  constructor(service) {
    this.service = service;
    this.cancellationObservable = new rxjs__WEBPACK_IMPORTED_MODULE_2__.Observable();
    this.users = [];
  }

  ngOnInit() {
    var _this = this;

    return (0,_Users_vinokurovpetr_Projects_BankingManagmentSystem_BankingManagmentSystem_Angular_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      _this.users = yield (0,rxjs__WEBPACK_IMPORTED_MODULE_3__.lastValueFrom)(_this.service.getUserList(_this.cancellationObservable));
      console.log(_this.users); //this.dataSource.items = () => this.users;
      //this.dataSource.load();
    })();
  }

}

UserListComponent.ɵfac = function UserListComponent_Factory(t) {
  return new (t || UserListComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_user_managment_service__WEBPACK_IMPORTED_MODULE_1__.UserManagmentService));
};

UserListComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineComponent"]({
  type: UserListComponent,
  selectors: [["app-user-list"]],
  decls: 11,
  vars: 5,
  consts: [["height", "790px", "keyExpr", "id", "id", "usersList", 3, "dataSource", "showBorders"], [3, "enabled"], ["mode", "virtual"], [3, "allowAdding"], [3, "visible"], ["name", "addRowButton", "location", "center"], ["name", "searchPanel", "locateInMenu", "auto", "location", "center"], ["dataField", "userName", "dataType", "string"], ["dataField", "email", "dataType", "string"]],
  template: function UserListComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](0, "div")(1, "dx-data-grid", 0);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](2, "dxo-load-panel", 1)(3, "dxo-scrolling", 2)(4, "dxo-editing", 3)(5, "dxo-search-panel", 4);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](6, "dxo-toolbar");
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](7, "dxi-item", 5)(8, "dxi-item", 6);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](9, "dxi-column", 7)(10, "dxi-column", 8);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("dataSource", ctx.users)("showBorders", true);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("enabled", true);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("allowAdding", true);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
      _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("visible", true);
    }
  },
  dependencies: [devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxiItemComponent, devextreme_angular__WEBPACK_IMPORTED_MODULE_6__.DxDataGridComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxiColumnComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoEditingComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoLoadPanelComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoScrollingComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoSearchPanelComponent, devextreme_angular_ui_nested__WEBPACK_IMPORTED_MODULE_5__.DxoToolbarComponent],
  styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1c2VyLWxpc3QuY29tcG9uZW50LnNjc3MifQ== */"]
});

/***/ }),

/***/ 78436:
/*!*************************************************************!*\
  !*** ./src/app/user-managment/user-managment-api-routes.ts ***!
  \*************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UserManagmentApiRoutes": () => (/* binding */ UserManagmentApiRoutes)
/* harmony export */ });
var UserManagmentApiRoutes;
(function (UserManagmentApiRoutes) {
    UserManagmentApiRoutes["Root"] = "usermanagment";
    UserManagmentApiRoutes["CreateNewUser"] = "createnewuser";
    UserManagmentApiRoutes["UserList"] = "userlist";
    UserManagmentApiRoutes["RoleList"] = "roleList";
})(UserManagmentApiRoutes || (UserManagmentApiRoutes = {}));


/***/ }),

/***/ 63099:
/*!*********************************************************!*\
  !*** ./src/app/user-managment/user-managment-routes.ts ***!
  \*********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UserManagmentRoutes": () => (/* binding */ UserManagmentRoutes)
/* harmony export */ });
var UserManagmentRoutes;
(function (UserManagmentRoutes) {
    UserManagmentRoutes["Root"] = "user-managment";
    UserManagmentRoutes["CreateNewUser"] = "new-user";
    UserManagmentRoutes["UserList"] = "user-list";
})(UserManagmentRoutes || (UserManagmentRoutes = {}));


/***/ }),

/***/ 43506:
/*!*****************************************************************!*\
  !*** ./src/app/user-managment/user-managment-routing.module.ts ***!
  \*****************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UserManagmentRoutingModule": () => (/* binding */ UserManagmentRoutingModule)
/* harmony export */ });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 60124);
/* harmony import */ var _new_user_new_user_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./new-user/new-user.component */ 17414);
/* harmony import */ var _roles_roles_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./roles/roles.component */ 85475);
/* harmony import */ var _user_list_user_list_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./user-list/user-list.component */ 56392);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 22560);






const routes = [
    { path: "new-user", component: _new_user_new_user_component__WEBPACK_IMPORTED_MODULE_0__.NewUserComponent },
    { path: "user-list", component: _user_list_user_list_component__WEBPACK_IMPORTED_MODULE_2__.UserListComponent },
    { path: "roles", component: _roles_roles_component__WEBPACK_IMPORTED_MODULE_1__.RolesComponent }
];
class UserManagmentRoutingModule {
}
UserManagmentRoutingModule.ɵfac = function UserManagmentRoutingModule_Factory(t) { return new (t || UserManagmentRoutingModule)(); };
UserManagmentRoutingModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineNgModule"]({ type: UserManagmentRoutingModule });
UserManagmentRoutingModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineInjector"]({ imports: [_angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterModule.forChild(routes), _angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterModule] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵsetNgModuleScope"](UserManagmentRoutingModule, { imports: [_angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterModule], exports: [_angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterModule] }); })();


/***/ }),

/***/ 55209:
/*!*********************************************************!*\
  !*** ./src/app/user-managment/user-managment.module.ts ***!
  \*********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UserManagmentModule": () => (/* binding */ UserManagmentModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ 94666);
/* harmony import */ var _user_managment_routing_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./user-managment-routing.module */ 43506);
/* harmony import */ var _user_managment_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./user-managment.service */ 62083);
/* harmony import */ var _new_user_new_user_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./new-user/new-user.component */ 17414);
/* harmony import */ var devextreme_angular__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! devextreme-angular */ 49889);
/* harmony import */ var devextreme_angular__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! devextreme-angular */ 41661);
/* harmony import */ var devextreme_angular__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! devextreme-angular */ 65821);
/* harmony import */ var _user_list_user_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./user-list/user-list.component */ 56392);
/* harmony import */ var _roles_roles_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./roles/roles.component */ 85475);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ 22560);








class UserManagmentModule {
}
UserManagmentModule.ɵfac = function UserManagmentModule_Factory(t) { return new (t || UserManagmentModule)(); };
UserManagmentModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineNgModule"]({ type: UserManagmentModule });
UserManagmentModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineInjector"]({ providers: [
        _user_managment_service__WEBPACK_IMPORTED_MODULE_1__.UserManagmentService
    ], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_6__.CommonModule,
        _user_managment_routing_module__WEBPACK_IMPORTED_MODULE_0__.UserManagmentRoutingModule,
        devextreme_angular__WEBPACK_IMPORTED_MODULE_7__.DxFormModule,
        devextreme_angular__WEBPACK_IMPORTED_MODULE_8__.DxButtonModule,
        devextreme_angular__WEBPACK_IMPORTED_MODULE_9__.DxDataGridModule] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵsetNgModuleScope"](UserManagmentModule, { declarations: [_new_user_new_user_component__WEBPACK_IMPORTED_MODULE_2__.NewUserComponent,
        _user_list_user_list_component__WEBPACK_IMPORTED_MODULE_3__.UserListComponent,
        _roles_roles_component__WEBPACK_IMPORTED_MODULE_4__.RolesComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_6__.CommonModule,
        _user_managment_routing_module__WEBPACK_IMPORTED_MODULE_0__.UserManagmentRoutingModule,
        devextreme_angular__WEBPACK_IMPORTED_MODULE_7__.DxFormModule,
        devextreme_angular__WEBPACK_IMPORTED_MODULE_8__.DxButtonModule,
        devextreme_angular__WEBPACK_IMPORTED_MODULE_9__.DxDataGridModule] }); })();


/***/ }),

/***/ 62083:
/*!**********************************************************!*\
  !*** ./src/app/user-managment/user-managment.service.ts ***!
  \**********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UserManagmentService": () => (/* binding */ UserManagmentService)
/* harmony export */ });
/* harmony import */ var _user_managment_api_routes__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./user-managment-api-routes */ 78436);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _common_services_http_api_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../common-services/http-api.service */ 21026);



class UserManagmentService {
    constructor(httpService) {
        this.httpService = httpService;
    }
    createNewUser(request, cancellationSubject) {
        return this.httpService.post(`${_user_managment_api_routes__WEBPACK_IMPORTED_MODULE_0__.UserManagmentApiRoutes.Root}/${_user_managment_api_routes__WEBPACK_IMPORTED_MODULE_0__.UserManagmentApiRoutes.CreateNewUser}`, request, cancellationSubject);
    }
    getUserList(cancellationSubject) {
        return this.httpService.get(`${_user_managment_api_routes__WEBPACK_IMPORTED_MODULE_0__.UserManagmentApiRoutes.Root}/${_user_managment_api_routes__WEBPACK_IMPORTED_MODULE_0__.UserManagmentApiRoutes.UserList}`, cancellationSubject);
    }
    getRolesList(cancellationSubject) {
        return this.httpService.get(`${_user_managment_api_routes__WEBPACK_IMPORTED_MODULE_0__.UserManagmentApiRoutes.Root}/${_user_managment_api_routes__WEBPACK_IMPORTED_MODULE_0__.UserManagmentApiRoutes.RoleList}`, cancellationSubject);
    }
}
UserManagmentService.ɵfac = function UserManagmentService_Factory(t) { return new (t || UserManagmentService)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵinject"](_common_services_http_api_service__WEBPACK_IMPORTED_MODULE_1__.HttpApiService)); };
UserManagmentService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineInjectable"]({ token: UserManagmentService, factory: UserManagmentService.ɵfac });


/***/ }),

/***/ 92340:
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "environment": () => (/* binding */ environment)
/* harmony export */ });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
const environment = {
    production: false,
    apiUrl: "https://localhost:5001/api",
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ 14431:
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/platform-browser */ 34497);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 22560);
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app/app.module */ 36747);
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./environments/environment */ 92340);




if (_environments_environment__WEBPACK_IMPORTED_MODULE_1__.environment.production) {
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.enableProdMode)();
}
_angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__.platformBrowser().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_0__.AppModule)
    .catch(err => console.error(err));


/***/ })

},
/******/ __webpack_require__ => { // webpackRuntimeModules
/******/ var __webpack_exec__ = (moduleId) => (__webpack_require__(__webpack_require__.s = moduleId))
/******/ __webpack_require__.O(0, ["vendor"], () => (__webpack_exec__(14431)));
/******/ var __webpack_exports__ = __webpack_require__.O();
/******/ }
]);
//# sourceMappingURL=main.js.map