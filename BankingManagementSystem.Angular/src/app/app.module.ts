import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { IdentityService } from './login/identity.service';
import { FormsModule } from '@angular/forms';
import { HttpApiService } from './common-services/http-api.service';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserManagementModule } from './user-management/user-management.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpErrorInterceptor } from './common-services/http-error-interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppEvents } from './app-events';
import { CookieService } from 'ngx-cookie-service';
import { DxMenuModule } from "devextreme-angular";
import DataSource from 'devextreme/data/data_source';
import { JwtHelperService, JWT_OPTIONS} from '@auth0/angular-jwt';
import { UserProfileComponent } from './app-components/user-profile/user-profile.component';
import { Store, StoreModule, provideStore } from '@ngrx/store';
import { AppEffects } from './app-state/app.effects';
import { EffectsModule } from '@ngrx/effects';
import { appReducer } from './app-state/app.reducer';
import { UserProfileDetailsComponent } from './app-components/user-profile-details/user-profile-details.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserProfileComponent,
    UserProfileDetailsComponent
  ],
  imports: [
    EffectsModule.forRoot([]),
    EffectsModule.forFeature([AppEffects]),
    BrowserModule,
    StoreModule.forRoot({ appState: appReducer }),
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    UserManagementModule,
    NgbModule,
    BrowserAnimationsModule,
    DxMenuModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true },
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    IdentityService,
    HttpApiService,
    HttpClient,
    AppEvents,
    CookieService,
    JwtHelperService,
    DataSource
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
