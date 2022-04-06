

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import {
  OKTA_CONFIG,
  OktaAuthGuard,
  OktaAuthModule,
  OktaCallbackComponent,
} from '@okta/okta-angular';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'login/callback',
    component: OktaCallbackComponent,
  },
];
const config = {
  clientId: '0oa4jjzyvo1nShxTQ5d7',
  issuer: 'https://dev-07426082.okta.com/oauth2/default',
  redirectUri: 'http://localhost:4200/login/callback',
  scopes: ['openid', 'profile', 'email'],
  pkce: true
};
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    OktaAuthModule,
    RouterModule.forRoot(appRoutes, { relativeLinkResolution: 'legacy' }),
  ],
  providers: [
    { provide: OKTA_CONFIG, useValue: config },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
