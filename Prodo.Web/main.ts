import { platformBrowserDynamic } from '@angular/platform-browser-dynamic'; // Just-in-time compiler
//import { platformBrowser } from '@angular/platform-browser'; // Ahead-of-Time pre-compiled (AoT)

import { AppModule } from './app/app.module';

platformBrowserDynamic().bootstrapModule(AppModule);

//platformBrowser().bootstrapModule(AppModule);

