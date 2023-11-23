import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import {
  provideHttpClient,
  withFetch,
  withInterceptors,
} from '@angular/common/http';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { routes } from './app.routes';
import { authInterceptorFn } from './auth-interceptor';
import { MSAL_GUARD_CONFIG, MsalModule } from '@azure/msal-angular';
import {
  MSALGuardConfigFactory,
  MSALInterceptorConfigFactory,
  msalInstance,
} from './authenticator';

/* --- NgZorro Configs --- */
import { NzConfig, provideNzConfig } from 'ng-zorro-antd/core/config';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { IconDefinition } from '@ant-design/icons-angular';
import {
  BankFill,
  ControlFill,
  LinkedinFill,
  GithubFill,
} from '@ant-design/icons-angular/icons';
<<<<<<< HEAD
const ngZorroConfig: NzConfig = {
  notification: { nzPlacement: 'bottomLeft' },
};
=======
import { provideHttpClient, withFetch } from '@angular/common/http';
>>>>>>> main
const icons: IconDefinition[] = [
  BankFill,
  ControlFill,
  LinkedinFill,
  GithubFill,
];
/* ---------------- */

import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
registerLocaleData(en);
import { en_US, provideNzI18n } from 'ng-zorro-antd/i18n';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideClientHydration(),
    provideAnimations(),
    provideNzI18n(en_US),
    provideHttpClient(withFetch(), withInterceptors([authInterceptorFn])),
    provideNzConfig(ngZorroConfig),
    importProvidersFrom(
      NzIconModule.forRoot(icons),
      MsalModule.forRoot(
        msalInstance,
        MSALGuardConfigFactory(),
        MSALInterceptorConfigFactory()
      )
    ),
  ],
};
